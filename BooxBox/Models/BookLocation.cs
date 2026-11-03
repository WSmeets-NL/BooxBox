using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class BookLocation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Description { get; set; } = "Deze locatie heeft nog geen beschrijving";

        public BookLocation()
        { 
        }

        public BookLocation(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
