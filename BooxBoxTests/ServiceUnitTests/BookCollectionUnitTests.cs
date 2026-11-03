using System;
using BooxBox.Models;
using BooxBox.Services;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using BooxBox.Interfaces;

namespace BooxBoxTests.ServiceUnitTests
{
    public class BookCollectionUnitTests
    {
        [Fact]
        public async Task GetAllBookCollectionsAsyncGetsAllCollections()
        {
            //Arrange 
            List<BookCollection> bookCollectionList = new List<BookCollection>();

            BookCollection collection1 = new BookCollection()
            {
                Id = 1,
                Name = "Novelle"
            };

            BookCollection collection2 = new BookCollection()
            {
                Id = 2,
                Name = "Deurstopper"
            };

            bookCollectionList.Add(collection1);
            bookCollectionList.Add(collection2);

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.GetAllBookCollectionsAsync()).ReturnsAsync(bookCollectionList);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act

            List<BookCollection> returnedCollection = await collectionService.GetAllBookCollectionsAsync();

            //Assert

            Assert.NotNull(returnedCollection);
            Assert.Equal(collection1, returnedCollection[0]);
            Assert.Equal(collection2, returnedCollection[1]);
        }

        [Fact]

        public async Task GetBookCollectionByIdAsyncGetsTheCorrectBook()
        {
            //Arrange 
            List<BookCollection> bookCollectionList = new List<BookCollection>();

            BookCollection collection1 = new BookCollection()
            {
                Id = 1,
                Name = "Novelle"
            };

            BookCollection collection2 = new BookCollection()
            {
                Id = 2,
                Name = "Deurstopper"
            };

            bookCollectionList.Add(collection1);
            bookCollectionList.Add(collection2);

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.GetBookCollectionByIdAsync(2)).ReturnsAsync(collection2);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act

            BookCollection returnedCollection = await collectionService.GetBookCollectionById(2);

            //Assert

            Assert.NotNull(returnedCollection);
            Assert.Equal(collection2, returnedCollection);
        }

        [Fact]

        public async Task AddBookCollectionCorrectlyCallsRepo()
        {
            //Arrange

            BookCollection collection1 = new BookCollection()
            {
                Id = 1,
                Name = "Novelle"
            };

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.AddBookCollectionAsync(collection1)).Returns(Task.CompletedTask);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act
            await collectionService.AddBookCollection(collection1);

            //Assert
            mockCollectionRepo.Verify(r => r.AddBookCollectionAsync(collection1), Times.Once);
        }

        [Fact]
        public async Task UdateBookCollectionCorrectlyCallsRepo()
        {
            //Arrange

            BookCollection collection1 = new BookCollection()
            {
                Id = 1,
                Name = "Novelle"
            };

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.UpdateBookCollectionAsync(collection1)).Returns(Task.CompletedTask);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act
            await collectionService.UpdateBookCollection(collection1);

            //Assert
            mockCollectionRepo.Verify(r => r.UpdateBookCollectionAsync(collection1), Times.Once);
        }

        [Fact]
        public async Task DeleteBookCollectionCorrectlyCallsRepo()
        {
            //Arrange

            BookCollection collection1 = new BookCollection()
            {
                Id = 1,
                Name = "Novelle"
            };

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.DeleteBookCollectionByIdAsync(1)).Returns(Task.CompletedTask);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act
            await collectionService.DeleteBookCollectionByIdAsync(1);

            //Assert
            mockCollectionRepo.Verify(r => r.DeleteBookCollectionByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task AssignBookToCollectionAsyncCorrectlyCallsRepo()
        {
            BookCollection collection1 = new BookCollection()
            {
                Id = 1,
                Name = "TestCollectie"
            };

            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test",
                AuthorId = 1,
                LanguageId = 1,
            };

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.AssignBookToCollectionAsync(1, 1)).Returns(Task.CompletedTask);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act

            await collectionService.AssignBookToCollection(1, 1);

            //Assert
            mockCollectionRepo.Verify(r => r.AssignBookToCollectionAsync(1, 1), Times.Once);
        }

        [Fact]
        public async Task GetCollectionsContainingBookCorrectlyReturnsCollections()
        {
            //Arrange
            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test",
                AuthorId = 1,
                LanguageId = 1,
            };

            BookCollection testCollection = new BookCollection()
            {
                Id = 1,
                Name = "Test",
            };

            List<BookCollection> returnedCollections = new List<BookCollection>();
            returnedCollections.Add(testCollection);

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.GetCollectionsContainingBookAsync(1)).ReturnsAsync(returnedCollections);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act
            List<BookCollection> collectionResult = await collectionService.GetCollectionsContainingBookAsync(1);

            //Assert
            Assert.NotNull(collectionResult);
            Assert.Equal(testCollection, collectionResult[0]);
        }

        public async Task RemoveBookFromCollectionCorrectlyCallsRepo()
        {
            //Arrange
            Book testBook = new Book()
            {
                Id = 1,
                Title = "Test",
                AuthorId = 1,
                LanguageId = 1,
            };

            BookCollection testCollection = new BookCollection()
            {
                Id = 1,
                Name = "Test",
            };

            List<BookCollection> returnedCollections = new List<BookCollection>();
            returnedCollections.Add(testCollection);

            Mock<IBookCollectionRepository> mockCollectionRepo = new Mock<IBookCollectionRepository>();
            mockCollectionRepo.Setup(r => r.RemoveBookFromCollection(1,1)).Returns(Task.CompletedTask);

            BookCollectionService collectionService = new BookCollectionService(mockCollectionRepo.Object);

            //Act
            await collectionService.RemoveBookFromCollection(1, 1);

            //Assert
            mockCollectionRepo.Verify(r=>  r.RemoveBookFromCollection(1, 1), Times.Once());
        }

    }
}
