using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace AntiMonoBehaviour
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // 全てのシーンで実行されると鬱陶しいので名前でガード
            if (SceneManager.GetActiveScene().name != "Entry") return;

            builder.RegisterEntryPoint<ApplicationEntryPoint>();
        }
    }
}
