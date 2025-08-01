using Gameplay.Core.Components;
using Gameplay.GameSystems.Inputs;
using Zenject;

namespace Gameplay.GameSystems.Controllers
{
    public class MoveController : ITickable
    {
        private readonly IMoveInput _moveInput;
        private readonly IMoveComponent _moveComponent;

        public MoveController(IMoveInput moveInput, IMoveComponent moveComponent)
        {
            _moveInput = moveInput;
            _moveComponent = moveComponent;
        }

        public void Tick()
        {
            Move();
        }

        private void Move()
        {
            var direction = _moveInput.Direction;

            _moveComponent.Move(direction);
        }
    }
}