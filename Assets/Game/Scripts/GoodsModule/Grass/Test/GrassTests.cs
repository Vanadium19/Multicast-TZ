using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace GoodsModule.Test
{
    public class GrassTests
    {
        private Collider _collider;
        private GoodConfig _goodConfig;
        private Grass _grass;

        [SetUp]
        public void SetUp()
        {
            var go = new GameObject("Grass");
            _collider = go.AddComponent<BoxCollider>();

            _goodConfig = AssetDatabase.LoadAssetAtPath<GoodConfig>("Assets/Game/Scripts/GoodsModule/Configs/Grass.asset");

            _grass = new Grass(_collider, _goodConfig);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_collider.gameObject);
        }

        [Test]
        public void Price_ShouldBeTakenFromConfig()
        {
            Assert.AreEqual(5, _grass.Price);
        }

        [Test]
        public void Collect_DisablesColliderAndSetsIsCollected()
        {
            Assert.IsTrue(_collider.enabled);
            Assert.IsFalse(_grass.IsCollected.CurrentValue);

            _grass.Collect();

            Assert.IsFalse(_collider.enabled);
            Assert.IsTrue(_grass.IsCollected.CurrentValue);
        }

        [Test]
        public void IsCollected_InitialValueIsFalse()
        {
            Assert.IsFalse(_grass.IsCollected.CurrentValue);
        }
    }
}