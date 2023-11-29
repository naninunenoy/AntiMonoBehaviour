using VContainer;
using VContainer.Unity;

namespace AntiMonoBehaviour.Processes.Installers
{
    public abstract class ProcessInstallerBase : IInstaller
    {
        public virtual void Install(IContainerBuilder builder)
        {
        }
    }
}
