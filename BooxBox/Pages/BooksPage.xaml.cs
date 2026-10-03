using BooxBox.Models;
namespace BooxBox;
public partial class BooksPage : ContentPage
{
	public IEnumerable<Book> Books { get; set;  }

	public BooksPage()
	{
		InitializeComponent();
		Books = new List<Book>
			{
			new Book(2005,  "Harry Potter en de steen der wijzen", "J.K. Rowling", "Penguin", 200),
			new Book(1993, "Lord of the Rings", "J.R. Tolkien", "The Shire", 400),
			new Book(1970, "De Helaasheid der dingen", "Dimitri Verhulst", "Uitgeverij Contact", 150)
			};

		BindingContext = this;
    }
}