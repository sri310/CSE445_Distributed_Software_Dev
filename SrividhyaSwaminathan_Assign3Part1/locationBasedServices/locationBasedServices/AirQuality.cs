using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace locationBasedServices
{
    public class Attribution
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class City
    {
        public IList<double> geo { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Co
    {
        public double v { get; set; }
    }

    public class No2
    {
        public double v { get; set; }
    }

    public class O3
    {
        public double v { get; set; }
    }

    public class Pm25
    {
        public int v { get; set; }
    }

    public class So2
    {
        public double v { get; set; }
    }

    public class Iaqi
    {
        public Co co { get; set; }
        public No2 no2 { get; set; }
        public O3 o3 { get; set; }
        public Pm25 pm25 { get; set; }
        public So2 so2 { get; set; }
    }

    public class Time
    {
        public string s { get; set; }
        public string tz { get; set; }
        public int v { get; set; }
    }

    public class Data
    {
        public int aqi { get; set; }
        public int idx { get; set; }
        public IList<Attribution> attributions { get; set; }
        public City city { get; set; }
        public string dominentpol { get; set; }
        public Iaqi iaqi { get; set; }
        public Time time { get; set; }
    }

    public class AirQuality
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
}