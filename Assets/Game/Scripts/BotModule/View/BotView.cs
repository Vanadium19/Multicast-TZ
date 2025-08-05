using System;
using CommonModule;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using Zenject;

namespace BotModule
{
    public class BotView : MonoBehaviour
    {
        private const string StartBuyingDialogue = "Can I buy hay?";
        private const string EndBuyingDialogue = "Thanks!";

        [SerializeField] private Animator _animator;

        [Header("Buying Animation")]
        [SerializeField] private float _delay = 0.8f;
        [SerializeField] private TMP_Text _dialogue;
        [SerializeField] private GameObject _dialoguePanel;
        [SerializeField] private RotationConstraint _constraint;

        [Inject]
        public void Construct(ConstraintSource source)
        {
            _constraint.AddSource(source);
        }

        public void SetMoving(bool value)
        {
            _animator.SetBool(AnimationHashes.IsMoving, value);
        }

        public void SetBuyingAnimation()
        {
            StartBuying().Forget();
        }

        private async UniTaskVoid StartBuying()
        {
            _dialoguePanel.SetActive(true);
            _dialogue.text = StartBuyingDialogue;
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));
            _dialogue.text = EndBuyingDialogue;
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));
            _dialoguePanel.SetActive(false);
        }
    }
}