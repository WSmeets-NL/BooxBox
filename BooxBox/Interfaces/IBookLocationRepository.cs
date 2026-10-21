using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

namespace BooxBox.Interfaces
{
    public interface IBookLocationRepository
    {
        Task<List<BookLocation>> GetAllBookLocations();

        Task AddBookLocation(BookLocation location);

        Task<BookLocation>? GetBookLocationById(int id);

        Task UpdateBookLocation(BookLocation location);

        Task DeleteBookLocationById(int id);
    }
}
