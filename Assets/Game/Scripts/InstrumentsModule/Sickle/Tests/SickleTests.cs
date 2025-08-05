using System;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using R3;
using System.Linq;
using EntityModule;
using GoodsModule;
using NSubstitute;
using UnityEditor;
using Object = UnityEngine.Object;

namespace InstrumentsModule.Tests
{
    public class SickleTests
    {
        private readonly Vector3 _position = new Vector3(100f, 0, 100f);

        private Sickle _sickle;
        private SickleArgs _args;
        private Transform _transform;
        private SickleConfig _config;

        [SetUp]
        public void Setup()
        {
            _config = AssetDatabase.LoadAssetAtPath<SickleConfig>("Assets/Game/Scripts/InstrumentsModule/Configs/SickleConfig.asset");
            _transform = new GameObject("Sickle").transform;
            _transform.position = _position;

            _args = new SickleArgs(_config, _transform);
            _sickle = new Sickle(_args);
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(_transform.gameObject);
        }

        [Test]
        public void Constructor_InitializesRadiusAndProgress()
        {
            Assert.AreEqual(Vector3.one * _config.StartRadius, _args.Transform.localScale);
            Assert.Greater(_sickle.Progress.CurrentValue, 0f);
        }

        [Test]
        public void CanUpgrade_True_WhenRadiusLessThanMax()
        {
            Assert.IsTrue(_sickle.CanUpgrade);
        }

        [Test]
        public void CanUpgrade_False_WhenRadiusEqualsMax()
        {
            _sickle.Upgrade();
            _sickle.Upgrade();
            _sickle.Upgrade();

            Assert.IsFalse(_sickle.CanUpgrade);
        }

        [Test]
        public void Upgrade_IncreasesRadiusAndUpdatesProgress()
        {
            var initialProgress = _sickle.Progress.CurrentValue;
            _sickle.Upgrade();
            Assert.Greater(_sickle.Progress.CurrentValue, initialProgress);
        }

        [Test]
        public void Chop_OnlyCollectsValidGrassEntities()
        {
            var grassMock = Substitute.For<IGrass>();
            var entityMock = Substitute.For<IEntity>();
            entityMock.TryGet(out Arg.Any<IGrass>())
                .Returns(call =>
                {
                    call[0] = grassMock;
                    return true;
                });

            var collider = new GameObject("Grass");
            collider.AddComponent<BoxCollider>();
            collider.AddComponent<TestEntity>().SetEntity(entityMock);
            collider.transform.position = _position;

            Physics.SyncTransforms();

            var result = _sickle.Chop().ToList();

            Assert.AreEqual(1, result.Count);

            Object.DestroyImmediate(collider);
        }

        [Test]
        public void Chop_TriggersChoppedEvent()
        {
            var triggered = false;
            _sickle.Chopped.Subscribe(_ => triggered = true);

            _sickle.Chop();

            Assert.IsTrue(triggered);
        }

        private class TestEntity : MonoBehaviour, IEntity
        {
            private IEntity _inner;

            public void SetEntity(IEntity entity)
            {
                _inner = entity;
            }

            public T Get<T>()
            {
                return _inner.Get<T>();
            }

            public bool TryGet<T>(out T value) where T : class
            {
                return _inner.TryGet(out value);
            }
        }
    }
}