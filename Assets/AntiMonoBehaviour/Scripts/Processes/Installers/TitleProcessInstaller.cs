using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    [CreateAssetMenu(fileName = "TitleProcessInstaller",
        menuName = "AntiMonoBehaviour/TitleProcessInstaller", order = 1)]
    public class TitleProcessInstaller : ProcessInstallerBase<TitleProcess>, ITitleProcessParams
    {
        [SerializeField] GameObject titleViewPrefab;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(this).As<ITitleProcessParams>();
        }

        public GameObject TitleViewPrefab => titleViewPrefab;
    }
}
