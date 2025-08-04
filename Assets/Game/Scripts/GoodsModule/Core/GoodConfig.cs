using UnityEngine;

namespace GoodsModule
{
    [CreateAssetMenu(fileName = "GoodConfig", menuName = "Game/Configs/GoodConfig")]
    public class GoodConfig : ScriptableObject
    {
        [SerializeField] private int _price = 5;

        public int Price => _price;
    }
}