namespace BooxBox.Pages;
using BooxBox.Models;
public partial class BookcasePage : ContentPage
{
	public IEnumerable<Bookcase> Bookcases { get; set; }
	public BookcasePage()
	{
        InitializeComponent();
        Bookcases= new List<Bookcase>
            {
            new Bookcase("Eikenhouten kast 1", "Woonkamer links van de TV-meubel"),
            new Bookcase("Eikenhouten kast 2", "Woonkamer rechts van de TV-meubel"),
            new Bookcase("Kunststof IKEA doos met het cijfer 1 geschreven op de zijkant", "Zolder")

            };

        BindingContext = this;
    }
}
