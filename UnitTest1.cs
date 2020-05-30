using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab12;
using System;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodList1()
        {
            //Arrange
            ListOne<double> l = new ListOne<double>();          
            //Act         
            //Assert
            Assert.IsTrue(l.Beg == null);
        }
        [TestMethod]
        public void TestMethodList2()
        {
            //Arrange
            ListOne<double> l = new ListOne<double>(2);
            //Act 
         
            //Assert
            Assert.IsTrue(l.Beg.Data == 0);
        }
        [TestMethod]
        public void TestMethodList3()
        {
            //Arrange
            double[] arr1 = new double[] { 0.2, 4 };
            //Act 
            ListOne<double> l = new ListOne<double>(arr1);
            ListOne<double> l2 = new ListOne<double>(l);
            //Assert
            Assert.IsTrue(l2.Length == 2);
        }
        [TestMethod]
        public void TestMethodList4()
        {
            //Arrange
            double[] arr1 = new double[] {0.2,4 };          
            //Act 
            ListOne<double> l = new ListOne<double>(arr1);
            //Assert
            Assert.IsTrue(l.Length == 2);
        }
        [TestMethod]
        public void TestMethodListBeg()
        {
            //Arrange
            double[] arr1 = new double[] { 0.2, 0.4 };
            //Act 
            ListOne<double> l = new ListOne<double>(arr1);
            //Assert
            Assert.IsTrue(l.Beg.Data == 0.2);
        }
        [TestMethod]
        public void TestMethodListEnd()
        {
            //Arrange
            double[] arr1 = new double[] { 0.2, 0.4 };
            //Act 
            ListOne<double> l = new ListOne<double>(arr1);
            //Assert
            Assert.IsTrue(l.End.Data == 0.4);
        }
        [TestMethod]
        public void TestMethodListPoint()
        {
            //Arrange   
            ListOne<double> l = new ListOne<double>();
            //Act 
            Point<double> p = l.MakePoint(0.3);
            //Assert
            Assert.IsTrue(p.Data == 0.3);
        }
        [TestMethod]
        public void TestMethodListAdd1()
        {
            //Arrange   
            ListOne<double> l = new ListOne<double>();
            //Act 
            l.Add(1, l.MakePoint(1));
            //Assert
            Assert.IsTrue(l.Length == 1);
        }
        [TestMethod]
        public void TestMethodListAdd2()
        {
            //Arrange   
            double[] arr = new double[] { 0.2, 0.4 };
            ListOne<double> l = new ListOne<double>(arr);
            //Act 
            l.Add(2, l.MakePoint(1));
            //Assert
            Assert.IsTrue(l.Length == 3);
        }
        [TestMethod]
        public void TestMethodListAdd3()
        {
            //Arrange   
            double[] arr = new double[] { 0.2, 0.4 };
            ListOne<double> l = new ListOne<double>();
            //Act 
            l.Add(1, arr);
            //Assert
            Assert.IsTrue(l.Length == 2);
        }
        [TestMethod]
        public void TestMethodListAdd4()
        {
            //Arrange   
            double[] arr = new double[] { 0.2, 0.4 };
            ListOne<double> l = new ListOne<double>(arr);
            //Act 
            l.Add(2, arr);
            //Assert
            Assert.IsTrue(l.Length == 4);
        }
        [TestMethod]
        public void TestMethodListDel1()
        {
            //Arrange   
            double[] arr = new double[] { 0.2, 0.4 };
            ListOne<double> l = new ListOne<double>(arr);
            //Act 
            l.Delete(2);
            //Assert
            Assert.IsTrue(l.Length == 1);
        }
        [TestMethod]
        public void TestMethodListDel2()
        {
            //Arrange   
            double[] arr = new double[] { 0.2, 0.4, 0.6};
            ListOne<double> l = new ListOne<double>(arr);
            //Act 
            l.Delete(1,2);
            //Assert
            Assert.IsTrue(l.Length == 1);
        }
        [TestMethod]
        public void TestMethodListDel3()
        {
            //Arrange   
            double[] arr = new double[] { 0.2 };
            ListOne<double> l = new ListOne<double>(arr);
            //Act 
            l.Delete(1);
            //Assert
            Assert.IsTrue(l.Beg == null);
        }
        [TestMethod]
        public void TestMethodListDel4()
        {
            //Arrange   
            double[] arr = new double[] { 0.2 };
            ListOne<double> l = new ListOne<double>(arr);
            //Act 
            l.Delete();
            //Assert
            Assert.IsTrue(l.Beg == null);
        }
        [TestMethod]
        public void TestMethodListDel5()
        {
            //Arrange   
            double[] arr = new double[] { 0.2 };
            ListOne<double> l = new ListOne<double>(arr);
            ListOne<double> ll = (ListOne<double>)l.Clone();
            //Act 
            l.Delete();
            //Assert
            Assert.IsTrue(ll.Beg.Data == 0.2);         
        }
        [TestMethod]
        public void TestMethodListDel6()
        {
            //Arrange   
            double[] arr = new double[] { 0.2 };
            ListOne<double> l = new ListOne<double>(arr);
            ListOne<double> ll = l.ShallowCopy();
            //Act 
            l.Delete();
            //Assert
            Assert.IsTrue(ll.Beg.Data == 0.2);
        }
        [TestMethod]
        public void TestMethod2List1()
        {
            //Arrange
            ListTwo<int> l = new ListTwo<int>();
            //Act         
            //Assert
            Assert.IsTrue(l.Beg == null);
        }
        [TestMethod]
        public void TestMethod2List2()
        {
            //Arrange
            PointTwo<int> p = new PointTwo<int>(4);
            ListTwo<int> l = new ListTwo<int>(p);
            //Act         
            //Assert
            Assert.IsTrue(l.Length() == 1);
        }
        [TestMethod]
        public void TestMethod2List3()
        {
            //Arrange
            PointTwo<int> p = new PointTwo<int>(4);
            ListTwo<int> ll = new ListTwo<int>(p);
            //Act      
            ListTwo<int> l = new ListTwo<int>(ll);
            //Assert
            Assert.IsTrue(l.Length() == 1);
        }
        [TestMethod]
        public void TestMethod2List4()
        {
            //Arrange
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.MakeList(3);
            //Assert
            Assert.IsTrue(l.Length() == 3);
        }
        [TestMethod]
        public void TestMethod2List5()
        {
            //Arrange
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.MakeList(3);
            //Assert
            Assert.IsTrue(l.Length() == 3);
        }
        [TestMethod]
        public void TestMethod2ListAdd1()
        {
            //Arrange
            Random rand = new Random();
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.Add(4,rand);
            //Assert
            Assert.IsTrue(l.Length() == 1);
        }
        [TestMethod]
        public void TestMethod2ListAdd2()
        {
            //Arrange
            Random rand = new Random();
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.Add(1, rand);
            //Assert
            Assert.IsTrue(l.Length() == 1);
        }
        [TestMethod]
        public void TestMethod2ListAdd3()
        {
            //Arrange
            Random rand = new Random();
            PointTwo<int> p = new PointTwo<int>(4);
            ListTwo<int> l = new ListTwo<int>(p);
            //Act      
            l.Add(2, rand);
            //Assert
            Assert.IsTrue(l.Length() == 2);
        }
        [TestMethod]
        public void TestMethod2ListAdd4()
        {
            //Arrange
            Random rand = new Random();
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.Add(1,3);
            //Assert
            Assert.IsTrue(l.Length() == 3);
        }
        [TestMethod]
        public void TestMethod2ListDel1()
        {
            //Arrange
            Random rand = new Random();
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.Add(1, 3);
            l.Delete(1);
            //Assert
            Assert.IsTrue(l.Length() == 2);
        }
        [TestMethod]
        public void TestMethod2ListDel2()
        {
            //Arrange
            Random rand = new Random();
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.Add(1, 3);
            l.Delete(1,2);
            //Assert
            Assert.IsTrue(l.Length() == 1);
        }
        [TestMethod]
        public void TestMethod2ListDel3()
        {
            //Arrange
            Random rand = new Random();
            ListTwo<int> l = new ListTwo<int>();
            //Act      
            l.Add(1, 3);
            l.Delete(2, 8);
            //Assert
            Assert.IsTrue(l.Length() == 1);
        }
        [TestMethod]
        public void TestMethod2ListDel4()
        {
            //Arrange
            Random rand = new Random();
            ListTwo<int> l = new ListTwo<int>();
            //Act      
           // l.Add(1,2);
            l.Delete(1, 4);
            //Assert
            Assert.IsTrue(l.Length() == 0);
        }
        [TestMethod]
        public void TestMethodTree1()
        {
            //Arrange

            Tree<string> t = new Tree<string>();
            //Act      
           
            //Assert
            Assert.IsTrue(t.Root == null);
        }

        [TestMethod]
        public void TestMethodTree2()
        {
            //Arrange
            string[] arr = new string[] { "am", "tt", "yy", "ii", };

            //Act      
            Tree<string> t = new Tree<string>(arr);
            //Assert
            Assert.IsTrue(t.Length() == 4);
        }
        [TestMethod]
        public void TestMethodTree3()
        {
            //Arrange
            PointTree < string > p= new PointTree<string>("aa");

            //Act      
            Tree<string> t = new Tree<string>(p);
            //Assert
            Assert.IsTrue(t.Length() == 1);
        }
        [TestMethod]
        public void TestMethodTree4()
        {
            //Arrange
            string[] arr = new string[] { "am", "tt", "yy", "ii", };

            //Act      
            Tree<string> t = new Tree<string>(0,arr);
            //Assert
            Assert.IsTrue(t.Length() == 4);
        }
        [TestMethod]
        public void TestMethodTree5()
        {
            //Arrange
            string[] arr = new string[] { "am", "tt", "yy", "ii", };

            //Act      
            Tree<string> t = new Tree<string>(0, arr);
            t.BuildSearch();
            //Assert
            Assert.IsTrue(t.Length() == 4);
        }
        [TestMethod]
        public void TestMethodTree6()
        {
            //Arrange
            string[] arr = new string[] { "am", "tt", "yy", "ii", };

            //Act      
            Tree<string> t = new Tree<string>(0, arr);
            t.Delete();
            //Assert
            Assert.IsTrue(t.Root == null);
        }
        [TestMethod]
        public void TestMethodTree7()
        {
            //Arrange
            string[] arr = new string[] { "am", "tt", "yy", "ii", };

            //Act      
            Tree<string> tt = new Tree<string>(0, arr);
            Tree<string> t = (Tree<string>)tt.ShallowCopy();
          
            //Assert
            Assert.IsTrue(t.Length() == 4);
        }
        [TestMethod]
        public void TestMethodStack1()
        {
            //Arrange

            MyStack<int> s = new MyStack<int>();
            //Act      

            //Assert
            Assert.IsTrue(s.StackList.Beg == null);
        }
        [TestMethod]
        public void TestMethodStack2()
        {
            //Arrange

            MyStack<int> s = new MyStack<int>(2);
            //Act      

            //Assert
            Assert.IsTrue(s.StackList.Beg.Data == 0);
        }
        [TestMethod]
        public void TestMethodStack3()
        {
            //Arrange
            int[] arr = new int[] {1,2,3,4 };
            MyStack<int> s = new MyStack<int>(arr);
            //Act      

            //Assert
            Assert.IsTrue(s.Count() == 4);
        }
        [TestMethod]
        public void TestMethodStack4()
        {
            //Arrange
            int[] arr = new int[] { 1, 2, 3, 4 };
            MyStack<int> ss = new MyStack<int>(arr);
            //Act      
            MyStack<int> s = new MyStack<int>(ss);
            //Assert
            Assert.IsTrue(s.Count() == 4);
        }
        [TestMethod]
        public void TestMethodStack5()
        {
            //Arrange
            int[] arr = new int[] { 1, 2, 3, 4 };
            MyStack<int> ss = new MyStack<int>(arr);
            //Act      
            MyStack<int> s =ss.ShallowCopy() ;
            //Assert
            Assert.IsTrue(s.Count() == 4);
        }
        [TestMethod]
        public void TestMethodStack6()
        {
            //Arrange
            int[] arr = new int[] { 1, 2, 3, 4 };
            MyStack<int> ss = new MyStack<int>(arr);
            //Act      
            MyStack<int> s = (MyStack<int>)ss.Clone();
            //Assert
            Assert.IsTrue(s.Count() == 4);
        }
        [TestMethod]
        public void TestMethodStack7()
        {
            //Arrange
            int[] arr = new int[] { 1, 2, 3, 4 };
            MyStack<int> s = new MyStack<int>(arr);
            //Act      
            s.Add(3);
            //Assert
            Assert.IsTrue(s.Count() == 5);
        }
        [TestMethod]
        public void TestMethodStack8()
        {
            //Arrange
            int[] arr = new int[] { 1, 2, 3, 4 };
            MyStack<int> s = new MyStack<int>(arr);
            //Act      
            s.Delete(2);
            //Assert
            Assert.IsTrue(s.Count() == 2);
        }
        [TestMethod]
        public void TestMethodStack9()
        {
            //Arrange
            int[] arr = new int[] { 1, 2, 3, 4 };
            MyStack<int> s = new MyStack<int>(arr);
            //Act      
            s.Delete();
            //Assert
            Assert.IsTrue(s.StackList.Beg == null);
        }









    }
}
