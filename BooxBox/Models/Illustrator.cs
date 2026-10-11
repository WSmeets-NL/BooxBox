using SQLite;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BooxBox.Models
{
    public class Illustrator
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;    
        string Name { get; set; }
        //public List<Book> Books { get; set; } = new List<Book>();

        public Illustrator()
        {
        }

        public Illustrator(string name)
        {
            Name = name;
        }

    }
}
