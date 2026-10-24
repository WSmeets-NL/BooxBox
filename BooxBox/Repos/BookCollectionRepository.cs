using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Repos
{
    public class BookCollectionRepository : IBookCollectionRepository
    {
        private readonly BooxBoxDbWrapper _wrapper;

        public BookCollectionRepository(BooxBoxDbWrapper wrapper)
        {
            _wrapper = wrapper;
        };


        public async Task<List<BookCollection>> GetAllBookCollectionsAsync()
        {
            {
                return await _wrapper._database.Table<BookCollection>().ToListAsync();
            }
        }

        public async Task AddBookCollectionAsync(BookCollection collection)
        {
            {
                await _wrapper._database.InsertAsync(collection);
            }

        }

        public async Task<BookCollection>? GetBookCollectionByIdAsync(int id)
        {
            BookCollection collection = await _wrapper._database.Table<BookCollection>().Where(b => b.Id == id).FirstOrDefaultAsync();
            if (collection != null)
            {
                return collection;
            }

            else
            {
                throw new FileNotFoundException();
            }
        }

        public async Task UpdateBookCollectionAsync(BookCollection collection)
        {
            BookCollection foundCollection = await GetBookCollectionByIdAsync(collection.Id);
            if (foundCollection != null)
            {
                foundCollection = collection;
                await _wrapper._database.UpdateAsync(foundCollection);
                return;
            }

            else
            {
                return;
            }
        }

        public async Task DeleteBookCollectionByIdAsync(int id)
        {
            {
                BookCollection? foundCollection = await GetBookCollectionByIdAsync(id);
                if (foundCollection != null)
                {
                    await _wrapper._database.DeleteAsync(foundCollection);
                }

                else
                {
                    return;
                }
            }
        }
    }
}
