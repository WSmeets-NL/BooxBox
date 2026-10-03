namespace BooxBox.Pages;
using BooxBox.Models;

public partial class CollectionsPage : ContentPage
{
	public IEnumerable<BookCollection> BookCollections { get; set; }

	public CollectionsPage()
	{
		InitializeComponent();
        BookCollections = new List<BookCollection>
            {
            new BookCollection("Geleende boeken", "Boeken die ik momenteel geleend heb van iemand anders."),
            new BookCollection("Kijk naar links", "Boeken waarbij het personage op de kaft naar links kijkt."),
            new BookCollection("In Uganda", "Boeken waarbij het verhaal zich afspeelt in Uganda")
            };

        BindingContext = this;
    }
}