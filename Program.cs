using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListGeneric
{    
    internal class Program
    {
        static void TestPrint(ArrayList<object> arrayList)
        {
            Console.WriteLine($"Capacity = {arrayList.Capacity}");
            Console.WriteLine($"Size = {arrayList.GetSize()}");
            Console.WriteLine(arrayList.ToString());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка методов добавления и удаления элементов.");
            Console.WriteLine();

            ArrayList<object> list = new ArrayList<object>(
                new string[] { "cat", "dog", "pig", "mous" });
            list.AddBack(58.29);
            list.AddArrayBack(new object[] { 1, 2, 3, });
            list.AddIndex(0, "null");
            list.AddArrayIndex(5, new object[] { 101, 102, 103 });
            TestPrint(list);
            list.DeleteBack();
            list.DeleteElem(8);
            list.DeleteRange(3, 5);
            TestPrint(list);
            list.Shrink();
            Console.WriteLine($"Capacity = {list.Capacity}");
            Console.WriteLine($"Size = {list.GetSize()}");

            Console.WriteLine();

            ArrayList<int> array1 = new ArrayList<int>(5);
            array1.AddArrayBack(new int[] { 26, 48, 86 });
            Console.WriteLine($"Capacity = {array1.Capacity}");
            Console.WriteLine($"Size = {array1.GetSize()}");
            Console.WriteLine(array1.ToString());
            Console.WriteLine();

            ArrayList<double> array2 = new ArrayList<double>();
            array2.AddBack(6.25);
            array2.AddBack(59.4);
            Console.WriteLine($"Capacity = {array2.Capacity}");
            Console.WriteLine($"Size = {array2.GetSize()}");
            Console.WriteLine(array2.ToString());
            Console.WriteLine();
        }
    }
}
