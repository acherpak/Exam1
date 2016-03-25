using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    public interface ILinkedList<T>
    {
        void AddFirst(T value);
        void AddLast(T value);
        void Remove(T value);
        void RemoveFirst();
        void RemoveLast();
        bool Find(T value);
        int Lenght();
        Item<T> First();
        Item<T> Last();
    }
}
