using System;
using Domain.IModel.InGame;

namespace Model.InGame
{
    public class QuestionModel: IMutQuestionModel, IQuestionAnswerModel
    {
        public int NextCursor { get; private set; } = 1;
        public void Success()
        {
            NextCursor++;
            OnUpdate.Invoke();
        }

        public string Question { get; private set; }
        public void SetNewQuestion(string question )
        {
            Question = question;
            NextCursor = 0;
            OnUpdate?.Invoke();
        }

        public Action OnUpdate { get; set; }
    }
}