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

    public void SortAlphabetically(Object sendeer, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void SearchBook(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void ToBookDetails(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
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