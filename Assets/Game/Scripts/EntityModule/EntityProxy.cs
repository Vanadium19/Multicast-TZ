using UnityEngine;

namespace EntityModule
{
    public class EntityProxy : MonoBehaviour, IEntity
    {
        [SerializeField] private Entity _entity;

        public T Get<T>() => _entity.Get<T>();

        public bool TryGet<T>(out T value) where T : class => _entity.TryGet(out value);
    }
}