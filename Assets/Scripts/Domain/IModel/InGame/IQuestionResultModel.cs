using System;

namespace Domain.IModel.InGame
{
    /// <summary>
    /// 問題に正解した際のイベントを購読する機能
    /// </summary>
    public interface ICompleteEventModel
    {
        public void SubscribeComplete(Func<Unit> func);
        public void UnsubscribeComplete(Func<Unit> func);
    }
    
    /// <summary>
    /// タイプミスをした際のイベントを購読する機能
    /// </summary>
    public interface IFailEventModel
    {
        public void SubscribeFail(Func<Unit> func);
        public void UnsubscribeFail(Func<Unit> func);
    }

    /// <summary>
    /// 正解または、失敗のイベントを発火する機能
    /// </summary>
    public interface IQuestionResultModel
    {
        public void OnSuccess();
        public void OnFail(char butChar);
    }

    public struct Unit
    {
    }
}