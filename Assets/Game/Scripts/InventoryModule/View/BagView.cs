using TMPro;
using UnityEngine;

namespace InventoryModule
{
    public class BagView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _goodsCount;

        public void UpdateCount(string value)
        {
            _goodsCount.text = value;
        }
    }
}