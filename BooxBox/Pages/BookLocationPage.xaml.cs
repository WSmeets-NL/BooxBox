namespace BooxBox.Pages;
using BooxBox.Models;
using BooxBox.Services;
using System.Net;

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
            GetAllLocations();
        }

        else
        {
            DisplayAlertAsync("Foutmelding", "Je hebt geen naam ingegeven.", "Terug");
        }
        
    }

    public void SortAlphabetically(Object sender, EventArgs e)
    {
        Locations = Locations.OrderBy(l => l.Name, StringComparer.OrdinalIgnoreCase).ToList();
        BookLocationView.ItemsSource = Locations;
    }

    public void SearchLocation(Object sender, EventArgs e)
    {
        List<BookLocation> filteredLocations = Locations.Where(l => l.Name.Contains(LocationSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        BookLocationView.ItemsSource = filteredLocations;
    }

    public async void ToLocationDetails(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int locationId = (int)button.BindingContext;
        await Shell.Current.GoToAsync($"BookLocationDetailsPage?id={locationId}");
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
            GetAllLocations();
        }

        else
        {
            await DisplayAlertAsync("Locatie behouden", "De locatie blijft behouden", "Terug");
        }
    }

    
}
