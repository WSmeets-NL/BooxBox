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
            new Book(2005,  "Dune", "J.K. Rowling", "Penguin", 200)
			};

		BindingContext = this;
    }
}