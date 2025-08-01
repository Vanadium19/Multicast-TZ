using UnityEngine;
using Zenject;

namespace InstrumentsModule
{
    public class InstrumentsInstaller : MonoInstaller
    {
        [SerializeField] private SickleArgs _sickleArgs;

        public override void InstallBindings()
        {
            SickleInstaller.Install(Container, _sickleArgs);
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