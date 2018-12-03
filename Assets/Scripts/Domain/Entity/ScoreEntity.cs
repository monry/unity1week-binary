using System;
using CAFU.Core;
using UniRx;

namespace Monry.Unity1Weeks.Binary.Domain.Entity
{
    public interface IScoreEntity : IEntity
    {
        void ToggleDigit(int digit);

        IObservable<ulong> OnChangeScoreAsObservable();

        void SendScore();
    }

    public class ScoreEntity : IScoreEntity
    {
        private IReactiveProperty<ulong> ScoreProperty { get; } = new ReactiveProperty<ulong>(0);

        public void ToggleDigit(int digit)
        {
            ScoreProperty.Value = ScoreProperty.Value ^ (ulong)1 << digit;
        }

        public IObservable<ulong> OnChangeScoreAsObservable()
        {
            return ScoreProperty;
        }

        public void SendScore()
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(ScoreProperty.Value);
        }
    }
}