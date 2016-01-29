using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace Assignment
{
    /// <summary>
    /// Error logging mechanism
    /// </summary>
    class Logger
    {
        /// <summary>
        /// Writes the error message to the log file
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void Log(string errorMessage)
        {
            try
            {
                Console.WriteLine(errorMessage);
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + "Logs";
                string filePath = System.IO.Path.Combine(folderPath, "log " + DateTime.Now.ToString("MM-dd-yyyy") + ".log");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                if (!File.Exists(filePath))
                {
                    using (var file = File.Create(filePath))
                    {
                    }
                }
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(DateTime.Now.ToString("hh:mm:ss.ff") + "> " + errorMessage);
                    sw.WriteLine("\n--------------------------------------------------------------------------------------------\n");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
