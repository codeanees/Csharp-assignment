using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assignment
{
    /// <summary>
    /// Provides change directory function for an abstract file system.
    /// </summary>
    public class Path
    {
        public string CurrentPath { get; private set; }

        public Path(string path)
        {
            this.CurrentPath = path;
        }

        public Path Cd(string newPath)
        {
            string[] oldPathArrayCollection = CurrentPath.Split('/');

            if (!newPath.Equals("/"))
            {
                string[] newPathArray = newPath.Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String p in newPathArray)
                {
                    if ("..".Equals(p))
                    {
                        int index = CurrentPath.LastIndexOf('/');
                        if (index != 0)
                            CurrentPath = CurrentPath.Remove(index, CurrentPath.Length - index);
                        else if (CurrentPath.Length != 1)
                            CurrentPath = CurrentPath.Remove(index + 1, CurrentPath.Length - 1);
                    }
                    else if (CurrentPath != "/")
                        CurrentPath += "/" + p;
                    else
                        CurrentPath += p;
                }
            }
            else
                CurrentPath = "/";

            return this;
        }
        /// <summary>
        /// Provides change directory function
        /// </summary>
        public static void ChangeDirectory()
        {
            try
            {
                Path path = new Path("/a/b/c/d");
                Console.WriteLine("Current Path is : " + path.CurrentPath);
                Console.Write("Enter the new Path : ");
                string changePath = Console.ReadLine().Trim();
                while (!ValidateRequestedInput(changePath))
                {
                    changePath = Console.ReadLine();
                }
                Console.WriteLine("New Path is : " + path.Cd(changePath).CurrentPath);
            }
            catch (Exception ex)
            {
                Logger.Log(string.Format("Exception at Path.ChangeDirectory {0} ST {1}", ex.Message, ex.StackTrace));
            }
        }
        /// <summary>
        /// Validates the requested path
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool ValidateRequestedInput(string input)
        {
            bool isValid = false;

            if (!string.IsNullOrEmpty(input) && input.IndexOf("//") == -1)
            {
                if (input.IndexOf(".") > -1)
                    if (input != "..")
                        input = input.Replace("/..", "").Replace("../", "").Replace("/../", "");
                    else
                        input = input.Replace("..", "");

                input = input.Replace("/", "");
                if (string.IsNullOrEmpty(input) || Validator.OnlyLetters(input))
                    isValid = true;
            }
            if(!isValid)
                    Console.WriteLine("\nError : Please enter a valid path\n");
            return isValid;
        }
    }
}