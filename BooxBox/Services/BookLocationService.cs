using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Services
{
    public class BookLocationService
    {
        private readonly IBookLocationRepository _locationRepo;

        public BookLocationService(IBookLocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public async Task<List<BookLocation>> GetAllBookLocationsAsync()
        {
            return await _locationRepo.GetAllBookLocationsAsync();
        }

        public async Task AddBookLocation(BookLocation location)
        {
            await _locationRepo.AddBookLocationAsync(location);
        }

        public async Task<BookLocation>? GetBookLocationById(int id)
        {
            return await _locationRepo.GetBookLocationByIdAsync(id);
        }

        public async Task UpdateBookLocation(BookLocation location)
        {
            await _locationRepo.UpdateBookLocationAsync(location);
        }

        public async Task DeleteBookLocationById(int id)
        {
            await _locationRepo.DeleteBookLocationByIdAsync(id);
        }

        public async Task<string> GetLocationName(int id)
        {
            string locationName = await _locationRepo.GetBookLocationNameAsync(id);
            return locationName;
        }
    }
}
