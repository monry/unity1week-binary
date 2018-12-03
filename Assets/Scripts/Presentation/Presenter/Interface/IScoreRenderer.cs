using CAFU.Core;

namespace Monry.Unity1Weeks.Binary.Presentation.Presenter
{
    public interface IScoreRenderer : IView
    {
        void Render(ulong score);
    }
}