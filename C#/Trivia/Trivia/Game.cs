using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia 
{
    public class Game
    {
        readonly List<Player> players = new List<Player>();
        private readonly Questions _questionsByCategory = new Questions();
        int currentPlayer = 0;
        bool isGettingOutOfPenaltyBox;
        private int _nbPursesToWin = 6;

        public Game()
        {
            
        }

        public Game(int nbPursesToWin)
        {
            _nbPursesToWin = nbPursesToWin;
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {

            Player player = new Player(playerName, _nbPursesToWin);
            
            players.Add(player);

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            
            return players.Count;
        }

        public void roll(int roll)
        {
            
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (players[currentPlayer].IsInPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");

                    players[currentPlayer].changePosition(roll);

                    Console.WriteLine(players[currentPlayer]
                                      + "'s new location is "
                                      + players[currentPlayer].Position);
                    Console.WriteLine("The category is " + currentCategory());
                    _questionsByCategory.AskQuestion(currentCategory());
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                players[currentPlayer].changePosition(roll);

                Console.WriteLine(players[currentPlayer]
                        + "'s new location is "
                        + players[currentPlayer].Position);
                Console.WriteLine("The category is " + currentCategory());
                _questionsByCategory.AskQuestion(currentCategory());
            }

        }


        private String currentCategory()
        {
            if (players[currentPlayer].Position == 0 || players[currentPlayer].Position == 4 ||
                players[currentPlayer].Position == 8)
            {
                return "Pop";
            }

            if (players[currentPlayer].Position == 1 || players[currentPlayer].Position == 5)
            {
                return "Science";
            }

            if (players[currentPlayer].Position == 2 || players[currentPlayer].Position == 6 ||
                players[currentPlayer].Position == 10)
            {
                return "Sports";
            }

            return "Rock";
        }

        public bool wasCorrectlyAnswered()
        {
            if (players[currentPlayer].IsInPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    players[currentPlayer].WinOnePurse();
                    Console.WriteLine(players[currentPlayer]
                            + " now has "
                            + players[currentPlayer].Purses
                            + " Gold Coins.");

                    bool winner = players[currentPlayer].didPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;
                    return true;
                }



            }
            else
            {

                Console.WriteLine("Answer was correct!!!!");
                players[currentPlayer].WinOnePurse();
                Console.WriteLine(players[currentPlayer]
                        + " now has "
                        + players[currentPlayer].Purses
                        + " Gold Coins.");

                bool winner = players[currentPlayer].didPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            players[currentPlayer].setIsInPenaltyBox(true);

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }

    }

}
