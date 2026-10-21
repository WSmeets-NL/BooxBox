namespace BooxBox.Pages;
using BooxBox.Data;
using BooxBox.Models;
using BooxBox.Services;


[QueryProperty(nameof(BookId), "id")]
public partial class BookDetailsPage : ContentPage
{
	private readonly BooxBoxDbWrapper _wrapper;
    private readonly AuthorService _authorService;


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
	public String BookLanguage { get; set; }

	public BookDetailsPage(BooxBoxDbWrapper wrapper, AuthorService authorService)
	{
        InitializeComponent();
		_wrapper = wrapper;
		_authorService = authorService;
	}

	public async Task GetChosenBook(int id)
	{
		ChosenBook = await _wrapper.GetBookById(id);
		BookAuthor = await _authorService.GetAuthorName(ChosenBook.AuthorId);
		BindingContext = ChosenBook;

	}

}