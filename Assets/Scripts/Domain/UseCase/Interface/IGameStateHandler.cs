using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.Unity1Weeks.Binary.Domain.UseCase
{
    public interface IGameStateHandler : IPresenter
    {
        IObservable<Unit> OnGameStartAsObservable();
        void RenderScore(ulong score);
        void RenderTime(int time);
    }
}