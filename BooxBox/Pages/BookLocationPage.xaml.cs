namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Services;

public partial class BookLocationPage : ContentPage
{
    private readonly BookLocationService _locationService;
    public IEnumerable<BookLocation> Locations { get; set; }
    public BookLocationPage(BookLocationService locationService)
    {
        InitializeComponent();
        _locationService = locationService;
        Locations = new List<BookLocation>
            {
            new BookLocation("Eikenhouten kast 1", "Woonkamer links van de TV-meubel"),
            new BookLocation("Eikenhouten kast 2", "Woonkamer rechts van de TV-meubel"),
            new BookLocation("Kunststof IKEA doos met het cijfer 1 geschreven op de zijkant", "Zolder")

            };

        BindingContext = this;

    }

    public async void AddBookLocation(Object sender, EventArgs e)
    {
        String locationName = await DisplayPromptAsync("Maak een nieuwe locatie aan:", "Vul hieronder de naam van je locatie in:", "Locatie Aanmaken", "Annuleren", "nieuwe locatie");
        if (String.IsNullOrWhiteSpace(locationName) == false)
        {
            BookLocation newLocation = new BookLocation()
            {
                Name = locationName,
            };
            await _locationService.AddBookLocation(newLocation);
            DisplayAlertAsync("Succes", $"Locatie \"{newLocation.Name}\" is toegevoegd.", "Sluit");
        }

        else
        {
            DisplayAlertAsync("Foutmelding", "Je hebt geen naam ingegeven.", "Terug");
        }
        
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
