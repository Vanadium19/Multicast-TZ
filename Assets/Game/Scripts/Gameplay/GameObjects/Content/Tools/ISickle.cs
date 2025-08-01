using System.Collections.Generic;
using Gameplay.Content.Goods;

namespace Gameplay.Content.Tools
{
    public interface ISickle
    {
        public IEnumerable<IGrass> CollectGrass();
    }
}