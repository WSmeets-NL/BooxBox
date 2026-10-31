using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using Java.Util;
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
        }


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

        public async Task AssignBookToCollectionAsync(int bookId, int collectionId)
        {
            BookBookCollection bookCollectionCouple = new BookBookCollection(bookId, collectionId);
            await _wrapper._database.InsertAsync(bookCollectionCouple);
        }

        public async Task<List<BookCollection>> GetCollectionsContainingBookAsync(int bookId)
        {
            List<BookCollection> BookCollections = new List<BookCollection>();
            List<BookBookCollection> coupledCollections = await _wrapper._database.Table<BookBookCollection>().Where(c => c.BookId == bookId).ToListAsync();
            foreach(BookBookCollection collection in coupledCollections)
            {
                BookCollection foundCollection = await _wrapper._database.Table<BookCollection>().Where(c => c.Id == collection.BookCollectionId).FirstOrDefaultAsync();
                BookCollections.Append(foundCollection);
            }
            return BookCollections;
        }

        public async Task RemoveBookFromCollection(int bookId, int collectionId)
        {
            await _wrapper._database.Table<BookBookCollection>().Where(bbc => bbc.BookId == bookId && bbc.BookCollectionId == collectionId).DeleteAsync();
        }
    }
}
