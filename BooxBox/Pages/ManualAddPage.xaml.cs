namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Data;
using System.Diagnostics;

public partial class ManualAddPage : ContentPage
{
	public readonly BooxBoxDbWrapper _database;

	public List<Language> languages;
	public ManualAddPage(BooxBoxDbWrapper database)
	{
		InitializeComponent();
		_database = database;
		getLanguages();
    }

	private async void getLanguages()
	{
		languages = await _database.GetAllLanguagesAsync();
		Debug.WriteLine($"Aantal talen = {languages.Count}");
        LanguagePicker.ItemsSource = languages;
    }

	public async void OnClickSubmit(object sender, EventArgs e)
	{
		Author author = await _database.GetAuthorByName(AuthorEntry.Text);
		Publisher publisher = await _database.GetPublisherByName(PublisherEntry.Text);
		Illustrator illustrator = await _database.GetIllustratorByName(IllustratorEntry.Text);
		Language selectedLanguage = (Language)LanguagePicker.SelectedItem;


		Book NewBook = new Book()
		{
			Title = TitleEntry.Text,
			AuthorId = author.Id,
			PublisherId = publisher.Id,
            LanguageId = selectedLanguage.Id,
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