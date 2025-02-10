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
            IWordView wordView,
            IInputView inputView,
            ICompleteEventModel completeEventModel
        )
        {
            QuestionWordModel = questionWordModel;
            QuestionModel = questionModel;
            WordView = wordView;
            InputView = inputView;
            CompleteEventModel = completeEventModel;
            
            SetQuestion();
            CompleteEventModel.OnCompleteEvent += SetQuestion;
        }

        private void SetQuestion()
        {
            var question = QuestionWordModel.GetQuestion();
            QuestionModel.SetNewQuestion(question);
            WordView.ShowText(question);
            InputView.Clear();
        }

        private IQuestionWordModel QuestionWordModel { get; }
        private IMutQuestionModel QuestionModel { get; }
        private IWordView WordView { get; }
        private IInputView InputView { get; }
        private ICompleteEventModel CompleteEventModel { get; }

        public void Dispose()
        {
            CompleteEventModel.OnCompleteEvent -= SetQuestion;
        }
    }
}