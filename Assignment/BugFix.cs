using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class BugFix
    {
        /// <summary>
        /// Displays the question to the user
        /// </summary>
        public static void DisplayQuestion()
        {
            #region Displays the question and answer to the user.
            Console.WriteLine(@"
                Fix the bugs:

                public class MathUtils
                {
                    public static double Average(int a, int b)
                    {
                          return a + b / 2;
                    }
                }");
            Console.WriteLine("Press enter key to see the answer");
            Console.ReadLine();
            Console.WriteLine(@"
                public class MathUtils
                {
                    public static double Average(int a, int b)
                    {
                          return ((double)(a + b) / 2);
                    }
                }"); 
            #endregion
            Console.WriteLine("Enter the value of a and b");
            int a , b = 0;
            int.TryParse(Console.ReadLine(), out a);
            int.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("The average of two given numbers is " + MathUtils.Average(a,b));
        }
    }
    /// <summary>
    /// Math Utility to provide Math functions. 
    /// </summary>
    public class MathUtils
    {
        /*
          Bug 1 : There should be braces around a and b.
          Bug 2 : In Result, it will always return integer and not double. Hence, we need to cast the inputs to double.
        */
        public static double Average(int a, int b)
        {
            return ((double)(a + b) / 2);
        }
    }
}
