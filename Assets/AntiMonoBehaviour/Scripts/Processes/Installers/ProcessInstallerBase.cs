using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace AntiMonoBehaviour.Processes.Installers
{
    public abstract class ProcessInstallerBase<TProcess> : ScriptableObject, IInstaller
        where TProcess : ProcessBase
    {
        public virtual void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TProcess>().As(typeof(TProcess));
        }
    }
}
