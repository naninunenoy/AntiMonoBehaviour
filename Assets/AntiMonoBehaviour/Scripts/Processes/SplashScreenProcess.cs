using System;
using System.Threading;
using AntiMonoBehaviour.Processes.Settings;
using Cysharp.Threading.Tasks;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public class SplashScreenProcess : ProcessBase
    {
        [Inject] readonly SplashScreenSettings _settings;

        public async UniTask ShowSplashScreenAsync(CancellationToken cancel)
        {
            var view = UnityEngine.Object.Instantiate(_settings.SplashScreenViewPrefab, base.Canvas.transform);
            base.WiiDestroyObjectsOnDispose.Add(view);
            await UniTask.Delay(TimeSpan.FromSeconds(_settings.SplashScreenSeconds), cancellationToken: cancel);
        }
    }
}
