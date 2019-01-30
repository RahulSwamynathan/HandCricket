using System;
using System.Collections.Generic;
using System.Linq;

namespace HandCricketApplication
{
    class PlayingOperation : IPlayOperation
    {
        private IHandling _playHandling {get; set;}
        public PlayingOperation(Handling handling)
        {
            _playHandling = handling; 
        }

        public PlayingOperation()
            :this(new Handling())
        {

        }

        void IPlayOperation.SinglePlay(string battingPerson, string bowlingPerson)
        {
            Console.WriteLine($"{battingPerson} is batting...");
            _playHandling.PlayingHandle(battingPerson, bowlingPerson);
        }



        public void SetBatsmanBowler(IPlayOperation operation)
        {
            Console.Write("Who is batting? ");
            string batsman = Console.ReadLine();
            Console.Write("Who is bowling? ");
            string bowler = Console.ReadLine();
            Console.WriteLine("{0} is batting", batsman);
            operation.SinglePlay(batsman, bowler);
        }

        void IPlayOperation.GroupPlaying(params string[] players)
        {
            int j = 1;
            IHandling handling;
            for (int i = 0; i < players.Distinct().Count(); i++)
            {
                if (j < players.Distinct().Count())
                {
                    while (j < players.Distinct().Count())
                    {
                        if (i != 0 && j + 1 > players.Length - 1)
                        {
                            j = players.Distinct().Count() + 1;
                        }
                        else
                        {
                            handling = new Handling();
                            Console.WriteLine($"{players[i]} is batting...");
                            handling.PlayingHandle(players[i], i == j ? players[j + 1] : players[j]);
                        }
                        j++;
                    }
                    j = 0;
                }
            }
        }
    }
}
