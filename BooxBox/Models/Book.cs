namespace BooxBox.Models
{
    public class Book
    {

        int Id { get; set; } = 0;
        string Title { get; set; }
        string Author { get; set; }
        string Publisher { get; set; }
        string Language { get; set; }
        int NumberOfPages { get; set; }
        string ReadingStatus { get; set; } = "Nog niet gelezen";

        Bookcase AssignedBookcase { get; set; }
        int BookcaseId { get; set; }
        int ReadingScore { get; set; }
        string ReaderComment { get; set; }
        DateTime PublishingDate { get; set; }
        List<BookCollection> InCollections { get; set; } = new List<BookCollection>();

        public Book(int id, string title, string author, string publisher, int numberOfPages, DateTime publishingDate)
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