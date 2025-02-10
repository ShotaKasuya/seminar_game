using System;
using Domain.IModel.InGame;
using Domain.IView.InGame;
using UnityEngine;

namespace Domain.UseCase.InGame
{
    public class UiUpdateCase: IDisposable
    {
        public UiUpdateCase
        (
            IScoreModel scoreModel,
            IScoreView scoreView,
            IQuestionAnswerModel questionModel,
            IQuestionView questionView,
            ITextColorModel textColorModel
        )
        {
            ScoreModel = scoreModel;
            ScoreView = scoreView;
            QuestionModel = questionModel;
            QuestionView = questionView;
            TextColorModel = textColorModel;

            scoreModel.OnScoreChange += UpdateScoreView;
            QuestionModel.OnUpdate += UpdateQuestionView;
        }

        private void UpdateScoreView(int score)
        {
            Debug.Log("score change");
            ScoreView.SetScore(score);
        }

        private void UpdateQuestionView()
        {
            var input = QuestionModel.NextCursor;
            var inputColor = TextColorModel.InputColorType;

            var question = QuestionModel.Question;
            var questionColor = TextColorModel.QuestionColorType;
            
            QuestionView.ShowInputAndQuestion(input, inputColor, question, questionColor);
        }
        
        private IScoreModel ScoreModel { get; }
        private IScoreView ScoreView { get; }
        private IQuestionAnswerModel QuestionModel { get; }
        private IQuestionView QuestionView { get; }
        private ITextColorModel TextColorModel { get; }

        public void Dispose()
        {
            ScoreModel.OnScoreChange -= UpdateScoreView;
            QuestionModel.OnUpdate -= UpdateQuestionView;
        }
    }
}