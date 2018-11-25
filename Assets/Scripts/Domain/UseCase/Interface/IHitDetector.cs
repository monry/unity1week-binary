using System;
using CAFU.Core;

namespace Monry.Unity1Weeks.Binary.Domain.UseCase
{
    public interface IHitDetector : IPresenter
    {
        IObservable<int> OnHitObservable();
    }
}