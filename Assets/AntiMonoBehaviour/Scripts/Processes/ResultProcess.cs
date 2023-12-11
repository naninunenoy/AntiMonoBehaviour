using System.Threading;
using AntiMonoBehaviour.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public interface IResultProcessParams
    {
        GameObject ResultViewPrefab { get; }
    }

    public class ResultProcess : ProcessBase
    {
        [Inject] readonly IResultProcessParams _params;
        IResultView _view;

        public void ShowResult(GameResult result)
        {
            var view = Object.Instantiate(_params.ResultViewPrefab, base.Canvas.transform);
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
