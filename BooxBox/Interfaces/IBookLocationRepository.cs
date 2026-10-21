using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

namespace BooxBox.Interfaces
{
    public interface IBookLocationRepository
    {
        List<BookLocation> GetAllBookLocation();

        BookLocation AddBookLocation(BookLocation location);

        BookLocation GetBookLocationById(int id);

        BookLocation UpdateBookLocation(BookLocation location);

        void DeleteBookLocationById(int id);
    }
}
