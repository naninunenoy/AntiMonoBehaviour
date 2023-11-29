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

        protected override void Configure(IContainerBuilder builder)
        {
            // 全てのシーンで実行されると鬱陶しいので名前でガード
            if (SceneManager.GetActiveScene().name != "Entry") return;

            // 各プロセスの生成
            builder.RegisterFactory(() =>
            {
                var scope = this.CreateChild(new SplashScreenInstaller(splashScreenSettings));
                return scope.Container.Resolve<SplashScreenProcess>();
                // ちなみにこのままだと作成された LifetimeScope のインスタンスは破棄されない
            });

            builder.RegisterEntryPoint<ApplicationEntryPoint>();
        }
    }
}
