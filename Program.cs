/*
 * Ellen Woodward
 * Blackjack
 * Submitted : 
 */ 

using Blackjack;

Console.WriteLine(@"                                                                                                                 
 ________  ___       ________  ________  ___  __          ___  ________  ________  ___  __                           
|\   __  \|\  \     |\   __  \|\   ____\|\  \|\  \       |\  \|\   __  \|\   ____\|\  \|\  \                         
\ \  \|\ /\ \  \    \ \  \|\  \ \  \___|\ \  \/  /|_     \ \  \ \  \|\  \ \  \___|\ \  \/  /|_                       
 \ \   __  \ \  \    \ \   __  \ \  \    \ \   ___  \  __ \ \  \ \   __  \ \  \    \ \   ___  \                      
  \ \  \|\  \ \  \____\ \  \ \  \ \  \____\ \  \\ \  \|\  \\_\  \ \  \ \  \ \  \____\ \  \\ \  \                     
   \ \_______\ \_______\ \__\ \__\ \_______\ \__\\ \__\ \________\ \__\ \__\ \_______\ \__\\ \__\                    
    \|_______|\|_______|\|__|\|__|\|_______|\|__| \|__|\|________|\|__|\|__|\|_______|\|__| \|__|                    
                                                                                                          ");

bool newRound = true;
bool isPotEmpty = false;

// create instances of objects
Player player = new Player();
Dealer dealer = new Dealer();
Casino casino = new Casino();

// create new game
Game game = new Game(player, dealer, casino);

// asks user for an initial pool, checks to make sure it is a number
bool correctPot = false;
while (!correctPot)
{
    Console.Write("\nEnter pot amount: ");
    string potInput = Console.ReadLine();

    correctPot = casino.isIntPot(potInput);
}


while (newRound && !isPotEmpty) // game continues if user wants a new round AND if their pot is not empty
{
    Console.WriteLine($"\nPot remaining: {casino.Pot:c}");

    int playersFinalScore = 0, dealersFinalScore = 0;

    Deck deck = new Deck();
    deck.ShuffleDeck();

    game.ClearHands(); // gets rid of existing cards in player and dealer hands

    // asks user for bet, checks to make sure it is a number and not bigger than pot
    bool correctBet = false;
    while (!correctBet)
    {
        Console.Write("\nEnter bet for this round: ");
        string betInput = Console.ReadLine();

        correctBet = casino.IsCorrectBet(betInput);
    }

    dealer.NewDeck(deck); // gives dealer the new shuffled deck
    game.Start();

    #region Player's Turn
    game.PlayerTurn(); // starts player turn

    bool isPlayerStillPlaying = true;
    bool isDealerStillPlaying = true;

    while (isPlayerStillPlaying) // while player is not bust
    {
        Console.Write("\nDo you want to stick or twist? (s/t) : ");
        string userChoice = Console.ReadLine().ToLower();

        switch (userChoice)
        {
            case "t":
                game.PlayerTwist();
                isPlayerStillPlaying = !(game.IsPlayerBusted()); // check if player is busted
                break;
            case "s":
                playersFinalScore = player.playerHand.TotalHandValue();
                isPlayerStillPlaying = false;
                // exit game - dealers turn
                break;
            default:
                Console.WriteLine("Invalid input, try again");
                isPlayerStillPlaying = true;
                break;
        }
    }

    if (game.IsPlayerBusted())
        Console.WriteLine("\nPlayer busted!");

    game.Sleep();
    #endregion Player's Turn

    #region Dealer's Turn
    game.DealerTurn(); // start dealer turn

    while (isDealerStillPlaying)
    {
        if (dealer.dealerHand.TotalHandValue() >= 17)
        {
            dealersFinalScore = dealer.dealerHand.TotalHandValue();
            isDealerStillPlaying = false; // dealer's turn is finished
        }
        else
        {
            game.DealerTwist();
            isDealerStillPlaying = !(game.IsDealerBust());
        }
    }
    #endregion Dealer's Turn

    #region Game Results
    // once both turns are over we see who wins
    if (game.IsPlayerBusted() && !(game.IsDealerBust())) // if player is busted and dealer is not
    {
        game.DealerWins();
        casino.CasinoWin();
    }
    else if (!(game.IsPlayerBusted()) && game.IsDealerBust()) // if player is not busted and dealer is
    {
        Console.WriteLine("\nDealer is busted");
        game.Sleep();
        game.PlayerWins();
        casino.CasinoLoss();
    }
    else if (game.IsPlayerBusted() && game.IsDealerBust()) // if player and dealer are busted
    {
        Console.WriteLine("\nPlayer and dealer are bust");
        game.Sleep();
        game.DealerWins();
        casino.CasinoWin();
    }
    else if (!(game.IsPlayerBusted()) && !(game.IsDealerBust())) // if neither player or dealer are bust compare hand scores
    {
        Console.WriteLine($"\nPlayer score : {playersFinalScore} and Dealer score : {dealersFinalScore}");

        if (playersFinalScore > dealersFinalScore)
        {
            game.PlayerWins();
            casino.CasinoLoss();

        }
        else if (playersFinalScore < dealersFinalScore)
        {
            game.DealerWins();
            casino.CasinoWin();
        }
        else
            Console.WriteLine("\nDRAW - No one wins"); // if scores are equal no one wins
    }

    game.DisplayResults();
    #endregion Game Results

    // do you want to continue?
    bool correctInput = false;

    while (!correctInput)
    {
        Console.Write("\nDo you want to play again? (y/n) : ");
        string userInputContinue = Console.ReadLine().ToLower();

        switch (userInputContinue)
        {
            case "y":
                newRound = true;
                correctInput = true;
                Console.Clear();
                // create a new round
                break;
            case "n":
                newRound = false;
                correctInput = true;
                // exit game
                break;
            default:
                Console.WriteLine("Invalid input, try again");
                correctInput = false;
                break;
        }
    }

    isPotEmpty = casino.IsPotEmpty();
}

if (isPotEmpty == true)
    Console.WriteLine("You have run out of money!");
else
    Console.WriteLine($"\nYou have {casino.Pot:c} left in your pot.");

Console.WriteLine("\nThank you for playing!");
Console.ReadLine();
