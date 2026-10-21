using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class Author
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Name { get; set; }

        public Author()
        {

        }

        public Author(string name)
        {
            Name = name;
        }
    }
}
