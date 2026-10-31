using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepo.GetAllBooksAsync();
        }

        public async Task<List<Book>>? GetAllBooksInCollection(int collectionId)
        {
            return await _bookRepo.GetBooksInCollectionAsync(collectionId);
        }

        public async Task<List<Book>>? GetAllBooksInLocation(int locationId)
        {
            return await _bookRepo.GetBooksInLocationAsync(locationId);
        }

        public async Task<Book>? GetBookById(int id)
        {
            return await _bookRepo.GetBookByIdAsync(id);
        }

        public async Task AddBook(Book book)
        {
            await _bookRepo.AddBookAsync(book);
        }

        public async Task UpdateBook(Book book)
        {
            await _bookRepo.UpdateBookAsync(book);
        }

        public async Task DeleteBookById(int id)
        {
            await _bookRepo.DeleteBookByIdAsync(id);
        }
    }
}
