using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketApplication.Repository
{
      interface IPlayerDetails
      {
            void AddPlayerScore(string battingPerson, int battingCount);
            void GetIndividualScore();
            void AddWinners(string player);
            void GetNoOfWins();
      }
}
