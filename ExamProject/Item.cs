using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    public class Item<T>
    {
         private T Data;
         private Item<T> NextItem;
         private Item<T> PrevItem;

        public Item(T Data)
        {
            this.Data = Data;            
        } 

        public T DataValue
         {
             get { return Data; }
             set { Data = value; }
         }

         public Item<T> Next
         {
             get { return this.NextItem; }
             set { this.NextItem = value; }
         }

         public Item<T> Prev
         {
             get { return this.PrevItem; }
             set { this.PrevItem = value; }
         }
    }
}
