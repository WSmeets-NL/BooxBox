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
		Author author = await _database.GetAuthorByName(AuthorEntry.Text);
		Publisher publisher = await _database.GetPublisherByName(PublisherEntry.Text);
		Language language = await _database.GetLanguageByDescription(LanguageEntry.Text);
		Illustrator? illustrator;


		Book NewBook = new Book()
		{
			Title = TitleEntry.Text,
			AuthorId = author.Id,
			PublisherId = publisher.Id,
            LanguageId = language.Id,
            ISBN = ISBNEntry.Text,
			PublishingDate = PublicationDateEntry.Date
		};

        if (IllustratorEntry != null)
        {
            illustrator = await _database.GetIllustratorByName(IllustratorEntry.Text);
			NewBook.IllustratorId = illustrator.Id;
        }

        await _database.AddBookAsync(NewBook);
        await Shell.Current.GoToAsync(nameof(BooksPage));
    }

}