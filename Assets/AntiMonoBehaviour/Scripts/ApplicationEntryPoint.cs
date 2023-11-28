using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace AntiMonoBehaviour
{
    public class ApplicationEntryPoint : IAsyncStartable
    {
        public UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log("Entry");
            return UniTask.CompletedTask;
        }
    }
}
