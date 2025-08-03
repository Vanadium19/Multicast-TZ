using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InstrumentsModule
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Button _buyButton;

        public Observable<Unit> BuyButtonClicked { get; private set; }

        public void Initialize()
        {
            BuyButtonClicked = _buyButton.OnClickAsObservable();
        }

        public void Enable(bool value)
        {
            gameObject.SetActive(value);
        }

        public void UpdateButton(bool interactable)
        {
            _buyButton.interactable = interactable;
        }

        public void UpgradePrice(string price)
        {
            _price.text = price;
        }
    }
}