using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class Bookcase
    {
        public int Id { get; set; } = 0;
        public string Description { get; set; }
        public string Location { get; set; }
        public List<Book> ContainedBooks { get; set; } = new List<Book>();

        public Bookcase(string description, string location)
        {
            Description = description;
            Location = location;
        }
    }
}
