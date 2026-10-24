using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Services
{
    public class BookCollectionService
    {
        private readonly IBookCollectionRepository _collectionRepo;

        public BookCollectionService(IBookCollectionRepository collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

        public async Task<List<BookCollection>> GetAllBookCollectionsAsync()
        {
            return await _collectionRepo.GetAllBookCollectionsAsync();
        }

        public async Task AddBookCollection(BookCollection collection)
        {
            await _collectionRepo.AddBookCollectionAsync(collection);
        }

        public async Task<BookCollection>? GetBookCollectionById(int id)
        {
            return await _collectionRepo.GetBookCollectionByIdAsync(id);
        }

        public async Task UpdateBookCollection(BookCollection collection)
        {
            await _collectionRepo.UpdateBookCollectionAsync(collection);
        }

        public async Task DeleteBookCollectionById(int id)
        {
            await _collectionRepo.DeleteBookCollectionByIdAsync(id);
        }
    }
}
