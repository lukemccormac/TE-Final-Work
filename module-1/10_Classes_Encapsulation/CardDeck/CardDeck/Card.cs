using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public bool IsFaceUp { get; set; }

        public Card ()
        {
<<<<<<< HEAD

=======
            IsFaceUp = false;
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
        }

        public Card(string value, string suit)
        {
            Value = value;
<<<<<<< HEAD
            Suit = Suit; 
=======
            Suit = suit;
            IsFaceUp = false;
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
        }

        public bool Flip()
        {
<<<<<<< HEAD
            IsFaceUp = !IsFaceUp; //inverts bool value stored inside IsFaceUp
            return IsFaceUp; 
        }

        public override string ToString() //lets my create my own implimentation for ToString due to override 
        {
            return Value + " " + Suit; 
=======
            IsFaceUp = !IsFaceUp;
            return IsFaceUp;
        }

        public override string ToString()
        {
            return Value + " " + Suit;
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
        }
    }
}
