using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace locationBasedServices
{
    public class Timezone
    {
        public string timezone_identifier { get; set; }
        public string timezone_abbr { get; set; }
        public int utc_offset_sec { get; set; }
        public string is_dst { get; set; }
    }

    public class Location
    {
        public string zip_code { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public Timezone timezone { get; set; }
        public IList<object> acceptable_city_names { get; set; }
    }
}