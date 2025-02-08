namespace Domain.IModel.InGame
{
    // FIXME: 名前もっとなんかあるはず
    public interface ICurrentTypeModel
    {
        public int NextCursor { get; }
        
        public void Success();
    }

    public interface IQuestionModel
    {
        public string Question { get; }
    }

    public interface IMutQuestionModel
    {
        public void SetNewQuestion(string question);
    }
}