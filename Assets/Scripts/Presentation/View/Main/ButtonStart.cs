using System;
using Monry.Unity1Weeks.Binary.Presentation.Presenter;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    public class ButtonStart : UIBehaviour, IGameStarter
    {
        public IObservable<Unit> OnGameStartAsObservable()
        {
            return this.OnPointerClickAsObservable().AsUnitObservable();
        }
    }
}