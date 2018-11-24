using CAFU.Core;
using Monry.Unity1Weeks.Binary.Application;
using Monry.Unity1Weeks.Binary.Structure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Image))]
    public class Bit : MonoBehaviour, IView
    {
        [Inject] private BitAttribute Attribute { get; set; }
        private RectTransform rectTransform;
        private RectTransform RectTransform => rectTransform ? rectTransform : (rectTransform = GetComponent<RectTransform>());
        private new Rigidbody2D rigidbody2D;
        private Rigidbody2D Rigidbody2D => rigidbody2D ? rigidbody2D : (rigidbody2D = GetComponent<Rigidbody2D>());
        private Image image;
        private Image Image => image ? image : (image = GetComponent<Image>());

        private void Start()
        {
            var sizeX = RectTransform.sizeDelta.x + Const.BitMargin * 2;
            RectTransform.anchoredPosition =
                new Vector2(
                    -sizeX / 2 - sizeX * Attribute.Digit,
                    0
                );
            Rigidbody2D.gravityScale = Const.Master.GravityScaleMap[Attribute.GravityScale];
            Image.color = Const.Master.SpreadRangeColorMap[Attribute.SpreadRange];
        }
    }
}