namespace BooxBox.Pages;
using BooxBox.Models;
public partial class BookLocationPage : ContentPage
{
    public IEnumerable<BookLocation> Locations { get; set; }
    public BookLocationPage()
    {
        InitializeComponent();
        Locations = new List<BookLocation>
            {
            new BookLocation("Eikenhouten kast 1", "Woonkamer links van de TV-meubel"),
            new BookLocation("Eikenhouten kast 2", "Woonkamer rechts van de TV-meubel"),
            new BookLocation("Kunststof IKEA doos met het cijfer 1 geschreven op de zijkant", "Zolder")

            };

        BindingContext = this;

    }

    public void AddLocation(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void SortAlphabetically(Object sendeer, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void SearchLocation(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void ToLocationDetails(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void DeleteLocation(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
