using System;

namespace Domain.IView.InGame
{
    public interface IWordView
    {
        public void ShowText(string text);
    }

    public interface IInputView
    {
        public Action<string> ValueChangedEvent { get; set; }
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