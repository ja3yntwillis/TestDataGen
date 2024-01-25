using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;
using System.Data;
using System.IO.Compression;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Paragraph = Xceed.Document.NET.Paragraph;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.CognitiveServices.Speech;
using Timer = System.Windows.Forms.Timer;


namespace scrprnt
{
    public partial class Form1 : Form
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        private Timer yourTimer;
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.button1, "Take Screenshot");
            ToolTip1.SetToolTip(this.button2, "Export Result to Doc");
            ToolTip1.SetToolTip(this.button3, "Reset");
            ToolTip1.SetToolTip(this.button4, "Use microphone to speak");
            ToolTip1.SetToolTip(this.button5, "Export Result to PDF");
            ToolTip1.SetToolTip(this.button6, "Export Screenshots to Zip");
            yourTimer = new Timer();
            yourTimer.Interval = 5000; // Interval in milliseconds (5 seconds)
           
        }
        private async void YourTimer_Tick(object sender, EventArgs e)
        {
            string subscriptionKey = Cred.subscriptionKey;
            string serviceRegion = Cred.serviceRegion;
            var speechConfig = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);
            var speechRecognizer = new SpeechRecognizer(speechConfig);
            var speechSynthesizer = new SpeechSynthesizer(speechConfig);
            var result = await speechRecognizer.RecognizeOnceAsync();
            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                string recognizedText = result.Text;
                string text_withoutChars = Program.RemoveSpecialCharacters(recognizedText);
                if (text_withoutChars.ToUpper() == "ADDCOMMENT")
                {
                    textBox1.Clear();
                    textBox1.Text = recognizedText;
                }
                if (text_withoutChars.ToUpper() == "CLICKSCREENSHOT")
                {
                   button1.PerformClick();
                }
                //await speechSynthesizer.SpeakTextAsync("you , just said."+recognizedText);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
            Thread.Sleep(1000);

            if (dt.Rows.Count == 0)
            {
                dt.Columns.Add("filename");
                dt.Columns.Add("time");
                dt.Columns.Add("comment");
                Program.DeleteAllFilesInFolder(@"screenshot\");
            }
            string filename = Program.capture();
            dt.Rows.Add(filename, "Captured at " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), textBox1.Text);
            WindowState = FormWindowState.Maximized;
            button2.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folderPath = @"screenshot\";
            string currentDate = DateTime.Now.ToString("MMddyyyyHHmmss");
            string outputPath = $"result\\Result_{currentDate}.docx";

            // Create a new Word document
            using (DocX doc = DocX.Create(outputPath))
            {
                String[] imageFiles = Directory.GetFiles(folderPath, "*.png", SearchOption.AllDirectories)
                                              .Concat(Directory.GetFiles(folderPath, "*.jpg", SearchOption.AllDirectories))
                .ToArray();

                for (int i = 0; i < imageFiles.Length; i++)
                {
                    var filename = "screenshot\\" + (string)dt.Rows[i]["filename"];
                    Xceed.Document.NET.Image image = doc.AddImage(filename);
                    Picture picture = image.CreatePicture();
                    picture.Height = 250;
                    picture.Width = 450;
                    Paragraph p1 = doc.InsertParagraph();
                    p1.Italic().AppendLine((string)dt.Rows[i]["filename"]);
                    p1.Italic().AppendLine((string)dt.Rows[i]["time"]);
                    p1.Italic().AppendLine("Comments : " + (string)dt.Rows[i]["comment"]);
                    p1.AppendPicture(picture);
                    p1.AppendLine();
                }

                doc.Save();
                Program.DeleteAllFilesInFolder(folderPath);
                dt.Rows.Clear();
                dt.Columns.Clear();
                button2.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                textBox1.Clear();
                string message = "Screenshot Document saved at Result folder.";

                MessageBox.Show(message, "MessageBox Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string folderPath = @"screenshot\";
            string currentDate = DateTime.Now.ToString("MMddyyyyHHmmss");
            string outputPath = $"result\\Result_{currentDate}.docx";
            string outputPathPDF = $"result\\Result_{currentDate}.pdf";

            // Create a new Word document
            using (DocX doc = DocX.Create(outputPath))
            {
                String[] imageFiles = Directory.GetFiles(folderPath, "*.png", SearchOption.AllDirectories)
                                              .Concat(Directory.GetFiles(folderPath, "*.jpg", SearchOption.AllDirectories))
                .ToArray();

                for (int i = 0; i < imageFiles.Length; i++)
                {
                    var filename = "screenshot\\" + (string)dt.Rows[i]["filename"];
                    Xceed.Document.NET.Image image = doc.AddImage(filename);
                    Picture picture = image.CreatePicture();
                    picture.Height = 250;
                    picture.Width = 450;
                    Paragraph p1 = doc.InsertParagraph();
                    p1.Italic().AppendLine((string)dt.Rows[i]["filename"]);
                    p1.Italic().AppendLine((string)dt.Rows[i]["time"]);
                    p1.Italic().AppendLine("Comments : " + (string)dt.Rows[i]["comment"]);
                    p1.AppendPicture(picture);
                    p1.AppendLine();
                }

                doc.Save();
                var wordApp = new Word.Application();
                try
                {
                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    var docs = wordApp.Documents.Open(path + outputPath);

                    docs.SaveAs2(path + outputPathPDF, WdSaveFormat.wdFormatPDF);
                    docs.Close();
                    wordApp.Quit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    var a = ex.Message;
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
                File.Delete(outputPath);
                Program.DeleteAllFilesInFolder(folderPath);
                dt.Rows.Clear();
                dt.Columns.Clear();
                button2.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                textBox1.Clear();
                string message = "Screenshot PDF saved at Result folder.";

                MessageBox.Show(message, "MessageBox Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string folderPath = @"screenshot\";
            string currentDate = DateTime.Now.ToString("MMddyyyyHHmmss");
            string outputPath = $"result\\Result_{currentDate}.zip";
            StreamWriter sw = new StreamWriter(@"screenshot\\comments.csv", false);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            ZipFile.CreateFromDirectory(folderPath, outputPath);
            Program.DeleteAllFilesInFolder(folderPath);
            dt.Rows.Clear();
            dt.Columns.Clear();
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            textBox1.Clear();
            string message = "Screenshots are zipped and saved at Result folder with comments in csv";

            MessageBox.Show(message, "MessageBox Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"result");
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            string subscriptionKey = Cred.subscriptionKey;
            string serviceRegion = Cred.serviceRegion;
            var speechConfig = SpeechConfig.FromSubscription(subscriptionKey, serviceRegion);
            var speechRecognizer = new SpeechRecognizer(speechConfig);
            var speechSynthesizer = new SpeechSynthesizer(speechConfig);
            await speechSynthesizer.SpeakTextAsync("Pixie is about to start ");
            var result = await speechRecognizer.RecognizeOnceAsync();

            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                string recognizedText = result.Text;
                string text_withoutChars = Program.RemoveSpecialCharacters(recognizedText);
                
                if (text_withoutChars.ToUpper() == "HIPIXIE")
                {
                    await speechSynthesizer.SpeakTextAsync("Hello,how may I assist you");
                    if (yourTimer.Enabled == false)
                    {
                        yourTimer.Tick += YourTimer_Tick;
                        yourTimer.Enabled = true;
                    }
                    //button1.PerformClick();
                   
                }
                if (text_withoutChars.ToUpper() == "ADDCOMMENT")
                {
                    textBox1.Clear();

                    textBox1.Text = recognizedText;
                }
                //await speechSynthesizer.SpeakTextAsync("you , just said."+recognizedText);
            }
           
        }
    }
    
}
