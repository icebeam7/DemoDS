using DemoDS.Models;
using System.Threading.Tasks;

namespace DemoDS.Interfaces
{
    public interface IReverseGeocode
    {
        Task<LocationAddress> GetLocationAddress(double latitude, double longitude);
    }
}
