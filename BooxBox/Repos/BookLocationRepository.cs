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

        public async Task<List<BookLocation>> GetAllBookLocations()
        {
            return await _wrapper._database.Table<BookLocation>().ToListAsync();
        }

        public async Task AddBookLocation(BookLocation location)
        {
            await _wrapper._database.InsertAsync(location);   
        }

        public async Task<BookLocation>? GetBookLocationById(int id)
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

        public async Task UpdateBookLocation(BookLocation location)
        {
            BookLocation foundLocation = await GetBookLocationById(location.Id);
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

        public async Task DeleteBookLocationById(int id)
        {
            {
                BookLocation? foundLocation = await GetBookLocationById(id);
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
