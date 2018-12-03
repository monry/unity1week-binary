using CAFU.Core;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    public class ButtonRetry : UIBehaviour, IView
    {
        protected override void Start()
        {
            base.Start();
            this.OnPointerClickAsObservable().Subscribe(_ => SceneManager.LoadScene("Main"));
        }
    }
}