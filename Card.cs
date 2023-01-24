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
using System.Xml.Linq;

namespace Blackjack
{
    public enum Suit // list of suits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Face // list of faces
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    internal class Card : IComparable<Card>
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; set; }

        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;

            switch (Face)
            {
                case Face.Ten:
                case Face.Jack:
                case Face.Queen:
                case Face.King:
                    Value = 10; // set value of face cards and ten to 10
                    break;
                case Face.Ace:
                    Value = 11; // initially set ace to 11
                    break;
                default:
                    Value = (int)Face; // set rest of cards to their face value
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format($"{Face} of {Suit}");
        }

        public int CompareTo(Card that)
        {
            return this.Value.CompareTo(that.Value); // compare values of cards
        }
    }
}
