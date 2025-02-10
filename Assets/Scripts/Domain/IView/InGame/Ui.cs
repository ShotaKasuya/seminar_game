using System;

namespace Domain.IView.InGame
{
    public interface IInputView
    {
        public Action<string> ValueChangedEvent { get; set; }
        public void Clear();
    }

    public interface IPlayerTypeView
    {
        public Action<char> TypeEvent { get; set; }
    }
    

    public interface IScoreView
    {
        public void SetScore(int score);
    }

    public interface ITimerView
    {
        public void SetTime(float time);
    }
}