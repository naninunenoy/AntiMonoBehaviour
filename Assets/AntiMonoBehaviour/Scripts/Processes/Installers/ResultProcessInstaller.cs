using AntiMonoBehaviour.Processes.Settings;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    public class ResultProcessInstaller : ProcessInstallerBase
    {
        readonly ResultProcessSettings _settings;

        public ResultProcessInstaller(ResultProcessSettings settings)
        {
            _settings = settings;
        }

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(_settings);
            builder.RegisterPlainEntryPoint<ResultProcess>();
        }
    }
}
