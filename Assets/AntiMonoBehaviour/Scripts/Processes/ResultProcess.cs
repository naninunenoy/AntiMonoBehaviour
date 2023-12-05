using System.Threading;
using AntiMonoBehaviour.Processes.Settings;
using AntiMonoBehaviour.Views;
using Cysharp.Threading.Tasks;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public class ResultProcess : ProcessBase
    {
        [Inject] readonly ResultProcessSettings _settings;
        IResultView _view;

        public void ShowResult(GameResult result)
        {
            var view = UnityEngine.Object.Instantiate(_settings.ResultViewPrefab, base.Canvas.transform);
            base.WiiDestroyObjectsOnDispose.Add(view);
            _view = view.GetComponent<IResultView>();

            _view.SetScore(result.Score);
        }

        public async UniTask<ResultNextActionType> WaitForNextActionAsync(CancellationToken cancel)
        {
            var winIndex = await UniTask.WhenAny(
                _view.ReplayButtonClickAsync(cancel),
                _view.ToTitleButtonClickAsync(cancel));
            return winIndex == 0 ? ResultNextActionType.Replay : ResultNextActionType.BackToTitle;
        }
    }
}
