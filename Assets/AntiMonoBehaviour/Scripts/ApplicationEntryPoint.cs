using System;
using System.Threading;
using AntiMonoBehaviour.Processes;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace AntiMonoBehaviour
{
    public class ApplicationEntryPoint : IAsyncStartable
    {
        [Inject] Func<SplashScreenProcess> _createSplashScreenProcess;
        [Inject] Func<TitleProcess> _createTitleProcess;
        [Inject] Func<GameProcess> _createGameProcess;
        [Inject] Func<ResultProcess> _createResultProcess;

        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellation)
        {
            // まずはスプラッシュ画面を表示
            var splashScreenProcess = _createSplashScreenProcess();
            await splashScreenProcess.ShowSplashScreenAsync(cancellation);
            splashScreenProcess.Dispose();

            // 終了まで タイトル->ゲーム->結果表示を繰り返す
            var isNextTitle = true;
            while (!cancellation.IsCancellationRequested)
            {
                if (isNextTitle)
                {
                    // タイトルの表示
                    var titleProcess = _createTitleProcess();
                    await titleProcess.WaitForPressStartButtonAsync(cancellation);
                    titleProcess.Dispose();
                }

                // ゲーム開始
                var gameProcess = _createGameProcess();
                var result = await gameProcess.WaitForFinishGameAsync(cancellation);
                gameProcess.Dispose();

                // 結果の表示
                var resultProcess = _createResultProcess();
                resultProcess.ShowResult(result);
                var next = await resultProcess.WaitForNextActionAsync(cancellation);
                resultProcess.Dispose();

                isNextTitle = next is ResultNextActionType.BackToTitle;
            }
        }
    }
}
