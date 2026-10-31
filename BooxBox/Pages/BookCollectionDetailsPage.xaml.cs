using BooxBox.Models;
using BooxBox.Services;

namespace BooxBox.Pages;

public partial class BookCollectionDetailsPage : ContentPage
{
    private readonly BookService _bookService;
    private readonly BookCollectionService _collectionService;


    public BookCollection ChosenCollection { get; set; }
    public int CollectionId
    {
        set
        {
            GetCollection(value);
        }

    }
    public List<Book> IncludedBooks{ get; set; }

    public BookCollectionDetailsPage(AuthorService authorService, BookService bookService, BookCollectionService collectionService)
    {
        InitializeComponent();
        _bookService = bookService;
        _collectionService = collectionService;
    }

    public async Task GetCollection(int collectionId)
    {
        ChosenCollection = await _collectionService.GetBookCollectionById(collectionId);
        IncludedBooks = await _bookService.GetAllBooksInCollection(collectionId);

        BooksInCollection.ItemsSource = IncludedBooks;
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
        await _collectionService.RemoveBookFromCollection(chosenBookId, ChosenCollection.Id);
        await GetCollection(ChosenCollection.Id);
    }
}