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
        public int AuthorId { get; set; }
        public int? IllustratorId { get; set; }
        public int LanguageId { get; set; }
        public string ISBN { get; set; }
        public int PublisherId { get; set; }
        public int? NumberOfPages { get; set; }
        public string ReadingStatus { get; set; } = "Nog niet gelezen";
        public int? LocationId { get; set; }
        public int? BookRating { get; set; }
        public string? ReaderComment { get; set; }
        public DateTime? PublishingDate { get; set; }

        //public Location? InLocation { get; set; }

        //public List<BookCollection> InCollections { get; set; } = new List<BookCollection>();

        //public List<Genre> BookGenres { get; set; } = new List<Genre>();

        public Book()
        {
        }

        public Book(int id, string title, int authorId, int publisherId, string iSBN, DateTime? publishingDate = null)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            PublisherId = publisherId;
            ISBN = iSBN;
            PublishingDate = publishingDate;
        }

    }
}