/* Assignment 5
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
 */

using System;
using System.Collections.Generic;
using static System.Console;
using static Assignment5.View.Prompt;
using Assignment5.Service;

namespace Assignment5.View
{
    /// <summary>
    /// Writes in the Console according to the requirements.
    /// </summary>
    public static class Presenter
    {
        /// <summary>
        /// Welcome message after loading.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void Welcome(LibraryService library)
        {
            WriteLine("Welcome\n");
            Statistics(library);
            Home(library);
        }

        /// <summary>
        /// Show statistics
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void Statistics(LibraryService library)
        {
            WriteLine(StatisticsMessage);
            WriteLine("\t" + StatisticsBooks + $" {library.BookCounter()}");
        }

        /// <summary>
        /// Write the main menu options.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void Home(LibraryService library)
        {
            WriteLine(MainMenu);
        }

        /// <summary>
        /// Calls the book creation.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void CreateBook(LibraryService library)
        {
            WriteLine(AskForTitle);
            WriteLine();

            // user input answer
            WriteLine(AskForAuthor);
            WriteLine();

            // user inputs answer
            WriteLine(AskForCopyright);
            WriteLine();

            // user inputs answer
            WriteLine(AskForNumberOfPages);
            WriteLine();

            // user inputs Answer

            // try to create book
            // try to store book
        }

        /// <summary>
        /// How user whants to search for a book.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void SearchBook(LibraryService library)
        {
            WriteLine(SearchMethods);

            // user input search method
            // select the right prompt
        }

        /// <summary>
        /// Search by Author Name.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void SearchByAuthor(LibraryService library)
        {
            WriteLine(AskForAuthorNameSearch);

            // user input name
            // search
            WriteLine(BookNotFound);

            // book found
        }

        /// <summary>
        /// Search by Author Name.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void SearchByTitle(LibraryService library)
        {
            WriteLine(AskForBookTitleSearch);

            // user input title
            // search
            WriteLine(BookNotFound);

            // book found
        }

        /// <summary>
        /// Edit an Book.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void EditAnBook(LibraryService library)
        {
            WriteLine("First, lets find the book...");
            SearchBook(library);
        }
    }
}
