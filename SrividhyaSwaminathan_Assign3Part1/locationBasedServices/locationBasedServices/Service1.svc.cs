using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace locationBasedServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /// <summary>
        /// Method returns the 5-day weather forecast for a given zipcode.
        /// Input: zipcode in string
        /// Output: 2d list consisting of 6 rows and 5 columns.
        ///         Row1 - shows format - "Date", "minTemperature", "maxTemperature", "Day conditions", "Night conditions"
        ///         Rows 2-6 - holds corresponding values for each of the 5 days
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public List<List<string>> weatherService(string zipcode)
        {
            List<List<string>> forecastArray = new List<List<string>>();
            //First api call is to find out the location key of the zipcode
            String baseUrl = "http://dataservice.accuweather.com/locations/v1/postalcodes/US/search?apikey=sgvP0qCQAWXSPEu6m2UWAiGFCMb1Rrj6&q=" + zipcode;
            WebClient webClient = new WebClient();
            String locationKey = "";
            try
            {
                String response = webClient.DownloadString(baseUrl);
                //The api call returns a JSON array consiting of single object
                JArray a = JArray.Parse(response);
                foreach (JObject o in a.Children())
                {
                    //the loop runs once and finds out the location key of the entered zipcode
                    locationKey = (String)(o["Key"]);
                }
                //second api call returns the forecast
                String forecastURL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/" + locationKey + "?apikey=sgvP0qCQAWXSPEu6m2UWAiGFCMb1Rrj6";
                String forecastResponse = webClient.DownloadString(forecastURL);
                //Template for DailyForecastArry is in file DailyForecastArray.cs 
                DailyForecastArray dailyForecastArrayObject = JsonConvert.DeserializeObject<DailyForecastArray>(forecastResponse);
                List<String> addHeader = new List<string>();
                addHeader.Add("Day");
                addHeader.Add("minTemperature");
                addHeader.Add("maxTemperature");
                addHeader.Add("Day Condtions");
                addHeader.Add("Night Condtions");
                forecastArray.Add(addHeader);
                for (int i = 0; i < dailyForecastArrayObject.DailyForecasts.Count; i++)
                {
                    List<String> temp = new List<string>();
                    temp.Add((dailyForecastArrayObject.DailyForecasts[i].Date).ToString());
                    temp.Add((dailyForecastArrayObject.DailyForecasts[i].Temperature.Minimum.Value).ToString());
                    temp.Add((dailyForecastArrayObject.DailyForecasts[i].Temperature.Maximum.Value).ToString());
                    temp.Add(dailyForecastArrayObject.DailyForecasts[i].Day.IconPhrase);
                    temp.Add(dailyForecastArrayObject.DailyForecasts[i].Night.IconPhrase);
                    forecastArray.Add(temp);

                }
            }
            catch(Exception em)
            {
                List<string> temp = new List<string>();
                temp.Add(em.Message.ToString());
                forecastArray.Add(temp);                

            }
                
            return forecastArray;

        }
        /// <summary>
        /// This method returns the airquality index and status for a given lattitude and longitude
        /// Input: decimal - lattidude value
        ///        decimal - longitude value
        /// Output: string - "{air quality Index} , {pollution level status}" 
        ///                 (ie) return string has airaquality index followed by a comma and the pollution level status
        ///                 (eg) "40,Good"
        /// </summary>
        /// <param name="geocode"></param>
        /// <returns></returns>
        public string airQuality(decimal lattitude, decimal longitude)
        {
            String airQualityIndex = "";
            string[] LatLng = new string[2];
            LatLng[0] = lattitude.ToString();
            LatLng[1] = longitude.ToString();
            string baseUrl = "https://api.waqi.info/feed/geo:";
            string location = LatLng[0] + ";" + LatLng[1];
            string token = "/?token=2b2d84eeb7bafbd0bc4581c9075b3de4fb6b5dea";
            string fullUrl = baseUrl + location + token;
            string status = "";           
            try
            {
                WebClient webClient = new WebClient();
                String response = webClient.DownloadString(fullUrl);
                //Template for airquality object is in file AirQuality.cs
                AirQuality airQualityObject = JsonConvert.DeserializeObject<AirQuality>(response);
                int aqi = airQualityObject.data.aqi;
                if (aqi <= 50)
                {
                    status = "Good";
                }
                else if (aqi >= 51 && aqi <= 100)
                {
                    status = "Moderate";
                }
                else if (aqi >= 101 && aqi <= 150)
                {
                    status = "Unhealthy for Sensitive Groups";
                }
                else if (aqi >= 151 && aqi <= 200)
                {
                    status = "Unhealthy";
                }
                else if (aqi >= 201 && aqi <= 300)
                {
                    status = "Very Unhealthy";
                }
                else status = "Hazardous";
                airQualityIndex = aqi.ToString() + "," + status;
            }
            catch (Exception e)
            {
                airQualityIndex = e.Message.ToString();
            }
            
            return airQualityIndex;
        }
        /// <summary>
        /// Method returns the lattitude and longitude of any US zip code
        /// Input : string - zipcode
        /// Output: string - "{lattitude},{longitude}"
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        public string getLatLng(string zipcode)
        {
            string geocode = "";
            string apikey = "iVJFS6fyv61zFuaLEwA0bYaCwBrBbSi58BHuhQoHlsWAfeNjksNyKhReuo5kYkjC";
            string unit = "degrees";
            string baseUrl = "https://www.zipcodeapi.com/rest/";
            string fullURL = baseUrl + apikey + "/info.json/" + zipcode + "/" + unit;
            try
            {
                WebClient webClient = new WebClient();
                String response = webClient.DownloadString(fullURL);
                //Template for LocationObject is defined in location.cs
                Location locationObject = JsonConvert.DeserializeObject<Location>(response);
                geocode = locationObject.lat.ToString() + "," + locationObject.lng.ToString();                
            }
            catch (Exception e)
            {
                geocode = e.Message.ToString();
            }

            return geocode;
        }


    }
}
