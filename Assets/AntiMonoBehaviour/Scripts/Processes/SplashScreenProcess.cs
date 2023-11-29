using System.Threading;
using AntiMonoBehaviour.Processes.Settings;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public class SplashScreenProcess : ProcessBase
    {
        [Inject] readonly SplashScreenSettings _settings;

        public async UniTask ShowSplashScreenAsync(CancellationToken cancel)
        {
            Debug.Log(_settings.SplashScreenMessage);
            await UniTask.Yield(cancel);
        }
    }
}
