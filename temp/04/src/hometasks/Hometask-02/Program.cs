using System;

namespace PearlPoet173377.Hometask_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write 6 numbers");
            int number;
            bool success = int.TryParse(Console.ReadLine(), out number);
            if(success)
            {
                if(number / 100000 > 0 && number / 100000 < 10)
                {
                    int left = 0;
                    int right = 0;
                    for(int i = 0; i < 3; i++)
                    {
                        right += number % 10;
                        number /= 10;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        left += number % 10;
                        number /= 10;
                    }
                    if(left == right)
                    {
                        Console.WriteLine("Ticket is lucky");
                    }
                    else
                    {
                        Console.WriteLine("Ticket is not lucky");
                    }
                }
                else
                {
                    Console.WriteLine("There are not 6 numbers");
                }
            }
            else
            {
                Console.WriteLine("You have not written anything");
            }
        }
    }
}