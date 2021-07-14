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
            int protT = 0;

            int sizeTeam = 0;
            List<Worker> workers = new List<Worker>();
            TeamLeader Leader = null;
            Team team = new Team(workers, Leader);
            House house = new House();

            do
            {
                Console.WriteLine("0. Выход.");
                Console.WriteLine("1. Добавить новую бригаду.");
                Console.WriteLine("2. Информация о бригаде.");
                Console.WriteLine("3. Построить дом");
                Console.WriteLine("4. Вывести отчёт");
                Console.Write("Выберете действие: "); key = Console.ReadKey().KeyChar; Console.Clear();
                switch (key)
                {
                    case '1':
                        {
                            if (protT == 0)
                            {
                                Console.Write("Введите размер бригады: "); sizeTeam = int.Parse(Console.ReadLine());
                                if (sizeTeam > 2)
                                {
                                    Console.Write("Введите имя бригадира: "); Leader = new TeamLeader(Console.ReadLine());
                                }
                                else
                                {
                                    Leader = null;
                                    sizeTeam++;
                                }
                                for (int i = 0; i < sizeTeam - 1; i++)
                                {
                                    Console.Write($"Введите имя рабочего №{ i + 1 }: "); workers.Add(new Worker(Console.ReadLine()));
                                }
                                team = new Team(workers, Leader);
                                Console.WriteLine("Бригада создана! Для выхода нажмите любую клавишу..."); Console.ReadKey(); Console.Clear();
                                protT++;
                            }
                            else
                            {
                                Console.WriteLine("Вторую бригаду нельзя добавить!\nДля выхода нажмите любую клавишу..."); Console.ReadKey(); Console.Clear();
                            }
                        }
                        break;
                    case '2':
                        {
                            if (sizeTeam != 0)
                            {
                                if (TeamLeader.Name != null)
                                {
                                    Console.WriteLine($"Лидер бригады: {TeamLeader.Name}");
                                }
                                for (int i = 0; i < workers.Count; i++)
                                {
                                    Console.WriteLine($"Рабочий №{i + 1}: {workers[i].Name}");
                                }
                            }
                            else Console.WriteLine("Бригада не создана!");
                            Console.WriteLine("Для выхода нажмите любую клавишу..."); Console.ReadKey(); Console.Clear();
                        }
                        break;
                    case '3':
                        {
                            if (team.report.Count != 11 && sizeTeam != 0)
                            {
                                char key2;
                                Console.WriteLine("Нажмите 1 чтобы строить дом. Чтобы выйти нажмите 0");
                                do
                                {
                                    key2 = Console.ReadKey().KeyChar;
                                    if (key2 == '1')
                                    {
                                        house.Build(house, team);
                                        Console.WriteLine(team.report.Count);
                                    }
                                    else if (key2 == '0') break;
                                    if (team.report.Count == 11)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Ваш дом построен!");
                                        house.Paint();
                                        break;
                                    }
                                } while (key2 != '0');
                                Console.WriteLine("Для выхода нажмите любую клавишу..."); Console.ReadKey(); Console.Clear();
                            }
                            else if (team.report.Count == 11)
                            {
                                Console.WriteLine("Дом уже построен!"); house.Paint();
                                Console.WriteLine("Для выхода нажмите любую клавишу..."); Console.ReadKey(); Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Бригада не создана!");
                                Console.WriteLine("Для выхода нажмите любую клавишу..."); Console.ReadKey(); Console.Clear();
                            }

                        }

                        break;
                    case '4':
                        {
                            if (sizeTeam != 0 && team.report.Count > 0)
                            {
                                foreach (var i in team.report)
                                {
                                    Console.WriteLine(i);
                                }
                            }
                            else Console.WriteLine("Дом еще не строился!");
                            Console.WriteLine("Для выхода нажмите любую клавишу..."); Console.ReadKey(); Console.Clear();
                        }
                        break;
                }
            } while (key != '0');
        }
    }
}