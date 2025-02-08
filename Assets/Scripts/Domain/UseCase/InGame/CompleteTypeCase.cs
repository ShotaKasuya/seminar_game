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
            IWordGeneratableModel questionMakeModel
        )
        {
            CompleteEventModel = completeEventModel;
            QuestionMakeModel = questionMakeModel;
            
            completeEventModel.OnCompleteEvent += OnComplete;
        }

        private void OnComplete()
        {
            QuestionMakeModel.MakeNewQuestion();
        }
        
        private ICompleteEventModel CompleteEventModel { get; }
        private IWordGeneratableModel QuestionMakeModel { get; }

        public void Dispose()
        {
            CompleteEventModel.OnCompleteEvent -= OnComplete;
        }
    }
}