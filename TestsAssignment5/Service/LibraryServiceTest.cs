using Assignment5.Model;
using Assignment5.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsAssignment5.Service
{
    class LibraryServiceTest
    {
        public LibraryService library;
        public Book book;
        [SetUp]
        public void Init()
        {
            library = new LibraryService();
            string title = "1984";
            string author = "George Orwell";
            int copyrightRelease = 1949;
            int numberOfPages = 328;
            book = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
        }

        [Test]
        public void AnEmptyLibraryWillAlwaysReturnFalse()
        {
            // Act
            bool actual = library.Search(book);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void LibraryWithBookItemWillReturnTrue()
        {
            library.AddBook(book);
            // Act
            bool actual = library.Search(book);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AnEmptyLibraryWillAlwaysCountZero()
        {
            // Act
            int actual = library.BookCounter();
            // Assert
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void AddABookToTheLibraryWillReturnTrue()
        {
            // Act
            bool actual = library.AddBook(book);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AuthorHasOneBookBeforeWillRemainTrue() 
        {
            // Act
            bool actual = library.AddBook(book);

            // Assert
            Assert.That(actual, Is.True);
            
            // Assemble
            string title = "Animal Farm";
            string author = "George Orwell";
            int copyrightRelease = 1945;
            int numberOfPages = 112;
            book = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            
            // Act
            actual = library.AddBook(book);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void AddTheSameBookTwiceReturnFalse()
        {
            // Act
            bool actual = library.AddBook(book);

            // Assert
            Assert.That(actual, Is.True);
           
            // Act
            // add another
            actual = library.AddBook(book);

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void AddTwoBooksYeldsTwoInAuthorBookCounter()
        {
            // Act
            library.AddBook(book);
            // Assemble
            string title = "Animal Farm";
            string author = "George Orwell";
            int copyrightRelease = 1945;
            int numberOfPages = 120;
            book = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            library.AddBook(book);
            // Assert
            Assert.That(library.BooksByAuthorCounter(author), Is.EqualTo(2));
            Assert.That(library.BookCounter(), Is.EqualTo(2));
        }

        [Test]
        public void RemoveBookReturnsFalseOnEmptyLibrary()
        {
            // Assemble
            // Act
            bool actual = library.RemoveBook(book);
            // Assert
            Assert.That(actual, Is.False);
        }
        [Test]
        public void RemoveBookReturnsTrueIfOnLibrary()
        {
            // Assemble
            library.AddBook(book);
            // Act
            bool actual = library.RemoveBook(book);
            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void RemoveBookReturnsFalseIfNotOnLibrary()
        {
            // Act
            library.AddBook(book);
            // Assemble
            string title = "Animal Farm";
            string author = "George Orwell";
            int copyrightRelease = 1945;
            int numberOfPages = 120;
            book = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            // Act
            bool actual = library.RemoveBook(book);
            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void AfterBookIsRemovedTheTotalBookDownsByOne()
        {
            // Act
            library.AddBook(book);
            // Assemble
            string title = "Animal Farm";
            string author = "George Orwell";
            int copyrightRelease = 1945;
            int numberOfPages = 120;
            book = new Book(title: title, author: author, copyrightYear: copyrightRelease, numberOfPages: numberOfPages);
            library.AddBook(book);
            // Act
            library.AddBook(book);
            int actual = library.BookCounter();
            // Assert
            Assert.That(actual, Is.EqualTo(2));
            // Act
            library.RemoveBook(book);
            actual = library.BookCounter();
            // Assert
            Assert.That(actual, Is.EqualTo(1));
        }

    }
}
