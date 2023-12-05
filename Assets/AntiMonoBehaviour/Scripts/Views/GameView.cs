using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AntiMonoBehaviour.Views
{
    public interface IGameView
    {
        UniTask FinishButtonClickAsync(CancellationToken cancel);
    }

    public class GameView : UnityViewBase, IGameView
    {
        [SerializeField] Button finishButton;

        public async UniTask FinishButtonClickAsync(CancellationToken cancel)
        {
            await finishButton.OnClickAsync(cancel);
        }
    }
}
