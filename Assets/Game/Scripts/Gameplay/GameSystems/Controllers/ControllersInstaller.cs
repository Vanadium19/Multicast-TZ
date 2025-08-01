using UnityEngine;
using Zenject;

namespace Gameplay.GameSystems.Controllers
{
    [CreateAssetMenu(fileName = "ControllersInstaller", menuName = "Game/Installers/ControllersInstaller")]
    public class ControllersInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private float _harvestDelay = 2f;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<HarvestController>()
                .AsSingle()
                .WithArguments(_harvestDelay)
                .NonLazy();
        }
    }
}