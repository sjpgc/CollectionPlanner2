using System;

namespace Cerritelli.CollectionPlanner.BehaviourTests.Stubs
{
    internal class Collectible : ICollectible
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}
