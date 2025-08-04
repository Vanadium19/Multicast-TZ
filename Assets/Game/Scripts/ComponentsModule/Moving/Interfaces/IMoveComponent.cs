using R3;

namespace ComponentsModule
{
    public interface IMoveComponent
    {
        public ReadOnlyReactiveProperty<bool> IsMoving { get; }
    }
}