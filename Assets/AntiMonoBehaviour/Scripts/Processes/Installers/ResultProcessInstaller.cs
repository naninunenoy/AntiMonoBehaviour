using UnityEngine;
using VContainer;

namespace AntiMonoBehaviour.Processes.Installers
{
    [CreateAssetMenu(fileName = "ResultProcessInstaller",
        menuName = "AntiMonoBehaviour/ResultProcessInstaller", order = 3)]
    public class ResultProcessInstaller : ProcessInstallerBase<ResultProcess>, IResultProcessParams
    {
        [SerializeField] GameObject resultViewPrefab;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
            builder.RegisterInstance(this).As<IResultProcessParams>();
        }

        public GameObject ResultViewPrefab => resultViewPrefab;
    }
}
