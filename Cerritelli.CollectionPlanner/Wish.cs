using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Wish : IPersistable
    {
        public IIdentity Id { get; set; }
        public ICollectible CollectibleDesired { get; set; }
        public AmountRange WishingToPay { get; set; }
    }
}