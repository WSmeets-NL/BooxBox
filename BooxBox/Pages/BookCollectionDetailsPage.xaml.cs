using BooxBox.Models;
using BooxBox.Services;

namespace BooxBox.Pages;

public partial class BookCollectionDetailsPage : ContentPage
{
    private readonly BookService _bookService;
    private readonly BookCollectionService _collectionService;
    private readonly BookLocationService _locationService;


    public BookCollection ChosenCollection { get; set; }
    public int CollectionId
    {
        set
        {
            GetCollection(value);
        }

    }
    public List<Book> IncludedBooks{ get; set; }
    public List<BookLocation> BookLocations { get; set; } = new List<BookLocation>();

    public BookCollectionDetailsPage(AuthorService authorService, BookService bookService, BookCollectionService collectionService, BookLocationService locationService)
    {
        InitializeComponent();
        _bookService = bookService;
        _collectionService = collectionService;
        _locationService = locationService;
    }

    public async Task GetCollection(int collectionId)
    {
        ChosenCollection = await _collectionService.GetBookCollectionById(collectionId);
        IncludedBooks = await _bookService.GetAllBooksInCollection(collectionId);

        foreach(Book book in IncludedBooks)
        {
            BookLocations.Add(await _locationService.GetBookLocationById(book.BookLocationId));
        }

        BindingContext = this;
    }
}