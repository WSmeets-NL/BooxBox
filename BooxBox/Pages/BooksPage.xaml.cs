using BooxBox.Models;
using BooxBox.Services;
using System.Diagnostics;
namespace BooxBox.Pages;
public partial class BooksPage : ContentPage
{
    public readonly BookService _bookService;
    public readonly AuthorService _authorService;
	public List<Book> Books { get; set;  }

	public BooksPage(AuthorService authorService, BookService bookService)
	{
        InitializeComponent();
        _authorService = authorService;
        _bookService = bookService;
        GetAllBooks();
    }

    public async void GetAllBooks()
    {
        Books = await _bookService.GetAllBooks();
        BookView.ItemsSource = Books;
    }

    public void SortAlphabetically(Object sender, EventArgs e)
    {
        Books = Books.OrderBy(b => b.Title, StringComparer.OrdinalIgnoreCase).ToList();
        BookView.ItemsSource = Books;
    }

    public void SearchBook(Object sender, EventArgs e)
    {
        List<Book> filteredBooks = Books.Where(b => b.Title.Contains(BookSearch.Text), StringComparison.OrdinalIgnoreCase).ToList();
        BookView.ItemsSource = filteredBooks;
    }

    public async void ToBookDetails(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int bookId = (int)button.BindingContext;
        await Shell.Current.GoToAsync($"BookDetailsPage?id={bookId}");
    }

    public async void DeleteBook(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int bookId = (int)button.BindingContext;
        string deletePrompt = await DisplayPromptAsync("Weet je zeker dat je dit boek wil verwijderen?", "Typ \'verwijder\' om dit boek te verwijderen", "verwijder", "annuleer");
        if (deletePrompt == "verwijder")
        {
            await DisplayAlertAsync("Verwijderd", "We hebben dit boek verwijderd", "Terug");
            await _bookService.DeleteBookById(bookId);
            GetAllBooks();
        }

        else
        {
            await DisplayAlertAsync("Boek behouden", "Het boek blijft behouden", "Terug");
        }
    }

    public async Task FilterBooks(Object sender, EventArgs e)
    {
        List<String> filterChoices = ["Auteur", "Illustrator", "LeesStatus",  "Score", "Uitgeverij"];
        string filterChoice = await DisplayActionSheetAsync("Waarop wil je filteren?", "Annuleer", null, filterChoices.ToArray());
        if (filterChoice == "Annuleer")
        {
            return;
        }
        if (filterChoice == "Auteur")
        {
            await filterByAuthor();
        }
    }

    public async Task filterByAuthor()
    {
        List<Author> authors = await _authorService.GetAllAuthorsAsync();
        
        string chosenAuthor = await DisplayActionSheetAsync("Waarop wil je filteren?", "Annuleer", null, authors.Select(a => a.Name).ToArray());
        if (chosenAuthor != "Annuleer")
        {
            Author foundAuthor = authors.Find(a => a.Name == chosenAuthor);
            List<Book> foundBooks = Books.Where(b => b.AuthorId == foundAuthor.Id).ToList();
            BookView.ItemsSource = foundBooks;
        }
        else
        {
            return;
        }
    }
}