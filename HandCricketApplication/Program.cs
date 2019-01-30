using System;

namespace HandCricketApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Handling handling = new Handling();
            IPlayOperation playingOperation = new PlayingOperation(handling);
            playingOperation.GroupPlaying("Rahul", "Deva", "Mani", "Shyam", "Sairam", "Venkat", "Elango", "Ashok", "Dinesh", "Sudhershan",
                "Aravind", "Arun", "Deepak", "Syed");
            handling.GetIndividualScore();
            handling.GetNoOfWins();
        }
    }
}
