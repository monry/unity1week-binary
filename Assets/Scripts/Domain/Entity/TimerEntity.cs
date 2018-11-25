using System;
using CAFU.Core;
using Monry.Unity1Weeks.Binary.Application;
using UniRx;

namespace Monry.Unity1Weeks.Binary.Domain.Entity
{
    public interface ITimerEntity : IEntity
    {
        void Start();

        void Stop();

        IObservable<int> OnChangeTimeAsObservable();
    }

    public class TimerEntity : ITimerEntity
    {
        private IReactiveProperty<int> TimerProperty { get; } = new ReactiveProperty<int>(Const.TotalDuration);

        private IDisposable timerDisposable;

        public void Start()
        {
            timerDisposable = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Subscribe(_ => TimerProperty.Value--);
        }

        public void Stop()
        {
            timerDisposable?.Dispose();
        }

        public IObservable<int> OnChangeTimeAsObservable()
        {
            return TimerProperty;
        }
    }
}