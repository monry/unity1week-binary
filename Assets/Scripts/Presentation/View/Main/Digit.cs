using System;
using Monry.Unity1Weeks.Binary.Presentation.Presenter;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    [RequireComponent(typeof(RectTransform))]
    public class Digit : MonoBehaviour, IHitReporter
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

        IObservable<int> IHitReporter.OnHitAsObservable()
        {
            return this
                .OnTriggerEnter2DAsObservable()
                .Where(x => x.gameObject.GetComponent<Bit>() != null)
                .Select(_ => Index);
        }
    }
}