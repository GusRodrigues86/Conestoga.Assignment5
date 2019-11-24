/* Assignment 5
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Helper
{
    /// <summary>
    /// Parser is a helper class that will filter users inputs that program can handle.
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Parse the user input to lower case.
        /// </summary>
        /// <param name="input">The user input.</param>
        /// <returns>The user input in lower case.</returns>
        /// <exception cref="ArgumentNullException">If input is null or whitespaced.</exception>
        public static string ParseInputToString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input));
            }
            return input.ToLower();
        }

        /// <summary>
        /// Convert string to int if non-negative and digit only.
        /// </summary>
        /// <param name="input">The user input.</param>
        /// <returns>The int represented by the user.</returns>
        /// <exception cref="FormatException">If input is not digit.</exception>
        public static int ParseToInt(string input)
        {
            if (input.Length > 11)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    throw new FormatException();
                }
            }

            return int.Parse(input);
        }

        /// <summary>
        /// A filtered input is checked for the menu options.
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>int representing the menu selection.</returns>
        public static int ParseInputToMenu(string input)
        {
            // first item
            if (input.Equals("1") || input.Equals("a") || input.StartsWith("1") || input.StartsWith("create") || input.StartsWith("new") || input.StartsWith("a-"))
            {
                return 1;
            }
            else if (input.Equals("2") || input.Equals("b") || input.StartsWith("2") || input.StartsWith("existing") || input.StartsWith("display") || input.StartsWith("b-"))
            {
                return 2;
            }
            else if (input.Equals("3") || input.Equals("c") || input.StartsWith("3") || input.StartsWith("edit") || input.StartsWith("change") || input.StartsWith("c-"))
            {
                return 3;
            }
            else if (input.Equals("4") || input.Equals("exit") || input.Equals("bye") || input.Equals("adios") || input.StartsWith("4") || input.StartsWith("four") || input.StartsWith("exit") || input.StartsWith("d-") || input.Equals("d"))
            {
                return 4;
            }

            return 0;
        }
    }
}
