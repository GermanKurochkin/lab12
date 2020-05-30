using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design.Serialization;

namespace lab12
{
    public class PointTree<T>
    {
        public T Data;
      
        public PointTree<T> left,
                            right;
        public PointTree()
        {
            Data = default(T);
            left = null;
            right = null;
        }
        public PointTree(T t)
        {
            Data = t;
            left = null;
            right = null;
        }
        //public PointTree(string str)
        //{           
        //    Data = str;
        //    left = null;
        //    right = null;
        //}
        //public PointTree(Random rand)
        //{
        //    Engine t = new Engine();
        //    Data = t.MakeRandom();
        //    left = null;
        //    right = null;
        //}
        public override string ToString()
        {
            return Data.ToString() + " ";
        }
    }
    public class Tree<T>: IEnumerable<T>
        where T : IComparable
    {
        static int count;
        public PointTree<T> Root { get; set; }

        public Tree()
        {
            Root = null;
        }
        public Tree(PointTree<T> t)
        {
            Root = t;
        }
        public Tree(params T[] arr)
        {
            Root = new PointTree<T>(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                Add(Root, arr[i]);
            }

        }
        public Tree(int i, params T[] arr)
        {
            count = 0;
            Root = IdealTree(arr.Length, arr);

        }


  

        public void Add(PointTree<T> root, T str)
        {
            PointTree<T> p = root; 
            PointTree<T> r = null;
            bool ok = false;

            while (p != null && !ok)
            {
                r = p;            
                if (str.Equals(p.Data)) ok = true;
                else
                if (str.CompareTo( p.Data)==-1) p = p.left; 
                else p = p.right; 
            }
            if (ok);
            else
            {
                PointTree<T> NewPoint = new PointTree<T>(str);

                if (str.CompareTo(r.Data) == -1) r.left = NewPoint;
                else r.right = NewPoint;              
            }
        }

        //public PointTree<T> IdealTree(int size, PointTree<T> root,T[] elem)
        //{
        //    count = 0;
        //    PointTree<T> r;
        //    int nleft, nright;
        //    if (size == 0)
        //    {
        //        root = null;
        //        return root;
        //    }
        //    nleft = size / 2;
        //    nright = size - nleft - 1;
        //    r = new PointTree<T>(elem[count]);
        //    count++;
        //    for (int i = 0; i < size; i++)
        //    {
        //        r.left = IdealTree(nleft, r.left,elem);
        //        r.right = IdealTree(nright, r.right,elem);
        //    }
        //    return root;
        //}
        private PointTree<T> IdealTree(int size,  params T[] arr)
        {
            PointTree<T> r;
            int nl, nr;
            if (size == 0) 
            {                  
                return null; 
            }
            nl = size / 2; nr = size - nl - 1;
            r = new PointTree<T>(arr[count]);
            count++;
            r.left = IdealTree(nl,  arr);
            r.right = IdealTree(nr,  arr);
            return r;
        }


        private void ShowTree(PointTree<T> p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);
                for (int i = 0; i < l; i++)
                    Console.Write(" ");
                Console.WriteLine(p.Data);
                ShowTree(p.right, l + 3);
            }
        }
        public void Show()
        {
            if (Root == null)
            {
                Console.WriteLine("Empty");
            }
            else
                ShowTree(Root, 5);

        }
        public void Run(PointTree<T> t)
        {
            if (t != null)
            {
                Run(t.left);
                Run(t.right);
            }
        }
        public int TreeDeep(PointTree<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(TreeDeep(root.left), TreeDeep(root.right));
            }
        }
        public void BuildSearch()
        {
            PointTree<T> beg = new PointTree<T>(Root.Data);
            MakeSearch(beg, Root);
            Root = beg;
        }
        private void MakeSearch(PointTree<T> search,PointTree<T> root)
        {

            if (root != null)
            {
                MakeSearch(search,root.left);
                if(!search.Data.Equals(root.Data)) Add(search, root.Data);
                MakeSearch(search,root.right);
               
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        public IEnumerator<T> InOrderTraversal()
        {
            if (Root != null)
            {
                Stack<PointTree<T>> stack = new Stack<PointTree<T>>();
                PointTree<T> current = Root;
                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.left != null)
                        {
                            stack.Push(current);
                            current = current.left;
                        }
                    }

                    yield return current.Data;

                    if (current.right != null)
                    {
                        current = current.right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }

            }
        }
        public Tree<T> Delete()
        {
            Root = null;
            Console.WriteLine("Коллекция удалена");
            return this;
        }
        public object ShallowCopy()
        {
            return (Tree<T>)this.MemberwiseClone(); ;
        }
        public int Length()
        {
            int i = 0;
            foreach (T elem in this) i++;
            return i;
        }

    }
}
