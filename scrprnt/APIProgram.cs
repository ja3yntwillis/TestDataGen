using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace scrprnt
{
    internal class APIProgram
    {
       // private readonly HttpClient _client;


        public static async System.Threading.Tasks.Task ConfigureJiraHttpClient(HttpClient client, string jiraBaseUrl, string username, string password, string issueKey)
        {
           // new JiraClient(jiraBaseUrl, username, password);
            client.BaseAddress = new Uri(jiraBaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Convert username and password to base64
            var base64String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            try
            {
                // Fetch XSRF token
                var xsrfResponse = await client.GetAsync($"/rest/api/2/issue/{issueKey}");
                xsrfResponse.EnsureSuccessStatusCode();
                var xsrfToken = xsrfResponse.Headers.Contains("XSRF-Token") ? xsrfResponse.Headers.GetValues("XSRF-Token").FirstOrDefault() : null;

                // Include XSRF token in the request headers
                client.DefaultRequestHeaders.Add("X-Atlassian-Token", "nocheck");
                if (xsrfToken != null)
                {
                    client.DefaultRequestHeaders.Add("XSRF-Token", xsrfToken);
                }
                else
                {
                    Console.WriteLine("XSRF token not found.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("An HTTP request error occurred while fetching XSRF token: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching XSRF token: " + ex.Message);
            }
        }


       public static async System.Threading.Tasks.Task jiraFunctionality_ClickAsync(object? sender, EventArgs e)
        {
            // Check some condition
            string jiraBaseUrl = Cred.jiraBaseUrl;
            string issueKey = Form1.textBox2.Text;
            string username = Cred.username;
            string password = Cred.password;
            string fileName = Program.GetLatestFileName(Cred.folderPath);
            var (summary, assignee) = await JiraClient.FetchJiraTitleAndAssignee(sender, e);
            switch (summary != null && assignee != null)
            {
                case true:
                    Console.WriteLine($"Title: {summary}");
                    Console.WriteLine($"Assignee: {assignee}");
                    // Call other methods or perform operations using summary and assignee values

                    // Ensure this code runs on the UI thread
                    if (sender is Control control)
                    {
                        control.Invoke((MethodInvoker)(async () =>
                        {
                            DialogResult result = MessageBox.Show($" Title is: {summary}. \n  Assignee is:  {assignee}. \n Do you want to proceed?\n", "Conditional Message Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    // User clicked Yes, perform the action
                                    MessageBox.Show("Proceeding as per user choice.");
                                    using (var client = new HttpClient())
                                    {
                                        var jiraClient = new JiraClient(jiraBaseUrl, username, password);

                                        try
                                        {
                                            var issue = await jiraClient.GetIssue(issueKey);

                                            if (issue != null && issue.Attachments != null && issue.Attachments.Count > 0)
                                            {
                                                bool fileExists = false;

                                                foreach (var attachment in issue.Attachments)
                                                {
                                                    if (attachment.Filename == fileName)
                                                    {
                                                        fileExists = true;
                                                        break;
                                                    }
                                                }

                                                if (fileExists)
                                                {
                                                    // If the file already exists as an attachment, rename the file and upload it again
                                                    string renamedFileName = Program.RenameFile(fileName);
                                                    await APIProgram.ConfigureJiraHttpClient(client, jiraBaseUrl, username, password, issueKey);
                                                    await JiraClient.UploadFile(client, issueKey, renamedFileName);
                                                }
                                                else
                                                {
                                                    // If the file does not exist as an attachment, upload it
                                                    Console.WriteLine("The file does not exist as an attachment.");
                                                    await APIProgram.ConfigureJiraHttpClient(client, jiraBaseUrl, username, password, issueKey);
                                                    await JiraClient.UploadFile(client, issueKey, fileName);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("No attachments found for the issue.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"An error occurred: {ex.Message}");
                                        }
                                    }

                                        break;
                                case DialogResult.No:
                                    // User clicked No, do nothing or show another message
                                    MessageBox.Show("Action cancelled by user.");
                                    break;
                            }
                        }));
                    }
                    break;
                case false:
                    MessageBox.Show("Condition is false. Not showing message box.", "Conditional Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }



    }
}
