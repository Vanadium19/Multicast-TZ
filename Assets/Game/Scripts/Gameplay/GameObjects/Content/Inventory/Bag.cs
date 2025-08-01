using System.Collections.Generic;
using System.Linq;
using Gameplay.Content.Goods;
using UnityEngine;

namespace Gameplay.Content.Inventory
{
    public class Bag : IBag
    {
        private readonly List<IGood> _goods = new();

        public int GoodsCost => _goods.Select(good => good.Cost).Sum();

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
            
            Debug.LogWarning($"Good added count: {_goods.Count}, total cost: {GoodsCost}");
        }

        public void Clear()
        {
            _goods.Clear();
        }
    }
}