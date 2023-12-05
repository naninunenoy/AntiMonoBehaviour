using UnityEngine;

namespace AntiMonoBehaviour.Processes.Settings
{
    [CreateAssetMenu(fileName = "ResultProcessSettings",
        menuName = "AntiMonoBehaviour/ResultProcessSettings", order = 3)]
    public class ResultProcessSettings : SettingsBase
    {
        [SerializeField] GameObject resultViewPrefab;
        public GameObject ResultViewPrefab => resultViewPrefab;
    }
}
