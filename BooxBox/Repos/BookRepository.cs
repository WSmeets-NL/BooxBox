using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Repos
{
    public class BookRepository : IBookRepository
    {
        private readonly BooxBoxDbWrapper _wrapper;

        public BookRepository(BooxBoxDbWrapper wrapper)
        {
            _wrapper = wrapper;
        }


        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _wrapper._database.Table<Book>().ToListAsync();
        }

        public async Task<List<Book>>? GetBooksInCollectionAsync(int collectionId)
        {
            List<Book> matchingBooks;
            List<BookBookCollection> matchingBookIds = await _wrapper._database.Table<BookBookCollection>().Where(b => b.BookCollectionId == collectionId).ToListAsync();
            foreach (BookBookCollection matchingId in matchingBookIds)
            {
                Book matchingBook = GetBookByIdAsync(matchingId.BookId);
                matchingBooks.Append(matchingBook);
            }
            return matchingBooks;
        }

        public async Task<List<Book>> GetBooksInLocationAsync(int locationId)
        {
            return await _wrapper._database.Table<Book>().Where(b => b.BookLocationId == locationId).ToListAsync();
        }

        public async Task<Book>? GetBookByIdAsync(int id)
        {
            return await _wrapper._database.Table<Book>().Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async void AddBookAsync(Book book)
        {
            await _wrapper._database.InsertAsync(book);
        }

        public async void UpdateBookAsync(Book book)
        {
            Book? foundBook = await GetBookByIdAsync(book.Id);
            if (foundBook != null)
            {
                foundBook = book;
                await _wrapper._database.UpdateAsync(foundBook);
                return;
            }

            else
            {
                return;
            }
        }

        public async void DeleteBookByIdAsync(int id)
        {
            Book? foundBook = await GetBookByIdAsync(id);
            if (foundBook != null)
            {
                await _wrapper._database.DeleteAsync(foundBook);
            }

            else
            {
                return;
            }
        }
    }
}
