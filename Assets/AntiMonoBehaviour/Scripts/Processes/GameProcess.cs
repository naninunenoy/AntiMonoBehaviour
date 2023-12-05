using System.Threading;
using AntiMonoBehaviour.Processes.Settings;
using AntiMonoBehaviour.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes
{

    public class GameProcess : ProcessBase
    {
        [Inject] readonly GameProcessSettings _settings;

        public async UniTask<GameResult> WaitForFinishGameAsync(CancellationToken cancel)
        {
            var view = Object.Instantiate(_settings.GameViewPrefab, base.Canvas.transform);
            base.WiiDestroyObjectsOnDispose.Add(view);

            var startupSeconds = Time.realtimeSinceStartup;
            await view.GetComponent<IGameView>().FinishButtonClickAsync(cancel);
            // ゲーム画面を開いた時間をスコアにする
            return new GameResult(Score: Mathf.FloorToInt(Time.realtimeSinceStartup - startupSeconds));
        }
    }
}
