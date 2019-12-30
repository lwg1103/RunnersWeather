using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Location
{
    public class LocationsProvider
    {
        public static List<LocationItem> GetSupportedLocations()
        {
            List<LocationItem> locations = new List<LocationItem>();

            locations.Add(new LocationItem { Name = "Wrocław, Piękna", Lattitude = 51.08613f, Longitude = 17.05629f });
            locations.Add(new LocationItem { Name = "Wrocław, Armi Krajowej 6b", Lattitude = 51.08393f, Longitude = 17.03901f });
            locations.Add(new LocationItem { Name = "Wrocław, Spiska", Lattitude = 51.07442f, Longitude = 17.026901f });
            locations.Add(new LocationItem { Name = "Wrocław, Klecina", Lattitude = 51.07243f, Longitude = 16.96595f });
            locations.Add(new LocationItem { Name = "Wrocław, Fiołkowa", Lattitude = 51.09364f, Longitude = 16.97707f });
            locations.Add(new LocationItem { Name = "Warszawa", Lattitude = 52.22935f, Longitude = 21.01219f });

            return locations;
        }
    }
}
