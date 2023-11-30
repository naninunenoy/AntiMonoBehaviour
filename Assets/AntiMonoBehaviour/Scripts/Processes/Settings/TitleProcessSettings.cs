using UnityEngine;

namespace AntiMonoBehaviour.Processes.Settings
{
    [CreateAssetMenu(fileName = "TitleProcessSettings",
        menuName = "AntiMonoBehaviour/TitleProcessSettings", order = 1)]
    public class TitleProcessSettings : SettingsBase
    {
        [SerializeField] GameObject titleViewPrefab;
        public GameObject TitleViewPrefab => titleViewPrefab;
    }
}
