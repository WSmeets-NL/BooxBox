using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class BookBookCollection
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int BookCollectionId { get; set; }

        public BookBookCollection()
        {

        }

        public BookBookCollection(int bookId, int bookCollectionId)
        {
            BookId = bookId;
            BookCollectionId = bookCollectionId;
        }
    }
}
