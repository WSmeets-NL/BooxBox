using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class Language
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Description { get; set; }

        public Language()
        {
        }

        public Language(string description)
        {
            Description = description;
        }
    }
}
