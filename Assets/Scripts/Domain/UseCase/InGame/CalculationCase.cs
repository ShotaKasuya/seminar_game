using System;
using Domain.IModel.InGame;
using Model.InGame;

namespace Domain.UseCase.InGame
{
    public class CalculationCase:IDisposable
    {
        public CalculationCase
        (
            ICompleteEventModel completeEventModel,
            IScoreModel scoreModel
        )
        {
            CompleteEventModel = completeEventModel;
            ScoreModel = scoreModel;

            Calculation();
            CompleteEventModel.OnCompleteEvent += Calculation;
        }

        private void Calculation()
        {
            var score = ScoreModel.Score;
            score++;
            ScoreModel.RevisedScore = score;
        }

        public IScoreModel ScoreModel { get; set; }

        public ICompleteEventModel CompleteEventModel { get; }

        public void Dispose()
        {
            CompleteEventModel.OnCompleteEvent -= Calculation;
        }
    }
}