using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AntiMonoBehaviour
{
    public static class ApplicationEntryPoint
    {
        [RuntimeInitializeOnLoadMethod]
        static void Entry()
        {
            if (SceneManager.GetActiveScene().name != "Entry") return;
            EntryAsync(Application.exitCancellationToken).Forget();
        }

        static UniTaskVoid EntryAsync(CancellationToken cancel)
        {
            Debug.Log("Entry");
            return default;
        }
    }
}
