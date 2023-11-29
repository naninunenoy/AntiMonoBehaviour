using AntiMonoBehaviour.Processes.Settings;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    public class SplashScreenInstaller : ProcessInstallerBase
    {
        readonly SplashScreenSettings _settings;

        public SplashScreenInstaller(SplashScreenSettings settings)
        {
            _settings = settings;
        }

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(_settings);
            builder.RegisterPlainEntryPoint<SplashScreenProcess>();
        }
    }
}
