/* Assignment 5
*
* Revision History
*      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
*/

namespace Assignment5.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Book is immutable object Representing a book that was released before 2020 and after 1923.
    /// <para>It has a non-null and non-whitespaced Title.</para>
    /// <para>It has a non-null List of non-null non-whitespaced Authors.</para>
    /// <para>It must have been released before 2019, inclusive, but not before 1924 as well.</para>
    /// <para>It must have at least one page.</para>
    /// </summary>
    public class Book
    {
        private readonly string Title;
        private readonly List<string> Authors;
        private readonly int CopyrightYear;
        private readonly int NumberOfPages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The book Title.</param>
        /// <param name="authors">The book Authors.</param>
        /// <param name="copyrightYear">The year of release.</param>
        /// <param name="numberOfPages">The number of pages.</param>
        public Book(string title, List<string> authors, int copyrightYear, int numberOfPages)
        {
            this.Title = title.ToLower();
            this.Authors = this.CheckAuthors(authors);
            this.CopyrightYear = copyrightYear;
            this.NumberOfPages = numberOfPages;
            this.CheckRep();
        }

        /// <summary>
        /// Get the list of authors.
        /// </summary>
        /// <returns>The list of authors.</returns>
        public List<string> GetAuthors()
        {
            this.CheckRep();
            return this.CheckAuthors(this.Authors);
        }

        /// <summary>
        /// Get the title of the Book.
        /// </summary>
        /// <returns>The title of the Book.</returns>
        public string GetTitle()
        {
            this.CheckRep();
            return this.Title;
        }

        /// <summary>
        /// Get the year that the Book was released.
        /// </summary>
        /// <returns>The year of the book release.</returns>
        public int GetCopyrightYear()
        {
            this.CheckRep();
            return this.CopyrightYear;
        }

        /// <summary>
        /// Get the total Number of Pages.
        /// </summary>
        /// <returns>The total number of pages.</returns>
        public int GetNumberOfPages()
        {
            this.CheckRep();
            return this.NumberOfPages;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is Book book)
                {
                    // EqualityComparer<List<string>>.Default.Equals(Authors, book.Authors) &&
                    return (this.Authors.Except(book.GetAuthors()).ToList().Count == 0) &&
                    this.Title == book.Title &&
                    this.CopyrightYear == book.CopyrightYear &&
                    this.NumberOfPages == book.NumberOfPages;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -956098;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Title);
            hashCode = (hashCode * -1521134295) + EqualityComparer<List<string>>.Default.GetHashCode(this.Authors);
            hashCode = (hashCode * -1521134295) + this.CopyrightYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.NumberOfPages.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Will return a list with all authors lowercased. The supplied author list must be made of non-null or white spaced name.
        /// </summary>
        /// <param name="toCheck">The list of Authors</param>
        /// <returns>A list of Authors with all names in lower case.</returns>
        /// <exception cref="NullReferenceException">If provided list is Empty or null.</exception>
        /// <exception cref="ArgumentNullException">If any element of the list is null or whitespaced.</exception>
        private List<string> CheckAuthors(List<string> toCheck)
        {
            if (toCheck == null || toCheck.Count == 0)
            {
                throw new NullReferenceException();
            }

            List<string> tempAuthors = new List<string>();
            toCheck.ForEach((author) =>
            {
                if (string.IsNullOrWhiteSpace(author))
                {
                    throw new ArgumentNullException(nameof(author));
                }

                tempAuthors.Add(author.ToLower());
            });

            return tempAuthors;
        }

        /// <summary> This methods will check the class invariance & abstract function.
        /// <para> AF(title) = (!null && !whiteSpace) && LowerCase</para>
        /// <para> AF(authors) = (!null && !NotEmptyList) &&  Elements LowerCase.</para>
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
            this.CheckAuthors(this.Authors);

            // AF(copyrightYear)
            _ = (this.CopyrightYear >= 1924 && this.CopyrightYear <= 2019) ? string.Empty : throw new ArgumentOutOfRangeException(nameof(this.CopyrightYear));

            // AF(numberOfPages)
            _ = (this.NumberOfPages >= 1) ? string.Empty : throw new ArgumentOutOfRangeException(nameof(this.NumberOfPages));
        }

    }
}
