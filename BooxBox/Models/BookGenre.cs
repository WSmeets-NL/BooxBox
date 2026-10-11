using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class BookGenre
    {
        public int Id { get; set; } = 0;
        public int BookId { get; set; }
        public int GenreId { get; set; }

        public BookGenre()
        {
        }

        public BookGenre(int bookId, int genreId)
        {
            BookId = bookId;
            GenreId = genreId;
        }

    }
}
