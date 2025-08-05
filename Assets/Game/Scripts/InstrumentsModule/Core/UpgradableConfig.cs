using UnityEngine;

namespace InstrumentsModule
{
    public abstract class UpgradableConfig : ScriptableObject
    {
        [SerializeField] private int _price = 25;

        public int Price => _price;
    }
}