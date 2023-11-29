using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AntiMonoBehaviour.Processes
{
    public class TitleProcess : ProcessBase
    {
        public async UniTask WaitForPressStartButtonAsync(CancellationToken cancel)
        {
            Debug.Log("タイトル");
            await UniTask.Never(cancel);
        }
    }
}
