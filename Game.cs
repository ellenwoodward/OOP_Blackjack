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
    internal class Game
    {
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }
        public Casino Casino { get; set; }


        public Game(Player player, Dealer dealer, Casino casino)
        {
            //create objects
            Player = player;
            Dealer = dealer;
            Casino = casino;
        }

        public void Start()
        {
            Console.WriteLine("\nStarting new round\n");

            // deal cards to player and dealer
            Dealer.DealCardsToPlayer(2, Player);
            Dealer.DealCardsToDealer(2);
        }

        public void ClearHands() // remove all existing cards from hands
        {
            Player.playerHand.hand.Clear();
            Dealer.dealerHand.hand.Clear();
        }

        public void PlayerTurn()
        {
            Console.WriteLine(@"  ___ _                   _      _____              
 | _ \ |__ _ _  _ ___ _ _( )___ |_   _|  _ _ _ _ _  
 |  _/ / _` | || / -_) '_|/(_-<   | || || | '_| ' \ 
 |_| |_\__,_|\_, \___|_|   /__/   |_| \_,_|_| |_||_|
             |__/                                   ");
            Sleep();
            Player.DisplayHand();
        }

        public void DealerTurn()
        {
            Console.WriteLine("\n" + @"  ___           _         _      _____              
 |   \ ___ __ _| |___ _ _( )___ |_   _|  _ _ _ _ _  
 | |) / -_) _` | / -_) '_|/(_-<   | || || | '_| ' \ 
 |___/\___\__,_|_\___|_|   /__/   |_| \_,_|_| |_||_|
                                                    ");
            Sleep();
            Dealer.DisplayHand();
        }

        public void PlayerTwist() // player takes another card
        {
            Dealer.DealCardsToPlayer(1, Player);
            Player.DisplayHand();
        }

        public void DealerTwist() // dealer takes another card
        {
            Dealer.DealCardsToDealer(1);
            Dealer.DisplayHand();
        }

        public bool IsPlayerBusted() // player hand over 21
        {
            return Player.IsBusted();
        }

        public bool IsDealerBust() // dealer hand over 21
        {
            return Dealer.IsBusted();
        }

        public void PlayerWins()
        {
            Sleep();
            Console.WriteLine("\nPLAYER WINS!");
            Player.Wins++; // increase player wins
            Sleep();
        }

        public void DealerWins()
        {
            Sleep();
            Console.WriteLine("\nDEALER WINS!");
            Dealer.Wins++; // increase dealer wins
            Sleep();
        }

        public void DisplayResults()
        {
            Console.WriteLine($"\nCurrent results:\nPlayer wins = {Player.Wins}\nDealer Wins = {Dealer.Wins}");
            Sleep();
        }

        public void Sleep()
        {
            Thread.Sleep(500);
        }
    }
}
