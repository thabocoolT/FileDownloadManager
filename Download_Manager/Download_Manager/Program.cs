using System;
using System.IO;

namespace file_download_manager
{
    class Program
    {
        private static readonly string downloadfolder = @"C:\Users\thabo\Downloads";
        private static readonly string aboveFolder = Path.Combine(downloadfolder, "Above500MB");
        private static readonly string belowFolder = Path.Combine(downloadfolder, "Below500MB");

        static void Main(string[] args)
        {
            
            try
            {
                string logFilePath = Path.Combine(downloadfolder, "log.txt");
                File.AppendAllText(logFilePath, $"Program started at {DateTime.Now}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }

            if (!Directory.Exists(downloadfolder))
            {
                Console.WriteLine($"Download Folder does not exist: {downloadfolder}");
                return;
            }

            //FileSystem watcher to monitor the download folder
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = downloadfolder,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size,
                Filter = "*.*" //This will watch all file types
            };

            //Hooking up the event handlers

            watcher.Created += OnNewFileDetected;

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Monitoring download folder...Press Enter to exit");
            Console.ReadLine();

        }

        private static void OnNewFileDetected(object sender, FileSystemEventArgs e) 
        {
            try
            {
                Console.WriteLine($"New file detected: {e.FullPath}");
                FileInfo fileInfo = new FileInfo(e.FullPath);

                //wait for the file to finish downloading
                while (IsFileLocked(fileInfo)) { }

                //Automatically create  above and below 500mb folders if they don't exist
                Directory.CreateDirectory(aboveFolder);
                Directory.CreateDirectory(belowFolder);

                //Determine file size and move it to the appropriate folder
                string destinationFolder = fileInfo.Length > 500 * 1024 * 1024
                    ? aboveFolder
                    : belowFolder;

                string destinationPath = Path.Combine(destinationFolder, fileInfo.Name);
                File.Move(e.FullPath, destinationPath);

                Console.WriteLine($"File moved to: {destinationFolder}");


            }

            catch (Exception ex )
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        
        }

        private static bool IsFileLocked( FileInfo file )
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();

                }
            }
            catch(IOException)
            {
                return true;
            }
            return false;
        }
    }
}