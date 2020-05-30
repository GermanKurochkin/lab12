using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab12
{

    public class MyStack<T> : IEnumerable<T>, ICloneable
    {
        public ListOne<T> StackList;
        public MyStack() 
        {
            StackList = new ListOne<T>();
        }
        public MyStack(int capacity) 
        {
            StackList = new ListOne<T>(capacity);
        }
        public MyStack(T[] arr)
        {
            StackList = new ListOne<T>(arr);
        }
        public MyStack(MyStack<T> c) 
        {
            StackList = c.StackList;          
        }

        public int Count()
        {          
            return StackList.Length;
        }

        public MyStack<T> ShallowCopy()
        {
            return (MyStack<T>)this.MemberwiseClone();
        }

        public void Add(T d)
        {
                      
             StackList.Add(Count()+1, StackList.MakePoint(d));
                  
        }
        public MyStack<T> Delete(int num)
        {
            for (int i = 0; i < num; i++)
            {
               StackList.Delete(Count() );
            }
            return this;
        }

        public void Search(T data)
        {
            bool ok = false;
            foreach (T item in this)
            {
                if (item.Equals(data))
                {
                    ok = true;
                }
            }
            if (ok == true) Console.WriteLine("Элемент входит в коллекцию");
            else Console.WriteLine("Элемент не входит в коллекцию");
            return;
        }

        public void Show()
        {
            if(StackList.Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }
            foreach (T item in this)
            {
                Console.WriteLine(item);
            }
        }
        public object Clone()
        {
            int i = 1;
            MyStack<T> clone = new MyStack<T>();
            foreach (T value in this)
            {
                clone.Add(value);
                i++;
            }
            return clone;
        }
        public MyStack<T> Delete()
        {
            StackList.Beg = null;
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = StackList.Beg;
            while (current != null)
            {
                yield return (T)current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public interface ICloneable
        {
            object Clone();
        }
    }
}
