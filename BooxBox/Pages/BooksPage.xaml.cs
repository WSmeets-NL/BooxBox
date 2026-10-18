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

    public void SortAlphabetically(Object sendeer, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void SearchBook(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void ToBookDetails(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void FilterBooks(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}