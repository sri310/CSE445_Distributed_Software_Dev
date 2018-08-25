using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce
{
    
    class Retailer
    {
        
        static Random rng = new Random();
        
        public Int32 cardNumber { get; set; }
        public string name { get; set; }
        public Retailer(int i) //Parameterized constructor for the Retailer class
        {
            this.cardNumber = rng.Next(900000, 999999);
            this.name = (i+1).ToString();
        }
        /// <summary>
        /// Method that runs as a retailer's thread. It orders chickes every day(1000ms).
        /// This ensures that each retailer orders  hikens atleast once per day (1000ms).
        /// This is important because the random number generated for chickenprice may never go down
        /// and pricecut event may never be emmited
        /// </summary>
        public void retailerFunc() //for starting reatiler thread
        {
            
            for (Int32 i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Int32 p = myApplication.chicken.getPrice();         
                Console.WriteLine("Store {0} has everyday low price: ${1} each -- {2} iteration", Thread.CurrentThread.Name, p, i+1);
                this.placeOrder();
                //Thread.CurrentThread.Name prints thread name
            }
        }
        public void chickenOnSale(Int32 p) //event Handler
        {
            //order chickens from chicken farm on the event of a pricecut - send orrder into queue
            Console.WriteLine("Store {0} chickens are on sale: as low as ${1} each", name, p);
            this.placeOrder();
            //Thread.CurrentThread.Name cannot print a name
        }
        public void receiveConfirmation(OrderClass orderObject, DateTime confTimeStamp, Int32 finalAmount) //event handler
        {
            //receives confirmation on the event of a complete order
            if (this.name == orderObject.senderId) //checks if the broadcasted event specifies its sender id
            {
                Console.WriteLine("Store {0}'s order of {1} chickens was sucessfuly completed for a final amount of {2}" +
                " at {3}", orderObject.senderId, orderObject.amount, finalAmount, confTimeStamp);
            }
            
        }
        /// <summary>
        /// This method places an order. It creates an order object, encodes it and places it in a MultiCellBuffer
        /// </summary>
        public void placeOrder()
        {
           
            OrderClass order = new OrderClass();
            order.cardNumber = this.cardNumber;
            order.amount = rng.Next(1, 10); //calculates the quantity of chiken to be ordered by generating a random number
            order.senderId = this.name;
            order.timeStamp = DateTime.Now; //stores the timestamp at which the order was placed
            String orderObjString = EncodeDecode.encode(order);           
            ResourcePool.countEmptySpaces.WaitOne(); //Semaphore allows the thread if buffer has space else blocks it        
            myApplication.mcb.setOneCell(orderObjString);
           
        }
       
    }
}
