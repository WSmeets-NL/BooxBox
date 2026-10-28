using BooxBox.Repos;
using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _Repo;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _Repo = authorRepository;
        }

        public async void AddAuthor(Author author)
        {
            _Repo.AddAuthor(author);
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _Repo.GetAllAuthorsAsync();
        }

        public async Task<Author>? GetAuthorById(int id)
        {
            Author? author = await _Repo.GetAuthorById(id);
            return author;
        }

        public async Task<Author>? GetAuthorByName(string name)
        {
            Author? author = await _Repo.GetAuthorByName(name);
            return author;            
        }

        public async Task<string>? GetAuthorName(int id)
        {
            string authorName = await _Repo.GetAuthorName(id);
            return authorName;
        }
    }
}
