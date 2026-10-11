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
        Book NewBook = new Book()
            {
                Title = TitleEntry.Text,
				AuthorId = _database.GetAuthorByName(AuthorEntry.Text).Id,
				PublisherId = _database.GetPublisherByName(PublisherEntry.Text).Id,
				ISBN = ISBNEntry.Text,
				PublishingDate = PublicationDateEntry.Date
			};
        await _database.AddBookAsync(NewBook);
	}

}