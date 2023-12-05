using System;
using UnityEngine;

namespace AntiMonoBehaviour.Views
{
    public abstract class UnityViewBase : MonoBehaviour, IDisposable
    {
        public virtual void Dispose()
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
