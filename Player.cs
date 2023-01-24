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
    internal class Player
    {
        public int Wins { get; set; }
        public Hand playerHand { get; set; }

        public Player()
        {
            playerHand = new Hand();
            Wins = 0;
        }

        public void AddCardToHand(Card card)
        {
            playerHand.AddCard(card); // add a card to the player hand
        }

        public void DisplayHand()
        {
            Console.WriteLine(playerHand);
        }

        public bool IsBusted() // player hand is over 21
        {
            return playerHand.IsBusted();
        }
    }
}
