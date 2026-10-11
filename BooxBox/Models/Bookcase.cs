using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> ContainedBooks { get; set; } = new List<Book>();

        public Location()
        { 
        }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
