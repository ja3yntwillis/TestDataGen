using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Text.Json;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.Http.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using scrprnt;

namespace scrprnt
{
    internal class JiraClient
    {
        private readonly HttpClient _client;
        private readonly string _jiraBaseUrl;
        private readonly string _username;
        private readonly string _password;


        public JiraClient(string jiraBaseUrl, string username, string password)
        {
            _jiraBaseUrl = jiraBaseUrl;
            _username = username;
            _password = password;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(jiraBaseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var base64String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{username}:{password}"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
        }

        public async Task<JiraIssue> GetIssue(string issueKey)
        {
            try
            {
                var response = await _client.GetAsync($"/rest/api/2/issue/{issueKey}?fields=attachment");

                if (response.IsSuccessStatusCode)
                {
                    // var content = await response.Content.ReadAsStringAsync();
                    //var issue = JsonConvert.DeserializeObject<JiraIssue>(content);
                    var content = await response.Content.ReadAsStringAsync();
                    var issue = DeserializeJiraIssue(content);

                    // Check if issue is null after deserialization
                    if (issue == null)
                    {
                        throw new Exception($"Failed to deserialize issue {issueKey}. Issue is null.");
                    }

                    return issue;
                }
                else
                {
                    throw new Exception($"Failed to get issue {issueKey}. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving issue {issueKey}: {ex.Message}", ex);
            }
        }



        private JiraIssue DeserializeJiraIssue(string content)
        {
            var json = JObject.Parse(content);

            // Extract attachments
            var attachmentsJson = json["fields"]?["attachment"];
            var attachments = new List<JiraAttachment>();
            if (attachmentsJson != null)
            {
                foreach (var attachmentJson in attachmentsJson)
                {
                    var attachment = new JiraAttachment
                    {
                        Filename = attachmentJson["filename"]?.ToString(),
                        // Populate other attachment properties if available
                    };
                    attachments.Add(attachment);
                }
            }

            // Create JiraIssue object
            var issue = new JiraIssue
            {
                Attachments = attachments,
                // Populate other JiraIssue properties from JSON
            };

            return issue;
        }


      
       public static async System.Threading.Tasks.Task UploadFile(HttpClient client, string issueKey, string filePath, string fileName)
        {
            {
                // Implement file upload logic here
                //  Read the file
                var fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Construct the request content
                var multipartContent = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                multipartContent.Add(fileContent, "file", fileName);

                // Send the request to upload attachment
                var response = await client.PostAsync($"/rest/api/2/issue/{issueKey}/attachments", multipartContent);
                Console.WriteLine($"Uploading file '{fileName}' to issue '{issueKey}'...");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Attachment uploaded successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to upload attachment. Status code: " + response.StatusCode);
                }
            }
        }


        public static async Task<JiraIssue> GetIssueDetails(string jiraBaseUrl, string issueKey, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(jiraBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                HttpResponseMessage response = await httpClient.GetAsync($"/rest/api/2/issue/{issueKey}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<JiraIssue>();
                }
                return null;
            }
        }

        /* public static async System.Threading.Tasks.Task FetchJiraTitleAndAssignee(object sender, EventArgs e)
          {
              string jiraBaseUrl = Cred.jiraBaseUrl;
              string issueKey = Cred.issueKey;
              string accessToken = Cred.accessToken; // Replace with your access token or other authentication mechanism

              JiraIssue issueDetails = await GetIssueDetails(jiraBaseUrl, issueKey, accessToken);
              if (issueDetails != null)
              {
                  Console.WriteLine($"Title: {issueDetails.Fields.Summary}");
                  Console.WriteLine($"Assignee: {issueDetails.Fields.Assignee?.DisplayName}");
                  if (((issueDetails.Fields.Summary) != null) && ((issueDetails.Fields.Assignee?.DisplayName) != null))
                  {
                      APIProgram.buttonShowMessageBox_Click(sender, e);
                  }
              }
              else
              {
                  Console.WriteLine($"Failed to fetch issue details for {issueKey}");
              }
          }*/

        public static async System.Threading.Tasks.Task<(string summary, string assignee)> FetchJiraTitleAndAssignee(object sender, EventArgs e)
            {
                string jiraBaseUrl = Cred.jiraBaseUrl;
                string issueKey = Cred.issueKey;
                string accessToken = Cred.accessToken; // Replace with your access token or other authentication mechanism

                JiraIssue issueDetails = await GetIssueDetails(jiraBaseUrl, issueKey, accessToken);
                if (issueDetails != null)
                {
                    string summary = issueDetails.Fields.Summary;
                    string assignee = issueDetails.Fields.Assignee?.DisplayName;
                    return (summary, assignee);
                }
                else
                {
                    Console.WriteLine($"Failed to fetch issue details for {issueKey}");
                    return (null, null);
                }
            }





    }



}



