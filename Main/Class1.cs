using Collections.MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            for (int i = 10; i > 0; i--)
            { //добавляем значения в список
                list.Add(i);
            }

            foreach (int item in list)
            {
                Console.Write(" - " + item);
            }

            Console.WriteLine();
            int[] arr = { 1, 2, 4, 5, 6, 34, 4 };
            list.AddRange(arr);
            foreach (int item in list)
            {
                Console.Write(" - " + item);
            }

            Console.WriteLine();

            Console.WriteLine("Count" + list.Count);
        }
    }
}
