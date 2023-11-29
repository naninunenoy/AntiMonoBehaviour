using UnityEngine;
using VContainer.Unity;

namespace AntiMonoBehaviour.Processes
{
    public abstract class ProcessBase : IProcess
    {
        LifetimeScope _lifetimeScope;
        public GameObject LifetimeScopeObject => _lifetimeScope.gameObject;

        public virtual void Dispose()
        {
            if (_lifetimeScope != null)
            {
                Object.Destroy(_lifetimeScope.gameObject);
            }
        }

        public void SetLifetimeScope(LifetimeScope lifetimeScope) => _lifetimeScope = lifetimeScope;
    }
}
