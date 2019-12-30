using Microsoft.VisualStudio.TestTools.UnitTesting;
using RunnersWeather.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Location.Tests
{
    [TestClass()]
    public class LocationsProviderTests
    {
        [TestMethod()]
        public void GetSupportedLocationsReturnsLocationList()
        {
            var list = LocationsProvider.GetSupportedLocations();
            Assert.IsInstanceOfType(list, typeof(List<LocationItem>));
        }
        [TestMethod()]
        public void GetSupportedLocationsReturnsLocationsConvertableToString()
        {
            foreach (var location in LocationsProvider.GetSupportedLocations())
            {
                Assert.IsInstanceOfType(location.ToString(), typeof(string));
                Assert.AreNotEqual("", location.ToString());
            }
        }
        [TestMethod()]
        public void GetSupportedLocationsReturnsLocationWithLatAndLngCoords()
        {
            foreach (var location in LocationsProvider.GetSupportedLocations())
            {
                Assert.IsInstanceOfType(location.Lattitude, typeof(float));
                Assert.AreNotEqual(0.0f, location.Lattitude);

                Assert.IsInstanceOfType(location.Longitude, typeof(float));
                Assert.AreNotEqual(0.0f, location.Longitude);
            }
        }
    }
}