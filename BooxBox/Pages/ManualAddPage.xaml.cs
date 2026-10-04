namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Data;

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
		Book NewBook = CreateNewBook();
        await _database.AddBookAsync(NewBook);
	}

	public Book CreateNewBook()
	{
		return new Book
		{
			Title = TitleEntry.Text,
			Author = AuthorEntry.Text,
			Publisher = PublisherEntry.Text,
			ISBN = ISBNEntry.Text,
			PublicationDate = PublicationDateEntry.Date
		};
	}
}