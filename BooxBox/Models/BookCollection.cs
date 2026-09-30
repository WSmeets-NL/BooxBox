using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class BookCollection
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> BooksInCollection { get; set; } = new List<Book>();

        public BookCollection()
        {
        }

        public BookCollection(string  name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
