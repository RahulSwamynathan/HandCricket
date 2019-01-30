namespace HandCricketApplication.Repository
{
      interface IPlayOperation
    {
        void SinglePlay(string battingPerson, string bowlingPerson);

        void GroupPlaying(params string[] players);
    }
}
