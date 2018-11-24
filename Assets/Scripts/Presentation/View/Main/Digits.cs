using CAFU.Core;
using UnityEngine;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    public class Digits : MonoBehaviour, IView
    {
        [Inject] private IFactory<int, Digit> BitFactory { get; set; }

        private void Start()
        {
            for (var i = 0; i < 32; i++)
            {
                BitFactory.Create(i);
            }
        }
    }
}