using System;

namespace Domain.IModel.InGame
{
    public interface IScoreModel
    {
        public int Score { get; }
        public int RevisedScore { set; }
        public Action<int> OnScoreChange { get; set; }
    }
}