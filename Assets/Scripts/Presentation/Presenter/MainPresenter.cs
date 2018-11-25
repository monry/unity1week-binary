using System;
using System.Collections.Generic;
using System.Linq;
using Monry.Unity1Weeks.Binary.Application;
using Monry.Unity1Weeks.Binary.Application.Enum;
using Monry.Unity1Weeks.Binary.Domain.UseCase;
using Monry.Unity1Weeks.Binary.Presentation.View.Main;
using Monry.Unity1Weeks.Binary.Structure;
using Monry.Unity1Weeks.Binary.Utility;
using UniRx;
using Zenject;
using Random = UnityEngine.Random;

namespace Monry.Unity1Weeks.Binary.Presentation.Presenter
{
    public class MainPresenter : IBitSpawner, IHitDetector, IGameStateHandler
    {
        [Inject] private IFactory<BitAttribute, Bit> BitFactory { get; set; }
        [Inject] private IFactory<int, Digit> DigitFactory { get; set; }
        [Inject] private IGameStarter GameStarter { get; set; }
        [Inject] private IScoreRenderer ScoreRenderer { get; set; }
        [Inject] private ITimeRenderer TimeRenderer { get; set; }

        private IList<IHitReporter> DigitList { get; } = new List<IHitReporter>();

        private ISubject<int> HitSubject { get; } = new Subject<int>();

        private IDisposable spawnDisposable;

        [Inject]
        private void Initialize()
        {
            ReadyDigits();
        }

        void IBitSpawner.SpawnStart()
        {
            spawnDisposable = Observable
                .Interval(TimeSpan.FromSeconds(Const.SpawnInterval))
                .Subscribe(_ => SpawnBit());
        }

        void IBitSpawner.SpawnStop()
        {
            spawnDisposable?.Dispose();
        }

        IObservable<int> IHitDetector.OnHitObservable()
        {
            return HitSubject;
        }

        IObservable<Unit> IGameStateHandler.OnGameStartAsObservable()
        {
            return GameStarter.OnGameStartAsObservable();
        }

        void IGameStateHandler.RenderScore(ulong score)
        {
            ScoreRenderer.Render(score);
        }

        void IGameStateHandler.RenderTime(int time)
        {
            TimeRenderer.Render(time);
        }

        private void ReadyDigits()
        {
            for (var i = 0; i < Const.TotalDigit; i++)
            {
                DigitList.Add(DigitFactory.Create(i));
            }

            DigitList.Select(x => x.OnHitAsObservable()).Merge().Subscribe(HitSubject);
        }

        private void SpawnBit()
        {
            BitFactory.Create(
                new BitAttribute
                {
                    Digit = Random.Range(0, Const.TotalDigit),
                    GravityScale = EnumUtility.GetRandom<GravityScale>(),
                    SpreadRange = EnumUtility.GetRandom<SpreadRange>(),
                }
            );
        }
    }
}