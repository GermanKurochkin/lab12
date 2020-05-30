using System;

namespace lab12
{
    class Program
    {
        static ListOne<double> l1 = new ListOne<double>();
        static ListTwo<int> l2 = new ListTwo<int>();
        static Tree<string> tr = new Tree<string>();
        static MyStack<Engine> stack = new MyStack<Engine>();
        static Engine eng = new Engine();
        static Engine CreateEng()
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите мощность");
            int num = InputNum(9999);

            return new Engine(name, num);
        }
        static int InputMenu(int maxNum)
        {
            int menu;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out menu);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (menu < 0 || menu > maxNum) Console.WriteLine($"Некорректный ввод.Выберите вариант от 0 до {maxNum} из меню");
            } while (!ok || menu < 0 || menu > maxNum);

            return menu;
        }

        static int InputNum(int maxNum)
        {
            int num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (num < 0 || num > maxNum) Console.WriteLine($"Некорректный ввод. Введите число не больше {maxNum}");
            } while (!ok || num < 0 || num > maxNum);

            return num;

        }
        static void CreateCollection(int size)
        {
            int i = 0;
            Random rand = new Random();
            double[] arr1 = new double[size];
            for (int m = 0; m < arr1.Length; m++)
            {
                arr1[m] = (rand.NextDouble() - 0.5) * 100;
            }
            l1 = new ListOne<double>(arr1);

            l2.MakeList(size);

            string[] arr3 = new string[] { "am", "tt", "yy", "ii", "oo", "aa", "ap", "ac", "ad", "ae", "af", "ag", "ar", "gi", "az" };
            tr = new Tree<string>(i,arr3);

            Engine[] arr4 = new Engine[size];
            for (int m = 0; m < arr4.Length; m++)            
                arr4[m]=eng.MakeRandom();           
            stack = new MyStack<Engine>(arr4);
        }
        static double InputDouble()
        {
            double num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = double.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");               
            } while (!ok );

            return num;

        }
        static void AddList()
        {
            Random rand = new Random();
            Console.WriteLine("Введите количество добавляемых элементов");
            int num = InputNum(20);
            double[] mas = new double[num];
            Console.WriteLine("Введите место добавления элементов");
            int place = InputNum(l1.Length + 1);
            for(int i = 0;i<num;i++)
                mas[i]= (rand.NextDouble() - 0.5) * 100;
            l1.Add(place, mas);          
        }
        static void AddListTwo()
        {
            Random rand = new Random();
            Console.WriteLine("Введите количество добавляемых элементов");
            int num = InputNum(20);
    
            Console.WriteLine("Введите место добавления элементов");
            int place = InputNum(l2.Length() + 1);
          
            l2.Add(place,num);
        }
        static void AddStack()
        {
            Console.WriteLine("Введите количество добавляемых элементов");
            int num = InputNum(20);
            for(int i=0;i<num;i++)
                stack.Add( eng.MakeRandom());
        }
        static void AddTree()
        {
            Random rand = new Random();
            Console.WriteLine("Введите добавляемую строку");
            string str = Console.ReadLine();

            tr.Add(tr.Root,str);
        }
        static void DeleteList()
        {
            Random rand = new Random();
            Console.WriteLine("Введите количество удаляемых элементов");
            int num = InputNum(20);
            Console.WriteLine("Введите место удаления элементов");
            int place = InputNum(l1.Length + 1);
         
            l1.Delete(place,num);
        }
        static void DeleteListTwo()
        {
            Random rand = new Random();
            Console.WriteLine("Введите количество удаляемых элементов");
            int num = InputNum(20);
            Console.WriteLine("Введите место удаления элементов");
            int place = InputNum(l2.Length() + 1);

            l2.Delete(place, num);
        }
        static void DeleteStack()
        {          
            Console.WriteLine("Введите количество удаляемых элементов");
            int num = InputNum(20);           
            stack.Delete(num);
        }
        static void SearchList()
        {
            Random rand = new Random();
            Console.WriteLine("Введите искомое число");
            double num = InputDouble();
            int i = 1;
            bool ok = false;
            foreach(double elem in l1)
            {
                if (elem == num)
                {
                    ok = true;
                    Console.WriteLine($"Элемент найден на {i} месте");
                }
                i++;
                
            }
            if (!ok) Console.WriteLine($"Элемент не найден");
        }
        static void TaskList()
        {
            int i = 0;
            bool[] mas = new bool[l1.Length];
            foreach (double elem in l1)
            {
                if (elem < 0)
                {
                    mas[i] = true;
                }
                i++;
            }
            for (int j = mas.Length - 1; j >= 0; j--)
            {
                if (mas[j])
                {
                    Point<double> zero = new Point<double>(0);
                    l1.Add(j + 2, zero);

                }
            }
            Console.WriteLine();
            l1.ShowList();
            Console.WriteLine();
        }
        static void TaskTree()
        {
            int i = 0;
            Console.WriteLine("Введите символ");
            string first = Console.ReadLine();
            if(first.Length>1)
            {
                Console.WriteLine("Взят первый символ из введенных");
                first = first.Substring(0, 1);
            }
            if (first.Length== 0)
            {
                Console.WriteLine("За символ взят пробел");
                first = " ";
            }
            foreach (string str in tr)
            {
                if (str.Substring(0, 1) == first) i++;
            }
            Console.WriteLine($"количество:{ i}");
        }
        static void TreeSearch()
        {
            int i = 0;
            Console.WriteLine("Введите искомую строку");
            string search = Console.ReadLine();
            bool ok = false;
            foreach (string str in tr)
            {
                if (str.Equals( search)) ok=true;
            }
            if (!ok) Console.WriteLine($"Элемент не найден");
            else Console.WriteLine($"Элемент найден");
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int menu = 10;


            while (menu != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Однонаправленный список ");
                Console.WriteLine("2. Двунаправленный список");
                Console.WriteLine("3. Дерево");
                Console.WriteLine("4. Стек на базе однонаправленного списка");
                Console.WriteLine("0.Выход");
                Console.ResetColor();
                menu = InputMenu(4);

                CreateCollection(10);
                Console.WriteLine("Коллекции созданы");

                if (menu == 0) break;
                else
                {
                    int menuNext = 10;

                    switch (menu)
                    {
                        #region task1
                        case 1:

                            while (menuNext != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("1.Показать коллекцию");
                                Console.WriteLine("2.Добавить элементы");
                                Console.WriteLine("3.Удалить элементы");
                                Console.WriteLine("4.Поиск");
                                Console.WriteLine("5.Копия");
                                Console.WriteLine("6.Поверхностная копия");
                                Console.WriteLine("7.Удалить коллекцию");
                                Console.WriteLine("8.Длина");
                                Console.WriteLine("9.Добавить 0 после отрицательных чисел");
                                Console.WriteLine("0.Назад");
                                Console.ResetColor();
                                menuNext = InputMenu(9);
                                if (menuNext == 0) break;
                                else
                                {
                                    switch (menuNext)
                                    {
                                        case 1:
                                            l1.ShowList();
                                            break;
                                        case 2:
                                            AddList();
                                            Console.WriteLine("Элементы добавлены");
                                            break;
                                        case 3:
                                            DeleteList();
                                            Console.WriteLine("Элементы удалены");
                                            break;
                                        case 4:
                                            SearchList();
                                            break;
                                        case 5:
                                            ListOne<double> ll1 = (ListOne<double>)l1.Clone();
                                            ll1.ShowList();
                                            break;
                                        case 6:
                                            ListOne<double> ll2 = (ListOne<double>)l1.ShallowCopy();
                                            ll2.ShowList();
                                            break;
                                        case 7:
                                            l1.Delete();
                                            l1.ShowList();
                                            break;
                                        case 8:
                                            Console.WriteLine($"Количество:{l1.Length }");
                                            break;
                                        case 9:
                                            TaskList();
                                            break;

                                    }
                                }

                            }
                            break;
                        #endregion task1

                        #region task2
                        case 2:


                            while (menuNext != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("1.Показать коллекции");
                                Console.WriteLine("2.Добавить элемент");
                                Console.WriteLine("3.Удалить элемент");
                                Console.WriteLine("4.Длина");
                                Console.WriteLine("5.Удалить четные цифры");
                                Console.WriteLine("0.Назад");
                                Console.ResetColor();

                                menuNext = InputMenu(5);

                                if (menuNext == 0) break;
                                else
                                {
                                    switch (menuNext)
                                    {
                                        case 1:
                                            Console.WriteLine("коллекция:");
                                            l2.ShowList();
                                            break;
                                        case 2:
                                            AddListTwo();
                                            Console.WriteLine("Элементы добавлены");
                                            break;
                                        case 3:
                                            DeleteListTwo();
                                            Console.WriteLine("Элементы удалены");
                                            break;
                                        case 4:
                                            Console.WriteLine($"Количество:{l2.Length() }");
                                            break;
                                        case 5:
                                            l2.DeleteEven();
                                            l2.ShowList();
                                            break;
                                    }
                                }
                            }
                            break;
                        #endregion task2

                        #region task3
                        case 3:
                            while (menuNext != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("1.Показать коллекцию");
                                Console.WriteLine("2.Добавить элемент");
                                Console.WriteLine("3.Выполнить клонирование");
                                Console.WriteLine("4.Дерево поиска");
                                Console.WriteLine("5.Сколько элементов начинаются с заданного символа");
                                Console.WriteLine("6.Длина");
                                Console.WriteLine("7.Найти элемент");
                                Console.WriteLine("0.Назад");

                                Console.ResetColor();
                                menuNext = InputMenu(7);
                                if (menuNext == 0) break;
                                else
                                {
                                    switch (menuNext)
                                    {
                                        case 1:
                                            tr.Show();
                                            break;
                                        case 2:
                                            AddTree();
                                            Console.WriteLine("Элемент добавлен");
                                            break;
                                        case 3:
                                            Tree<string> tr2 = (Tree<string>)tr.ShallowCopy();
                                            tr2.Show();
                                            break;
                                        case 4:
                                            tr.BuildSearch();
                                            tr.Show();
                                            break;
                                        case 5:
                                            TaskTree();
                                            break;
                                        case 6:
                                            Console.WriteLine($"Количество:{tr.Length()}");
                                            Console.WriteLine($"Глубиина:{tr.TreeDeep(tr.Root)}");
                                            break;
                                        case 7:
                                            TreeSearch();
                                            break;
                                       
                                    }
                                }
                            }
                            break;
                        #endregion task3

                      
                        #region task4
                        case 4:

                            while (menuNext != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("1.Показать коллекцию");
                                Console.WriteLine("2.Добавить элементы");
                                Console.WriteLine("3.Удалить элементы");
                                Console.WriteLine("4.Поиск");
                                Console.WriteLine("5.Копия");
                                Console.WriteLine("6.Поверхностная копия");
                                Console.WriteLine("7.Удалить коллекцию");
                                Console.WriteLine("8.Длина");                                
                                Console.WriteLine("0.Назад");
                                Console.ResetColor();
                                menuNext = InputMenu(8);
                                if (menuNext == 0) break;
                                else
                                {
                                    switch (menuNext)
                                    {
                                        case 1:
                                            stack.Show();
                                            break;
                                        case 2:
                                            AddStack();
                                            Console.WriteLine("Элементы добавлены");
                                            break;
                                        case 3:
                                            DeleteStack();
                                            Console.WriteLine("Элементы удалены");
                                            break;
                                        case 4:

                                            stack.Search(CreateEng());
                                            break;
                                        case 5:
                                            MyStack<Engine> s2 = (MyStack<Engine>)stack.Clone();
                                            s2.Show();
                                            break;
                                        case 6:
                                            MyStack<Engine> s3 = stack.ShallowCopy();
                                            s3.Show();
                                            break;
                                        case 7:
                                            stack.Delete();
                                            stack.Show();
                                            break;
                                        case 8:
                                            Console.WriteLine($"Количество:{stack.Count() }");
                                            break;
                                    }
                                }

                            }
                            break;
                            #endregion task4

                    }
                }
            }









            //Random rand = new Random();
            //ListTwo<int> l = new ListTwo<int>();
            //l.MakeList(6);
            //Console.WriteLine();
            //l.ShowList();
            //l.Delete(3, 2);
            //Console.WriteLine();
            //l.ShowList();
            //l.Add(1, 4);
            //Console.WriteLine();
            //l.ShowList();
            //Console.WriteLine();
            //l.DeleteEven();
            //Console.WriteLine();
            //l.ShowList();

            //double[] arr = new double[8];
            //for(int m=0; m<arr.Length;m++)
            //{
            //    arr[m] = (rand.NextDouble() - 0.5) * 100;
            //}
            //ListOne<double> l1 = new ListOne<double>(arr);            
            //Console.WriteLine();
            //l1.ShowList();
            //Console.WriteLine();
            //Point<double> p = new Point<double>(-0.5);
            //l1.Add(7, p);
            //Console.WriteLine();
            //l1.ShowList();
            //Console.WriteLine();
            //l1.Delete(5, 1);
            //l1.ShowList();

            //int i = 0;
            //bool[] mas = new bool[l1.Length];
            //foreach(double elem in l1)
            //{
            //    if(elem<0)
            //    {
            //        mas[i] = true;
            //    }
            //        i++;
            //}
            //for(int j= mas.Length-1; j>=0;j--)
            //{
            //    if (mas[j])
            //    {
            //        Point<double> zero = new Point<double>(0);
            //        l1.Add(j+2 , zero);

            //    }
            //}
            //Console.WriteLine();
            //l1.ShowList();
            //Console.WriteLine();

            //ListOne<double> ll1 = (ListOne<double>)l1.Clone();
            //ll1.ShowList();
            //Console.WriteLine();
            //ll1.Delete().ShowList();
            //Console.WriteLine();

            //string[] mas = new string[] { "am", "tt", "yy", "ii", "oo", "aa", "ap", "ac", "ad", "ae", "af", "ag", "ar", "gi", "az" };
            //int i;
            //Tree<string> tr = new Tree<string>(mas);
            //PointTree<string> p = new PointTree<string>("kk");

            //tr.Show();
            //Console.WriteLine("___________");

            //tr = new Tree<string>(0, mas);

            //tr.Show();
            //Console.WriteLine("___________");


            //tr.BuildSearch();
            //tr.Show();

            //i = 0;
            //string first = "a";
            //foreach (string str in tr)
            //{
            //    if (str.Substring(0, 1) == first) i++;
            //}
            //Console.WriteLine(i);

        }
    }
}
