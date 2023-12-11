using System.Threading;
using AntiMonoBehaviour.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public interface ITitleProcessParams
    {
        GameObject TitleViewPrefab { get; }
    }

    public class TitleProcess : ProcessBase
    {
        [Inject] readonly ITitleProcessParams _params;

        public async UniTask WaitForPressStartButtonAsync(CancellationToken cancel)
        {
            var view = Object.Instantiate(_params.TitleViewPrefab, base.Canvas.transform);
            base.WiiDestroyObjectsOnDispose.Add(view);
            await view.GetComponent<ITitleView>().StartButtonClickAsync(cancel);
        }
    }
}
