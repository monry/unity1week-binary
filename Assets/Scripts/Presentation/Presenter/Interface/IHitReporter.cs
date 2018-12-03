using System;
using CAFU.Core;

namespace Monry.Unity1Weeks.Binary.Presentation.Presenter
{
    public interface IHitReporter : IView
    {
        IObservable<int> OnHitAsObservable();
    }
}