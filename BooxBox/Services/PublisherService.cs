using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Services
{

    public class PublisherService
    {
        private readonly IPublisherRepository _publisherRepo;

        public PublisherService(IPublisherRepository publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        public async Task<List<Publisher>> GetAllPublishersAsync()
        {
            return await _publisherRepo.GetAllPublishersAsync();
        }
         
        public async Task<Publisher?> GetPublisherById(int id)
        {
            return await _publisherRepo.GetPublisherByIdAsync(id);
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
            await _publisherRepo.AddPublisherAsync(publisher);
        }
    }
}
