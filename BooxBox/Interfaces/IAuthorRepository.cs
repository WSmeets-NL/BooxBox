using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Interfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthor(Author author);

        Task<Author>? GetAuthorById(int id);
        Task<Author>? GetAuthorByName(string name);
        Task<String>? GetAuthorName(int id);
        Task<List<Author>> GetAllAuthorsAsync();
        Task UpdateAuthor (Author author);
        Task DeleteAuthorById (int id);
    }
}
