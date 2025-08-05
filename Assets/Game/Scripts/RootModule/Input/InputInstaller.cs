using PlayerModule;
using Zenject;

namespace RootModule
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