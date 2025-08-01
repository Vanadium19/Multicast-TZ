using Zenject;

namespace Gameplay.GameSystems.Inputs
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IMoveInput>()
                .To<MoveInput>()
                .AsSingle();
        }
    }
}