using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce
{
   
    public class ChickenFarm
    {
        static Random rng = new Random();
        public static event priceCutEvent priceCut;
        public static event completeOrderEvent completeOrder;
        private static Int32 chikenPrice = 10;
        private Int32 noOfPriceChanges;
        public ChickenFarm(int number)
        {
            this.noOfPriceChanges = number;
        }
        public Int32 getPrice() { return chikenPrice; }
        public static void changePrice(Int32 price)
        {
            if (price < chikenPrice) // a price cut
            {
                if (priceCut != null) //there is atleast a subsriber
                {
                    priceCut(price); //emit event ot subsribers
                }

            }
            chikenPrice = price;
        }
        public Int32 pricingModel() //This method calculates the price of the chicken as a random number
        {
            return (rng.Next(5, 10));
        }
        /// <summary>
        /// Method proceeses an order and emits completeOrder event on successful processing
        /// This method is started as a thread by startAcceptOrder thread
        /// </summary>
        /// <param name="orderObject"></param>
        /// <param name="p"></param>
        public  void orderProcessing(OrderClass orderObject, Int32 p)
        {
            
            Console.WriteLine("started procesing order store {0}'s order of {1} chickens placed at {2}",
                                orderObject.senderId, orderObject.amount,orderObject.timeStamp);
            if (orderObject.cardNumber >= 900000 && orderObject.cardNumber <= 999999)
            {
                Int32 tax = Convert.ToInt32((orderObject.amount * p) * (0.1)); //10% Tax and rounding the nearest integer
                Int32 shipping = 5; //constnt amount of 5 for shipping
                Int32 finalAmount = (orderObject.amount * p) + tax + shipping;  
                if(completeOrder != null)
                {
                    completeOrder(orderObject, DateTime.Now, finalAmount); //emit event
                }
            }
            else
            {   //prints when order can't be processed
                Console.WriteLine("Sorry, {0}- your order was not processed", orderObject.senderId);
            }
            
        }

        /// <summary>
        /// This method is started as a thread by the farmerFunc thread.
        /// It checks the MultiCellBuffer once in every 500ms
        /// </summary>
        public void startAcceptOrder()
        {
            Console.WriteLine("looking for orders");
            while(myApplication.runApp) //thread accepts order as long as the farmer thread is running
            {                           //myApplication.runApp is bool that checks if farmer thread is alive
                Thread.Sleep(500);
                ResourcePool.countFilledSpaces.WaitOne(); //Semaphore allows the thread if there is something in the buffer to process
                String objString = myApplication.mcb.getOneCell();                
                OrderClass orderObj = EncodeDecode.decode(objString);
                Int32 currPrice = this.getPrice();
                Thread orderProcessor = new Thread(() => orderProcessing(orderObj, currPrice));
                orderProcessor.Start();
            }           
            
        }
        /// <summary>
        /// This method is started as thread by the main function
        /// It starts the runOrder thread
        /// It changes the chiken price #noOfPriceChanges times
        /// The application stops when this thread dies
        /// </summary>
        public void farmerFunc()
        {
            //runOrder is the thread that checks
            //whether there is an order in the MulitCellBuffer that needs to be processed
            Thread runOrder = new Thread(new ThreadStart(this.startAcceptOrder));
            runOrder.Start();
           // iterates #noOfPriceChanges times 
            for (Int32 i = 0; i < noOfPriceChanges; i++)
            {                
                Thread.Sleep(500);                
                Int32 p = pricingModel();
                Console.WriteLine("New price is {0} -- iteration {1}", p, i+1);
                changePrice(p);
                
            }
        }

    }
}
