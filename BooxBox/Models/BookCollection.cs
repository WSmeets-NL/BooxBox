using System;
using System.Collections.Generic;
using System.Text;

namespace BooxBox.Models
{
    public class BookCollection
    {
        int Id { get; set; } = 0;
        string Name { get; set; }
        string Description { get; set; }
        List<Book> BooksInCollection { get; set; } = new List<Book>();
    }
}
