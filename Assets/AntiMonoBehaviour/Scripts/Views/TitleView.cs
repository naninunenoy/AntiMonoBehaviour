using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AntiMonoBehaviour.Views
{
    public interface ITitleView
    {
        UniTask StartButtonClickAsync(CancellationToken cancel);
    }

    public class TitleView : UnityViewBase, ITitleView
    {
        [SerializeField] Button startButton;

        public async UniTask StartButtonClickAsync(CancellationToken cancel)
        {
            await startButton.OnClickAsync(cancel);
        }
    }
}
