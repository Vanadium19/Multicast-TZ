using System.Collections.Generic;
using Gameplay.Content.Goods;

namespace Gameplay.Content.Inventory
{
    public interface IBag
    {
        public int GoodsCost { get; }
        
        public void Add(IEnumerable<IGood> goods);
        public void Add(IGood good);
        public void Clear();
    }
}