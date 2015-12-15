using System.Collections.Generic;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class CollectibleCatalog : IPersistable, IHaveAName, IHaveADescription
    {
        public IIdentity Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ICollectible> Collectibles { get; set; } 
    }
}
