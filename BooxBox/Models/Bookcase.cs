using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class Bookcase
    {
        int Id { get; set; } = 0;
        string Description { get; set; }
        string Location { get; set; }
        List<Book> ContainedBooks { get; set; } = new List<Book>();

        public Bookcase(string description, string location)
        {
            Description = description;
            Location = location;
        }
    }
}
