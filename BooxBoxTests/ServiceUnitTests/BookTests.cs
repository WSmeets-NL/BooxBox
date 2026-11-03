using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;
using BooxBox.Services;
using Xunit;
using Moq;
using BooxBox.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace BooxBoxTests.ServiceUnitTests
{
    public class BookTests
    {
        [Fact]
        public async Task GetAllBooksReturnsAllBooks()
        {
            //Arrange
            Book testBook1 = new Book()
            {
                Id = 1,
                Title = "Test1",
                AuthorId = 1,
                LanguageId = 1,
            };

            Book testBook2 = new Book()
            {
                Id = 2,
                Title = "Test2",
                AuthorId = 1,
                LanguageId = 1,
            };

            List<Book> books = new List<Book>();

            books.Add(testBook1);
            books.Add(testBook2);

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.GetAllBooksAsync()).ReturnsAsync(books);

            BookService bookService = new BookService(mockBookRepo.Object);

            //Act
            List<Book> returnedBooks = await bookService.GetAllBooks();

            //Assert
            Assert.NotNull(returnedBooks);
            Assert.Equal(testBook1, returnedBooks[0]);
            Assert.Equal(testBook2, returnedBooks[1]);
        }

        [Fact]
        public async Task GetAllBooksInCollectionCorrectlyReturnsListOfBooks()
        {
            //Arrange
            BookCollection testCollection = new BookCollection()
            {
                Id = 1,
                Name = "testverzameling"
            };

            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test1",
                AuthorId = 1,
                LanguageId = 1,
            };


            List<Book> booksInCollection = new List<Book>();
            booksInCollection.Add(testBook);

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.GetBooksInCollectionAsync(1)).ReturnsAsync(booksInCollection);

            BookService bookService = new BookService(mockBookRepo.Object);

            //Act
            List<Book> returnedBooks = await bookService.GetAllBooksInCollection(1);

            //Assert
            Assert.NotNull(returnedBooks);
            Assert.Equal(testBook, returnedBooks[0]);
        }

        [Fact]
        public async Task GetAllBooksInLocationCorrectlyReturnsListOfBooks()
        {
            //Arrange
            BookLocation testLocation = new BookLocation()
            {
                Id = 1,
                Name = "testkast"
            };

            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test1",
                AuthorId = 1,
                LanguageId = 1,
                BookLocationId = 1,
            };


            List<Book> booksInLocation = new List<Book>();
            booksInLocation.Add(testBook);

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.GetBooksInLocationAsync(1)).ReturnsAsync(booksInLocation);

            BookService bookService = new BookService(mockBookRepo.Object);

            //Act
            List<Book> returnedBooks = await bookService.GetAllBooksInLocation(1);

            //Assert
            Assert.NotNull(returnedBooks);
            Assert.Equal(testBook, returnedBooks[0]);
        }

        [Fact]
        public async Task GetBookByIdReturnsCorrectBook()
        {
            //Arrange
            Book testBook1 = new Book()
            {
                Id = 1,
                Title = "Test1",
                AuthorId = 1,
                LanguageId = 1,
            };

            Book testBook2 = new Book()
            {
                Id = 2,
                Title = "Test2",
                AuthorId = 1,
                LanguageId = 1,
            };

            List<Book> books = new List<Book>();
            books.Add(testBook1);
            books.Add(testBook2);

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.GetBookByIdAsync(1)).ReturnsAsync(books.Where(b => b.Id == 1).FirstOrDefault);

            BookService bookService = new BookService(mockBookRepo.Object);

            //Act
            Book returnedBook = await bookService.GetBookById(1);

            //Assert
            Assert.NotNull(returnedBook);
            Assert.Equal(testBook1, returnedBook);
        }

        [Fact]
        public async Task AddBookCorrectlyCallsRepo()
        {
            //Arrange

            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test me",
                AuthorId = 1,
                LanguageId = 1,
                BookLocationId = 1,
                IllustratorId = 1,
            };

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.AddBookAsync(testBook)).Returns(Task.CompletedTask);

            BookService bookService = new BookService(mockBookRepo.Object);


            //Act
            await bookService.AddBook(testBook);

            //Assert
            mockBookRepo.Verify(r => r.AddBookAsync(testBook), Times.Once);
        }


        [Fact]
        public async Task UpdateBookCorrectlyCallsRepo()
        {
            //Arrange

            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test me",
                AuthorId = 1,
                LanguageId = 1,
                BookLocationId = 1,
                IllustratorId = 1,
            };

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.UpdateBookAsync(testBook)).Returns(Task.CompletedTask);

            BookService bookService = new BookService(mockBookRepo.Object);


            //Act
            await bookService.UpdateBook(testBook);

            //Assert
            mockBookRepo.Verify(r => r.UpdateBookAsync(testBook), Times.Once);
        }

        [Fact]
        public async Task DeleteBookByIdCorrectlyCallsRepo()
        {
            //Arrange

            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test me",
                AuthorId = 1,
                LanguageId = 1,
                BookLocationId = 1,
                IllustratorId = 1,
            };

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.DeleteBookByIdAsync(1)).Returns(Task.CompletedTask);

            BookService bookService = new BookService(mockBookRepo.Object);


            //Act
            await bookService.DeleteBookById(1);

            //Assert
            mockBookRepo.Verify(r => r.DeleteBookByIdAsync(1), Times.Once);
        }

        public async Task DeleteBookFromLocationCorrectlyCallsRepo()
        {
            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test me",
                AuthorId = 1,
                LanguageId = 1,
                BookLocationId = 1,
                IllustratorId = 1,
            };

            Mock<IBookRepository> mockBookRepo = new Mock<IBookRepository>();
            mockBookRepo.Setup(r => r.DeleteBookFromLocation(1)).Returns(Task.CompletedTask);

            BookService bookService = new BookService(mockBookRepo.Object);


            //Act
            await bookService.DeleteBookFromLocation(1);

            //Assert
            mockBookRepo.Verify(r => r.DeleteBookFromLocation(1), Times.Once);
        }
    }
}