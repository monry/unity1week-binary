using System;
using CAFU.Core;
using UniRx;

namespace Monry.Unity1Weeks.Binary.Presentation.Presenter
{
    public interface IGameStarter : IView
    {
        IObservable<Unit> OnGameStartAsObservable();
    }
}