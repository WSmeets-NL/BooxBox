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
    private readonly BookService _bookService;
    private readonly BookCollectionService _collectionService;
    private readonly BookLocationService _locationService;
    private readonly IllustratorService _illustratorService;
	private readonly LanguageService _languageService;


	public List<Author> Authors;
    public List<BookCollection> Collections;
    public List<BookLocation> Locations;
    public List<Illustrator> Illustrators;
	public List<Language> Languages;

	public ManualAddPage(AuthorService authorService, BookService bookservice, BookCollectionService collectionService, BookLocationService locationService, IllustratorService illustratorService, LanguageService languageService)
	{
		InitializeComponent();
		_authorService = authorService;
		_bookService = bookservice;
        _collectionService = collectionService;
		_illustratorService = illustratorService;
		_languageService = languageService;
        _locationService = locationService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await GetAuthors();
        await GetCollections();
        await GetIllustrators();
        await GetLanguages();
        await GetLocations();
    }

	private async Task GetAuthors()
	{
        Authors = await _authorService.GetAllAuthorsAsync();
        AuthorPicker.ItemsSource = Authors;
    }

    private async Task GetCollections()
    {
        Collections = await _collectionService.GetAllBookCollectionsAsync();
        CollectionPicker.ItemsSource = Collections;
    }

    private async Task GetIllustrators()
    {
        Illustrators = await _illustratorService.GetAllIllustratorsAsync();
		IllustratorPicker.ItemsSource = Illustrators;
    }


    private async Task GetLanguages()
	{
		Languages = await _languageService.GetAllLanguages();
        LanguagePicker.ItemsSource = Languages;
    }

    private async Task GetLocations()
    {
        Locations = await _locationService.GetAllBookLocationsAsync();
        LocationPicker.ItemsSource = Locations;
    }

    //Add-button methods
	public async void AddNewAuthor(object sender, EventArgs e)
	{
		string authorName = await DisplayPromptAsync("Nieuwe Auteur", "Voeg hieronder de naam van de auteur in.", "Auteur toevoegen", "Annuleer");
		Author newAuthor = new Author
		{
			Name = authorName,
		};
		await _authorService.AddAuthor(newAuthor);
		await GetAuthors();
	}

    public async void AddNewCollection(object sender, EventArgs e)
    {
        string collectionName = await DisplayPromptAsync("Nieuwe Verzameling", "Voeg hieronder de naam van de verzameling in.", "Verzameling toevoegen", "Annuleer");
        BookCollection newCollection = new BookCollection
        {
            Name = collectionName,
        };
        await _collectionService.AddBookCollection(newCollection);
        await GetCollections();
    }

    public async void AddNewIllustrator(object sender, EventArgs e)
    {
        string illustratorName = await DisplayPromptAsync("Nieuwe Illustrator", "Voeg hieronder de naam van de illustrator in.", "Illustrator toevoegen", "Annuleer");
        Illustrator newIllustrator = new Illustrator
        {
            Name = illustratorName,
        };
        await _illustratorService.AddIllustrator(newIllustrator);
        await GetIllustrators();
    }

    public async void AddNewLanguage(object sender, EventArgs e)
    {
        string languageName = await DisplayPromptAsync("Nieuwe Taal", "Voeg hieronder de taal in.", "Taal toevoegen", "Annuleer");
        Language newLanguage = new Language
        {
            Description = languageName,
        };
        await _languageService.AddLanguage(newLanguage);
        await GetLanguages();
    }

    public async void AddNewLocation(object sender, EventArgs e)
    {
        string locationName = await DisplayPromptAsync("Nieuwe Locatie", "Voeg hieronder de naam van de locatie in.", "Locatie toevoegen", "Annuleer");
        BookLocation newLocation = new BookLocation
        {
            Name = locationName,
        };
        await _locationService.AddBookLocation(newLocation);
        await GetLocations();
    }


    //Searchbar-methods
    private void FilterAuthors(object sender, EventArgs e)
    {
        List<Author> filteredAuthors = Authors.Where(a => a.Name.Contains(AuthorSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        AuthorPicker.ItemsSource = filteredAuthors;
    }

    private void FilterIllustrators(object sender, EventArgs e)
    {
        List<Illustrator> filteredIllustrators = Illustrators.Where(i => i.Name.Contains(IllustratorSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        IllustratorPicker.ItemsSource = filteredIllustrators;
    }

    private void FilterLocations(object sender, EventArgs e)
    {
        List<BookLocation> filteredLocations = Locations.Where(l => l.Name.Contains(LocationSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        LocationPicker.ItemsSource = filteredLocations;
    }

    private void FilterCollections(object sender, EventArgs e)
    {
        List<BookCollection> filteredCollections = Collections.Where(c => c.Name.Contains(AuthorSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        CollectionPicker.ItemsSource = filteredCollections;
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
                await DisplayAlertAsync("Foutmelding", "Niet alle velden zijn ingevuld.\nProbeer alstublieft opnieuw", "Bevestig");
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


        if (LocationPicker.SelectedItem != null)
        {
            BookLocation selectedLocation = (BookLocation)LocationPicker.SelectedItem;
            newBook.BookLocationId = selectedLocation.Id;
        }

        if (CollectionPicker.SelectedItem != null)
        {
            BookCollection selectedCollection = (BookCollection)CollectionPicker.SelectedItem;
            await _collectionService.AssignBookToCollection(newBook.Id, selectedCollection.Id);
        }

        await _bookService.AddBook(newBook);
		await DisplayAlertAsync("Succes", $"\"{newBook.Title}\" is toegevoegd", "Terug naar 'Mijn boeken'");
        await Shell.Current.GoToAsync(nameof(BooksPage));
    }

}
