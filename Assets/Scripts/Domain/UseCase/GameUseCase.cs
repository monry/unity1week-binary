using CAFU.Core;
using Monry.Unity1Weeks.Binary.Application.Enum;
using Monry.Unity1Weeks.Binary.Domain.Entity;
using UniRx;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Domain.UseCase
{
    public interface IGameUseCase : IUseCase
    {
    }

    public class GameUseCase : IGameUseCase, IInitializable
    {
        [Inject] private ITimerEntity TimerEntity { get; set; }
        [Inject] private IScoreEntity ScoreEntity { get; set; }
        [Inject] private IGameStateHandler GameStateHandler { get; set; }
        [Inject] private IBitSpawner BitSpawner { get; set; }
        [Inject] private IMessagePublisher MessagePublisher { get; set; }

        void IInitializable.Initialize()
        {
            MessagePublisher.Publish(GameState.Ready);
            GameStateHandler
                .OnGameStartAsObservable()
                .Subscribe(
                    _ =>
                    {
                        TimerEntity.Start();
                        BitSpawner.SpawnStart();
                        MessagePublisher.Publish(GameState.Started);
                    }
                );
            TimerEntity
                .OnChangeTimeAsObservable()
                .Subscribe(x => GameStateHandler.RenderTime(x));
            TimerEntity
                .OnChangeTimeAsObservable()
                .Where(x => x <= 0)
                .Take(1)
                .Subscribe(
                    _ =>
                    {
                        TimerEntity.Stop();
                        BitSpawner.SpawnStop();
                        ScoreEntity.SendScore();
                        MessagePublisher.Publish(GameState.Finished);
                    }
                );
        }
    }
}