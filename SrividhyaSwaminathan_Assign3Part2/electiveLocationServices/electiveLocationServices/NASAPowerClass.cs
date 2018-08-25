using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electiveLocationServices
{
    public class Geometry
    {
        public List<double> coordinates { get; set; }
        public string type { get; set; }
    }

    public class WS10M
    {
        public Dictionary<int, double> avg { get; set; }
    }

    public class Parameter
    {
        public Dictionary<int,double> WS10M { get; set; }
        public Dictionary<int, double> ALLSKY_SFC_SW_DWN { get; set; }
    }

    public class Properties
    {
        public Parameter parameter { get; set; }
    }

    public class Feature
    {
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
        public string type { get; set; }
    }

    public class Header
    {
        public string api_version { get; set; }
        public string fillValue { get; set; }
        public string range { get; set; }
        public string title { get; set; }
    }

    public class Outputs
    {
        public string json { get; set; }
    }

    public class WS10M2
    {
        public string longname { get; set; }
        public string units { get; set; }
    }

    public class ParameterInformation
    {
        public WS10M2 WS10M { get; set; }
    }

    public class NASAPowerClass
    {
        public List<Feature> features { get; set; }
        public Header header { get; set; }
        public List<object> messages { get; set; }
        public Outputs outputs { get; set; }
        public ParameterInformation parameterInformation { get; set; }
        public List<List<object>> time { get; set; }
        public string type { get; set; }
        
    }
}