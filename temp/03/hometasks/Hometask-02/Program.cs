using System;

namespace PearlPoet173377.Hometask_02
{
    class Program
    {
       
         static void Main(string[] args)
        {
            Console.WriteLine("this program sorts array\n");
            // create array and fill it
            Random r = new Random();
            int count = 15;
            int[] arr = new int[count];
            for (int i = 0; i < count; ++i)
            {
                arr[i] = r.Next(-15, 15);
            }
            Console.Write("Source array: ");
            foreach (int n in arr)
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine("\n");
            // sorted negative numbers to left 
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < count - i - 1; ++j)
                {
                    if (arr[j] > 0 && arr[j + 1] < 0)
                    {
                        int a = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = a;
                    }
                }
            }
            // write array
            Console.Write("Sorted array: ");
            foreach (int n in arr)
            {
                Console.Write($"{n} ");
            }
        }

    }
}