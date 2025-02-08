using System;
using Domain.IModel.InGame;

namespace Model.InGame
{
    public class QuestionResultEventModel : ICompleteEventModel, IFailEventModel, IQuestionResultModel
    {
        public Action OnCompleteEvent { get; set; }
        public Action<char> OnFailEvent { get; set; }

        public void OnSuccess()
        {
            OnCompleteEvent?.Invoke();
        }

        public void OnFail(char badChar)
        {
            OnFailEvent?.Invoke(badChar);
        }

    }
}