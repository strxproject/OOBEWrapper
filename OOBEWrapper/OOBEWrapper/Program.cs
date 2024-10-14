using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string basicthemer = @"C:\Classic Files\basicthemer.exe";
        string fixer = @"C:\Classic Files\fixer.exe";
        string path = @"C:\Windows\psoobe.exe";

        Process themeProcess = null;
        Process fixerProcess = null;

        if (File.Exists(basicthemer))
        {
            themeProcess = Process.Start(basicthemer);
            if (themeProcess == null)
            {
                Console.WriteLine("Failed to start basicthemer.exe.");
            }
        }
        else
        {
            Console.WriteLine("basicthemer.exe does not exist at the specified path.");
        }

        if (File.Exists(fixer))
        {
            fixerProcess = Process.Start(fixer);
            if (fixerProcess == null)
            {
                Console.WriteLine("Failed to start fixer.exe.");
            }
        }
        else
        {
            Console.WriteLine("fixer.exe does not exist at the specified path.");
        }

        if (File.Exists(path))
        {
            var process = Process.Start(path);
            if (process != null)
            {
                process.WaitForExit();

                if (themeProcess != null && !themeProcess.HasExited)
                {
                    themeProcess.Kill();
                    themeProcess.Dispose();
                }
                if (fixerProcess != null && !fixerProcess.HasExited)
                {
                    fixerProcess.Kill();
                    fixerProcess.Dispose();
                }
            }
            else
            {
                Console.WriteLine("Failed to start psoobe.exe.");
            }
        }
        else
        {
            Console.WriteLine("psoobe.exe does not exist at the specified path.");
        }
    }
}
