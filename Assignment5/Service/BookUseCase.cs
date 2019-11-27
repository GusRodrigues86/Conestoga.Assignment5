
/* Assignment 1
*
* Revision History
*      Gustavo Bonifacio Rodrigues, 2019.11.27: Created
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5.Helper;
using static System.Console;

namespace Assignment5.Service
{
    public static class BookUseCase
    {
        public static string CreateTitle(string input)
        {
            try
            {
                input = Parser.ParseInputToString(input);
            }
            catch (ArgumentNullException)
            {
                WriteLine("Invalid book title. Try again, please.");
                CreateTitle(ReadLine());
            }

            return input;
        }

        public static string CreateAuthor(string input)
        {
            try
            {
                input = Parser.ParseInputToString(input);
            }
            catch (ArgumentNullException)
            {
                WriteLine("Invalid author name. Try again, please");
                CreateAuthor(ReadLine());
            }

            return input;
        }
        
        public static int CreateCopyrightYear(string input)
        {
            int answer = 0;
            try
            {
                answer = Parser.ParseToInt(input);
            }
            catch (FormatException)
            {
                WriteLine("Year must be between 1924 and 2019. Please, try again.");
                CreateCopyrightYear(ReadLine());
            }

            return answer;
        }

        public static int CreateNumberOfPages(string input)
        {
            int answer = 0;
            try
            {
                answer = Parser.ParseToInt(input);
            }
            catch (FormatException)
            {
                WriteLine("A book must have AT LEAST one page. Please, try again.");
                CreateNumberOfPages(ReadLine());
            }

            return answer;
        }
    }
}
