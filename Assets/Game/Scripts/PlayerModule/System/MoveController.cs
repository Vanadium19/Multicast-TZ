using ComponentsModule;
using Zenject;

namespace PlayerModule
{
    public class MoveController : ITickable
    {
        private readonly IMoveInput _moveInput;
        private readonly IDirectionMoveComponent _moveComponent;

        public MoveController(IMoveInput moveInput, IDirectionMoveComponent moveComponent)
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