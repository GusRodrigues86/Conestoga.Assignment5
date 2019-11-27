/* Assignment 5
*
* Revision History
*      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
*/

using Assignment5.Model;
using System;
using System.Collections.Generic;

namespace Assignment5.Service
{
    /// <summary>
    /// The Library Service will hold records by author and by title
    /// of all known books by the library.
    /// LibraryService is Mutable.
    /// </summary>
    public class LibraryService
    {
        private Library Library;

        // rep invariant:
        //    non null library
        //
        // abstraction function:
        //    The Library of Books that is non null.

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class.
        /// </summary>
        public LibraryService()
        {
            this.Library = new Library();
            this.CheckRep();
        }

        /// <summary>
        /// Searches for all books.
        /// </summary>
        /// <param name="book">The book to be searched.</param>
        /// <returns>True if and only if the book is in library.</returns>
        public bool Search(Book book) => this.Library.Search(book);

        /// <summary>
        /// Will count all books in the library.
        /// </summary>
        /// <returns>The total of books.</returns>
        public int BookCounter() => this.Library.BookCounter();

        /// <summary>
        /// Counts how many books are known by that author.
        /// </summary>
        /// <param name="author">The author of the books.</param>
        /// <returns>the total books know of that author.</returns>
        public int BooksByAuthorCounter(string author) => this.Library.BooksByAuthorCounter(author);

        /// <summary>
        /// Add a book to the library
        /// </summary>
        /// <param name="book">Book to be added.</param>
        /// <returns>True if and only if the add was successfull.</returns>
        public bool AddBook(Book book) => this.Library.AddBook(book);

        /// <summary>
        /// Remove a book from the library.
        /// </summary>
        /// <param name="book">The book to be removed.</param>
        /// <returns>true if and only if the book was on the library.</returns>
        public bool RemoveBook(Book book) => this.Library.RemoveBook(book);

        /// <summary>
        /// abstraction function:
        /// <para>The Library of Books that is non null.</para>
        /// </summary>
        private void CheckRep()
        {
            _ = this.Library ?? throw new NullReferenceException(nameof(this.Library));
        }

        /// <summary>
        /// Search and retrieve a book by it's title.
        /// </summary>
        /// <param name="title">The title to search.</param>
        /// <returns>A book if and only if the books is in library.
        /// </returns>
        /// <exception cref="KeyNotFoundException">If no book is found.
        /// </exception>
        public Book SearchByTitle(string title)
        {
            if (this.Library.SearchByTitle(title))
            {
                return this.Library.GetByTitle(title);
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Search and retrieve a book by it's author.
        /// </summary>
        /// <param name="author">The author to search.</param>
        /// <returns>A book if and only if the books is in library.
        /// </returns>
        /// <exception cref="KeyNotFoundException">If no book is found.
        /// </exception>
        public Book SearchByAuthor(string author)
        {
            if (this.Library.SearchByAuthor(author))
            {
                return this.Library.GetByAuthor(author);
            }

            throw new KeyNotFoundException();
        }
    }
}
