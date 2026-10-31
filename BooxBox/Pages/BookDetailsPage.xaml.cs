namespace BooxBox.Pages;
using BooxBox.Data;
using BooxBox.Models;
using BooxBox.Services;


[QueryProperty(nameof(BookId), "id")]
public partial class BookDetailsPage : ContentPage
{
    private readonly AuthorService _authorService;
	private readonly BookService _bookService;
	private readonly BookCollectionService _collectionService;
	private readonly BookLocationService _locationService;
	private readonly IllustratorService _illustratorService;
	private readonly LanguageService _languageService;


    public Book ChosenBook { get; set; }
	public int BookId
	{ 
		set 
		{
			GetChosenBook(value);
		}
		
	}

	public String BookAuthor { get; set; }
	public List<BookCollection> IncludedCollections { get; set; }
	public String? BookIllustrator { get; set; } = "Geen illustrator";
	public String BookLocation { get; set; } = "Geen locatie toegewezen.";
	public String BookLanguage { get; set; }

	public BookDetailsPage(AuthorService authorService, BookService bookService, BookCollectionService collectionService, BookLocationService locationService, IllustratorService illustratorService, LanguageService languageService)
	{
        InitializeComponent();
		_authorService = authorService;
		_bookService = bookService;
		_collectionService = collectionService;
		_illustratorService = illustratorService;
		_locationService = locationService;
		_languageService = languageService;
	}

	public async Task GetChosenBook(int id)
	{
		ChosenBook = await _bookService.GetBookById(id);
		BookAuthor = await _authorService.GetAuthorName(ChosenBook.AuthorId);

		IncludedCollections = await _collectionService.GetCollectionsContainingBookAsync(id);
		BookCollectionView.ItemsSource = IncludedCollections;

		if (ChosenBook.IllustratorId != null)
		{
			BookIllustrator = await _illustratorService.GetIllustratorName(ChosenBook.IllustratorId.Value);
		}
		BookLanguage = await _languageService.GetLanguageDescription(ChosenBook.LanguageId);
		BookLocation = await _locationService.GetLocationName(ChosenBook.BookLocationId);
		BindingContext = this;
	}

	public async void ChangeBookLocation(Object sender, EventArgs e)
	{
		List<BookLocation> allLocations = await _locationService.GetAllBookLocationsAsync();
		string chosenLocationName = await DisplayActionSheetAsync("Kies een locatie", "Annuleer", null, allLocations.Select(l => l.Name).ToArray());
		
		if (chosenLocationName != "Annuleer")
		{
            BookLocation chosenLocation = allLocations.Find(b => b.Name == chosenLocationName);
            ChosenBook.BookLocationId = chosenLocation.Id;
            _bookService.UpdateBook(ChosenBook);
            await DisplayAlertAsync("Succes", "Locatie gewijzigd", "ok");
        }

	}

	public async void AddToCollection(object sender, EventArgs e)
	{
		List<BookCollection> allCollections = await _collectionService.GetAllBookCollectionsAsync();
		string chosenCollectionName = await DisplayActionSheetAsync("Kies een verzameling", "Annuleer", null, allCollections.Select(c => c.Name).ToArray());

        if (chosenCollectionName != "Annuleer")
        {
			BookCollection chosenCollection = allCollections.Find(c => c.Name == chosenCollectionName);

            await _collectionService.AssignBookToCollection(ChosenBook.Id, chosenCollection.Id);
            await DisplayAlertAsync("Succes", "Nieuwe verzameling toegekend", "ok");

			IncludedCollections = await _collectionService.GetCollectionsContainingBookAsync(ChosenBook.Id);
			CollectionView.ItemsSource = IncludedCollections;
        }
    }
}