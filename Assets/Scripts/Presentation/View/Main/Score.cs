using Monry.Unity1Weeks.Binary.Presentation.Presenter;
using TMPro;
using UnityEngine;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Score : MonoBehaviour, IScoreRenderer
    {
        private TextMeshProUGUI textMeshProUGUI;
        private TextMeshProUGUI TextMeshProUGUI => textMeshProUGUI ? textMeshProUGUI : (textMeshProUGUI = GetComponent<TextMeshProUGUI>());

        private void Start()
        {
            Render(0);
        }

        public void Render(ulong score)
        {
            TextMeshProUGUI.text = score.ToString();
        }
    }
}