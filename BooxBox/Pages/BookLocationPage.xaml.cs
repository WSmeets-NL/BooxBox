namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Services;

public partial class BookLocationPage : ContentPage
{
    private readonly BookLocationService _locationService;
    public List<BookLocation> Locations { get; set; }
    public BookLocationPage(BookLocationService locationService)
    {
        InitializeComponent();
        _locationService = locationService;
        GetAllLocations();
    }

    public async void GetAllLocations()
    {
        Locations = await _locationService.GetAllBookLocationsAsync();
        BookLocationView.ItemsSource = Locations;
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

    public async void DeleteLocation(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int LocationId = (int)button.BindingContext;
        string deletePrompt = await DisplayPromptAsync("Weet je zeker dat je deze locatie wil verwijderen?", "Typ \'verwijder\' om deze locatie te verwijderen", "verwijder", "annuleer");
        if (deletePrompt == "verwijder")
        {
            await DisplayAlertAsync("Verwijderd", "We hebben deze locatie verwijderd", "Terug");
            await _locationService.DeleteBookLocationById(LocationId);
        }

        else
        {
            await DisplayAlertAsync("Locatie behouden", "De locatie blijft behouden", "Terug");
        }
    }
}
