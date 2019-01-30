using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketApplication.Repository
{
      interface IScoreCalculator
      {
            void FinalScore();
            Dictionary<string, int> Scores { get; set; }
            int Rounds { get; set; }
            int BattingCount { get; set; }
            bool ScoreCreater(int a, int b, string battingPerson, string bowlingPerson);
      }
}
