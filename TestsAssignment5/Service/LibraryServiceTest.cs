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
            bool actual = library.SearchByAuthor("George Orwell");
            // Assert
            Assert.That(actual, Is.False);

            actual = library.SearchByTitle("1984");
            Assert.That(actual, Is.False);
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
            Assert.Fail();
        }
    }
}
