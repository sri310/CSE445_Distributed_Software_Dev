using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;


namespace resfulStoreLocationService
{
   
    public class Service1 : IService1
    {
        /// <summary>
        /// Description: Use an existing online Yelp API to find the provided storeName 
        /// closest to the latitude and longitude and return the address.
        /// If no store is found, return an error message.  
        /// If the store is further than 20 miles, from the zipcode, return a “no stores within 20 miles” 
        /// Input: decimal latitude, decimal longitude, string storename
        /// Output: string address
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="storeName"></param>
        /// <returns></returns>
        public string findNearestStore(decimal latitude, decimal longitude, string storeName)
        {
            WebClient webClient = new WebClient();          
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + "tEFvfkrFdTURK0yIz7S5YulplyV7zgZqVI6JjCMl8vPMpHvZxiKqT6Ps4LclNoLW2EdarfQduSUUaeBqaQ66kJBqx3HFasehUoBEtogoUf6D6ia-lpUbjd_9xcscW3Yx");
            string baseURL = "https://api.yelp.com/v3/businesses/search?";
            string paramTerm = storeName; //exact store name or related term
            string paramLatitude = latitude.ToString();
            string paramLongitude = longitude.ToString();
            string paramRadius = "32186"; //20 miles
            string paramLimit = "1";  //gives 1 result
            string paramSortBy = "distance";  // to find the neares shop 
            string fullURL= baseURL+"term="+paramTerm+"&latitude="+paramLatitude+"&longitude="+paramLongitude+"&radius="+paramRadius+
                            "&limit="+paramLimit+"&sort_by="+paramSortBy;
            string address = "";
            try
            {
                string response = webClient.DownloadString(fullURL);
                YelpBusinessesSearch yelpBusinessesSearch = JsonConvert.DeserializeObject<YelpBusinessesSearch>(response);
                if (yelpBusinessesSearch.businesses.Count > 0)
                {
                    address = yelpBusinessesSearch.businesses[0].name;
                    for (int i = 0; i < yelpBusinessesSearch.businesses[0].location.display_address.Count; i++)
                    {
                        address += " " + yelpBusinessesSearch.businesses[0].location.display_address[i];
                    }
                    return address;
                }
                address = "No store found within 20 miles distance";
                return address;


            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }   
           
            
        }
    }
}
