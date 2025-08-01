using UnityEngine;
using Zenject;

namespace Gameplay.Content.Goods
{
    public class GrassInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Temporary solution to bind the GameObject
            Container.Bind<GameObject>()
                .FromInstance(gameObject)
                .AsSingle();

            Container.Bind<IGrass>()
                .To<Grass>()
                .AsSingle();
        }
    }
}