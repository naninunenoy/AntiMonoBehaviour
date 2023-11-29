using AntiMonoBehaviour.Processes.Settings;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    public class TitleProcessInstaller : ProcessInstallerBase
    {
        readonly TitleProcessSettings _settings;

        public TitleProcessInstaller(TitleProcessSettings settings)
        {
            _settings = settings;
        }

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(_settings);
            builder.RegisterPlainEntryPoint<TitleProcess>();
        }
    }
}
