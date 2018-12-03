using Monry.Unity1Weeks.Binary.Application.Enum;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    public class Controller : MonoBehaviour
    {
        [Inject] private ButtonStart ButtonStart { get; set; }
        [Inject] private ButtonRetry ButtonRetry { get; set; }
        [Inject] private IMessageReceiver MessageReceiver { get; set; }

        private void Start()
        {
            MessageReceiver
                .Receive<GameState>()
                .Where(x => x == GameState.Started)
                .Subscribe(_ => Destroy(ButtonStart.gameObject));
            MessageReceiver
                .Receive<GameState>()
                .Where(x => x == GameState.Finished)
                .Subscribe(_ => ButtonRetry.gameObject.SetActive(true));
        }
    }
}