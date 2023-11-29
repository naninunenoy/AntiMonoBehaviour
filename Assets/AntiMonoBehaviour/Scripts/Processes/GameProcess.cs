using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace AntiMonoBehaviour.Processes
{
    public class GameProcess : ProcessBase
    {

        public UniTask<GameResult> WaitForFinishGameAsync(CancellationToken cancel)
        {
            throw new NotImplementedException("TODO");
        }
    }
}
