using System.Collections.Generic;
using GoodsModule;
using R3;

namespace InstrumentsModule
{
    public interface ISickle : IUpgradeable
    {
        public Observable<Unit> Chopped { get; }

        public IEnumerable<IGrass> Chop();
    }
}