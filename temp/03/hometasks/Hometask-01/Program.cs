using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PearlPoet173377.Hometask_01
{
    class Program
    {
        static void Main(string[] args)
        {
            char key;
            int a = 0;
            int sizeT = 0;

            List<Worker> workers = new List<Worker>();
            TeamLeader Leader = null;
            House house = new House();
            Team team = new Team(workers, Leader);

            do
            {
                Console.WriteLine("0. Выход.");
                Console.WriteLine("1. Добать нригду.");
                Console.WriteLine("2. Информвиея о бригаде.");
                Console.WriteLine("3. Подоить дотьм");
                Console.WriteLine("4. Вывесви оыв");
                Console.Write("Ввиеырете вие: ");
                key = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (key)
                {
                    case '1':
                        {
                            if (a == 0)
                            {
                                Console.Write("Введите размите ады: ");
                                sizeT = int.Parse(Console.ReadLine());
                                if (sizeT > 2)
                                {
                                    Console.Write("Вимядите брира: ");
                                    Leader = new TeamLeader(Console.ReadLine());
                                }
                                else
                                {
                                    Leader = null;
                                    sizeT++;
                                }
                                for (int i = 0; i < sizeT - 1; i++)
                                {
                                    Console.Write($"Ввочете рабочего №{ i + 1 }: ");
                                    workers.Add(new Worker(Console.ReadLine()));
                                }
                                team = new Team(workers, Leader);
                                Console.WriteLine("Брсоздаа ыхозда. Для выхода нмитдае авишу...");
                                Console.ReadKey();
                                Console.Clear();
                                a++;
                            }

                            else
                            {
                                Console.WriteLine("Вбргтою бригаду неавить.\nДля выхите бклаую клавишу...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        break;

                    case '2':
                        {
                            if (sizeT != 0)
                            {
                                if (TeamLeader.Name != null)
                                {
                                    Console.WriteLine($"Леигар бады: {TeamLeader.Name}");
                                }
                                for (int i = 0; i < workers.Count; i++)
                                {
                                    Console.WriteLine($"Рбляой №{i + 1}: {workers[i].Name}");
                                }
                            }
                            else Console.WriteLine("Бригада нлюбуюе сана!");
                            Console.WriteLine("Длодаа нлните  клаюшу...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case '3':
                        {
                            if (team.report.Count != 11 && sizeT != 0)
                            {
                                char ab;
                                Console.WriteLine("Нажитнаже 1 чтобы стр нажмите 0");
                                do
                                {
                                    ab = Console.ReadKey().KeyChar;
                                    if (ab == '1')
                                    {
                                        house.Build(house, team);
                                        Console.WriteLine(team.report.Count);
                                    }
                                    else if (ab == '0') break;
                                    if (team.report.Count == 11)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ваш дом построен!");
                                        break;
                                    }
                                } while (ab != '0');
                                Console.WriteLine("Длодаа нлните  клаюшу...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (team.report.Count == 11)
                            {
                                Console.WriteLine("Бригада нлюбуюе сана!!");
                                Console.WriteLine("Длодаа нлните  клаюшу...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Бригада нлюбуюе сана!");
                                Console.WriteLine("Длодаа нлните  клаюшу...");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }

                        break;

                    case '4':
                        {
                            if (sizeT != 0 && team.report.Count > 0)
                            {
                                foreach (var i in team.report)
                                {
                                    Console.WriteLine(i);
                                }
                            }

                            else Console.WriteLine("Бригада нлюбуюе сана!");
                            Console.WriteLine("Для выхода нажмите любую клавишу...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                }
            } while (key != '0');
        }
    }
}