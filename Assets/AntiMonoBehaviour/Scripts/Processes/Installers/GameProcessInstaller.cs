using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    [CreateAssetMenu(fileName = "GameProcessInstaller",
        menuName = "AntiMonoBehaviour/GameProcessInstaller", order = 2)]
    public class GameProcessInstaller : ProcessInstallerBase<GameProcess>, IGameProcessParams
    {
        [SerializeField] GameObject gameViewPrefab;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(this).As<IGameProcessParams>();
        }

        public GameObject GameViewPrefab => gameViewPrefab;
    }
}
