using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.View
{
    /// <summary>
    /// All possible responses for the user.
    /// </summary>
    public static class Prompt
    {
        /// <summary>
        /// Ask for user input the book title.
        /// </summary>
        public static readonly string AskForTitle =
            "Please, provide the title of the book:";

        /// <summary>
        /// Ask for user input the book author.
        /// </summary>
        public static readonly string AskForAuthor =
            "Please, provide the name of the author:";

        /// <summary>
        /// Ask for user input the book copyright year of the book.
        /// </summary>
        public static readonly string AskForCopyright =
            "rovide the copyright year of the book:";

        /// <summary>
        /// Ask for user input the book number of Pages.
        /// </summary>
        public static readonly string AskForNumberOfPages =
            "Please, provide the number of pages of the book:";

        /// <summary>
        /// Ask for user input the book title to search.
        /// </summary>
        public static readonly string AskForBookTitle =
            "Please, provide a book title to search:";

        /// <summary>
        /// Ask for user input the author name to search.
        /// </summary>
        public static readonly string AskForAuthorName =
            "Please, provide an author to search:";

        /// <summary>
        /// Tells that book already exists on the collection.
        /// </summary>
        public static readonly string BookAlreadyExists =
            "Book record already exists";

        /// <summary>
        /// Tells that no book was found on the collection.
        /// </summary>
        public static readonly string NoBookFound =
            "No book record exists";

        /// <summary>
        /// The Main Menu.
        /// </summary>
        public static readonly string MainMenu =
            "A. Create a new book" +
            "B. Display the details of an existing book" +
            "C. Edit an existing book:" +
            "D. Exit the program:";

    }
}
