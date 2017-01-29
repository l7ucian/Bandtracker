using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Net
{
    public class PythonProcess
    {
        public static string CallPython(string search_item)
        {
            System.Diagnostics.Debug.WriteLine("Before process starts");
            string fileName = @"C:\Users\lucian\Documents\PycharmProjects\facebook_events_collecter\facebook_scrape_events.py "+ search_item;

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\lucian\AppData\Local\Programs\Python\Python36-32\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            System.Diagnostics.Debug.WriteLine("Process started");
            System.Diagnostics.Debug.WriteLine(output);

            return output;

        }
    }
}
