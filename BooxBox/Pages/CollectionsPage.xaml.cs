namespace BooxBox.Pages;
using BooxBox.Models;

public partial class CollectionsPage : ContentPage
{

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

    public async void AddCollection(Object sender, EventArgs e)
    {
        String collectionName = await DisplayPromptAsync("Maak een nieuwe verzameling aan:", "Vul hieronder de naam van je verzameling in:", "Verzameling Aanmaken", "Annuleren", "nieuwe verzameling");
        if (String.IsNullOrWhiteSpace(collectionName) == false)
        {
            BookLocation newCollection = new BookLocation()
            {
                Name = collectionName,
            };
            await _collectionService.AddBookCollection(newCollection);
            DisplayAlertAsync("Succes", $"Locatie \"{newCollectoin.Name}\" is toegevoegd.", "Sluit");
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