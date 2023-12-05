using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AntiMonoBehaviour.Views
{
    public interface IResultView
    {
        void SetScore(int score);
        UniTask ReplayButtonClickAsync(CancellationToken cancel);
        UniTask ToTitleButtonClickAsync(CancellationToken cancel);
    }

    public class ResultView : UnityViewBase, IResultView
    {
        [SerializeField] Text scoreText;
        [SerializeField] Button replayButton;
        [SerializeField] Button backToTitleButton;

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public async UniTask ReplayButtonClickAsync(CancellationToken cancel)
        {
            await replayButton.OnClickAsync(cancel);
        }

        public async UniTask ToTitleButtonClickAsync(CancellationToken cancel)
        {
            await backToTitleButton.OnClickAsync(cancel);
        }
    }
}
