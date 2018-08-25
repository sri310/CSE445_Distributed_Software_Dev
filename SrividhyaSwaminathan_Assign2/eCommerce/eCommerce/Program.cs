using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
namespace eCommerce{
    public delegate void priceCutEvent(Int32 pt);
    public delegate void completeOrderEvent(OrderClass order, DateTime timestamp, Int32 finalAmount);

    /// <summary>
    /// Order class is the class with which instance of an order can be created
    /// </summary>
    public class OrderClass
    {
        public DateTime timeStamp { get; set; } //shorthand for creating a private member with public getter and setter
        public String senderId { get; set; } //shorthand for creating a private member with public getter and setter
        public Int32 cardNumber { get; set; } //shorthand for creating a private member with public getter and setter
        public Int32 amount { get; set; } //shorthand for creating a private member with public getter and setter
        public OrderClass()
        {          
        }
       public OrderClass(String senderId, Int32 cardNumber, Int32 amount) //Parametrized constructor for OrderClass
        {
            this.senderId = senderId;
            this.cardNumber = cardNumber;
            this.amount = amount;
            this.timeStamp = DateTime.Now;
        }
       
       
    }

   // Main class that has the main function 
    public class myApplication
    {
        public static MultiCellBuffer mcb; //creats an object of MultiCellBuffer to be used by everyone
        public static ChickenFarm chicken = new ChickenFarm(20); //onely one ChikenFarm object for the entire application
        public static Boolean runApp = false; //boolean variable checks if the farmer thread of ChickenFarm is alive or not 

        static void Main( string[] args)
        {
            Int32 noOfRetailers = 5;
            Int32 bufferSize = 3;
            mcb = new MultiCellBuffer(bufferSize);
            ResourcePool.initializeSemaphore(); 
            //farmer thread is a theread of the ChickenFarm class started by the farmerFunc method
            //This thread decides whether the farm is open (changing price, accepting orders) or not
            // Once this thread dies the application ends
            Thread farmer = new Thread(new ThreadStart(chicken.farmerFunc));           
            farmer.Name = "farmer";
            runApp = true;
            farmer.Start(); //start one farmer thread            
            Retailer[] chikenstore = new Retailer[5];
            for(int i=0; i<noOfRetailers; i++) //create one object for each retailer
            {
                chikenstore[i] = new Retailer(i);
                //subscribes each reatailer object to the chikenOnSale event
                ChickenFarm.priceCut += new priceCutEvent(chikenstore[i].chickenOnSale);
                //subscribes each retailer object to the completeOrder event
                ChickenFarm.completeOrder += new completeOrderEvent(chikenstore[i].receiveConfirmation);
            }           
            
            Thread[] retailers = new Thread[5];
            for(int i = 0; i < noOfRetailers; i++) //Creating a thread for each retailer
            {
                //Start N retailer threads
                retailers[i] = new Thread(new ThreadStart(chikenstore[i].retailerFunc));
                retailers[i].Name = (i + 1).ToString();
                retailers[i].Start();
               
            }
            while (farmer.IsAlive)
            {
                runApp = true;
            }
            runApp = false;
           
            Console.ReadKey();


        }
    }
    
}
