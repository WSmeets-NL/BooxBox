namespace BooxBox.Pages;
using BooxBox.Data;
using BooxBox.Models;
using BooxBox.Services;


[QueryProperty(nameof(BookId), "id")]
public partial class BookDetailsPage : ContentPage
{
	private readonly BooxBoxDbWrapper _wrapper;
    private readonly AuthorService _authorService;
	private readonly BookLocationService _locationService;
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
	public String? BookIllustrator { get; set; }
	public String BookLocation { get; set; } = "Geen locatie toegewezen.";
	public String BookLanguage { get; set; }

	public BookDetailsPage(BooxBoxDbWrapper wrapper, AuthorService authorService, BookLocationService locationService, LanguageService languageService)
	{
        InitializeComponent();
		_wrapper = wrapper;
		_authorService = authorService;
		_locationService = locationService;
		_languageService = languageService;
	}

	public async Task GetChosenBook(int id)
	{
		ChosenBook = await _wrapper.GetBookById(id);
		BookAuthor = await _authorService.GetAuthorName(ChosenBook.AuthorId);
		BookLanguage = await _languageService.GetLanguageDescription(ChosenBook.LanguageId);
		BindingContext = this;
	}

}