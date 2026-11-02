using BooxBox.Models;
using BooxBox.Services;

namespace BooxBox.Pages;

[QueryProperty(nameof(BookLocationId), "id")]
public partial class BookLocationDetailsPage : ContentPage
{
    private readonly BookService _bookService;
    private readonly BookLocationService _locationService;


    public BookLocation ChosenLocation { get; set; }
    public int BookLocationId
    {
        set
        {
            GetLocation(value);
        }

    }
    public List<Book> IncludedBooks { get; set; }

    public BookLocationDetailsPage(AuthorService authorService, BookService bookService, BookLocationService locationService)
    {
        InitializeComponent();
        _bookService = bookService;
        _locationService = locationService;
    }

    public async Task GetLocation(int locationId)
    {
        ChosenLocation = await _locationService.GetBookLocationById(locationId);
        IncludedBooks = await _bookService.GetAllBooksInLocation(locationId);
        IncludedBooks = IncludedBooks.OrderBy(b => b.Title, StringComparer.OrdinalIgnoreCase).ToList();
        BooksInLocation.ItemsSource = IncludedBooks;
        BindingContext = this;
    }

    public async void ToBookDetails(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int chosenBookId = (int)button.BindingContext;
        await Shell.Current.GoToAsync($"BookDetailsPage?id={chosenBookId}");
    }

    public async void RemoveBook(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int chosenBookId = (int)button.BindingContext;
        await _bookService.DeleteBookFromLocation(chosenBookId);
        await GetLocation(ChosenLocation.Id);
    }
}