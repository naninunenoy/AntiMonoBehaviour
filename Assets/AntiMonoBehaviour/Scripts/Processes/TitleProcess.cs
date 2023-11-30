using System.Threading;
using AntiMonoBehaviour.Processes.Settings;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
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
            await view.GetComponentInChildren<Button>().OnClickAsync(cancel);
        }
    }
}
