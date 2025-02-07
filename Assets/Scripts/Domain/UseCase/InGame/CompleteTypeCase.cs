using System;
using Domain.IModel.InGame;

namespace Domain.UseCase.InGame
{
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
            
            completeEventModel.SubscribeComplete(OnComplete);
        }

        private Unit OnComplete()
        {
            QuestionMakeModel.MakeNewQuestion();

            return new Unit();
        }
        
        private ICompleteEventModel CompleteEventModel { get; }
        private IWordGeneratableModel QuestionMakeModel { get; }

        public void Dispose()
        {
            CompleteEventModel.UnsubscribeComplete(OnComplete);
        }
    }
}