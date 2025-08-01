using System.Collections.Generic;
using GoodsModule;

namespace InstrumentsModule
{
    public interface ISickle : IUpgradeable
    {
        public IEnumerable<IGrass> CollectGrass();
    }
}