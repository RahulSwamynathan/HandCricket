using HandCricketApplication.Implementations;
using HandCricketApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandCricketApplication.Context
{
    class Handling : ScoreCalculator, IHandling, IPlayerDetails
    {
        private RandomGenerator _randomGenerator;
        private int FirstValue;
        private int SecondValue;

        public Handling()
            : base(scores: new Dictionary<string, int>())
        {
            _randomGenerator = new RandomGenerator();
        }

        private bool Loopfunction(int a, int b, string battingPerson, string bowlingPerson)
        {
            bool checker = false;
            checker = ScoreCreater(a, b, battingPerson, bowlingPerson);

            /*
             * Only if sorce is not equal
             */
            while (!checker)
            {
                /*
                 * Checking that the second batsam got more then first - to stop looping
                 */
                if (Rounds == 1 && Scores.Where(x => x.Key == bowlingPerson).First().Value < BattingCount)
                {
                    checker = true;
                    Rounds = 2;
                    AddPlayerScore(battingPerson, BattingCount);
                }
                else
                {
                    /*
                     * Next sequence if the numbers not equal
                     */
                    Console.WriteLine($"{battingPerson} throws {FirstValue},{bowlingPerson} throws {SecondValue}. {battingPerson}'s Score is {BattingCount}");
                    UpdateRandomNumber();
                    checker = ScoreCreater(FirstValue, SecondValue, battingPerson, bowlingPerson);
                }
            }
            return checker;
        }

        void IHandling.PlayingHandle(string battingPerson, string bowlingPerson)
        {
            //Scores = new Dictionary<string, int>();
            UpdateRandomNumber();
            bool checker = Loopfunction(FirstValue, SecondValue, battingPerson, bowlingPerson);

            /*
             * Until the first batsem got out
             */
            while (checker)
            {
                /*
                 * Prints the user numbers and continue the sequence if the round is not more than 2
                 */
                Console.WriteLine($"{battingPerson} throws {FirstValue},{bowlingPerson} throws {SecondValue}. {battingPerson}'s Score is {BattingCount}.");

                /*
                 * Only after two sequence complete - means both the players got chance to play
                 */
                if (Rounds == 2)
                {
                    /*
                    * Checking that the second batsam got more then first - to stop looping
                    */
                    if (Scores.Where(x => x.Key == bowlingPerson).First().Value < BattingCount)
                    {
                        FinalScore();
                        Console.WriteLine(); 
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{battingPerson} got out"); Console.WriteLine(); Console.ResetColor();
                        FinalScore();
                        Console.WriteLine(); 
                    }
                    checker = false;
                }
                else
                {
                    /*
                     * Swaping the bowler and batsmen if the first set is completed
                     */
                    BattingCount = 0;
                    string value = battingPerson;
                    UpdateRandomNumber();
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"{battingPerson} got out"); Console.WriteLine(); Console.ResetColor();
                    Console.WriteLine($"{bowlingPerson} is batting...");
                    checker = Loopfunction(FirstValue, SecondValue, battingPerson = bowlingPerson, bowlingPerson = value);
                }
            }
        }

        /// <summary>
        ///  Updates the new set of random numbers
        /// </summary>
        private void UpdateRandomNumber()
        {
            FirstValue = _randomGenerator.RandomNumbers(1, 6);
            SecondValue = _randomGenerator.RandomNumbers(1, 6);
        }
    }
}
