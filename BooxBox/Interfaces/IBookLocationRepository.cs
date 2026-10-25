using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

namespace BooxBox.Interfaces
{
    public interface IBookLocationRepository
    {
        Task<List<BookLocation>> GetAllBookLocationsAsync();

        Task AddBookLocationAsync(BookLocation location);

        Task<BookLocation>? GetBookLocationByIdAsync(int id);

        Task UpdateBookLocationAsync(BookLocation location);

        Task DeleteBookLocationByIdAsync(int id);

        Task<String> GetBookLocationNameAsync(int id);
    }
}
