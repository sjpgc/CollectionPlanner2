using System;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Acquisition : IPersistable, IHappen
    {
        public Guid Id { get; set; }
        public DateTime HappenedWhen { get; set; }
        public ICollectible CollectibleAcquired { get; set; }
        public Amount PricePaid { get; set; }
    }
}