/* Assignment 5
*
* Revision History
*      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment5.Model
{
    /// <summary>
    /// Book is immutable object Representing a book that was released
    /// before 2020 and after 1923.
    /// <para>It has a non-null and non-whitespaced Title.</para>
    /// <para>It has a non-null List of non-null non-whitespaced
    /// Authors.</para>
    /// <para>It must have been released before 2019, inclusive,
    /// but not before 1924 as well.</para>
    /// <para>It must have at least one page.</para>
    /// </summary>
    public class Book
    {
        private readonly string Title;
        private readonly string Author;
        private readonly int CopyrightYear;
        private readonly int NumberOfPages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The book title.</param>
        /// <param name="author">The book author.</param>
        /// <param name="copyrightYear">The year of release.</param>
        /// <param name="numberOfPages">The number of pages.</param>
        public Book(
            string title,
            string author,
            int copyrightYear,
            int numberOfPages)
        {
            this.Title = title.ToLower();
            this.Author = author.ToLower();
            this.CopyrightYear = copyrightYear;
            this.NumberOfPages = numberOfPages;
            this.CheckRep();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">Book cannot exist without information</exception>
        private Book() => throw new NotSupportedException();

        /// <summary>
        /// Get the author.
        /// </summary>
        /// <returns>The list of author.</returns>
        public string GetAuthor() => this.Author;

        /// <summary>
        /// Get the title of the Book.
        /// </summary>
        /// <returns>The title of the Book.</returns>
        public string GetTitle() => this.Title;

        /// <summary>
        /// Get the year that the Book was released.
        /// </summary>
        /// <returns>The year of the book release.</returns>
        public int GetCopyrightYear() => this.CopyrightYear;

        /// <summary>
        /// Get the total Number of Pages.
        /// </summary>
        /// <returns>The total number of pages.</returns>
        public int GetNumberOfPages() => this.NumberOfPages;

        /// <summary>
        /// The textual representation of the Book.
        /// </summary>
        /// <returns>The string representing of the Book.</returns>
        public string Display() => this.ToString();

        /// <summary>
        /// To comply with object signature.
        /// </summary>
        /// <exception cref="InvalidOperationException">On every call.</exception>
        public void Edit() => throw new InvalidOperationException();

        /// <inheritdoc/>
        public override string ToString()
        {
            return
             $"[Information About: {this.Title}]\n" +
             $"Author: {this.Author}.\n" +
             $"Released: {this.CopyrightYear}\n" +
             $"Number of Pages: {this.NumberOfPages}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            _ = obj ?? throw new NullReferenceException();

            return obj is Book book &&
                   this.Title == book.Title &&
                   this.Author == book.Author &&
                   this.CopyrightYear == book.CopyrightYear &&
                   this.NumberOfPages == book.NumberOfPages;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -956098;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Title);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Author);
            hashCode = (hashCode * -1521134295) + this.CopyrightYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.NumberOfPages.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// This methods will check the class invariance &
        /// abstract function.
        /// <para> AF(title) = (!null && !whiteSpace) && LowerCase</para>
        /// <para> AF(authors) = (!null && !NotEmptyList) &&
        /// Elements LowerCase.</para>
        /// <para> AF(copyrightYear) <= 2019 && >= 1924 </para>
        /// <para> AF(numberOfPages) > 0</para>
        /// Invariance: All cases must be true.
        /// </summary>
        private void CheckRep()
        {
            // AF (title)
            if (string.IsNullOrWhiteSpace(this.Title))
            {
                throw new ArgumentNullException(nameof(this.Title));
            }

            // AF(authors)
            if (string.IsNullOrWhiteSpace(this.Author))
            {
                throw new ArgumentNullException(nameof(this.Author));
            }

            // AF(copyrightYear)
            _ = (this.CopyrightYear >= 1924 &&
                this.CopyrightYear <= 2019) ?
                string.Empty : throw new
                ArgumentOutOfRangeException(nameof(this.CopyrightYear));

            // AF(numberOfPages)
            _ = (this.NumberOfPages >= 1) ?
                string.Empty : throw new
                ArgumentOutOfRangeException(nameof(this.NumberOfPages));
        }
    }
}
