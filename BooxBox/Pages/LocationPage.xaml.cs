namespace BooxBox.Pages;
using BooxBox.Models;
public partial class LocationPage : ContentPage
{
    public IEnumerable<Models.Location> Locations { get; set; }
    public LocationPage()
    {
        InitializeComponent();
        Locations = new List<Models.Location>
            {
            new Location("Eikenhouten kast 1", "Woonkamer links van de TV-meubel"),
            new Location("Eikenhouten kast 2", "Woonkamer rechts van de TV-meubel"),
            new Location("Kunststof IKEA doos met het cijfer 1 geschreven op de zijkant", "Zolder")

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
