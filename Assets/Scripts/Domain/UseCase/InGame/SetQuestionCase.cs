using System;
using Domain.IModel.InGame;
using Domain.IView.InGame;
using UnityEngine;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 問題をセットする
    /// </summary>
    public class SetQuestionCase: IDisposable
    {
        public SetQuestionCase
        (
            IQuestionWordModel questionWordModel,
            IMutQuestionModel questionModel,
            IQuestionView questionView,
            ICompleteEventModel completeEventModel
        )
        {
            QuestionWordModel = questionWordModel;
            QuestionModel = questionModel;
            QuestionView = questionView;
            CompleteEventModel = completeEventModel;
            
            SetQuestion();
            CompleteEventModel.OnCompleteEvent += SetQuestion;
        }

        private void SetQuestion()
        {
            var question = QuestionWordModel.GetQuestion();
            QuestionModel.SetNewQuestion(question);
            QuestionView.ShowText(question);
        }

        private IQuestionWordModel QuestionWordModel { get; }
        private IMutQuestionModel QuestionModel { get; }
        private IQuestionView QuestionView { get; }
        private ICompleteEventModel CompleteEventModel { get; }

        public void Dispose()
        {
            CompleteEventModel.OnCompleteEvent -= SetQuestion;
        }
    }
}