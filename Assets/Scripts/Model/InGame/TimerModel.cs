using System;
using Domain.IModel.InGame;
using UnityEngine;

namespace Model.InGame
{
    public class TimerModel: ITimeModel
    {
        public void InitTime(float time)
        {
            TimeMax = time;
            TimeRemain = time;
        }

        public void DecTime(float dt)
        {
            if (dt < 0)
            {
                Debug.LogError($"dt must be higher than 0 : {dt}");
            }

            TimeRemain -= dt;
        }

        public float TimeMax { get; private set; }
        public float TimeRemain
        {
            get => _timeRemain;
            private set
            {
                var prev = _timeRemain;
                _timeRemain = value;
                var timeChange = new TimeChangeEventArg(_timeRemain, prev);
                TimeChangeEvent?.Invoke(timeChange);
            }
        }
        private float _timeRemain;
        public Action<TimeChangeEventArg> TimeChangeEvent { get; set; }
    }
}