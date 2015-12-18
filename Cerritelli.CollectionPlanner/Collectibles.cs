
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerritelli.CollectionPlanner
{
    public class Collectibles : List<ICollectible>
    {
        public ICollectible this[Guid id]
        {
            get { return this.SingleOrDefault(collectible => collectible.Id == id); }
        }
    }
}
