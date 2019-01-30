using System;

namespace HandCricketApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Handling handling = new Handling();
            IPlayOperation playingOperation = new PlayingOperation(handling);
            playingOperation.GroupPlaying("User1",
                                          "User2",
                                          "User3",
                                          "User4",
                                          "User6");
            handling.GetIndividualScore();
            handling.GetNoOfWins();
        }
    }
}
