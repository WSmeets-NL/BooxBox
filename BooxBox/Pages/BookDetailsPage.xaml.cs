namespace BooxBox.Pages;
using BooxBox.Data;
using BooxBox.Models;
using BooxBox.Services;


[QueryProperty(nameof(BookId), "id")]
public partial class BookDetailsPage : ContentPage
{
    private readonly AuthorService _authorService;
	private readonly BookService _bookService;
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
	public String? BookIllustrator { get; set; } = "Geen illustrator";
	public String BookLocation { get; set; } = "Geen locatie toegewezen.";
	public String BookLanguage { get; set; }

	public BookDetailsPage(AuthorService authorService, BookService bookService, BookLocationService locationService, IllustratorService illustratorService, LanguageService languageService)
	{
        InitializeComponent();
		_authorService = authorService;
		_bookService = bookService;
		_illustratorService = illustratorService;
		_locationService = locationService;
		_languageService = languageService;
	}

	public async Task GetChosenBook(int id)
	{
		ChosenBook = await _bookService.GetBookById(id);
		BookAuthor = await _authorService.GetAuthorName(ChosenBook.AuthorId);
		if (ChosenBook.IllustratorId != null)
		{
			BookIllustrator = await _illustratorService.GetIllustratorName(ChosenBook.IllustratorId.Value);
		}
		BookLanguage = await _languageService.GetLanguageDescription(ChosenBook.LanguageId);
		BindingContext = this;
	}

}