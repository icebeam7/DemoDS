using System.Windows.Input;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;

using DemoDS.Models;
using DemoDS.Services;

namespace DemoDS.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        private LocationAddress _locationAddress;

        public LocationAddress LocationAddress
        {
            get { return _locationAddress; }
            set { _locationAddress = value; OnPropertyChanged(); }
        }

        public ICommand GetAddressCommand { private set; get; }

        public LocationViewModel()
        {
            GetAddressCommand = new Command(async () => await GetAddress());
        }

        async Task GetAddress()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var gps = await Geolocation.GetLocationAsync(request);

            if (gps != null)
                LocationAddress = await LocationService.GetAddress(gps.Latitude, gps.Longitude);
        }
    }
}
