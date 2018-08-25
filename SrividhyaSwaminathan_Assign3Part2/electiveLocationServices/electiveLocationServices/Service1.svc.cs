using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace electiveLocationServices
{

    public class Service1 : IService1
    {
        /// <summary>
        /// Description: This method returns a 2d list having information about the nearest relevant airports for a given
        /// latitude and longitude.
        /// Input -  decimal latitude , decimla longitude
        /// Output - 2d string list
        /// Output format - first row is the header  of form [ "Airport Code", "Airport Name", "Distance", "City Name"]
        ///               - Each sunsequent row has corresponding values for each airport that is found as neareset to the specified location.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public List<List<string>> nearestAirport(decimal latitude, decimal longitude)
        {
            List<List<string>> relevantAirports = new List<List<string>>();
            string baseURL = "https://api.sandbox.amadeus.com/v1.2/airports/nearest-relevant?";
            string apikey = "naGoAtPvARClRfJEwGGuqmpHtYHWnOwO";
            string fullURL = baseURL + "apikey=" + apikey + "&latitude=" + latitude + "&longitude=" + longitude;
            string response = "";
            try
            {
                WebClient webClient = new WebClient();
                response = webClient.DownloadString(fullURL);
                List<Airport> airports = JsonConvert.DeserializeObject<List<Airport>>(response);
                List<string> header = new List<string>();
                header.Add("Airport Code");
                header.Add("Airport Name");
                header.Add("Distance");
                header.Add("city name");

                relevantAirports.Add(header);
                for (int index = 0; index < airports.Count; index++)
                {
                    List<string> temp = new List<string>();
                    temp.Add(airports[index].airport);
                    temp.Add(airports[index].airport_name);
                    temp.Add(airports[index].distance.ToString());
                    temp.Add(airports[index].city_name);
                    relevantAirports.Add(temp);
                }
            }
            catch (Exception e)
            {
                List<string> temp = new List<string>();
                temp.Add(e.Message.ToString());
                relevantAirports.Add(temp);
            }
            return relevantAirports;

        }
        /// <summary>
        /// Description : Method returns the average annual wind intensity at 10m for the given location
        /// Input: decimal latitude, decimal longitude
        /// Output: decimal {average wind intensity}
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public decimal WindIntensity(decimal latitude, decimal longitude)
        {
            string baseURL = "https://power.larc.nasa.gov/cgi-bin/v1/DataAccess.py?";
            string paramIdentifier = "SinglePoint";
            string paramRequest = "execute";
            string parameters = "WS10M";
            string paramUserCommuntiy = "SSE";
            string paramTempAverage = "CLIMATOLOGY";
            string paramOutputList = "JSON";
            string paramLatitude = latitude.ToString();
            string paramLongitude = longitude.ToString();
            string user = "anonymous";
            string fullURL =baseURL+"request="+paramRequest+"&identifier="+paramIdentifier+"&parameters="+parameters+
                             "&userCommunity="+ paramUserCommuntiy+"&tempAverage="+ paramTempAverage+
                             "&outputList="+paramOutputList+"&lat="+paramLatitude+"&lon="+paramLongitude+"&user="+user;
            try
            {
                WebClient webClient = new WebClient();
                string response = webClient.DownloadString(fullURL);
                NASAPowerClass nASAPowerClassObject = JsonConvert.DeserializeObject<NASAPowerClass>(response);
                return Convert.ToDecimal(nASAPowerClassObject.features[0].properties.parameter.WS10M[13]);                
            }
            catch(Exception e)
            {
                return -1;
            }
            
        }
        /// <summary>
        ///  Description : Method returns the average annual solar intensity for the given location
        /// Input: decimal latitude, decimal longitude
        /// Output: decimal {average solar intensity}
        /// Metric used :
        ///    ALLSKY_SFC_SW_DWN - Averaged Insolation Incident On A Horizontal Surface
        ///                      -The average amount of the total solar radiation incident 
        ///                       on a horizontal surface at the surface of the earth.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public decimal SolarIntensity(decimal latitude, decimal longitude)
        {
            string baseURL = "https://power.larc.nasa.gov/cgi-bin/v1/DataAccess.py?";
            string paramIdentifier = "SinglePoint";
            string paramRequest = "execute";
            string parameters = "ALLSKY_SFC_SW_DWN";
            string paramUserCommuntiy = "SSE";
            string paramTempAverage = "CLIMATOLOGY";
            string paramOutputList = "JSON";
            string paramLatitude = latitude.ToString();
            string paramLongitude = longitude.ToString();
            string user = "anonymous";
            string fullURL = baseURL + "request=" + paramRequest + "&identifier=" + paramIdentifier + "&parameters=" + parameters +
                             "&userCommunity=" + paramUserCommuntiy + "&tempAverage=" + paramTempAverage +
                             "&outputList=" + paramOutputList + "&lat=" + paramLatitude + "&lon=" + paramLongitude + "&user=" + user;
            try
            {
                WebClient webClient = new WebClient();
                string response = webClient.DownloadString(fullURL);
                NASAPowerClass nASAPowerClassObject = JsonConvert.DeserializeObject<NASAPowerClass>(response);                
                return Convert.ToDecimal(nASAPowerClassObject.features[0].properties.parameter.ALLSKY_SFC_SW_DWN[13]);               
            }
            catch (Exception e)
            {
                return -1;
            }

        }
        /// <summary>
        /// Method returns a string array of zipocdes for a given city name and state code
        /// Input -  string cityName, string stateCode
        /// Ouput - strin[] zipcodes
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="stateCode"></param>
        /// <returns></returns>
        public string[] location2zip(string cityName, string stateCode)
        {
            string baseURL = "https://www.zipcodeapi.com/rest/iVJFS6fyv61zFuaLEwA0bYaCwBrBbSi58BHuhQoHlsWAfeNjksNyKhReuo5kYkjC/city-zips.json";
            string fullURL = baseURL + "/" + cityName + "/" + stateCode;
            try
            {
                WebClient webClient = new WebClient();
                string response = webClient.DownloadString(fullURL);
                zipCodesClass zipCodesObject = JsonConvert.DeserializeObject<zipCodesClass>(response);
                string[] array = zipCodesObject.zip_codes.ToArray();
                return array;
            }
            catch(Exception e)
            {
                string[] s = new string[1];
                s[0] = e.Message.ToString();
                return s;
            }

        }
    }
}
