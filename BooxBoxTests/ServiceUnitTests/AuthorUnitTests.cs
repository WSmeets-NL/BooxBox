using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Interfaces;
using BooxBox.Models;
using BooxBox.Services;
using BooxBox.Repos;
using Moq;
using Xunit;

namespace BooxBoxTests.ServiceUnitTests
{
    public class AuthorUnitTests
    {
        [Fact]

        public async Task GetAllAuthorsReturnsAllAuthors()
        {
            //Arrange
            List<Author> authors = new List<Author>();

            Author author1 = new Author()
            {
                Id = 1,
                Name = "Willy Vandersteen"
            };

            Author author2 = new Author()
            {
                Id = 2,
                Name = "Gerrit de Jager"
            };

            authors.Add(author1);
            authors.Add(author2);

            Mock<IAuthorRepository> mockAuthorRepo = new Mock<IAuthorRepository>();

            mockAuthorRepo.Setup(r => r.GetAllAuthorsAsync()).ReturnsAsync(authors);

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            List<Author> returnedAuthors = await authorService.GetAllAuthorsAsync();

            //Assert
            Assert.NotNull(returnedAuthors);
            Assert.Equal(2, returnedAuthors.Count);
        }

        [Fact]
        public async Task GetAuthorByIdReturnsCorrectAuthor()
        {
            //Arrange
            List<Author> authors = new List<Author>();

            Author author1 = new Author()
            {
                Id = 1,
                Name = "Willy Vandersteen"
            };

            Author author2 = new Author()
            {
                Id = 2,
                Name = "Gerrit de Jager"
            };

            authors.Add(author1);
            authors.Add(author2);

            Mock<IAuthorRepository> mockAuthorRepo = new Mock<IAuthorRepository>();

            mockAuthorRepo.Setup(r => r.GetAuthorById(1)).Returns((Task<Author>)authors.Where(a => a.Id == 1));

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            Author returnedAuthor = await authorService.GetAuthorById(1);

            //Assert
            Assert.NotNull(returnedAuthor);
            Assert.Equal(1, returnedAuthor.Id);
        }
        [Fact]
        public async Task AddAuthorCorrectlyCallsTheRepo()
        {
            //Arrange

            Author newAuthor = new Author()
            {
                Id = 1,
                Name = "Jef Nys"
            };


            Mock<IAuthorRepository> mockAuthorRepo = new Mock<IAuthorRepository>();

            mockAuthorRepo.Setup(r => r.AddAuthor(newAuthor)).Returns(Task.CompletedTask);

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            await authorService.AddAuthor(newAuthor);

            //Assert
            mockAuthorRepo.Verify(r => r.AddAuthor(newAuthor), Times.Once);
        }

        [Fact]

        public async Task GetAuthorByNameGetsTheCorrectAuthor()
        {
            //Arrange
            Author author1 = new Author()
            {
                Id = 1,
                Name = "Willy Vandersteen"
            };

            Author author2 = new Author()
            {
                Id = 2,
                Name = "Gerrit de Jager"
            };


            Mock<IAuthorRepository> mockAuthorRepo = new Mock<IAuthorRepository>();

            mockAuthorRepo.Setup(r => r.GetAuthorByName("Gerrit de Jager")).ReturnsAsync(author2);

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            Author returnedAuthor = await authorService.GetAuthorByName("Gerrit de Jager");

            //Assert
            Assert.NotNull(returnedAuthor);
            Assert.Equal(author2.Id, returnedAuthor.Id);

        }

        [Fact]
        public async Task GetAuthorNameReturnsAuthorName()
        {
            //Arrange
            Author author1 = new Author()
            {
                Id = 1,
                Name = "Willy Vandersteen"
            };

            Author author2 = new Author()
            {
                Id = 2,
                Name = "Gerrit de Jager"
            };


            Mock<IAuthorRepository> mockAuthorRepo = new Mock<IAuthorRepository>();

            mockAuthorRepo.Setup(r => r.GetAuthorName(1)).ReturnsAsync("Willy Vandersteen");

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            String returnedAuthorName = await authorService.GetAuthorName(1);

            //Assert
            Assert.NotNull(returnedAuthorName);
            Assert.Equal(author1.Name, returnedAuthorName);

        }

    }
}