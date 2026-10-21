using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Repos
{
    public class BookLocationRepository : IBookLocationRepository
    {
        private readonly BooxBoxDbWrapper _wrapper;

        public BookLocationRepository(BooxBoxDbWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<List<BookLocation>> GetAllBookLocationsAsync()
        {
            return await _wrapper._database.Table<BookLocation>().ToListAsync();
        }

        public async Task AddBookLocationAsync(BookLocation location)
        {
            await _wrapper._database.InsertAsync(location);   
        }

        public async Task<BookLocation>? GetBookLocationByIdAsync(int id)
        {
            BookLocation location = await _wrapper._database.Table<BookLocation>().Where(b => b.Id == id).FirstOrDefaultAsync();
            if (location != null)
            {
                return location;
            }

            else
            {
                throw new FileNotFoundException();
            }

        }

        public async Task UpdateBookLocationAsync(BookLocation location)
        {
            BookLocation foundLocation = await GetBookLocationByIdAsync(location.Id);
            if (foundLocation != null)
            {
                foundLocation = location;
                await _wrapper._database.UpdateAsync(foundLocation);
                return;
            }

            else
            {
                return;
            }
        }

        public async Task DeleteBookLocationByIdAsync(int id)
        {
            {
                BookLocation? foundLocation = await GetBookLocationByIdAsync(id);
                if (foundLocation != null)
                {
                    await _wrapper._database.DeleteAsync(foundLocation);
                }

                else
                {
                    return;
                }
            }
        }
    }
}
