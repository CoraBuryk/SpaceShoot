using System;

namespace Assets.Space.Scripts.Gameplay
{
    public static class ScoreCounter
    {
        public static int Counter { get; set; }

        public static event Action ScoreChange;

        public static void ChangeScore(int newScore)
        {
            Counter = newScore;
            ScoreChange?.Invoke();
        }
    }
}
