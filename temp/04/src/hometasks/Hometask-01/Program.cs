using System;

namespace PearlPoet173377.Hometask_01
{
    class Program
    {
        static void Main(string[] args)
        {
            char a;
            Console.WriteLine("Write some symbols with point at the end: ");
            int spaces = 0;

            do
            {
                a = Console.ReadKey().KeyChar;
                if (a == ' ')
                    spaces++;
            }
            while (a != '.');

            Console.WriteLine("\nSpaces: " + spaces);
        }
    }
}
