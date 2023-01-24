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
    internal class Hand 
    {
        public List<Card> hand { get; set; }

        public Hand()
        {
            hand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public int TotalHandValue()
        {
            int total = 0;
            hand.Sort(); // arrange hand in accending card value

            for(int i = 0; i < hand.Count; i++)
            {
                // makes an ace either 1 or 11 depending on total value of cards before it
                if (hand[i].Face == Face.Ace)
                {
                    if (total <= 10)
                        total += hand[i].Value; 
                    else
                        total += 1; // if total before ace is greater than 10, make ace 1
                }
                else
                    total += hand[i].Value; // total up value of cards
            }

            return total;
        }

        public bool IsBusted()
        {
            return (TotalHandValue() > 21); // hand is busted if total of hand is greater than 21
        }

        public override string ToString() // print current hand to console
        {
            string handInfo = "\nCurrent hand:\n----------------\n";

            for (int i = 0; i < hand.Count; i++)
            {
                handInfo += hand[i] + "\n";
            }

            handInfo += $"----------------\nTotal score: {TotalHandValue()}";

            return handInfo;

        }

    }
}
