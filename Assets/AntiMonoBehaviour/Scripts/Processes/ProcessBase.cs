using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace AntiMonoBehaviour.Processes
{
    public abstract class ProcessBase : IProcess
    {
        [Inject] readonly Canvas _canvas;
        protected Canvas Canvas => _canvas;

        LifetimeScope _lifetimeScope;
        public GameObject LifetimeScopeObject => _lifetimeScope.gameObject;
        protected List<GameObject> WiiDestroyObjectsOnDispose { get; } = new();

        public virtual void Dispose()
        {
            if (_lifetimeScope != null)
            {
                _lifetimeScope.Dispose();
            }

            foreach (var willDestroy in WiiDestroyObjectsOnDispose)
            {
                if (willDestroy == null) continue;
                Object.Destroy(willDestroy);
            }
        }

        public void SetLifetimeScope(LifetimeScope lifetimeScope) => _lifetimeScope = lifetimeScope;
    }
}
