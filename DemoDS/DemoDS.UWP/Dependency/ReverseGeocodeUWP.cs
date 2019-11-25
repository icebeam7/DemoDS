using System;
using System.Linq;
using System.Threading.Tasks;

using Windows.Services.Maps;
using Windows.Devices.Geolocation;

using DemoDS.Models;
using DemoDS.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DemoDS.UWP.Dependency.ReverseGeocodeUWP))]
namespace DemoDS.UWP.Dependency
{
    public class ReverseGeocodeUWP : IReverseGeocode
    {
        public async Task<LocationAddress> GetLocationAddress(double latitude, double longitude)
        {
            MapService.ServiceToken = "";

            var geoPosition = new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            var geoPoint = new Geopoint(geoPosition);
            var place = await MapLocationFinder.FindLocationsAtAsync(geoPoint);
            
            if (place.Status == MapLocationFinderStatus.Success)
            {
                var mapLocation = place.Locations.First();
                var mapAddress = mapLocation.Address;

                var location = new LocationAddress()
                {
                    Name = mapLocation.DisplayName,
                    City = mapAddress.Town,
                    Province = mapAddress.Region,
                    ZipCode = mapAddress.PostCode,
                    Country = $"{mapAddress.Country} ({mapAddress.CountryCode})",
                    Address = $"{mapAddress.Street} {mapAddress.StreetNumber}",
                };

                return location;
            }

            return null;
        }
    }
}
