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
	private readonly IllustratorService _illustratorService;
	private readonly LanguageService _languageService;
	private readonly BookService _bookService;

	public List<Language> languages;
	public ManualAddPage(AuthorService authorService, BookService bookservice, IllustratorService illustratorService, LanguageService languageService)
	{
		InitializeComponent();
		_authorService = authorService;
		_bookService = bookservice;
		_illustratorService = illustratorService;
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
		bool allFieldsFilled = ConfirmInputs();
		{
			if (allFieldsFilled)
			{
				CreateNewBook();
			}
			else
			{
				DisplayAlertAsync("Foutmelding", "Niet alle velden zijn ingevuld.\nProbeer alstublieft opnieuw", "Bevestig");
			}
		}
	}
		


	public bool ConfirmInputs()
	{
		if (String.IsNullOrEmpty(TitleEntry.Text) == false && String.IsNullOrEmpty(AuthorEntry.Text) == false && LanguagePicker.SelectedItem == null)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public async void CreateNewBook()
	{
        Author author = await _authorService.GetAuthorByName(AuthorEntry.Text);
        if (author == null)
        {
            Author newAuthor = new Author()
            {
                Name = AuthorEntry.Text,
            };
            _authorService.AddAuthor(newAuthor);
            author = await _authorService.GetAuthorByName(newAuthor.Name);
        }

        Illustrator illustrator = null;
        if (IllustratorEntry != null)
        {

            illustrator = await _illustratorService.GetIllustratorByName(IllustratorEntry.Text);
        }

        Language selectedLanguage = (Language)LanguagePicker.SelectedItem;
        Book NewBook = new Book()
        {
            Title = TitleEntry.Text,
            AuthorId = author.Id,
            LanguageId = selectedLanguage.Id
        };

        if (illustrator != null)
        {
            NewBook.IllustratorId = illustrator.Id;
        }
        _bookService.AddBook(NewBook);
        await Shell.Current.GoToAsync(nameof(BooksPage));
    }
}
