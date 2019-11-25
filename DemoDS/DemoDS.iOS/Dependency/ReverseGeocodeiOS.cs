using System.Linq;
using System.Threading.Tasks;

using Contacts;
using CoreLocation;

using DemoDS.Models;
using DemoDS.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DemoDS.iOS.Dependency.ReverseGeocodeiOS))]
namespace DemoDS.iOS.Dependency
{
    public class ReverseGeocodeiOS : IReverseGeocode
    {
        public async Task<LocationAddress>GetLocationAddress(double latitude, double longitude)
        {
            var geoCoder = new CLGeocoder();
            var place = new CLLocation(latitude, longitude);
            var placemarks = await geoCoder.ReverseGeocodeLocationAsync(place);

            if (placemarks.Any())
            {
                var placeMark = placemarks.First();

                var location = new LocationAddress()
                {
                    Name = placeMark.Name,
                    City = placeMark.Locality,
                    Province = placeMark.AdministrativeArea,
                    ZipCode = placeMark.PostalCode,
                    Country = $"{placeMark.Country} ({placeMark.IsoCountryCode})",
                    Address = new CNPostalAddressFormatter().StringFor(placeMark.PostalAddress)
                };

                return location;
            }

            return null;
        }
    }
}