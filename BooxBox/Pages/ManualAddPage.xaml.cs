namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Data;

public partial class ManualAddPage : ContentPage
{
	public ManualAddPage()
	{
		InitializeComponent();
	}

	public async void OnClickSubmit(object sender, EventArgs e)
	{
		Book NewBook = CreateNewBook();
		await BooxBoxDbWrapper.AddBookAsync(NewBook);
	}

	public Book CreateNewBook()
	{
		return new Book
		{
			Title = TitleEntry.Text,
			Author = AuthorEntry.Text,
			Publisher = PublisherEntry.Text,
			ISBN = Convert.ToInt32(ISBNEntry.Text),
			PublishingDate = PublicationDateEntry.Date
		};

	}
}