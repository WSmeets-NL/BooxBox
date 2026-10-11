namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Data;
using Microsoft.EntityFrameworkCore.Storage;

public partial class ManualAddPage : ContentPage
{
	public readonly BooxBoxDbWrapper _database;
	public ManualAddPage(BooxBoxDbWrapper database)
	{
		InitializeComponent();
		_database = database;
	}

	public async Task OnClickSubmit(object sender, EventArgs e)
	{
		Book NewBook = CreateNewBook();
        await _database.AddBookAsync(NewBook);
	}

	public async Task<Book> CreateNewBook()
	{
		return new Book
		{
			Title = TitleEntry.Text,
			AuthorId = await _database.
			PublisherId = PublisherEntry.Int,
			ISBN = ISBNEntry.Text,
			PublishingDate = PublicationDateEntry.Date
		};

	}
}