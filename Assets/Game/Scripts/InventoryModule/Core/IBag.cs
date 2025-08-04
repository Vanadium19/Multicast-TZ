using System.Collections.Generic;
using R3;

namespace InventoryModule
{
    public interface IBag
    {
        public int GoodsCost { get; }
        public ReadOnlyReactiveProperty<int> GoodsCount { get; }

        public void Add(IEnumerable<IGood> goods);
        public void Add(IGood good);
        public void Clear();
    }
}