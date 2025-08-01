using UnityEngine;
using Zenject;

namespace Gameplay.Content.Inventory
{
    [CreateAssetMenu(fileName = "BagInstaller", menuName = "Game/Installers/BagInstaller")]
    public class BagInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBag>()
                .To<Bag>()
                .AsSingle();
        }
    }
}