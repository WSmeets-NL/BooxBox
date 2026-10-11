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

	public async void OnClickSubmit(object sender, EventArgs e)
	{
		Author author = await _database.GetAuthorByName(AuthorEntry.Text);
		Publisher publisher = await _database.GetPublisherByName(PublisherEntry.Text);

		Book NewBook = new Book()
		{
			Title = TitleEntry.Text,
			AuthorId = author.Id,
			PublisherId = publisher.Id,
			ISBN = ISBNEntry.Text,
			PublishingDate = PublicationDateEntry.Date
		};

        await _database.AddBookAsync(NewBook);
	}

}