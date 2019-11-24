using Assignment5.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsAssignment5.Model
{
    class BookTest
    {
        /* Test Strategy for the Book class
         * Test valid implementation - Done
         * Test Immutability - Done
         * Test Equality - Broken
         * Test Invalid Copyright Year - Done
         * Test No page book 
         * Test Negative page book 
         * Test Null author list
         * Test Empty author list
         * Test Whitespaced author list
         * Test null Title
         * Test whitespaced Title
         */
        public Book book;
        [SetUp]
        public void Init()
        {
            string title = "1984";
            string author = "George Orwell";
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            book = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
        }

        [Test]
        public void Test_BookIsImmutable()
        {
            // Assemble
            string title = "1984";
            string author = "George Orwell";
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            book = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            // Act by changing everything
            // change title
            title = "Brave new World";
            // add author to list
            author = "Bob";
            // change release date
            copyrightRelease = 1984;
            // number of pages
            numberOfPages = 200;
            Book secondBook = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            // Assert
            Assert.That(book.GetTitle(), Is.Not.EqualTo(title));
            Assert.That(book.GetAuthor(), Is.Not.EqualTo(author));
            Assert.That(book.GetCopyrightYear(), Is.Not.EqualTo(copyrightRelease));
            Assert.That(book.GetNumberOfPages(), Is.Not.EqualTo(numberOfPages));
            Assert.That(book, Is.Not.EqualTo(secondBook));
        }

        [Test]
        public void Test_ForEquality()
        {
            // Assemble
            Book secondBook;
            Book thirdBook;
            Book invalidBook;
            bool reflexive;
            bool symmetric;
            bool transitive;
            bool invalid;
            string title = "1984";
            string author = "George Orwell";
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            secondBook = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            thirdBook = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            invalidBook = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: 1);
            // Act
            reflexive = book.Equals(book);
            symmetric = (book.Equals(secondBook) && secondBook.Equals(book));
            transitive = (book.Equals(secondBook) && secondBook.Equals(thirdBook) && book.Equals(thirdBook));
            invalid = book.Equals(invalidBook);
            // Assert
            // reflexive
            Assert.That(reflexive, Is.True);
            Assert.That(symmetric, Is.True);
            Assert.That(transitive, Is.True);
            Assert.That(invalid, Is.False);
        }

        [Test]
        public void InvalidCopyRightYearTest()
        {
            string title = "1984";
            string authors = "George Orwell";
            int copyrightRelease = 1923;
            int numberOfPages = 328;

            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("Specified argument was out of the range of valid values. (Parameter 'CopyrightYear')")

            );
        }

        [Test]
        public void Test_NoPageBook()
        {
            // Assemble
            string title = "1984";
            string authors = "George Orwell";
            int copyrightRelease = 1949;
            int numberOfPages = 0;
            // Act
            // Assert
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>()
                );
        }

        [Test]
        public void Test_NegativePageBook()
        {
            // Assemble
            string title = "1984";
            string authors = "George Orwell";
            int copyrightRelease = 1949;
            int numberOfPages = -328;
            // Act
            // Assert
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>()
                );
        }


        [Test]
        public void Test_NullOrEmptyAuthorListThrowNRException()
        {

            // Assemble
            string title = "1984";
            string authors = null;
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            // Act
            // Assert
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<NullReferenceException>()
                );

            authors = string.Empty;
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentNullException>()
                );
        }

        [Test]
        public void Test_WhitespacedAuthorInAuthorThrowException()
        {
            // Assemble
            string title = "1984";
            string authors = " ";
            int copyrightRelease = 1949;
            int numberOfPages = 328;

            // Act
            // Assert
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentNullException>()
                );
            authors = string.Empty;

            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentNullException>()
                );
        }


        [Test]
        public void Test_NullOrWhitespacedTitleThrowsException()
        {
            // Assemble
            string title = " ";
            string authors = "George Orwell";
            int copyrightRelease = 1949;
            int numberOfPages = 328;

            // Assert
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentNullException>()
                );
            title = string.Empty;
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<ArgumentNullException>()
                );

            title = null;
            Assert.That(() => new Book(title: title, author: authors, copyrightYear: copyrightRelease, numberOfPages: numberOfPages),
                Throws.Exception.TypeOf<NullReferenceException>()
                );
        }

        [Test]
        public void Test_BookDisplayInformation()
        {
            // Assemble
            string title = "1984";
            string author = "George Orwell".ToLower();
            int copyrightRelease = 1949;
            int numberOfPages = 328;

            string expected =
             $"[Information About: {title}]\n" +
             $"Author: {author}.\n" +
             $"Released: {copyrightRelease}\n" +
             $"Number of Pages: {numberOfPages}";

            // Act
            string actual = book.Display();

            Assert.That(actual, Is.EqualTo(expected));

        }
    }
}
