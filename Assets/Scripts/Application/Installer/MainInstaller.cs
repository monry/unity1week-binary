using Monry.Unity1Weeks.Binary.Presentation.View.Main;
using Monry.Unity1Weeks.Binary.Structure;
using UnityEngine;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Application.Installer
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Transform digitsTransform;
        [SerializeField] private Transform spawnerTransform;
        [SerializeField] private Digit digitPrefab;
        [SerializeField] private Bit bitPrefab;
        private Transform DigitsTransform => digitsTransform;
        private Transform SpawnerTransform => spawnerTransform;
        private Digit DigitPrefab => digitPrefab;
        private Bit BitPrefab => bitPrefab;

        public override void InstallBindings()
        {
            Container
                .BindIFactory<int, Digit>()
                .To<Digit>()
                .FromComponentInNewPrefab(DigitPrefab)
                .UnderTransform(DigitsTransform);
            Container
                .BindIFactory<BitAttribute, Bit>()
                .To<Bit>()
                .FromComponentInNewPrefab(BitPrefab)
                .UnderTransform(SpawnerTransform);
        }
    }
}