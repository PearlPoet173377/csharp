using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UdincevBogdan.Hometask_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input, input2;
            List<BankAccount> bankAccounts = new List<BankAccount>();
            do
            {
                MainMenu();
                input = Console.ReadKey(true); Console.WriteLine(input.KeyChar);
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Clear();
                            string name, currency;
                            Console.Write("Введите свое имя: "); name = Console.ReadLine();
                            Console.Write("Введите валюту: "); currency = Console.ReadLine();
                            bankAccounts.Add(new BankAccount(name, currency));
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            if (bankAccounts.Count > 0)
                                foreach (BankAccount bankAccount in bankAccounts)
                                    bankAccount.InformationScore();
                            else throw new InvalidOperationException("Счета еще не открыты!");
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            uint _number;
                            int n = 0;
                            Console.Clear(); Console.Write("Введите номер счета: ");
                            _number = uint.Parse(Console.ReadLine());
                            if (bankAccounts.Any(x => x.number == _number))
                            {
                                foreach (var i in bankAccounts)
                                {
                                    if (i.number == _number) break;
                                    else n++;
                                }
                            }
                            else throw new InvalidOperationException("Такого счета нету!");
                            if (bankAccounts[n].close == false) throw new InvalidOperationException("Счет закрыт!");
                            do
                            {
                                AccountMenu();
                                input2 = Console.ReadKey(true); Console.WriteLine(input2.KeyChar);
                                switch (input2.Key)
                                {
                                    case ConsoleKey.D1:
                                        {
                                            Console.Clear();
                                            bankAccounts[n].CheckBalance();
                                            break;
                                        }
                                    case ConsoleKey.D2:
                                        {
                                            Console.Clear();
                                            bankAccounts[n].GetHistory();
                                            break;
                                        }
                                    case ConsoleKey.D3:
                                        {
                                            uint sum;
                                            Console.Write("Введите сумму пополнения: "); sum = uint.Parse(Console.ReadLine());
                                            bankAccounts[n].Replenish(sum);
                                            break;
                                        }
                                    case ConsoleKey.D4:
                                        {
                                            uint sum;
                                            Console.Write("Введите сумму снятия: "); sum = uint.Parse(Console.ReadLine());
                                            bankAccounts[n].Withdraw(sum);
                                            break;
                                        }
                                    case ConsoleKey.D5:
                                        {
                                            Console.Clear();
                                            bankAccounts[n].Close();
                                            Console.WriteLine("Счет закрыт!");
                                            break;
                                        }
                                    default: break;
                                }
                            } while (input2.Key != ConsoleKey.Escape || !bankAccounts[n].close);
                            break;
                        }
                    default: break;
                }
            } while (input.Key != ConsoleKey.Escape);
        }
        static void MainMenu()
        {
            Console.WriteLine("Программа 'Банк'\nДля выхода нажмите Esc");
            Console.Write
                (
                "1. Добавить новый счет.\n" +
                "2. Посмотреть список текущих.\n" +
                "3. Выбрать счет.\n" +
                "Выбрать: "
                );
        }
        static void AccountMenu()
        {
            Console.WriteLine("Меню аккаунта\nДля выхода нажмите Esc");
            Console.Write
                (
                "1. Проверить баланс.\n" +
                "2. Получить историю операций.\n" +
                "3. Пополнить счет.\n" +
                "4. Снять средства.\n" +
                "5. Закрыть счет.\n" +
                "Выбрать: "
                );
        }
    }
}