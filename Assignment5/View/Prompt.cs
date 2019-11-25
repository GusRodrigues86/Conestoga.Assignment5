/* Assignment 5
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
 */
namespace Assignment5.View
{
    /// <summary>
    /// All possible responses for the user.
    /// </summary>
    internal static class Prompt
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
        /// Search options.
        /// </summary>
        public static readonly string SearchMethods =
            "A. By the title of the book\n" +
            "B. By the author of the book\n";

        /// <summary>
        /// Ask for user input the book title to search.
        /// </summary>
        public static readonly string AskForBookTitleSearch =
            "Please, provide a book title to search:";

        /// <summary>
        /// Ask for user input the author name to search.
        /// </summary>
        public static readonly string AskForAuthorNameSearch =
            "Please, provide an author to search:";

        /// <summary>
        /// Tells that book already exists on the collection.
        /// </summary>
        public static readonly string BookAlreadyExists =
            "Book record already exists";

        /// <summary>
        /// Tells that no book was found on the collection.
        /// </summary>
        public static readonly string BookNotFound =
            "No book record exists";

        /// <summary>
        /// The Main Menu.
        /// </summary>
        public static readonly string MainMenu =
            "Choose one of the Following\n" +
            "A. Create a new book\n" +
            "B. Display the details of an existing book\n" +
            "C. Edit an existing book:\n" +
            "D. Exit the program:";

        /// <summary>
        /// General statistics header.
        /// </summary>
        public static readonly string StatisticsMessage =
            "Hour library has a total of: ";

        /// <summary>
        /// Basic statistics.
        /// </summary>
        public static readonly string StatisticsBooks =
            "Books: ";
    }
}
