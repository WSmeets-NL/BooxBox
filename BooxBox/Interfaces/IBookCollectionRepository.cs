using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Interfaces
{
    public interface IBookCollectionRepository
    {
        Task<List<BookCollection>> GetAllBookCollectionsAsync();

        Task AddBookCollectionAsync(BookCollection collection);

        Task<BookCollection>? GetBookCollectionByIdAsync(int id);

        Task UpdateBookCollectionAsync(BookCollection collection);

        Task DeleteBookCollectionByIdAsync(int id);
    }
}
