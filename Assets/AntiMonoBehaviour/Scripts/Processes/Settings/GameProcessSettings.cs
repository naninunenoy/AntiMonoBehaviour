using UnityEngine;

namespace AntiMonoBehaviour.Processes.Settings
{
    [CreateAssetMenu(fileName = "GameProcessSettings",
        menuName = "AntiMonoBehaviour/GameProcessSettings", order = 2)]
    public class GameProcessSettings : SettingsBase
    {
        [SerializeField] GameObject gameViewPrefab;
        public GameObject GameViewPrefab => gameViewPrefab;
    }
}
