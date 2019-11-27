/* Assignment 5
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
 */

using System;
using System.Collections.Generic;
using static System.Console;
using static Assignment5.View.Prompt;
using static Assignment5.Service.BookUseCase;
using Assignment5.Service;
using Assignment5.Model;
using Assignment5.Helper;

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
            int selection;
            Statistics(library);
            WriteLine(MainMenu);
            selection = MenuUseCase.MainMenu(ReadLine());

            switch (selection)
            {
                case 1:
                    CreateBook(library);
                    break;
                case 2:
                    SearchBook(library);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Home(library);
                    break;
            }
        }

        /// <summary>
        /// Calls the book creation.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void CreateBook(LibraryService library)
        {
            Clear();
            string title;
            string author;
            int copyrightYear;
            int numberOfPages;
            Book book;

            WriteLine(AskForTitle);
            title = CreateTitle(ReadLine());
            WriteLine();

            // user input answer
            WriteLine(AskForAuthor);
            author = CreateAuthor(ReadLine());
            WriteLine();

            // user inputs answer
            WriteLine(AskForCopyright);
            copyrightYear = CreateCopyrightYear(ReadLine());
            WriteLine();

            // user inputs answer
            WriteLine(AskForNumberOfPages);
            numberOfPages = CreateNumberOfPages(ReadLine());
            WriteLine();

            // try to create book
            try
            {
                book = new Book(title: title, author: author, copyrightYear: copyrightYear, numberOfPages: numberOfPages);

                // try to store book
                if (!library.AddBook(book))
                {
                    throw new InvalidOperationException();
                }
                WriteLine($"Saved \"{book.GetTitle()}\" successfully:");
            }
            catch (InvalidOperationException)
            {
                Write("Unable to save the book in our library.\n" +
                    "This mean that this books is already in the library.");
                Home(library);
            }
            catch (Exception)
            {
                WriteLine("I'm sorry Dave, I'm afraid that I can't do that...");
                WriteLine("Let's try again to create this book.");
                CreateBook(library);
            }

            Home(library);
        }

        /// <summary>
        /// How user whants to search for a book.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void SearchBook(LibraryService library)
        {
            Clear();
            int selection;
            WriteLine(SearchMethods);
            selection = MenuUseCase.Search(ReadLine());
            switch (selection)
            {
                case 1:
                    SearchByTitle(library);
                    break;
                case 2:
                    SearchByAuthor(library);
                    break;
                case 3:
                    Clear();
                    WriteLine("Returning to the main menu");
                    Home(library);
                    break;
                default:
                    WriteLine("Try again, please.");
                    SearchBook(library);
                    break;
            }
        }

        /// <summary>
        /// Search by Author Name.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void SearchByAuthor(LibraryService library)
        {
            string author;
            Book book;
            WriteLine(AskForAuthorNameSearch);
            author = CreateAuthor(ReadLine());
            try
            {
                book = library.SearchByAuthor(author);
                Clear();
                WriteLine(book);
                WriteLine();
            }
            catch (KeyNotFoundException)
            {
                Clear();
                WriteLine(BookNotFound);
                Write("Press any key to go back to the search menu.");
                ReadKey();
                SearchBook(library);
            }

            Home(library);
        }

        /// <summary>
        /// Search by Author Name.
        /// </summary>
        /// <param name="library">The library service.</param>
        public static void SearchByTitle(LibraryService library)
        {
            string title;
            Book book;
            WriteLine(AskForBookTitleSearch);
            title = CreateTitle(ReadLine());
            try
            {
                book = library.SearchByTitle(title);
                Clear();
                WriteLine(book);
                WriteLine();
            }
            catch (KeyNotFoundException)
            {
                Clear();
                WriteLine(BookNotFound);
                Write("Press any key to go back to the search menu.");
                ReadKey();
                SearchBook(library);
            }

            Home(library);

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
