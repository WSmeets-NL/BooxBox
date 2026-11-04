
using BooxBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Interfaces
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllPublishersAsync();

        Task<Publisher>? GetPublisherByIdAsync(int id);

        Task AddPublisherAsync(Publisher publisher);
    }
}
