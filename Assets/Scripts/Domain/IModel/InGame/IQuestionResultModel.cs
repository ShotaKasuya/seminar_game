using System;

namespace Domain.IModel.InGame
{
    /// <summary>
    /// 問題に正解した際のイベントを購読する機能
    /// </summary>
    public interface ICompleteEventModel
    {
        public Action OnCompleteEvent { get; set; }
    }
    
    /// <summary>
    /// タイプミスをした際のイベントを購読する機能
    /// </summary>
    public interface IFailEventModel
    {
        public Action OnFailEvent { get; set; }
    }

    /// <summary>
    /// 正解または、失敗のイベントを発火する機能
    /// </summary>
    public interface IQuestionResultModel
    {
        public void OnSuccess();
        public void OnFail(char butChar);
    }
}