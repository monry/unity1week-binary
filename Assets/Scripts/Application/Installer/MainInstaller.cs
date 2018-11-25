using Monry.Unity1Weeks.Binary.Domain.Entity;
using Monry.Unity1Weeks.Binary.Domain.UseCase;
using Monry.Unity1Weeks.Binary.Presentation.Presenter;
using Monry.Unity1Weeks.Binary.Presentation.View.Main;
using Monry.Unity1Weeks.Binary.Structure;
using UnityEngine;
using Zenject;

namespace Monry.Unity1Weeks.Binary.Application.Installer
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Controller controller;
        [SerializeField] private Transform digitsTransform;
        [SerializeField] private Transform spawnerTransform;
        [SerializeField] private Digit digitPrefab;
        [SerializeField] private Bit bitPrefab;
        private Controller Controller => controller;
        private Transform DigitsTransform => digitsTransform;
        private Transform SpawnerTransform => spawnerTransform;
        private Digit DigitPrefab => digitPrefab;
        private Bit BitPrefab => bitPrefab;

        public override void InstallBindings()
        {
            // Entities
            Container
                .BindInterfacesTo<ScoreEntity>()
                .AsCached();
            Container
                .BindInterfacesTo<TimerEntity>()
                .AsCached();

            // UseCases
            Container
                .BindInterfacesTo<GameUseCase>()
                .AsCached();
            Container
                .BindInterfacesTo<ScoreUseCase>()
                .AsCached();

            // Presenters
            Container
                .BindInterfacesTo<MainPresenter>()
                .AsCached();

            // Views
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
            Container
                .BindInterfacesTo<Controller>()
                .FromInstance(Controller)
                .AsCached();
        }
    }
}