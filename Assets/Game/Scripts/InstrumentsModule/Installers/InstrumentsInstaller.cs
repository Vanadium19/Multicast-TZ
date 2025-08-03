using UnityEngine;
using Zenject;

namespace InstrumentsModule
{
    public class InstrumentsInstaller : MonoInstaller
    {
        [SerializeField] private SickleArgs _sickleArgs;
        [SerializeField] private UpgradeView _view;

        public override void InstallBindings()
        {
            SickleInstaller.Install(Container, _sickleArgs);

            Container.BindInterfacesTo<UpgradeSystemPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<UpgradeView>()
                .FromInstance(_view)
                .AsSingle();
        }

        private void OnDrawGizmos()
        {
            DrawSickleGizmos();
        }

        private void DrawSickleGizmos()
        {
            if (_sickleArgs == null)
                return;

            if (!_sickleArgs.Transform)
                return;

            var radius = _sickleArgs.RadiusForGizmos == 0 ? _sickleArgs.StartRadius : _sickleArgs.RadiusForGizmos;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_sickleArgs.Point, radius);
        }
    }
}