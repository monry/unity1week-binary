using System;
using System.Collections.Generic;
using Monry.Unity1Weeks.Binary.Application;
using Monry.Unity1Weeks.Binary.Structure;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class Bit : UIBehaviour
    {
        [Inject] private BitAttribute Attribute { get; set; }
        [Inject] private IFactory<BitAttribute, Bit> BitFactory { get; set; }
        private RectTransform rectTransform;
        private RectTransform RectTransform => rectTransform ? rectTransform : (rectTransform = GetComponent<RectTransform>());
        private Image image;
        private Image Image => image ? image : (image = GetComponent<Image>());
        private IList<Bit> SubBitList { get; } = new List<Bit>();

        protected override void Start()
        {
            var sizeX = RectTransform.sizeDelta.x + Const.BitMargin * 2;
            RectTransform.anchoredPosition =
                new Vector2(
                    -sizeX / 2 - sizeX * Attribute.Digit,
                    0
                );
            Image.color = Const.Master.SpreadRangeColorMap[Attribute.SpreadRange][Attribute.IsSubBit];

            if (!Attribute.IsSubBit)
            {
                // 設置したら消去
                //   ヒット判定は Digit 側で行っている
                this
                    .OnTriggerEnter2DAsObservable()
                    .Where(x => x.gameObject.GetComponent<Digit>() != null)
                    .Subscribe(_ => DestroyWithSubBits());
                // クリックされたら消去
                this
                    .OnPointerDownAsObservable()
                    .Subscribe(_ => DestroyWithSubBits());
                for (var i = 0; i < (int) Attribute.SpreadRange; i++)
                {
                    SpawnSubBit(i + 1);
                    SpawnSubBit(-i - 1);
                }
            }

            Observable
                .Interval(TimeSpan.FromSeconds(Const.MoveInterval))
                .Subscribe(_ => RectTransform.anchoredPosition += new Vector2(0.0f, -24.0f))
                .AddTo(gameObject);
        }

        private void DestroyWithSubBits()
        {
            foreach (var subBit in SubBitList)
            {
                Destroy(subBit.gameObject);
            }
            Destroy(gameObject);
        }

        private void SpawnSubBit(int distance)
        {
            SubBitList
                .Add(
                    BitFactory
                        .Create(
                            new BitAttribute
                            {
                                Digit = Attribute.Digit + distance,
                                GravityScale = Attribute.GravityScale,
                                IsSubBit = true,
                                SpreadRange = Attribute.SpreadRange,
                            }
                        )
                );
        }
    }
}