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
    public class Casino
    {
        public int Pot { get; set; }
        public int Bet { get; set; }

        public Casino()
        {
            Pot = 0;
            Bet = 0;
        }

        public void CasinoWin() // if dealer wins, take bet away from pot
        {
            Pot -= Bet;
        }

        public void CasinoLoss() // if player wins, double bet and add it to pot
        {
            Pot += (Bet * 2);
        }

        public bool IsPotEmpty()
        {
            return (Pot <= 0);
        }

        public bool IsCorrectBet(string bet) // ensure bet is a whole number, greater than 0 and is not bigger then pot
        {
            int output;

            bool correctBet = int.TryParse(bet, out output);

            if (correctBet)
            {
                Bet = output;

                if (Bet <= Pot)
                {
                    if (Bet > 0)
                        return true; // if all conditions are true, return true
                    else
                    {
                        Console.WriteLine("Please enter a value greater than 0");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a lower bet");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Please enter a whole number");
                return false;
            }
        }

        public bool isIntPot(string pot) // ensures pot entered is a number and greater than 0
        {
            int output;

            bool correctPot = int.TryParse(pot, out output);

            if (correctPot)
            {
                Pot = output; // only after check if output is an int is it assigned to Pot

                if (Pot > 0)
                    return true;
                else
                {
                    Console.WriteLine("Please enter a number greater than 0");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Please enter a whole number");
                return false;
            } 
        }
    }
}

