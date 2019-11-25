using System.Threading.Tasks;

using DemoDS.Models;
using DemoDS.Interfaces;

using Xamarin.Forms;

namespace DemoDS.Services
{
    public static class LocationService
    {
        public static async Task<LocationAddress> GetAddress(double latitude, double longitude)
        {
            var service = DependencyService.Get<IReverseGeocode>();
            var location = await service.GetLocationAddress(latitude, longitude);
            return location;
        }
    }
}
