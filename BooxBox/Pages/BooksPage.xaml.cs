using BooxBox.Models;
using BooxBox.Services;
using System.Diagnostics;
namespace BooxBox.Pages;
public partial class BooksPage : ContentPage
{
    public readonly BookService _bookService;
	public List<Book> Books { get; set;  }

	public BooksPage(BookService bookService)
	{
        InitializeComponent();
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
        throw new NotImplementedException();
    }

    public void SearchBook(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public async void ToBookDetails(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int bookId = (int)button.BindingContext;
        await Shell.Current.GoToAsync($"BookDetailsPage?id={bookId}");
    }

    public void DeleteBook(Object sender, EventArgs e)
    { 
        throw new NotImplementedException();
    }

    public void FilterBooks(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}