using HandCricketApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandCricketApplication
{
      abstract class ScoreCalculator : IScoreCalculator
      {
            private Dictionary<string, int> _score;
            private static Dictionary<string, int> Individuals = new Dictionary<string, int>();
            private static Dictionary<string, int> Winers = new Dictionary<string, int>();
            public Dictionary<string, int> Scores
            {
                  get
                  {
                        return _score ?? new Dictionary<string, int>();
                  }
                  set
                  {
                        _score = value;
                  }
            }

            public int Rounds { get; set; }

            public int BattingCount { get; set; }

            protected ScoreCalculator(Dictionary<string, int> scores)
            {
                  Scores = scores;
            }

            /// <summary>
            /// Checks wheather the batsem is out or not.
            /// Returns true if the scores are equal
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="battingPerson"></param>
            /// <param name="bowlingPerson"></param>
            /// <returns></returns>
            public bool ScoreCreater(int a, int b, string battingPerson, string bowlingPerson)
            {
                  if (a != b)
                  {
                        BattingCount = BattingCount + a;
                  }
                  if (a == b)
                  {
                        AddPlayerScore(battingPerson, BattingCount);
                        Rounds++;
                        return true;
                  }
                  return false;
            }

            public void FinalScore()
            {
                  int maxScore = Scores.Max(x => x.Value);
                  Console.ForegroundColor = ConsoleColor.White;
                  Console.WriteLine(maxScore == 0 ? "Match is Draw" : $"Winner is {Scores.Where(x => x.Value == Scores.Max(y => y.Value)).Distinct().First().Key} and the score is {maxScore}");
                  Console.ResetColor();
                  AddWinners(Scores.Where(x => x.Value == Scores.Max(y => y.Value)).Distinct().First().Key);
            }

            public void AddPlayerScore(string battingPerson, int battingCount)
            {
                  Scores.Add(battingPerson, battingCount);
                  IndividualScores(battingPerson, battingCount);
            }

            public void IndividualScores(string battingPerson, int battingCount)
            {
                  Dictionary<string, int> Holder = new Dictionary<string, int>();
                  if (Individuals != null)
                  {
                        if (Individuals.ContainsKey(battingPerson))
                        {
                              KeyValuePair<string, int> common = Individuals.Where(x => x.Key == battingPerson).First();
                              Holder.Add(common.Key, common.Value);
                              Individuals[battingPerson] = Holder.Where(x => x.Key == Individuals.Where(y => y.Key == x.Key).First().Key).First().Value + battingCount;
                        }
                        else
                        {
                              Individuals.Add(battingPerson, battingCount);
                        }
                  }
            }

            public void GetIndividualScore()
            {
                  if (Individuals != null)
                  {
                        foreach (var item in Individuals.OrderByDescending(x => x.Value))
                        {
                              Console.ForegroundColor = ConsoleColor.DarkGreen;
                              Console.WriteLine($"{item.Key}'s session score is {item.Value}");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"Highest run getter of the Session was {Individuals.Where(y => y.Value == Individuals.Max(j => j.Value)).Distinct().First().Key} with the Score of {Individuals.Max(x => x.Value)}");
                        Console.ResetColor();
                  }
            }

            public void AddWinners(string player)
            {
                  Dictionary<string, int> Holder = new Dictionary<string, int>();
                  if (Winers != null)
                  {
                        if (Winers.ContainsKey(player))
                        {
                              KeyValuePair<string, int> common = Winers.Where(x => x.Key == player).First();
                              Holder.Add(common.Key, common.Value);
                              Winers[player] = Holder.Where(x => x.Key == Winers.Where(y => y.Key == x.Key).First().Key).First().Value + 1;
                        }
                        else
                        {
                              Winers.Add(player, 1);
                        }
                  }
            }

            public void GetNoOfWins()
            {
                  if (Winers != null)
                  {
                        foreach (var item in Winers.OrderByDescending(x => x.Value))
                        {
                              Console.ForegroundColor = ConsoleColor.DarkMagenta;
                              Console.WriteLine($"{item.Key} Won {item.Value} matches");
                        }
                        Console.ResetColor();
                  }
            }
      }
}
