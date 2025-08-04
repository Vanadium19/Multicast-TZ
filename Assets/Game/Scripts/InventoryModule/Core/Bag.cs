using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine;

namespace InventoryModule
{
    public class Bag : IBag
    {
        private readonly List<IGood> _goods = new();
        private readonly ReactiveProperty<int> _goodsCount = new();

        public int GoodsCost => _goods.Select(good => good.Price).Sum();
        public ReadOnlyReactiveProperty<int> GoodsCount => _goodsCount;

        public void Add(IEnumerable<IGood> goods)
        {
            foreach (var good in goods)
                Add(good);
        }

        public void Add(IGood good)
        {
            if (_goods.Contains(good))
                return;

            _goods.Add(good);
            _goodsCount.Value++;
        }

        public void Clear()
        {
            _goods.Clear();
            _goodsCount.Value = 0;
        }
    }
}