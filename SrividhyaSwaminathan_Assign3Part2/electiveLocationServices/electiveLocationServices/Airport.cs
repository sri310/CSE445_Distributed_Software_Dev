using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electiveLocationServices
{
    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Airport
    {
        public string airport { get; set; }
        public string airport_name { get; set; }
        public string city { get; set; }
        public string city_name { get; set; }
        public int distance { get; set; }
        public Location location { get; set; }
        public int aircraft_movements { get; set; }
        public string timezone { get; set; }
    }

}