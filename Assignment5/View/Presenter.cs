using System;
using System.Collections.Generic;
using static System.Console;
using static Assignment5.View.Prompt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.View
{
    /// <summary>
    /// Writes in the Console according to the requirements.
    /// </summary>
    static class Presenter
    {
        /// <summary>
        /// Write the main menu options.
        /// </summary>
        public static void Home()
        {
            WriteLine(MainMenu);
        }

        /// <summary>
        /// Calls the book creation.
        /// </summary>
        public static void CreateBook()
        {
            WriteLine(AskForTitle);
            // user input answer
            WriteLine(AskForAuthor);
            // user inputs answer
            WriteLine(AskForCopyright);
            // user inputs answer
            WriteLine(AskForNumberOfPages);
            // user inputs Answer

            // try to create book
            // try to store book
        }

        /// <summary>
        /// How user whants to search for a book.
        /// </summary>
        public static void SearchBook()
        {
            WriteLine(SearchMethods);
            // user input search method
            // select the right prompt
        }

        /// <summary>
        /// Search by Author Name
        /// </summary>
        public static void SearchByAuthor()
        {
            WriteLine(AskForAuthorNameSearch);
            // user input name
            // search
            WriteLine(BookNotFound);
            // book found
        }

        /// <summary>
        /// Search by Author Name
        /// </summary>
        public static void SearchByTitle()
        {
            WriteLine(AskForBookTitleSearch);
            // user input title
            // search
            WriteLine(BookNotFound);
            // book found
        }

        /// <summary>
        /// Edit an Book
        /// </summary>
        public static void EditAnBook()
        {
            WriteLine("First, lets find the book...");
            SearchBook();
        }
    }
}
