using System;
using Domain.IModel.InGame;
using Domain.IView.InGame;

namespace Domain.UseCase.InGame
{
    public class SetQuestionCase: IDisposable
    {
        public SetQuestionCase
        (
            IQuestionWordModel questionWordModel,
            IMutQuestionModel questionModel,
            IWordView wordView,
            ICompleteEventModel completeEventModel
        )
        {
            QuestionWordModel = questionWordModel;
            QuestionModel = questionModel;
            WordView = wordView;
            CompleteEventModel = completeEventModel;
            
            SetQuestion();
            CompleteEventModel.OnCompleteEvent += SetQuestion;
        }

        private void SetQuestion()
        {
            var question = QuestionWordModel.GetQuestion();
            QuestionModel.SetNewQuestion(question);
            WordView.ShowText(question);
        }

        private IQuestionWordModel QuestionWordModel { get; }
        private IMutQuestionModel QuestionModel { get; }
        private IWordView WordView { get; }
        private ICompleteEventModel CompleteEventModel { get; }

        public void Dispose()
        {
            CompleteEventModel.OnCompleteEvent -= SetQuestion;
        }
    }
}