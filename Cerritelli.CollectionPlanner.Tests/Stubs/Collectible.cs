using System;

namespace Cerritelli.CollectionPlanner.BehaviourTests.Stubs
{
    internal class Collectible : ICollectible
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        
        public bool Equals(ICollectible other)
        {
            return other.GetType() == typeof(Collectible) && other.Id == Id;
        }
    }
}
