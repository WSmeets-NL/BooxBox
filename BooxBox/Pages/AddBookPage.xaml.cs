using BooxBox.Pages;

namespace BooxBox.Pages;

public partial class AddBookPage : ContentPage
{
	public AddBookPage()
	{
		InitializeComponent();
	}

    private async void ManualAddNavigation(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddBookForm));
    }

    private async void SearchAddNavigation(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(FindBook));
    }

    private async void ScanAddNavigation(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ScanBook));
    }
}