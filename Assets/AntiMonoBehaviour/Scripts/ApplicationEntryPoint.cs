using UnityEngine;

namespace AntiMonoBehaviour
{
    public static class ApplicationEntryPoint
    {
        [RuntimeInitializeOnLoadMethod]
        static void Entry()
        {
            Debug.Log("Entry");
        }
    }
}
