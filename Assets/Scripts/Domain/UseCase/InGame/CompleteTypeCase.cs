using System;
using Domain.IModel.InGame;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 正解した際の処理
    /// </summary>
    public class CompleteTypeCase: IDisposable
    {
        public CompleteTypeCase
        (
            ICompleteEventModel completeEventModel,
            IQuestionWordModel questionWordModel,
            IMutQuestionModel questionModel
        )
        {
            CompleteEventModel = completeEventModel;
            QuestionWordModel = questionWordModel;
            QuestionModel = questionModel;
            
            completeEventModel.OnCompleteEvent += OnComplete;
        }

        private void OnComplete()
        {
            var question = QuestionWordModel.GetQuestion();
            QuestionModel.SetNewQuestion(question);
        }
        
        private ICompleteEventModel CompleteEventModel { get; }
        private IQuestionWordModel QuestionWordModel { get; }
        private IMutQuestionModel QuestionModel { get; }

        public void Dispose()
        {
            CompleteEventModel.OnCompleteEvent -= OnComplete;
        }
    }
}