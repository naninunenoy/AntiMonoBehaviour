using UnityEngine;

namespace AntiMonoBehaviour.Processes.Settings
{
    [CreateAssetMenu(fileName = "SplashScreenProcessSettings",
        menuName = "AntiMonoBehaviour/SplashScreenProcessSettings", order = 0)]
    public class SplashScreenSettings : SettingsBase
    {
        [SerializeField] GameObject splashScreenViewPrefab;
        [SerializeField] float splashScreenSeconds;

        public GameObject SplashScreenViewPrefab => splashScreenViewPrefab;
        public float SplashScreenSeconds => splashScreenSeconds;
    }
}
