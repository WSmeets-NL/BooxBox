using System;
using BooxBox.Models;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<List<Book>> GetBooksInCollectionAsync();

        Task<List<Book>> GetBooksInLocationAsync();

        Task AddBookAsync(Book book);

        Task<Book>? GetBookByIdAsync(int id);

        Task UpdateBookAsync(Book book);

        Task DeleteBookCollectionByIdAsync(int id);
    }
}
