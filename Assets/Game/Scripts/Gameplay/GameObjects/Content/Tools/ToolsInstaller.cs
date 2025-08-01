using UnityEngine;
using Zenject;

namespace Gameplay.Content.Tools
{
    public class ToolsInstaller : MonoInstaller
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

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_sickleArgs.Point, _sickleArgs.Radius);
        }
    }
}