using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eCommerce
{
    //class used by both farmer and retailer to encode and decode objects 
    public static class EncodeDecode
    {
        /// <summary>
        /// This method converts(encodes) an object of the OrderClass to a String and sends it the retailer
        /// </summary>
        /// <param name="orderObject"></param>
        /// <returns></returns>
        public static String encode(OrderClass orderObject)
        {
            string serializedData = string.Empty;  // The string variable that will hold the serialized data

            XmlSerializer serializer = new XmlSerializer(orderObject.GetType());
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, orderObject); //Serializes an object to a XML string
                serializedData = sw.ToString();
                return serializedData;
            }

        }
        /// <summary>
        /// This method decodes a string to an orderObject and sends it to the chikenFarm
        /// </summary>
        /// <param name="encodedObjString"></param>
        /// <returns></returns>
        public static OrderClass decode(String encodedObjString)
        {
            //deserializes the received objectstring to an orderObject
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderClass));
            using (TextReader tr = new StringReader(encodedObjString))
            {
                OrderClass decodeOrderObj = (OrderClass)deserializer.Deserialize(tr);
                return decodeOrderObj;
            }


        }
    }
}
