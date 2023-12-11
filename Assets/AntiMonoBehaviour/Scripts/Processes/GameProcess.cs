using System.Threading;
using AntiMonoBehaviour.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public interface IGameProcessParams
    {
        GameObject GameViewPrefab { get; }
    }

    public class GameProcess : ProcessBase
    {
        [Inject] readonly IGameProcessParams _params;

        public async UniTask<GameResult> WaitForFinishGameAsync(CancellationToken cancel)
        {
            var view = Object.Instantiate(_params.GameViewPrefab, base.Canvas.transform);
            base.WiiDestroyObjectsOnDispose.Add(view);

            var startupSeconds = Time.realtimeSinceStartup;
            await view.GetComponent<IGameView>().FinishButtonClickAsync(cancel);
            // ゲーム画面を開いていた時間をスコアにする
            var seconds = Time.realtimeSinceStartup - startupSeconds;
            return new GameResult(Score: Mathf.FloorToInt(seconds * 100));
        }
    }
}
