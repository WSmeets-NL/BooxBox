namespace BooxBox.Pages;
using BooxBox.Data;
using BooxBox.Models;
using Microsoft.EntityFrameworkCore.Storage;

[QueryProperty(nameof(BookId), "id")]
public partial class BookDetailsPage : ContentPage
{
	private readonly BooxBoxDbWrapper _database;

	public Book ChosenBook { get; private set; }
	public int BookId
	{

		set 
		{
			GetChosenBook(value);
		}
		
	}

	public BookDetailsPage(BooxBoxDbWrapper database)
	{
		InitializeComponent();
		_database = database;
	}

	public async Task GetChosenBook(int id)
	{
		ChosenBook = await _database.GetBookById(id);
	}

}