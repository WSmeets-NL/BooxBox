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

    }

}
