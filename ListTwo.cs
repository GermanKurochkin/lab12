using System;
using System.Collections.Generic;
using System.Text;

namespace lab12
{
    public class PointTwo<T>
    {
        public object Data { get; set; }
        public PointTwo<T> Next { get; set; }
        public PointTwo<T> Pred { get; set; }

        public PointTwo()
        {
            Next = null;
            Pred = null;
            Data = default(T);
        }

        public PointTwo(T data)
        {
            Data = data;
            Next = null;
            Pred = null;
        }
        public PointTwo(Random rand)
        {
           
            Data = rand.Next(100);
            Next = null;
        }
        //public PointTwo(Random rnd)
        //{
        //    Engine t = new Engine();
        //    Data = t.MakeRandom();
        //    Next = null;
        //}
        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }
    public class ListTwo<T>
    {
        public PointTwo<T> Beg { get; set; }

        public ListTwo()
        {
            Beg = null;
        }

        public ListTwo(PointTwo<T> data)
        {
            Beg = data;
        }

        public ListTwo(ListTwo<T> list)
        {
            Beg = list.Beg;
        }


        public PointTwo<T> MakePoint(Random rand)
        {
            PointTwo<T> p = new PointTwo<T>(rand);
            return p;
        }
        public int Length()
        {
            int count = 0;
            if (Beg == null)
            {

                return count;
            }
            else
            {
                PointTwo<T> p = Beg;
                while (p != null)
                {
                    count++;
                    p = p.Next;
                }
                return count;
            }

        }

        public void MakeList(int size) 
        {
            Random rand = new Random();            
            PointTwo<T> beg = MakePoint(rand);
          

            PointTwo<T> p2 = beg;

            for (int i = 1; i < size; i++)
            {
                PointTwo<T> p = MakePoint(rand);
                
                p2.Next = p;
                p.Pred = p2;
                p2 = p;
              
            }
            Beg= beg;
        }
        public void ShowList()
        {          
            if (Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }
            PointTwo<T> p = Beg;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.Next;
            }
            Console.WriteLine();
        }
        public void Add(int number, Random rand)
        {
            PointTwo<T> NewPoint = MakePoint(rand);
            
            if (Beg == null)
            {
                Beg = MakePoint(rand);
            }
            else
            {
                if (number == 1)
                {
                    NewPoint.Next = Beg;
                    Beg.Pred = NewPoint;
                    Beg = NewPoint;
                }
                else
                {
                    PointTwo<T> p = Beg;
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
                        NewPoint.Pred = p;
                        p.Next.Pred = NewPoint;
                        
                    }
                }
            }
        }
        public void Add(int place, int num)
        {
            Random rand = new Random();
            for (int i = 0; i < num; i++)
            {
                this.Add(place + i, rand);
            }
        }
        public void Delete(int place)
        {
            if (Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
            }
            else
            {
                if (place == 1)
                {
                    Beg = Beg.Next;
                    Beg.Pred = null;
                }
                else
                {
                    PointTwo<T> p = Beg;
                    for (int i = 1; i < place - 1 && p != null; i++)
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
        public void Delete(int place, int num)
        {
            for (int i = 0; i < num; i++)
            {
                this.Delete(place);
            }
        }
        public void DeleteEven()
        {
            if (Beg == null)
            {
                Console.WriteLine("Коллекция пуста");
            }
            else
            {
                PointTwo<T> p = Beg;
                int i = 1;
                while (p != null)
                {
                    if ((int)p.Data % 2 == 0)
                    {
                        p = p.Next;
                        i--;
                        this.Delete(i+1);
                    }
                    else
                    {
                        p = p.Next;
                    }
                    i++;
                }
            }
        }
    }
}
