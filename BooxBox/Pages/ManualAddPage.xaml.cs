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

	public List<Author> Authors;
	public List<Illustrator> Illustrators;
	public List<Language> Languages;
	public ManualAddPage(AuthorService authorService, BookService bookservice, IllustratorService illustratorService, LanguageService languageService)
	{
		InitializeComponent();
		_authorService = authorService;
		_bookService = bookservice;
		_illustratorService = illustratorService;
		_languageService = languageService;
		getAuthors();
		getIllustrators();
		getLanguages();
    }

	private async void getAuthors()
	{
        Authors = await _authorService.GetAllAuthorsAsync();
        AuthorPicker.ItemsSource = Authors;
    }

    private async void getIllustrators()
    {
        Illustrators = await _illustratorService.GetAllIllustratorsAsync();
		IllustratorPicker.ItemsSource = Illustrators;
    }


    private async void getLanguages()
	{
		Languages = await _languageService.GetAllLanguages();
        LanguagePicker.ItemsSource = Languages;
    }



	public async void AddNewAuthor(Object sender, EventArgs e)
	{
		string authorName = await DisplayPromptAsync("Nieuwe auteur", "Voeg hieronder de naam van de auteur in.", "Auteur toevoegen", "Annuleer");
		Author newAuthor = new Author
		{
			Name = authorName,
		};
		_authorService.AddAuthor(newAuthor);
		getAuthors();
	}

    public async void AddNewIllustrator(Object sender, EventArgs e)
    {
        string illustratorName = await DisplayPromptAsync("Nieuwe Illustrator", "Voeg hieronder de naam van de illustrator in.", "Illustrator toevoegen", "Annuleer");
        Illustrator newIllustrator = new Illustrator
        {
            Name = illustratorName,
        };
        _illustratorService.AddIllustrator(newIllustrator);
        getIllustrators();
    }

    public async void AddNewLanguage(Object sender, EventArgs e)
    {
        string languageName = await DisplayPromptAsync("Nieuwe Taal", "Voeg hieronder de taal in.", "Taal toevoegen", "Annuleer");
        Language newLanguage = new Language
        {
            Description = languageName,
        };
        _languageService.AddLanguage(newLanguage);
        getLanguages();
    }

    public async void OnClickSubmit(object sender, EventArgs e)
    {
        bool allFieldsFilled = ConfirmInputs();
        {
            if (allFieldsFilled)
            {
                await CreateNewBook();
            }
            else
            {
                DisplayAlertAsync("Foutmelding", "Niet alle velden zijn ingevuld.\nProbeer alstublieft opnieuw", "Bevestig");
            }
        }
    }

    public bool ConfirmInputs()
    {
        if(string.IsNullOrWhiteSpace(TitleEntry.Text) == true || AuthorPicker.SelectedItem == null || LanguagePicker.SelectedItem == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public async Task CreateNewBook()
	{
        Author selectedAuthor = (Author)AuthorPicker.SelectedItem;
        Language selectedLanguage = (Language)LanguagePicker.SelectedItem;

        Book newBook = new Book()
        {
            Title = TitleEntry.Text,
            AuthorId = selectedAuthor.Id,
            LanguageId = selectedLanguage.Id
        };

        if (IllustratorPicker.SelectedItem != null)
        {
            Illustrator selectedIllustrator = (Illustrator)IllustratorPicker.SelectedItem;
            newBook.IllustratorId = selectedIllustrator.Id;
        }
        await _bookService.AddBook(newBook);
		await DisplayAlertAsync("Succes", $"\"{newBook.Title}\" is toegevoegd", "Terug naar 'Mijn boeken'");
        await Shell.Current.GoToAsync(nameof(BooksPage));
    }

}
