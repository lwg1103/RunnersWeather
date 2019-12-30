using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Location
{
    public class LocationItem
    {
        public string Name { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }

        public override string ToString() => Name;
    }
}
