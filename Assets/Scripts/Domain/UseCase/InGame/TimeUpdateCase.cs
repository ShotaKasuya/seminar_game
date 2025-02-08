using System;
using Domain.IModel.InGame;
using Domain.IView.InGame;
using Module.Installer;

namespace Domain.UseCase.InGame
{
    public class TimeUpdateCase: ITickable, IDisposable
    {
        public TimeUpdateCase
        (
            ITimeModel timeModel,
            ITimerView timerView
        )
        {
            TimeModel = timeModel;
            TimerView = timerView;

            timeModel.TimeChangeEvent += ChangeTime;
        }
        
        public void Tick(float deltaTime)
        {
            TimeModel.DecTime(deltaTime);
        }

        private void ChangeTime(TimeChangeEventArg timeChangeEvent)
        {
            TimerView.SetTime(timeChangeEvent.CurrentTime);
        }
        
        private ITimeModel TimeModel { get; }
        private ITimerView TimerView { get; }

        public void Dispose()
        {
            TimeModel.TimeChangeEvent -= ChangeTime;
        }
    }
}