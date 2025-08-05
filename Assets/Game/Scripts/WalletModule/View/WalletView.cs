using TMPro;
using UnityEngine;

namespace WalletModule
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyAmount;
        [SerializeField] private ParticleSystem _addedMoneyEffect;

        public void UpdateMoney(string value)
        {
            _moneyAmount.text = value;
        }

        public void PlayAddedMoneyEffect()
        {
            _addedMoneyEffect.Clear();
            _addedMoneyEffect.Play();
        }
    }
}