using AntiMonoBehaviour.Processes;
using AntiMonoBehaviour.Processes.Installers;
using AntiMonoBehaviour.Processes.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace AntiMonoBehaviour
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] SplashScreenSettings splashScreenSettings;
        [SerializeField] TitleProcessSettings titleProcessSettings;
        [SerializeField] GameProcessSettings gameProcessSettings;
        [SerializeField] ResultProcessSettings resultProcessSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            // 全てのシーンで実行されると鬱陶しいので名前でガード
            if (SceneManager.GetActiveScene().name != "Entry") return;

            // 事前にInstallerのインスタンスを作成
            var splashScreenInstaller = new SplashScreenInstaller(splashScreenSettings);
            var titleProcessInstaller = new TitleProcessInstaller(titleProcessSettings);
            var gameProcessInstaller = new GameProcessInstaller(gameProcessSettings);
            var resultProcessInstaller = new ResultProcessInstaller(resultProcessSettings);

            // 各プロセスの生成
            builder.RegisterFactory(() => CreateProcess<SplashScreenProcess>(splashScreenInstaller, this));
            builder.RegisterFactory(() => CreateProcess<TitleProcess>(titleProcessInstaller, this));
            builder.RegisterFactory(() => CreateProcess<GameProcess>(gameProcessInstaller, this));
            builder.RegisterFactory(() => CreateProcess<ResultProcess>(resultProcessInstaller, this));

            builder.RegisterEntryPoint<ApplicationEntryPoint>();
        }

        static TProcess CreateProcess<TProcess>(IInstaller installer, LifetimeScope parentLifetimeScope)
            where TProcess : ProcessBase
        {
            var childScope = parentLifetimeScope.CreateChild(installer);
            childScope.name = $"{typeof(TProcess).Name}LifetimeScope";
            var process = childScope.Container.Resolve<TProcess>();
            process.SetLifetimeScope(childScope);
            return process;
        }
    }
}
