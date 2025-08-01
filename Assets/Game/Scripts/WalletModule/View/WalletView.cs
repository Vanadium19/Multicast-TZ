using TMPro;
using UnityEngine;

namespace WalletModule
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyAmount;

        public void UpdateMoney(string value)
        {
            _moneyAmount.text = value;
        }
    }
}