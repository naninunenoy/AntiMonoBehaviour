using UnityEngine;

namespace AntiMonoBehaviour.Processes.Settings
{
    [CreateAssetMenu(fileName = "SplashScreenProcessSettings",
        menuName = "AntiMonoBehaviour/SplashScreenProcessSettings", order = 0)]
    public class SplashScreenSettings : SettingsBase
    {
        [SerializeField] string splashScreenMessage;

        public string SplashScreenMessage => splashScreenMessage;
    }
}
