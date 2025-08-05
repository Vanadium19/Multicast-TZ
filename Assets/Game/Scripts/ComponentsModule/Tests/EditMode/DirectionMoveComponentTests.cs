using NUnit.Framework;
using UnityEngine;

namespace ComponentsModule.Tests
{
    public class DirectionMoveComponentTests
    {
        private GameObject _testObject;
        private Rigidbody _rigidbody;
        private DirectionMoveComponent _moveComponent;

        [SetUp]
        public void Setup()
        {
            _testObject = new GameObject("TestObject");
            _rigidbody = _testObject.AddComponent<Rigidbody>();
            _rigidbody.useGravity = false;
            _moveComponent = new DirectionMoveComponent(_rigidbody, 5f);
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(_testObject);
        }

        [Test]
        public void Move_WithZeroDirection_SetsVelocityToZero_AndIsMovingFalse()
        {
            _moveComponent.Move(Vector3.zero);

            Assert.AreEqual(Vector3.zero, _rigidbody.velocity);
            Assert.IsFalse(_moveComponent.IsMoving.CurrentValue);
        }

        [Test]
        public void Move_WithDirection_SetsVelocityAndIsMovingTrue()
        {
            Vector3 direction = Vector3.forward;
            float expectedSpeed = 5f;

            _moveComponent.Move(direction);

            Assert.AreEqual(direction * expectedSpeed, _rigidbody.velocity);
            Assert.IsTrue(_moveComponent.IsMoving.CurrentValue);
        }
    }
}