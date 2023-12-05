using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AntiMonoBehaviour.Processes
{
    public class ResultProcess : ProcessBase
    {
        public void ShowResult(GameResult result)
        {
            Debug.Log(result.Score);
        }

        public UniTask<ResultNextActionType> WaitForNextActionAsync(CancellationToken cancel)
        {
            throw new NotImplementedException("TODO");
        }

    }
}
