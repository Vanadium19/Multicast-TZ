using UnityEngine;
using Zenject;

namespace Gameplay.Content.Tools
{
    public class SickleInstaller : Installer<SickleArgs, SickleInstaller>
    {
        private readonly SickleArgs _sickleArgs;

        public SickleInstaller(SickleArgs sickleArgs)
        {
            _sickleArgs = sickleArgs;
        }

        public override void InstallBindings()
        {
            Container.Bind<ISickle>()
                .To<Sickle>()
                .AsSingle()
                .WithArguments(_sickleArgs);
        }
    }
}