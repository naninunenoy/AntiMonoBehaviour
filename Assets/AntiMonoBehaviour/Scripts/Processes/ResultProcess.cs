using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace AntiMonoBehaviour.Processes
{
    public class ResultProcess : ProcessBase
    {
        public void ShowResult(GameResult result)
        {
            throw new NotImplementedException("TODO");
        }

        public UniTask<ResultNextActionType> WaitForNextActionAsync(CancellationToken cancel)
        {
            throw new NotImplementedException("TODO");
        }

    }
}
