namespace BooxBox.Pages;
using BooxBox.Data;
using BooxBox.Models;
using Microsoft.EntityFrameworkCore.Storage;

[QueryProperty(nameof(BookId), "id")]
public partial class BookDetailsPage : ContentPage
{
	private readonly BooxBoxDbWrapper _database;

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

	public BookDetailsPage(BooxBoxDbWrapper database)
	{
		InitializeComponent();
		_database = database;
	}

	public async Task GetChosenBook(int id)
	{
		ChosenBook = await _database.GetBookById(id);
		BookAuthor = await _database.GetAuthorName(ChosenBook.AuthorId);
		BookIllustrator = await _database.GetIllustratorName(ChosenBook.IllustratorId);
		BookLanguage = await _database.GetLanguageName(ChosenBook.LanguageId);
		BindingContext = ChosenBook;

	}

}S