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
            DisplayAlertAsync("Succes", $"Locatie \"{newCollection.Name}\" is toegevoegd.", "Sluit");
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

    public void DeleteCollection(Object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}