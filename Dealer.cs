/*
 * Ellen Woodward
 * Blackjack
 * Submitted : 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Dealer
    {
        public Deck Deck { get; set; }
        public Hand dealerHand { get; set; }
        public int Wins { get; set; }

        public Dealer()
        {
            dealerHand = new Hand();
            Wins = 0;
        }

        public void NewDeck(Deck deck) // each round dealer gets a new deck
        {
            Deck = deck;
        }

        public void DealCardsToPlayer(int amount, Player player)
        {
            string cardMessage = (amount == 1) ? "card" : "cards"; // chooses which text to output
            Console.Write($"\nDealing new {cardMessage} for player");

            for(int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(" ."); // prints . . . with time inbetween
            }

            Thread.Sleep(300);
            Console.WriteLine("\n");

            for (int i = 0; i < amount; i++)
            {
                player.AddCardToHand(Deck.DrawCard()); // draw cards from the deck and add them to player hand
            }
        }

        public void DealCardsToDealer(int amount) // practically same as above
        {
            string cardMessage = (amount == 1) ? "card" : "cards";
            Console.Write($"\nDealing new {cardMessage} for dealer");

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(" .");
            }

            Thread.Sleep(300);
            Console.WriteLine("\n");

            for (int i = 0; i < amount; i++)
            {
                dealerHand.AddCard(Deck.DrawCard());
            }
        }

        public bool IsBusted() // dealer hand is over 21
        {
            return dealerHand.IsBusted();
        }

        public void DisplayHand()
        {
            Console.WriteLine(dealerHand);
        }
    }
}
