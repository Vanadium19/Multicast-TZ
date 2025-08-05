using System.Collections.Generic;
using NUnit.Framework;

namespace InventoryModule.Tests
{
    public class BagTests
    {
        private Bag _bag;
        private TestGood _good1;
        private TestGood _good2;

        [SetUp]
        public void Setup()
        {
            _bag = new Bag();
            _good1 = new TestGood(100);
            _good2 = new TestGood(200);
        }

        [Test]
        public void Add_SingleGood_IncreasesCountAndCost()
        {
            _bag.Add(_good1);

            Assert.AreEqual(1, _bag.GoodsCount.CurrentValue);
            Assert.AreEqual(100, _bag.GoodsCost);
        }

        [Test]
        public void Add_SameGoodTwice_DoesNotDuplicate()
        {
            _bag.Add(_good1);
            _bag.Add(_good1);

            Assert.AreEqual(1, _bag.GoodsCount.CurrentValue);
            Assert.AreEqual(100, _bag.GoodsCost);
        }

        [Test]
        public void Add_MultipleGoods_IncreasesCountAndCost()
        {
            _bag.Add(new List<IGood> { _good1, _good2 });

            Assert.AreEqual(2, _bag.GoodsCount.CurrentValue);
            Assert.AreEqual(300, _bag.GoodsCost);
        }

        [Test]
        public void Clear_RemovesAllGoods()
        {
            _bag.Add(_good1);
            _bag.Add(_good2);
            _bag.Clear();

            Assert.AreEqual(0, _bag.GoodsCount.CurrentValue);
            Assert.AreEqual(0, _bag.GoodsCost);
        }

        private class TestGood : IGood
        {
            public int Price { get; }

            public TestGood(int price)
            {
                Price = price;
            }
        }
    }
}