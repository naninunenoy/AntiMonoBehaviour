using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public interface ISplashScreenParams
    {
        GameObject SplashScreenViewPrefab { get; }
        float SplashScreenSeconds { get; }
    }

    public class SplashScreenProcess : ProcessBase
    {
        [Inject] readonly ISplashScreenParams _params;

        public async UniTask ShowSplashScreenAsync(CancellationToken cancel)
        {
            var view = UnityEngine.Object.Instantiate(_params.SplashScreenViewPrefab, base.Canvas.transform);
            base.WiiDestroyObjectsOnDispose.Add(view);
            await UniTask.Delay(TimeSpan.FromSeconds(_params.SplashScreenSeconds), cancellationToken: cancel);
        }
    }
}
