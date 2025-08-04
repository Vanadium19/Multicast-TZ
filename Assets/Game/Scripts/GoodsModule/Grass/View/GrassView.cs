using UnityEngine;

namespace GoodsModule
{
    public class GrassView : MonoBehaviour
    {
        [SerializeField] private float _offsetY = -0.3f;
        [SerializeField] private Transform _transform;

        public void SetCollectAnimation()
        {
            var position = _transform.position;
            position.y += _offsetY;

            _transform.position = position;
        }
    }
}