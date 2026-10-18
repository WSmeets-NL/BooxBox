using BooxBox.Data;
using BooxBox.Models;
using System.Diagnostics;
namespace BooxBox.Pages;
public partial class BooksPage : ContentPage
{
    public readonly BooxBoxDbWrapper _database;
	public List<Book> Books { get; set;  }

	public BooksPage(BooxBoxDbWrapper database)
	{
        InitializeComponent();
        _database = database;
        GetAllBooks();
    }

    public async void GetAllBooks()
    {
        Books = await _database.GetAllBooksAsync();
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