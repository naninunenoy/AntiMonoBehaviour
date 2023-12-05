using System.Threading;
using AntiMonoBehaviour.Processes.Settings;
using AntiMonoBehaviour.Views;
using Cysharp.Threading.Tasks;
using VContainer;

namespace AntiMonoBehaviour.Processes
{
    public class TitleProcess : ProcessBase
    {
        [Inject] readonly TitleProcessSettings _settings;

        public async UniTask WaitForPressStartButtonAsync(CancellationToken cancel)
        {
            var view = UnityEngine.Object.Instantiate(_settings.TitleViewPrefab, base.Canvas.transform);
            base.WiiDestroyObjectsOnDispose.Add(view);
            await view.GetComponent<ITitleView>().StartButtonClickAsync(cancel);
        }
    }
}
