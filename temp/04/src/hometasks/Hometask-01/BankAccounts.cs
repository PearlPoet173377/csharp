using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UdincevBogdan.Hometask_01
{
    class BankAccount
    {
        public string name;
        public string currency;
        private uint _number;
        public uint number { get { return _number; } }
        private DateTime _openScore;
        private DateTime _closeScore;
        private bool _close = true;
        public bool close { get { return _close; } }
        private uint _balance;
        private List<string> _history = new List<string>();
        Random rand = new Random();
        uint num = 1;

        public BankAccount() { }
        public BankAccount(string name, string currency)
        {
            _number = (uint)rand.Next(100000, 999999);
            this.name = name;
            _openScore = DateTime.Now;
            this.currency = currency;
            _balance = 0;
        }

        public void CheckBalance()
        {
            if (_close)
            {
                Console.WriteLine($"Баланс счета под номером {_number} равен: {_balance} {currency}.");
                HistoryAdd("Проверка баланса", _balance, true);
            }
            else
            {
                throw new InvalidOperationException($"Can't perform operation {System.Reflection.MethodInfo.GetCurrentMethod().Name} on a closed account {_number}");
            }
        }
        public void Close()
        {
            if (_close)
            {
                if (_balance > 0) Withdraw(_balance);
                _closeScore = DateTime.Now; _close = false;
                HistoryAdd("Закрытие счета", _balance, true);
            }
            else
            {
                throw new InvalidOperationException($"Can't perform operation {System.Reflection.MethodInfo.GetCurrentMethod().Name} on a closed account {_number}");
            }
        }
        public void GetHistory()
        {
            if (_close)
            {
                if (_history.Count != 0) foreach (var i in _history) Console.WriteLine(i);
                else Console.WriteLine("У счета нету истории операций!");
            }
            else
            {
                throw new InvalidOperationException($"Can't perform operation {System.Reflection.MethodInfo.GetCurrentMethod().Name} on a closed account {_number}");
            }
        }
        public void Replenish(uint sum, string operationComments = "")
        {
            if (_close)
            {
                decimal balanceBefore = _balance;
                _balance += sum;
                HistoryAdd("Пополнение счета", balanceBefore, true, sum, operationComments);
            }
            else
            {
                throw new InvalidOperationException($"Can't perform operation {System.Reflection.MethodInfo.GetCurrentMethod().Name} on a closed account {_number}");
            }
        }
        public void Withdraw(uint sum, string operationComments = "")
        {
            if (_close)
            {
                decimal balanceBefore = _balance;
                if (sum > _balance)
                {
                    HistoryAdd("Снятие со счета", balanceBefore, false, sum, operationComments = "Неудача");
                }
                else
                {
                    _balance -= sum; HistoryAdd("Снятие со счета", balanceBefore, true, sum, operationComments);
                }
            }
            else
            {
                throw new InvalidOperationException($"Can't perform operation {System.Reflection.MethodInfo.GetCurrentMethod().Name} on a closed account {_number}");
            }
        }
        public void InformationScore()
        {
            string status, closeDate = "Открыт";
            if (_close) { status = "Открыт"; }
            else { status = "Закрыт"; closeDate = $"{_closeScore}"; }
            HistoryAdd("Запрос выписки", _balance, true);
            Console.WriteLine("\nИнформация по счету:\n" +
                             $"Номер счета: {_number}\n" +
                             $"Владелец: {name}\n" +
                             $"Статуc: {status}\n" +
                             $"Дата открытия: {_openScore}\n" +
                             $"Дата закрытия: {closeDate}\n" +
                             $"Баланс: {_balance} {currency}.\n");
        }

        private void HistoryAdd(string operationType, decimal balanceBefore, bool operationStatus, decimal operationSum = 0, string operationComments = "")
        {
            var sign = ' ';
            if (operationType == "Пополнение счета") sign = '+';
            else if (operationType == "Снятие со счета") sign = '-';
            else sign = ' ';

            var status = operationStatus ? "Успешно" : "Отказано";

            _history.Add
                (
                $"----- Операция №{num} -----\n" +
                $"Время операции: {DateTime.Now}\n" +
                $"Тип операции: {operationType}\n" +
                $"Сумма: {sign}{operationSum} {currency}.\n" +
                $"Статус операции: {status}\n" +
                $"Комментарий: {operationComments}\n" +
                $"Баланс перед операцией: {balanceBefore}\n" +
                $"Баланс после операции: {_balance}.\n"
                );
            num++;
        }
        private void HistoryAdd(string operationType, decimal balanceBefore, bool operationStatus)
        {
            var status = operationStatus ? "Успешно" : "Отказано";

            _history.Add
                (
                $"----- Операция №{num} -----\n" +
                $"Время операции: {DateTime.Now}\n" +
                $"Тип операции: {operationType}\n" +
                $"Статус операции: {status}\n"
                );
            num++;
        }
    }
}