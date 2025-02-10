using System;

namespace Domain.IModel.InGame
{
    // FIXME: 名前もっとなんかあるはず
    public interface IPlayerAnswerModel
    {
        public int NextCursor { get; }
        
        public void Success();
    }

    public interface IQuestionModel
    {
        public string Question { get; }
    }

    public interface IQuestionAnswerModel: IPlayerAnswerModel, IQuestionModel
    {
        public Action OnUpdate { get; set; }
    }

    public interface IMutQuestionModel
    {
        public void SetNewQuestion(string question);
    }
}