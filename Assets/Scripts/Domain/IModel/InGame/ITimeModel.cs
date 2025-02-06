using System;

namespace Domain.IModel.InGame
{
    public interface ITimeModel
    {
        public void InitTime(float time);
        public void DecTime(float dt);
        
        public float TimeMax { get; }
        public float TimeRemain { get; }
        
        public Action<TimeChangeEventArg> TimeChangeEvent { get; set; } 
    }

    public struct TimeChangeEventArg
    {
        public TimeChangeEventArg
        (
            float currentTime, float prevTime
        )
        {
            CurrentTime = currentTime;
            PrevTime = prevTime;
        }
        
        public float CurrentTime { get; }
        public float PrevTime { get; }
    }
}