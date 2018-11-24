using CAFU.Core;
using UnityEngine;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    [RequireComponent(typeof(RectTransform))]
    public class Digit : MonoBehaviour, IView
    {
        [Inject] private int Index { get; set; }
        private RectTransform rectTransform;
        private RectTransform RectTransform => rectTransform ? rectTransform : (rectTransform = GetComponent<RectTransform>());

        private void Start()
        {
            var sizeX = RectTransform.sizeDelta.x;
            RectTransform.anchoredPosition =
                new Vector2(
                    -sizeX / 2 - sizeX * Index,
                    0
                );
        }
    }
}