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

        public async void GetAllAuthorsReturnsAllAuthors()
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

            Mock<AuthorRepository> mockAuthorRepo = new Mock<AuthorRepository>();

            mockAuthorRepo.Setup(r => r.GetAllAuthorsAsync()).ReturnsAsync(authors);

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            List<Author> returnedAuthors = await authorService.GetAllAuthorsAsync();

            //Assert
            Assert.NotNull(returnedAuthors);
            Assert.Equal(2, returnedAuthors.Count);
        }

        [Fact]
        public async void GetAuthorByIdReturnsCorrectAuthor()
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

            Mock<AuthorRepository> mockAuthorRepo = new Mock<AuthorRepository>();

            mockAuthorRepo.Setup(r => r.GetAuthorById(1)).ReturnsAsync(authors.Where(a => a.Id == 1).First());

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            Author returnedAuthor = await authorService.GetAuthorById(1);

            //Assert
            Assert.NotNull(returnedAuthor);
            Assert.Equal(author1, returnedAuthor);
        }
        [Fact]
        public async void AddAuthorAddsAuthorToDatabase()
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

            Author newAuthor = new Author()
            {
                Id = 3,
                Name = "Jef Nys"
            };

            authors.Add(author1);
            authors.Add(author2);

            Mock<AuthorRepository> mockAuthorRepo = new Mock<AuthorRepository>();

            mockAuthorRepo.Setup(r => r.AddAuthor(newAuthor)).Returns(Task.CompletedTask);

            AuthorService authorService = new AuthorService(mockAuthorRepo.Object);


            //Act
            authorService.AddAuthor(newAuthor);
            List<Author> authorList = await authorService.GetAllAuthorsAsync();

            //Assert
            Assert.NotNull(authorList);
            Assert.Equal(newAuthor, authorList[3]);
        }
    }
}
