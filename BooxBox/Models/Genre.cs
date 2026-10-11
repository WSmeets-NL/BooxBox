using SQLite;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BooxBox.Models
{
    public class Genre
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre()
        {
        }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
