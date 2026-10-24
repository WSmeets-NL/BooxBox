using System;
using BooxBox.Models;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<List<Book>> GetBooksInCollectionAsync(int collectionId);

        Task<List<Book>> GetBooksInLocationAsync(int locationId);

        Task AddBookAsync(Book book);

        Task<Book>? GetBookByIdAsync(int id);

        Task UpdateBookAsync(Book book);

        Task DeleteBookByIdAsync(int id);
    }
}
