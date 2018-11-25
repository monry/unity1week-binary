using Monry.Unity1Weeks.Binary.Application;
using Monry.Unity1Weeks.Binary.Presentation.Presenter;
using TMPro;
using UnityEngine;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Timer : MonoBehaviour, ITimeRenderer
    {
        private TextMeshProUGUI textMeshProUGUI;
        private TextMeshProUGUI TextMeshProUGUI => textMeshProUGUI ? textMeshProUGUI : (textMeshProUGUI = GetComponent<TextMeshProUGUI>());

        private void Start()
        {
            Render(Const.TotalDuration);
        }

        public void Render(int time)
        {
            TextMeshProUGUI.text = time.ToString();
        }
    }
}