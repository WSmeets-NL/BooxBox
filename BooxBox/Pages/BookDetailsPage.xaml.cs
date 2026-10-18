namespace BooxBox.Pages;
using BooxBox.Data;
using BooxBox.Models;
using Microsoft.EntityFrameworkCore.Storage;

public partial class BookDetailsPage : ContentPage
{
	private readonly BooxBoxDbWrapper _database;
	public Book chosenBook;

	public BookDetailsPage(BooxBoxDbWrapper database, int bookId)
	{
		InitializeComponent();
		_database = database;
		GetChosenBook(bookId);
	}

	public async void GetChosenBook(int id)
	{
		chosenBook = await _database.GetBookById(id);
	}

}