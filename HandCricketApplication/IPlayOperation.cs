using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandCricketApplication
{
    interface IPlayOperation
    {
        void SinglePlay(string battingPerson, string bowlingPerson);

        void GroupPlaying(params string[] players);
    }
}
