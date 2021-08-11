using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexandr_safarov.Hometask_01
{
    class Player
    {
        private string name;

        private int _cardId;
        public string Name { get { return name; } }

        public int CardId
        {
            get { return _cardId; }
            set { _cardId = value; }
        }

        public Queue<Card> hand = new Queue<Card>();
        public Player(string name)
        {
            this.name = name;
        }
        public void ShowHand() //help
        {
            foreach (Card item in hand)
            {
                Console.WriteLine(item);
            }
        }

    }
}