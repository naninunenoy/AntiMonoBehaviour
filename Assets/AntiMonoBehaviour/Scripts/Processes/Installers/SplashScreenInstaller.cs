using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    [CreateAssetMenu(fileName = "SplashScreenInstaller",
        menuName = "AntiMonoBehaviour/SplashScreenInstaller", order = 0)]
    public class SplashScreenInstaller : ProcessInstallerBase<SplashScreenProcess>, ISplashScreenParams
    {
        [SerializeField] GameObject splashScreenViewPrefab;
        [SerializeField] float splashScreenSeconds;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(this).As<ISplashScreenParams>();
        }

        public GameObject SplashScreenViewPrefab => splashScreenViewPrefab;
        public float SplashScreenSeconds => splashScreenSeconds;
    }
}
