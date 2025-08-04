using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InvetoryModule
{
    public class Bag : IBag
    {
        private readonly List<IGood> _goods = new();

        public int GoodsCost => _goods.Select(good => good.Cost).Sum();
        public int GoodsCount => _goods.Count;

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
        }

        public void Clear()
        {
            _goods.Clear();
        }
    }
}