using System.Text.RegularExpressions;
using System;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace scrprnt
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public static void DeleteAllFilesInFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    File.Delete(file);
                }
            }
            else
            {
                Console.WriteLine("Folder does not exist.");
            }
        }
        public static string capture()
        {
            string saveDirectory = @"screenshot\";
            Bitmap screenshot = CaptureScreen();
            string fileName = GetNextAvailableFileName(saveDirectory, "screenshot", "png");
            screenshot.Save(Path.Combine(saveDirectory, fileName), System.Drawing.Imaging.ImageFormat.Png);
            screenshot.Dispose();
            return fileName;
        }

        static Bitmap CaptureScreen()
        {
            Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, screenshot.Size);
            }
            return screenshot;
        }

        static string GetNextAvailableFileName(string directory, string baseName, string extension)
        {
            string fileName = $"{baseName}_1.{extension}";
            int counter = 1;

            while (File.Exists(Path.Combine(directory, fileName)))
            {
                counter++;
                fileName = $"{baseName}_{counter}.{extension}";
            }

            return fileName;
        }
        public static string RemoveSpecialCharacters(string input)
        {
            // Define the regular expression pattern for special characters
            string pattern = "[^a-zA-Z0-9]";

            // Replace special characters with an empty string
            string result = Regex.Replace(input, pattern, "");

            return result;
        }

        
        public static string RenameFile(string fileName)
        {
            // Implement file renaming logic here
            return "renamed_" + fileName;
        }

        //public static string RenameFile(string fileName)
        //{
        //    // Split the file name and extension
        //    string nameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
        //    string fileExtension = Path.GetExtension(fileName);

        //    // Append timestamp to the file name
        //    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        //    string renamedFileName = $"{nameWithoutExtension}_{timestamp}{fileExtension}";

        //    return renamedFileName;
        //}


       public static int GetTotalFileSize(string filePath)
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Get the FileInfo object for the file
                FileInfo fileInfo = new FileInfo(filePath);

                // Get the file size in bytes
                long fileSizeBytes = fileInfo.Length;

                return (int)fileSizeBytes; // Convert long to int (assuming file size won't exceed int range)
            }
            else
            {
                Console.WriteLine("File does not exist.");
                return -1; // Return -1 to indicate file not found
            }
        }

        public static string GetLatestFileName(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                // Get all files in the folder
                string[] files = Directory.GetFiles(folderPath);

                // Check if there are any files in the folder
                if (files.Length > 0)
                {
                    // Get the latest file based on last write time
                    string latestFile = files.OrderByDescending(f => new FileInfo(f).LastWriteTime).First();

                    // Extract and return the file name
                    return Path.GetFileName(latestFile);
                }
            }
            return null; // Return null if folder doesn't exist or no files found
        }


        public static void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is the spacebar
            if (e.KeyCode == Keys.Space)
            {
                // Prevent the checkbox from being checked
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public static void HandleSpacebarKeyPress(System.Windows.Forms.TextBox textBox)
        {
            // Get the cursor position
            int cursorPosition = textBox.SelectionStart;

            // Check if the last character entered is a space
            if (textBox.Text.Length > 0 && textBox.Text[cursorPosition - 1] == ' ')
            {
                // If the last character entered is a space, remove it
                textBox.Text = textBox.Text.Remove(cursorPosition - 1, 1);

                // Move the cursor back
                textBox.SelectionStart = cursorPosition - 1;
                textBox.SelectionLength = 0;
            }
        }
    }
}