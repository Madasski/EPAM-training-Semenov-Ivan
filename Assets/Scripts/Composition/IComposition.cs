using Core;
using UI;

namespace Composition
{
    public interface IComposition
    {
        void Destroy();
        IUIRoot GetUIRoot();
        IResourceManager GetResourceManager();
    }
}