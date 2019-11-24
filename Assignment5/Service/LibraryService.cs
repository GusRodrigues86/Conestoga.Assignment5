/* Assignment 5
*
* Revision History
*      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
*/

using Assignment5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Service
{
    /// <summary>
    /// The Library Service will hold records by author and by title
    /// of all known books by the library.
    /// </summary>
    public class LibraryService
    {
        public IDictionary<string, ISet<Book>> BooksByAuthor;
        public IDictionary<string, ISet<Book>> BooksByTitle;

        // rep invariant:
        //    non null dictionaries
        //
        // abstraction function:
        //    The set of books in BooksByAuthor excluding the set
        //    BooksByTitle is empty.
        //    The set of books in BooksByTitle excluding the set
        //    BooksByAuthor is empty.

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class.
        /// </summary>
        public LibraryService()
        {
            this.BooksByAuthor = new Dictionary<string, ISet<Book>>();
            this.BooksByTitle = new Dictionary<string, ISet<Book>>();
            this.CheckRep();
        }

        /// <summary>
        /// Searches for all books with that author.
        /// </summary>
        /// <param name="author">The author to be searched.</param>
        /// <returns>True if and only if there is a book with that author.</returns>
        public bool SearchByAuthor(string author)
        {
            return this.BooksByAuthor.Keys.Contains(author.ToLower());
        }

        /// <summary>
        /// Searches for all books with that title.
        /// </summary>
        /// <param name="title">The title to be searched.</param>
        /// <returns>True if and only if there is a book with that author.</returns>
        public bool SearchByTitle(string title)
        {
            return this.BooksByTitle.Keys.Contains(title.ToLower());
        }

        /// <summary>
        /// Add a book to the library
        /// </summary>
        /// <param name="book">Book to be added.</param>
        /// <returns>True if and only if the add was successfull.</returns>
        public bool AddBook(Book book)
        {
            this.BooksByAuthor.Add(book.GetAuthor(), new HashSet<Book>() { book });
            this.BooksByTitle.Add(book.GetTitle(), new HashSet<Book>() { book });
            return true;
        }

        /// <summary>
        /// abstraction function:
        /// <para>The set of books in BooksByAuthor excluding the set
        /// BooksByTitle is empty.</para>
        /// <para>The set of books in BooksByTitle excluding the set
        /// BooksByAuthor is empty.</para>
        /// </summary>
        private void CheckRep()
        {
            _ = this.BooksByAuthor ?? throw new NullReferenceException(nameof(this.BooksByAuthor));
            _ = this.BooksByTitle ?? throw new NullReferenceException(nameof(this.BooksByTitle));
            _ = (this.BooksByAuthor.Values.ToHashSet().Except(this.BooksByTitle.Values.ToHashSet()).Count() == 0) ? string.Empty :
                throw new ArgumentOutOfRangeException();
            _ = (this.BooksByTitle.Values.ToHashSet().Except(this.BooksByAuthor.Values.ToHashSet()).Count() == 0) ? string.Empty :
                throw new ArgumentOutOfRangeException();
        }
    }
}
