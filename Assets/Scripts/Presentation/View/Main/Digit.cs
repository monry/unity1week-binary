using System;
using Monry.Unity1Weeks.Binary.Application;
using Monry.Unity1Weeks.Binary.Presentation.Presenter;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    [RequireComponent(typeof(RectTransform))]
    public class Digit : MonoBehaviour, IHitReporter
    {
        [Inject] private int Index { get; set; }
        [SerializeField] private Image filled;
        private Image Filled => filled;
        private RectTransform rectTransform;
        private RectTransform RectTransform => rectTransform ? rectTransform : (rectTransform = GetComponent<RectTransform>());
        private IReactiveProperty<bool> IsFilledProperty { get; } = new ReactiveProperty<bool>(false);

        private void Start()
        {
            var sizeX = RectTransform.sizeDelta.x;
            RectTransform.anchoredPosition =
                new Vector2(
                    -sizeX / 2 - sizeX * Index,
                    0
                );
            OnBitTriggeredAsObservable().Subscribe(_ => IsFilledProperty.Value = !IsFilledProperty.Value);
            IsFilledProperty.Subscribe(x => Filled.color = Const.Master.FilledDigitColorMap[x]);
        }

        IObservable<int> IHitReporter.OnHitAsObservable()
        {
            return OnBitTriggeredAsObservable()
                .Select(_ => Index);
        }

        private IObservable<Unit> OnBitTriggeredAsObservable()
        {
            return this
                .OnTriggerEnter2DAsObservable()
                .Where(x => x.gameObject.GetComponent<Bit>() != null)
                .AsUnitObservable();
        }
    }
}