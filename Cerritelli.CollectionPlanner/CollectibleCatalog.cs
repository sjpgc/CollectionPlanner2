using System;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class CollectibleCatalog : IPersistable, IHaveAName, IHaveADescription
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Collectibles Collectibles { get; set; } 
    }
}
