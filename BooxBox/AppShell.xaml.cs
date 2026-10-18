using BooxBox.Pages;
namespace BooxBox
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ManualAddPage), typeof(ManualAddPage));
            Routing.RegisterRoute(nameof(FindBook), typeof(FindBook));
            Routing.RegisterRoute(nameof(ScanBook), typeof(ScanBook));
            Routing.RegisterRoute(nameof(BookDetailsPage), typeof(BookDetailsPage));
        }
    }
}
