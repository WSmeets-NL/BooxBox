using BooxBox.Models;
namespace BooxBox.Pages;
public partial class BooksPage : ContentPage
{
	public IEnumerable<Book> Books { get; set;  }

	public BooksPage()
	{
		InitializeComponent();
		Books = new List<Book>
			{
			new Book("Harry Potter en de steen der wijzen", 0, 0, "1234567890123"),
			new Book("Harry Potter en de geheime kamer", 0, 0, "22345678901234"),
			new Book("Harry Potter en de gevangene van Azkaban", 0, 0, "3456789012345")
			};

		BindingContext = this;
    }
}