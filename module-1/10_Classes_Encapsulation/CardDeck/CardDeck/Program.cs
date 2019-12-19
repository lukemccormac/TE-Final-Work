using System;

namespace CardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD

=======
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
            Console.WriteLine("Hello World!");

            Card myCard = new Card();
            myCard.Suit = "H";
            myCard.Value = "Q";

            Card myCard2 = new Card("A", "S");

<<<<<<< HEAD
            
            Console.WriteLine(myCard);
            Console.WriteLine(myCard2);

            Deck myDeck = new Deck();
            Console.WriteLine(myDeck.Deal()); 

            Console.ReadLine(); 
=======
            Console.WriteLine(myCard);
            Console.WriteLine(myCard2);


            Deck myDeck = new Deck();
            Console.WriteLine(myDeck.Deal());

            Console.ReadLine();
>>>>>>> de43434c5f845acca0a5a502b9ea508f2d4d3a80
        }
    }
}
