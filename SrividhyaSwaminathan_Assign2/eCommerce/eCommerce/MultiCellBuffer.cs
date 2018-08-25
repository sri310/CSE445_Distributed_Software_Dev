using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce
{
    /// <summary>
    /// this class holds the semaphores that can be accesed by both the chikenFarm and RReatailers
    /// </summary>
    public static class ResourcePool
    {
        public static Semaphore countFilledSpaces; //Semaphore that counts the no of resources/ buffercells used
        public static Semaphore countEmptySpaces; //Semaphore that counts the no of empty spaces in the buffer
        public  static void initializeSemaphore()
        {
            countFilledSpaces = new Semaphore(0, 2); //Intitializing to 0
            countEmptySpaces = new Semaphore(2, 2); //Initializing to 1
        }
    }
    /// <summary>
    /// An instance of this class is stored in the multicellbuffer
    /// </summary>
    public class BufferCell
    {
        public String cellData { get; set; }
        public BufferCell(String cellData)
        {
            this.cellData = cellData;
        }

        public BufferCell()
        {
            this.cellData = "";
        }
    }
    
    public class MultiCellBuffer
    {
        private int bufferSize;        
        private Queue<BufferCell> cellQueue; //Actual buffer is implemented as quueue
        //max elements that can be allowed in the buffer is controlled by the semaphore
        public MultiCellBuffer(int bufferSize) //Parameterized constructor
        {
            this.cellQueue = new Queue<BufferCell>();
            this.bufferSize = bufferSize;

        }
        /// <summary>
        /// Method places one cell object in the buffer
        /// </summary>
        /// <param name="orderObjString"></param>
        public void setOneCell(String orderObjString)
        {
          lock (cellQueue)
            {
                //if the buffer doesn't have space, the thread realeases the lock and waits
                while (cellQueue.Count >= this.bufferSize)
                {
                    Monitor.Wait(cellQueue);
                }
                cellQueue.Enqueue(new BufferCell(orderObjString));
                ResourcePool.countFilledSpaces.Release(); // Increase no of filled up spaces after enqueuing                        
                Monitor.PulseAll(cellQueue);
                
            }          

        }
        public String getOneCell()
        {          
            BufferCell returnObj = new BufferCell();
            lock (cellQueue)
            {
                //if the buffer doesn't have anything to dequeue , the thread realeased the lock and waits
                while (cellQueue.Count == 0)
                {
                    Monitor.Wait(cellQueue);
                }
                returnObj = cellQueue.Dequeue();
                ResourcePool.countEmptySpaces.Release(); //Increase no of empty spaces after dequeueing
                Monitor.PulseAll(cellQueue);
                
                return returnObj.cellData;
            }            
            
            
        }
    }
}
