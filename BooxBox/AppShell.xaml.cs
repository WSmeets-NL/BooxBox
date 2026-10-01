using BooxBox.Pages;
namespace BooxBox
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddBookForm), typeof(AddBookForm));
            Routing.RegisterRoute(nameof(FindBook), typeof(FindBook));
            Routing.RegisterRoute(nameof(ScanBook), typeof(ScanBook));
        }
    }
}
