using BooxBox.Data;
using BooxBox.Interfaces;
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Repos
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BooxBoxDbWrapper _wrapper;

        public PublisherRepository(BooxBoxDbWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<List<Publisher>> GetAllPublishersAsync()
        {
            return await _wrapper._database.Table<Publisher>().ToListAsync();
        }

        public async Task<Publisher?> GetPublisherByIdAsync(int id)
        {
            Publisher foundPublisher = await _wrapper._database.Table<Publisher>().Where(p => p.Id == id).FirstOrDefaultAsync();
            return foundPublisher;
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
            await _wrapper._database.InsertAsync(publisher);
        }
    }
}
