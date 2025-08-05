using NUnit.Framework;
using UnityEngine;

namespace ComponentsModule.Tests
{
    public class RotationComponentTests
    {
        private GameObject _testObject;
        private Transform _transform;
        private RotationComponent _rotationComponent;

        [SetUp]
        public void Setup()
        {
            _testObject = new GameObject("Rotatable");
            _transform = _testObject.transform;
            _rotationComponent = new RotationComponent(_transform);
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(_testObject);
        }

        [Test]
        public void Rotate_WithValidDirection_SetsCorrectRotation()
        {
            Vector3 direction = Vector3.forward;

            _rotationComponent.Rotate(direction);

            Quaternion expectedRotation = Quaternion.LookRotation(direction);
            Assert.AreEqual(expectedRotation.eulerAngles, _transform.rotation.eulerAngles);
        }

        [Test]
        public void Rotate_WithZeroDirection_DoesNotChangeRotation()
        {
            Quaternion originalRotation = Quaternion.Euler(0, 45, 0);
            _transform.rotation = originalRotation;

            _rotationComponent.Rotate(Vector3.zero);

            Assert.AreEqual(originalRotation.eulerAngles, _transform.rotation.eulerAngles);
        }
    }
}