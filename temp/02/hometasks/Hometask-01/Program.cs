using System;

namespace PearlPoet173377.Hometask_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program delete 0 from array and fill free places -1\n");
            // create array and fill it
            Random r = new Random();
            int[] arr = new int[10];
            for(int i = 0; i < 10; ++i)
            {
                arr[i] = r.Next(3);
            }
            // Write array
            Console.Write("Source array: ");
            foreach (int n in arr)
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 9 - i; ++j)
                {
                    if (arr[j] == 0 && arr[j + 1] != 0)
                    {
                        int a = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = a;
                    }
                }
            }
            // change
            for (int i = 0; i < 10; ++i)
            {
                if (arr[i] == 0)
                {
                    arr[i] = -1;
                }
            }
            // write array
            Console.Write("Array: ");
            foreach (int n in arr)
            {
                Console.Write($"{n} ");
            }
        }
    }
}
