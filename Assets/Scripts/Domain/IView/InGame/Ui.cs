using System;

namespace Domain.IView.InGame
{
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