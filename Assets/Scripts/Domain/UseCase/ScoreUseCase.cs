using CAFU.Core;
using Monry.Unity1Weeks.Binary.Domain.Entity;
using UniRx;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Domain.UseCase
{
    public interface IScoreUseCase : IUseCase
    {
    }

    public class ScoreUseCase : IScoreUseCase, IInitializable
    {
        [Inject] private IScoreEntity ScoreEntity { get; set; }

        [Inject] private IHitDetector HitDetector { get; set; }

        [Inject] private IGameStateHandler GameStateHandler { get; set; }

        void IInitializable.Initialize()
        {
            HitDetector.OnHitObservable().Subscribe(x => ScoreEntity.ToggleDigit(x));
            ScoreEntity.OnChangeScoreAsObservable().Subscribe(x => GameStateHandler.RenderScore(x));
        }
    }
}