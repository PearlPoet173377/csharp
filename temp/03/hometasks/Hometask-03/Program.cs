using System;

namespace PearlPoet173377.Hometask_03
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Check number in array from 1 to 9: ");
            int number;
            bool success = int.TryParse(Console.ReadLine(), out number);
            if(success)
            {
                if(number > 0 && number < 10)
                {
                    // create array and fill it
                    Random r = new Random();
                    int num = 15;
                    int[] arr = new int[num];
                    for (int i = 0; i < num; ++i)
                    {
                        arr[i] = r.Next(10);
                    }

                    // write array
                    int count = 0;
                    Console.Write("Source array: ");
                    //count input number

                    foreach (int n in arr)
                    {
                        if (n == number) ++count;
                        Console.Write($"{n} ");
                    }

                    Console.WriteLine($"\nThere {count} input number\n");
                }

                else
                {
                    Console.WriteLine("Wrong number");
                    return;
                }

            }

            else
            {
                Console.WriteLine("NAN");
                return;
            }

        }
    }
}
