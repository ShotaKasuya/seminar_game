using System;
using Domain.IModel.InGame;

namespace Model.InGame
{
    public class ScoreModel : IScoreModel
    {
        public int Score { get; private set; }

        public int RevisedScore
        {
            set
            {
                Score = value;
                OnScoreChange?.Invoke(value);
            }
        }

        public Action<int> OnScoreChange { get; set; }
    }
}