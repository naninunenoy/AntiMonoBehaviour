using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AntiMonoBehaviour.Processes
{
    public class GameProcess : ProcessBase
    {
        public async UniTask<GameResult> WaitForFinishGameAsync(CancellationToken cancel)
        {
            Debug.Log("Game Start");
            await UniTask.Never(cancel);
            return null;
        }
    }
}
