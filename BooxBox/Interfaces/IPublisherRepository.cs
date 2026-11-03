using System;
using System.Collections.Generic;
using System.Text;
using BooxBox.Models;

namespace BooxBox.Interfaces
{
    interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllPublishersAsync();

        Task<Publisher>? GetPublisherByIdAsync(int id);

        Task AddPublisherAsync(Publisher publisher);
    }
}
