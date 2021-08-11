using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexandr_safarov.Hometask_01
{
    class Game : IGameControl, IGameProcess
    {
        private Card[] deck = new Card[52]; //карточная коллода

        private int numberOfPlayers; //количество игроков в игре

        private Card biggestCard; //переменная для хранения большей карты на столе

        private uint roundNumber = 0; //счетчик раундов в игре

        public Player winner;

        private LinkedList<Card> gameTable = new LinkedList<Card>(); //коллекция для хранения карт на столе

        private LinkedList<Card> _gameTable = new LinkedList<Card>(); //дополнительная коллекция, для хранения карт, которые не попали к игрокам

        private List<Player> players = new List<Player>(); //игроки

        private List<Player> playerWithSimilarCard = new List<Player>();//коллекция для хранения игроков с картами одинакового веса в раунде

        public Game(int numberOfPlayers) //конструктор 
        {
            this.numberOfPlayers = numberOfPlayers;
            InicializePlayers();
            InicializeDeck();
            Distribute();

        }

        private void Mix() //Метод для перемешивания коллоды. Использовал алгоритм Фишера-Йетса
        {
            Random rand = new Random();
            for (int i = deck.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                Card tmp = deck[j];
                deck[j] = deck[i];
                deck[i] = tmp;
            }
        }

        private void InicializeDeck() //Создание коллоды карт
        {
            int number = 0;
            uint weight = 0;
            for (int i = 2; i <= 10; i++)
            {
                deck[number++] = new Card("Spides", i.ToString(), weight);
                deck[number++] = new Card("Hearts", i.ToString(), weight);
                deck[number++] = new Card("Clubs", i.ToString(), weight);
                deck[number++] = new Card("Diamonds", i.ToString(), weight);
                weight++;
            }
            deck[number++] = new Card("Spides", "Jack", weight);
            deck[number++] = new Card("Hearts", "Jack", weight);
            deck[number++] = new Card("Clubs", "Jack", weight);
            deck[number++] = new Card("Diamonds", "Jack", weight);
            weight++;
            deck[number++] = new Card("Spides", "Queen", weight);
            deck[number++] = new Card("Hearts", "Queen", weight);
            deck[number++] = new Card("Clubs", "Queen", weight);
            deck[number++] = new Card("Diamonds", "Queen", weight);
            weight++;
            deck[number++] = new Card("Spides", "King", weight);
            deck[number++] = new Card("Hearts", "King", weight);
            deck[number++] = new Card("Clubs", "King", weight);
            deck[number++] = new Card("Diamonds", "King", weight);
            weight++;
            deck[number++] = new Card("Spides", "Ace", weight);
            deck[number++] = new Card("Hearts", "Ace", weight);
            deck[number++] = new Card("Clubs", "Ace", weight);
            deck[number++] = new Card("Diamonds", "Ace", weight);
            Mix();
            //deck.Reverse();

        }

        private void InicializePlayers() //Создание игроков
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player($"Игрок № {i}"));
            }

        }

        private void Distribute() //Метод для раздачи карт в начале игры
        {

            int cardInHand = 52 / numberOfPlayers;
            int remains = 52 - (numberOfPlayers * cardInHand);
            int cardNumber = 0;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                for (int k = 0; k < cardInHand; cardNumber++, k++)
                {
                    deck[cardNumber].PlayerId = i;
                    players[i].hand.Enqueue(deck[cardNumber]);
                }
            }
            if (remains != 0)
            {
                for (int i = cardNumber; i < deck.Length; i++)
                {
                    _gameTable.AddFirst(deck[i]);
                }

            }

        }

        public void GameTable() //Метод для отображения карточного стола и выкладывания карт вначале
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Игровой стол:\n" +
                              $"Раунд №{roundNumber}\n" +
                              $"Игроков: {players.Count}\n");
            foreach (Player item in players)
            {
                Console.WriteLine($"{item.Name} - {item.hand.Count} карт");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Player item in players)
            {
                gameTable.AddFirst(PutCards(item)); //выкладывание карт на стол
            }
            int i = 0;
            //int _PlayerId=players.Count;
            Console.WriteLine("Карты на столе:");
            foreach (Card item in gameTable)
            {
                //item.PlayerId = _PlayerId;
                if (i == players.Count)
                {
                    break;
                }
                Console.WriteLine($"Игрок {item.PlayerId} Карта:|{item.Suit}/{item.Value}|");
                //players[i].CardId = _PlayerId--;
                i++;
            }
            Console.ResetColor();

        }

        public void Round() //Запуск раунда
        {
            roundNumber++;
            GameTable();
            CheckBiggestCard();
            GetCards();
            //DropOutPlayer();
        }

        public Card PutCards(Player player) //Выкладывание карт на стол
        {
            return player.hand.Dequeue();
        }

        public void CheckBiggestCard() //Определение большей карты
        {
            biggestCard = gameTable.First(); //инициализируем карту для сравнения и выявления наивысшей

            bool isSimilarCard = false; //переменная для идентификации наличия карт одинакового веса 

            foreach (Card item in gameTable) //определение наибольшей карты
            {
                if (biggestCard.Weight < item.Weight)
                {
                    biggestCard = item;
                }
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Наибольшая карта |{biggestCard.Suit}/{biggestCard.Value}|\n" +
                              $"принадлежит Игроку {biggestCard.PlayerId}");
            Console.ResetColor();
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить....");
            Console.ReadKey();

        }

        public void GetCards() //Добавление карт игроку
        {

            foreach (Card item in gameTable)
            {

                players[biggestCard.PlayerId].hand.Enqueue(item);

            };
            gameTable.Clear();

        }

        public void DropOutPlayer() //Выбывание из игры
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].hand.Count == 0)
                {
                    players.Remove(players[i]);
                }
            }
        }

        public void ShowPlayers()
        {
            int i = 0;
            foreach (Player item in players)
            {
                Console.WriteLine($"Player {players[i].Name}/CardId{players[i].CardId}");
                i++;
            }
        }

        public void PrintDeck()
        {
            int i = 0;
            foreach (Card card in deck)
            {
                Console.WriteLine($"|{card.Suit}/{card.Value}/{card.PlayerId}|");
                i++;
            }

        }

        public void PrintRemains()
        {

            int i = 0;
            foreach (Card card in _gameTable)
            {
                Console.WriteLine($"|{card.Suit}/{card.Value}/{card.Weight}|");
                i++;
            }
        }
    }

}