using Microsoft.EntityFrameworkCore;
using SQLite;
using System.ComponentModel.DataAnnotations;
using PrimaryKeyAttribute = SQLite.PrimaryKeyAttribute;

namespace BooxBox.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string? Language { get; set; }
        public int NumberOfPages { get; set; }
        public string ReadingStatus { get; set; } = "Nog niet gelezen";

        public Bookcase? InBookcase { get; set; }
        public int? BookcaseId { get; set; }
        public int? BookRating { get; set; }
        public string? ReaderComment { get; set; }
        public DateTime? PublishingDate { get; set; }
        public List<BookCollection> InCollections { get; set; } = new List<BookCollection>();

        public Book()
        {
        }

        public Book(int id, string title, string author, string publisher, int numberOfPages, DateTime? publishingDate = null)
        {
            Id = id;
            Title = title;
            Author = author;
            Publisher = publisher;
            NumberOfPages = numberOfPages;
            PublishingDate = publishingDate;
        }

    }
}