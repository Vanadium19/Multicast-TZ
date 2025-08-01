using System.Collections.Generic;

namespace InvetoryModule
{
    public interface IBag
    {
        public int GoodsCost { get; }
        
        public void Add(IEnumerable<IGood> goods);
        public void Add(IGood good);
        public void Clear();
    }
}