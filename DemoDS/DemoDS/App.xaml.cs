using Xamarin.Forms;

namespace DemoDS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.LocationView();
        }
    }
}
