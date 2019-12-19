using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    class Deck
    {
<<<<<<< HEAD
        private List<Card> Cards = new List<Card>();
=======
        private List<Card> cards = new List<Card>();
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80

        public Deck()
        {
            string[] suits = { "H", "D", "C", "S" };
<<<<<<< HEAD
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }; 
            
            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    Cards.Add(new Card(value, suit)); 
=======
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach(string suit in suits)
            {
                foreach(string value in values)
                {
                    cards.Add(new Card(value, suit));
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
                }
            }
        }

<<<<<<< HEAD
        public void shuffle()
=======
        public void Shuffle()
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
        {

        }

        public Card Deal()
        {
<<<<<<< HEAD
            Card result = Cards[0];
            Cards.RemoveAt(0);
            return result; 
        }

=======
            Card result = cards[0];
            cards.RemoveAt(0);
            return result;
        }
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
    }
}
