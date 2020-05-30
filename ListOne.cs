using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace lab12
{
    public class Point<T>
    {
        public T Data { get; set; }
        public Point<T> Next { get; set; }

        public Point()
        {
            Next = null;
            Data = default(T);
        }

        public Point(T data)
        {
            Data = data;
            Next = null;
        }

        //public Point(Random rand)
        //{

        //    Data = (double)(rand.NextDouble() - 0.5) * 100;
        //    Next = null;
        //}
        //public Point(Random rnd)
        //{
        //    Engine t = new Engine();
        //    Data = t.MakeRandom();
        //    Next = null;
        //}

        public override string ToString()
        {
            return Data.ToString();
        }
    }
    public class ListOne<T> : IEnumerable<T>, ICloneable
    {
        public Point<T> Beg { get; set; }
        static int count;

        public ListOne()
        {
            Beg = null;
        }
        public ListOne(Point<T> data)
        {
            Beg = data;
        }          
        public ListOne(int size)
        {
            Beg = new Point<T>();
            Point<T> p = Beg;
            for (int i = 1; i < size; i++)
            {
                Point<T> temp = new Point<T>();
                temp.Next = p;
                p = temp;

            }
        }

        public ListOne(params T[] mas)
        {
            Beg = new Point<T>();
            Beg.Data = mas[0];
            Point<T> p = Beg;
            for (int i = 1; i < mas.Length; i++)
            {
                Point<T> temp = new Point<T>();
                temp.Data = mas[i];
                p.Next = temp;
                p = temp;
            }
        }
        public int Length
        {
            get
            {
                if (Beg == null) return 0;
                int len = 0;
                Point<T> p = Beg;
                while (p != null)
                {
                    p = p.Next;
                    len++;
                }
                return len;

            }
        }

        public Point<T> End
        {
            get
            {
                if (Beg == null) return Beg;
                Point<T> p = Beg;
                while (p.Next != null)
                {
                    p = p.Next;

                }
                return p;
            }
        }
        public ListOne(ListOne<T> list)
        {
            Beg = list.Beg;
        }


        public Point<T> MakePoint(T tr)
        {
            Point<T> p = new Point<T>(tr);
            return p;
        }
       
        public void ShowList()
        {
            if (Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }
            else
            {
                Point<T> p = Beg;
                while (p != null)
                {
                    Console.WriteLine(p);
                    p = p.Next;
                }
                Console.WriteLine();
            }
        }
        //public void Add( int number, Random rand)
        //{           
        //    Point<T> NewPoint = MakePoint(rand);
        //    Console.WriteLine("Добавленный элемент:");
        //    Console.WriteLine(NewPoint.Data);
        //    if (Beg == null)
        //    {
        //        Beg = NewPoint;
        //    }
        //    else
        //    {
        //        if (number == 1)
        //        {
        //            NewPoint.Next = Beg;
        //            Beg = NewPoint;                  
        //        }
        //        else
        //        {
        //            Point<T> p = Beg;
        //            for (int i = 2; i < number && p != null; i++)
        //                p = p.Next;
        //            if (p == null)
        //            {
        //                Console.WriteLine("В коллекции нет столько элементов");
        //            }
        //            else
        //            {
        //                NewPoint.Next = p.Next;
        //                p.Next = NewPoint;
        //                Console.WriteLine("Элемент добавлен");
        //            }
        //        }
        //    }
        //}
        public void Add(int number, Point<T> New)
        {
            Point<T> NewPoint = new Point<T>();
            NewPoint.Data = New.Data;
            if (Beg == null)
            {
                Beg = NewPoint;
            }
            else
            {
                if (number == 1)
                {
                    NewPoint.Next = Beg;
                    Beg = NewPoint;
                }
                else
                {
                    Point<T> p = Beg;
                    for (int i = 2; i < number && p != null; i++)
                        p = p.Next;
                    if (p == null)
                    {
                        Console.WriteLine("В коллекции нет столько элементов");
                    }
                    else
                    {
                        NewPoint.Next = p.Next;
                        p.Next = NewPoint;                      
                    }
                }
            }
        }
        public void Add(int place, T[] mas)
        {
         
            for (int i = 0; i < mas.Length; i++)
            {
                Add(place+i, MakePoint( mas[i]));
            }
        }
        public void Delete( int number)
        {
            if (Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
            }
            else
            {
                if (number == 1)
                {
                    Beg = Beg.Next;
                }
                else
                {
                    Point<T> p = Beg;
                    for (int i = 1; i < number - 1 && p != null; i++)
                        p = p.Next;
                    if (p.Next == null)
                    {
                        Console.WriteLine("В коллекции нет столько элементов");
                    }
                    else
                    {
                        p.Next = p.Next.Next;
                    }
                }
            }
        }
        public ListOne<T> Delete()
        {
            Beg = null;            
            Console.WriteLine("Коллекция удалена");
            return this;
        }
        public void Delete(int place,int num)
        {
            for (int i = 0; i < num; i++)
            {
                Delete(place);
            }
        }
        //public void AddAfterMinus()
        //{
        //    Random rand = new Random();
        //    Point<T> newp = new Point<T>();           
        //    newp.Data = (double)0;
        //    if (Beg == null)
        //    {
        //        Console.WriteLine("Коллекция пуста");
        //    }
        //    else
        //    {
        //        Point<T> p = Beg;
        //        Point<T> p2 = null ;
        //        while (p != null)
        //        {
        //            if ((double)p.Data < 0)
        //            {
        //                if(p2==null)
        //                {
        //                    Point<T> p0= new Point<T>();
        //                    p0.Data = newp.Data;
        //                    p0.Next = Beg;
        //                    Beg = p0;
        //                }
        //                else
        //                {
        //                    Point<T> p0 = new Point<T>();
        //                    p0.Data = newp.Data;
        //                    p2.Next = p0;
        //                    p0.Next = p;
        //                }
        //            }

        //            p2 = p;
        //            p = p.Next;
        //        }
        
        //    }
        //}
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Point<T> current = Beg;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;

            }
        }
        public interface ICloneable
        {
            object Clone();
        }
        public object Clone()
        {
            int i = 1;
            ListOne<T> clone = new ListOne<T>();
            foreach (T value in this)
            {
                clone.Add(i,new Point<T>(value));
                i++;
            }
            return clone;
        }
        public ListOne<T> ShallowCopy()
        {
            return (ListOne<T>)this.MemberwiseClone();
        }
    }
}
