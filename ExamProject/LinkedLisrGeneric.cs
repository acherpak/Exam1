using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
   public class LinkedListGeneric<T> : ISortable<T>, ILinkedList<T>, IPrintable where T: IComparable
    {
        private Item<T> _First;
        private Item<T> _Last;
        private Item<T> _Current;
        private Int32 size;
        
        public LinkedListGeneric()//+
        {
            _First = _Current = _Last = null;
            size = 0;
        }

        public void AddFirst(T value)//+
        {
          Item<T> newItem = new Item<T>(value);

          if (_First == null)
          {
            _First = _Last = newItem;
          }
          else
          {
            newItem.Next = _First;
            _First = newItem; 
            newItem.Next.Prev = _First;
            newItem.Prev = null;

          }
             size++;
        }

        public void AddLast(T value)//+
        {
            Item<T> newItem = new Item<T>(value);

            if (_First == null)
            {
                _First = _Last = newItem;
            }
            else
            {
                _Last.Next = newItem;
                newItem.Prev = _Last;
                _Last = newItem;
                newItem.Next = null;
            }
            size++;
        }

        public bool Find(T value) //+
        {
            bool valueisFound = false;
            if (size == 0) return valueisFound; // list is empty
            _Current = _First;

            while (_Current.Next != null)
            {
                valueisFound = (_Current.DataValue.Equals(value));
                if (valueisFound) break;
                _Current = _Current.Next;
            }
            return valueisFound;
        }

        public Item<T> First()//+
        {
            return _First;
        }

        public Item<T> Last()//+
        {
            return _Last;
        }

        public int Lenght()//+
        {
            return size;
        }

        public void Remove(T value) //+
        {
            bool valueisFound = false;
            if (size == 0) return; // if list is empty
            _Current = _First;

            for (int i = 1; i <= size; i++)//Find element in the list
            {
                valueisFound = (_Current.DataValue.Equals(value));
                if (valueisFound) break;
                if (_Current.Next != null) { _Current = _Current.Next; }
            }
            
            if (!valueisFound) return;//value is not detected

            else if (_Current.Prev == null)
            {
                RemoveFirst();
            }
            else if (_Current.Next == null)
            {
                RemoveLast();
            }
            else
            {
                _Current.Next.Prev = _Current.Prev;
                _Current.Prev.Next = _Current.Next;
                _Current = null;
            }
        }

        public void RemoveFirst()//+
        {
            if (size > 1)
            {
                _First = _First.Next;
                _First.Prev = null;
                size--;
            }
            else if (size == 1)
            {
                _First = _Last = _Current = null;
                size--;
            }
            
        }

        public void RemoveLast()//+
        {
            if (size > 1)
            {
                _Last = _Last.Prev;
                _Last.Next = null;
                size--;
            }
            else if (size == 1)
            {
                _First = _Last = _Current = null;
                size--;
            }
         }

        public void Sort() //BubbleSort + 
        {
            if (size == 0) { return; }

            int lenght = size;
            T[] array = new T[size];
            _Current = _First;

            for (int x = 0; x <= (size-1); x++)//Copy list to array for sorting
            {
                array[x] = _Current.DataValue;
                if (_Current.Next != null) { _Current = _Current.Next; }
            }

            int iter = 0;
            for (int i = 0; i < lenght - 1; i++) //Sorting array====
            {
                for (int j = 0; j < lenght - 1 - i; j++)
                {
                    iter++;
                    if (array[j].CompareTo(array[j + 1]) > 0) // if 1st > 2nd then swap
                    {
                        T tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }

            //Move data from sorted array back to the list
            _Current = _First;
            for (int x = 0; x <= (size - 1); x++)//Copy list to array for sorting
            {
                _Current.DataValue = array[x];
                if (_Current.Next != null) { _Current = _Current.Next; }
            }
        }

        void IPrintable.Print()//+
        {
            if (size == 0) return;
            _Current = _First;
            for (int i = 1; i<= size; i++)
            {
                Console.WriteLine(_Current.DataValue);
                if (_Current.Next != null) { _Current = _Current.Next; }

            }
        }

        void SwapItemWithNext(T FisrtItemData)
        {
            T tmp = default(T);
            if (this.Find(FisrtItemData) && (_Current.Next != null))
            {
                tmp = _Current.DataValue;
                _Current.DataValue = _Current.Next.DataValue;
                _Current.Next.DataValue = tmp;
            }
        }
    }
    
}
