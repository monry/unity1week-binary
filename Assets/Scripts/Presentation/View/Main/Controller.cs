using System;
using Monry.Unity1Weeks.Binary.Presentation.Presenter;
using UniRx;
using UnityEngine;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    public class Controller : MonoBehaviour, IGameStarter
    {
        IObservable<Unit> IGameStarter.OnGameStartAsObservable()
        {
            return Observable.ReturnUnit();
        }
    }
}