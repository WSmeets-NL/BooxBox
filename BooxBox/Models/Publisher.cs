using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class Publisher
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }

        public List<Book> PublishedBooks { get; set; } = new List<Book>();

        public Publisher()
        {
        }

        public Publisher(string name)
        {
            Name = name;
        }
    }
}
