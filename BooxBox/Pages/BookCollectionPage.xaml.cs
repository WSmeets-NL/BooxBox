namespace BooxBox.Pages;

using BooxBox.Interfaces;
using BooxBox.Models;
using BooxBox.Services;

public partial class BookCollectionPage : ContentPage
{
    private readonly BookCollectionService _collectionService;

    public List<BookCollection> BookCollections { get; set; }
    public BookCollectionPage(BookCollectionService collectionService)
    {
        InitializeComponent();
        _collectionService = collectionService;
        GetAllCollections();
    }

    public async void GetAllCollections()
    {
        BookCollections = await _collectionService.GetAllBookCollectionsAsync();
        BookCollectionView.ItemsSource = BookCollections;
    }

    public async void AddCollection(Object sender, EventArgs e)
    {
        String collectionName = await DisplayPromptAsync("Maak een nieuwe verzameling aan:", "Vul hieronder de naam van je verzameling in:", "Verzameling Aanmaken", "Annuleren", "nieuwe verzameling");
        if (String.IsNullOrWhiteSpace(collectionName) == false)
        {
            BookCollection newCollection = new BookCollection()
            {
                Name = collectionName,
            };
            await _collectionService.AddBookCollection(newCollection);
            DisplayAlertAsync("Succes", $"Verzameling \"{newCollection.Name}\" is toegevoegd.", "Sluit");
            GetAllCollections();
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

    public void SearchCollection(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public void ToCollectionDetails(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public async void DeleteCollection(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int collectionId = (int)button.BindingContext;
        string deletePrompt = await DisplayPromptAsync("Weet je zeker dat je deze verzameling wil verwijderen?", "Typ \'verwijder\' om deze verzameling te verwijderen", "verwijder", "annuleer");
        if (deletePrompt == "verwijder")
        {
            await DisplayAlertAsync("Verwijderd", "We hebben deze verzameling verwijderd", "Terug");
            await _collectionService.DeleteBookCollectionById(collectionId);
            GetAllCollections ();
        }

        else
        {
            await DisplayAlertAsync("Verzameling behouden", "De verzamelinge blijft behouden", "Terug");
        }
    }
}