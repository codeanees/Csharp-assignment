using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment
{
    /// <summary>
    /// Utility which provides vaidation functions.
    /// </summary>
    class Validator
    {
        public static bool OnlyLetters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }
    }
}
