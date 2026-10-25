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
		if (String.IsNullOrEmpty(TitleEntry.Text) != true || String.IsNullOrEmpty(AuthorEntry.Text) != true || LanguagePicker.SelectedItem != null)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public async Task<Author> FetchAuthor()
	{
        Author? author = await _authorService.GetAuthorByName(AuthorEntry.Text);
        if (author == null)
        {
            Author newAuthor = new Author()
            {
                Name = AuthorEntry.Text,
            };
            _authorService.AddAuthor(newAuthor);
            return author = await _authorService.GetAuthorByName(newAuthor.Name);
        }
		else
		{
			return author;
		}
    }

    public async Task<Illustrator> FetchIllustrator()
    {
        {
            Illustrator? illustrator = await _illustratorService.GetIllustratorByName(IllustratorEntry.Text);
            if (illustrator == null)
            {
                Illustrator newIllustrator = new Illustrator()
                {
                    Name = IllustratorEntry.Text
                };
				await _illustratorService.AddIllustrator(newIllustrator);

                return illustrator = await _illustratorService.GetIllustratorByName(newIllustrator.Name);
            }
			else
			{
				return illustrator;
			}
        }
    }

    public async void CreateNewBook()
	{
		Author author = await FetchAuthor();

		Illustrator illustrator = null;
        if (IllustratorEntry.Text != null)
		{
			illustrator = await FetchIllustrator();
		}
        Language selectedLanguage = (Language)LanguagePicker.SelectedItem;

        Book newBook = new Book()
        {
            Title = TitleEntry.Text,
            AuthorId = author.Id,
            LanguageId = selectedLanguage.Id
        };

        if (illustrator != null)
        {
            newBook.IllustratorId = illustrator.Id;
        }
        _bookService.AddBook(newBook);
		DisplayAlert("Succes", $"\"{newBook.Title}\" is toegevoegd", "Terug naar 'Mijn boeken'");
        await Shell.Current.GoToAsync(nameof(BooksPage));
    }
}
