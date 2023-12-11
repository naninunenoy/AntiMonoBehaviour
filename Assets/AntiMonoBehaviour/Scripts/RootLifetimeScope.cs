using AntiMonoBehaviour.Processes;
using AntiMonoBehaviour.Processes.Installers;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace AntiMonoBehaviour
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] SplashScreenInstaller splashScreenInstaller;
        [SerializeField] TitleProcessInstaller titleProcessInstaller;
        [SerializeField] GameProcessInstaller gameProcessInstaller;
        [SerializeField] ResultProcessInstaller resultProcessInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
            // 全てのシーンで実行されると鬱陶しいので名前でガード
            if (SceneManager.GetActiveScene().name != "Entry") return;

            // 共通情報のDI
            builder.RegisterInstance(FindAnyObjectByType<Canvas>());

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
