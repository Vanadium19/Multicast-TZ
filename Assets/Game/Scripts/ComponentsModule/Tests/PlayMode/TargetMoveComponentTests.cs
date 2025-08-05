using NUnit.Framework;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using UnityEngine.TestTools;

namespace ComponentsModule.Tests
{
    public class TargetMoveComponentTests
    {
        private GameObject _testObject;
        private Transform _transform;
        private TargetMoveComponent _moveComponent;

        [SetUp]
        public void Setup()
        {
            DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

            _testObject = new GameObject("Mover");
            _transform = _testObject.transform;
            _transform.position = Vector3.zero;

            _moveComponent = new TargetMoveComponent(_transform, speed: 5f);
        }

        [TearDown]
        public void Teardown()
        {
            DOTween.KillAll();
            Object.DestroyImmediate(_testObject);
        }

        [UnityTest]
        public IEnumerator MoveToTarget_SetsIsMoving_And_MovesToPosition() => UniTask.ToCoroutine(async () =>
        {
            var target = new Vector3(10, 0, 0);

            Assert.IsFalse(_moveComponent.IsMoving.CurrentValue);

            var tween = _moveComponent.MoveToTarget(target);

            await UniTask.WaitUntil(() => !_moveComponent.IsMoving.CurrentValue);

            Assert.AreEqual(target.x, _transform.position.x, 0.1f);
            Assert.IsFalse(_moveComponent.IsMoving.CurrentValue);
        });

        [UnityTest]
        public IEnumerator MoveToTarget_CancelBeforeComplete_KillsTween() => UniTask.ToCoroutine(async () =>
        {
            var target = new Vector3(1000, 0, 0);

            var cts = new CancellationTokenSource();

            _moveComponent.MoveToTarget(target, cts.Token);

            await UniTask.Delay(200);

            cts.Cancel();

            await UniTask.NextFrame();

            Assert.IsFalse(_moveComponent.IsMoving.CurrentValue);
        });
    }
}