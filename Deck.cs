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
    internal class Deck 
    {
        public List<Card> CardDeck { get; set; }
        public List<Card> ShuffledDeck { get; set; }

        public Deck()
        {
            CardDeck = new List<Card>();

            for (int i = 0; i < Enum.GetValues(typeof(Suit)).Length; i++)
            {
                for (int j = 1; j <= Enum.GetValues(typeof(Face)).Length; j++)
                {
                    Card card = new Card((Suit)i, (Face)j); // create a card with a each suit and each value
                    CardDeck.Add(card); // add to deck
                }
            }
        }

        public void ShuffleDeck()
        {
            Random random = new Random();
            ShuffledDeck = CardDeck.OrderBy(a => random.Next()).ToList<Card>(); // randomises list of cards , i.e. shuffle them
        }

        public Card DrawCard()
        {
            Card cardDrawn = ShuffledDeck[0]; // takes first card in shuffled deck
            ShuffledDeck.Remove(cardDrawn); // removes card from deck
            return cardDrawn;
        }

        // displays deck - used for testing
        public void DisplayInfo()
        {
            foreach (Card card in CardDeck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"There are {CardDeck.Count} cards in the deck");
        }
    }
}
