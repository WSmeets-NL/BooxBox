using BooxBox.Models;
using BooxBox.Data;
namespace BooxBox;
public partial class BooksPage : ContentPage
{
	public IEnumerable<Book>? Books;

	public BooksPage()
	{
		InitializeComponent();
	}
}