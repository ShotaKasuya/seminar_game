using Domain.IModel.InGame;

namespace Model.InGame
{
    public class QuestionModel: ICurrentTypeModel, IQuestionModel, IMutQuestionModel
    {
        public int NextCursor { get; private set; } = 1;
        public void Success()
        {
            NextCursor++;
        }

        public string Question { get; private set; }
        public void SetNewQuestion(string question )
        {
            Question = question;
            NextCursor = 0;
        }
    }
}