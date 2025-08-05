using ComponentsModule;
using Zenject;

namespace PlayerModule
{
    internal class MoveController : ITickable
    {
        private readonly IMoveInput _moveInput;
        private readonly IDirectionMoveComponent _moveComponent;
        private readonly IRotationComponent _rotationComponent;

        public MoveController(IMoveInput moveInput,
            IDirectionMoveComponent moveComponent,
            IRotationComponent rotationComponent)
        {
            _moveInput = moveInput;
            _moveComponent = moveComponent;
            _rotationComponent = rotationComponent;
        }

        public void Tick()
        {
            Move();
        }

        private void Move()
        {
            var direction = _moveInput.Direction;

            _moveComponent.Move(direction);
            _rotationComponent.Rotate(direction);
        }
    }
}