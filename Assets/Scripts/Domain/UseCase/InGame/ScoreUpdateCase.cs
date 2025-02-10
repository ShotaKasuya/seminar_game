using Domain.IModel.InGame;
using Domain.IView.InGame;
using Model.InGame;

namespace Domain.UseCase.InGame
{
    public class ScoreUpdateCase
    {
        public ScoreUpdateCase
        (
            IScoreModel scoreModel,
            IScoreView scoreView
        )
        {
            ScoreModel = scoreModel;
            ScoreView = scoreView;

            scoreModel.OnScoreChange += ChangeScore;
        }

        private void ChangeScore(int score)
        {
            
        }

        public IScoreView ScoreView { get; set; }

        public IScoreModel ScoreModel { get; set; }
    }
}