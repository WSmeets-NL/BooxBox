namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Data;
using System.Diagnostics;
using BooxBox.Services;
using BooxBox.Interfaces;
using System.Reflection.Metadata.Ecma335;

public partial class ManualAddPage : ContentPage
{
	private readonly AuthorService _authorService;
	private readonly LanguageService _languageService;
	private readonly BookService _bookService;

	public List<Language> languages;
	public ManualAddPage(AuthorService authorService, BookService bookservice, LanguageService languageService)
	{
		InitializeComponent();
		_authorService = authorService;
		_bookService = bookservice;
		_languageService = languageService;
		getLanguages();
    }

	private async void getLanguages()
	{
		languages = await _languageService.GetAllLanguages();
		Debug.WriteLine($"Aantal talen = {languages.Count}");
        LanguagePicker.ItemsSource = languages;
    }

	public async void OnClickSubmit(object sender, EventArgs e)
	{
		Author author = await _authorService.GetAuthorByName(AuthorEntry.Text);
		if(author ==null)
		{
			Author newAuthor = new Author()
			{
				Name = AuthorEntry.Text,
			};
			_authorService.AddAuthor(newAuthor);
			author = await _authorService.GetAuthorByName(TitleEntry.Text);
		}

		//Illustrator illustrator = await _database.GetIllustratorByName(IllustratorEntry.Text); //No services, rpos and interfaces are created yet,
		Language selectedLanguage = (Language)LanguagePicker.SelectedItem;


		Book NewBook = new Book()
		{
			Title = TitleEntry.Text,
			AuthorId = author.Id,
			//IllustratorId = illustrator.Id,
            LanguageId = selectedLanguage.Id,
		};

   //     if (IllustratorEntry != null)
   //     {
   //         illustrator = await _database.GetIllustratorByName(IllustratorEntry.Text);
			//NewBook.IllustratorId = illustrator.Id;
   //     }

        _bookService.AddBook(NewBook);
        await Shell.Current.GoToAsync(nameof(BooksPage));
    }

}