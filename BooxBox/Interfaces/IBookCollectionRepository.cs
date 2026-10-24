using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Interfaces
{
    public interface IBookCollectionRepository
    {
        Task<List<BookCollection>> GetAllBookCollectionsAsync();

        Task AddBookCollectionAsync(BookLocation location);

        Task<BookLocation>? GetBookCollectionByIdAsync(int id);

        Task UpdateBookCollectionAsync(BookLocation location);

        Task DeleteBookCollectionByIdAsync(int id);
    }
}
