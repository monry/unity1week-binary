using CAFU.Core;

namespace Monry.Unity1Weeks.Binary.Domain.UseCase
{
    public interface IBitSpawner : IPresenter
    {
        void SpawnStart();

        void SpawnStop();
    }
}