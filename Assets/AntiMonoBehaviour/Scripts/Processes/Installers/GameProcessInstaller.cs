using AntiMonoBehaviour.Processes.Settings;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    public class GameProcessInstaller : ProcessInstallerBase
    {
        readonly GameProcessSettings _settings;

        public GameProcessInstaller(GameProcessSettings settings)
        {
            _settings = settings;
        }

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(_settings);
            builder.RegisterPlainEntryPoint<GameProcess>();
        }
    }
}
