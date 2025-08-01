using Gameplay.GameSystems.Inputs;
using Zenject;

namespace Game.Scripts.Gameplay.GameSystems
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputInstaller.Install(Container);
        }
    }
}