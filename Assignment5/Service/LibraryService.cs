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
        private IDictionary<string, ISet<Book>> BooksByAuthor;

        // rep invariant:
        //    non null dictionary
        //
        // abstraction function:
        //    The set of books in BooksByAuthor contains a set of Book that is non null.

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class.
        /// </summary>
        public LibraryService()
        {
            this.BooksByAuthor = new Dictionary<string, ISet<Book>>();
            this.CheckRep();
        }

        /// <summary>
        /// Searches for all books.
        /// </summary>
        /// <param name="book">The book to be searched.</param>
        /// <returns>True if and only if the book is in library.</returns>
        public bool Search(Book book)
        {
            if (this.SearchByAuthor(book.GetAuthor()))
            {
                if (this.BooksByAuthor[book.GetAuthor()].Contains(book))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Will count all books in the library.
        /// </summary>
        /// <returns>The total of books.</returns>
        public int TotalOfBooks()
        {
            int counter = 0;
            if (this.BooksByAuthor.Keys.Count != 0)
            {
                foreach (KeyValuePair<string, ISet<Book>> pair in this.BooksByAuthor)
                {
                    counter += this.BooksByAuthor[pair.Key].Count;
                }

                return counter;
            }

            return 0;
        }

        /// <summary>
        /// Counts all books know by that author.
        /// </summary>
        /// <param name="author">The author of the books</param>
        /// <returns>the total books know of that author</returns>
        public int BooksByAuthorCounter(string author)
        {
            author = author.ToLower();
            if (this.SearchByAuthor(author))
            {
                ISet<Book> tempSet = new HashSet<Book>();
                this.BooksByAuthor.TryGetValue(author, out tempSet);
                return tempSet.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Add a book to the library
        /// </summary>
        /// <param name="book">Book to be added.</param>
        /// <returns>True if and only if the add was successfull.</returns>
        public bool AddBook(Book book)
        {
            if (this.SearchByAuthor(book.GetAuthor()))
            {
                if (this.BooksByAuthor[book.GetAuthor()].Contains(book))
                {
                    return false;
                }
                else
                {
                    this.BooksByAuthor[book.GetAuthor()].Add(book);
                    this.CheckRep();
                    return true;
                }

                // Book already exists.
                return false;
            }
            else
            {
                this.BooksByAuthor.Add(book.GetAuthor(), new HashSet<Book>() { book });
                this.CheckRep();
                return true;
            }

        }

        /// <summary>
        /// Remove a book from the library.
        /// </summary>
        /// <param name="book">The book to be removed.</param>
        /// <returns>true if and only if the book was on the library.</returns>
        public bool RemoveBook(Book book)
        {
            if (this.SearchByAuthor(book.GetAuthor()))
            {
                if (this.BooksByAuthor[book.GetAuthor()].Contains(book))
                {
                    this.BooksByAuthor[book.GetAuthor()].Remove(book);
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Searches for all books with that author.
        /// </summary>
        /// <param name="author">The author to be searched.</param>
        /// <returns>True if and only if there is a book with that author.</returns>
        private bool SearchByAuthor(string author)
        {
            return this.BooksByAuthor.Keys.Contains(author.ToLower());
        }

        /// <summary>
        /// abstraction function:
        /// <para>The set of books in BooksByAuthor contains a set of Book that is non null.</para>
        /// </summary>
        private void CheckRep()
        {
            _ = this.BooksByAuthor ?? throw new NullReferenceException(nameof(this.BooksByAuthor));
            foreach (var pair in this.BooksByAuthor)
            {
                _ = pair.Value ?? throw new ArgumentNullException();
            }
        }
    }
}
