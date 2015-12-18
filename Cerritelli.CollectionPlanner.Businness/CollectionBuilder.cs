using Cerritelli.CollectionPlanner.BaseTypes;

namespace Cerritelli.CollectionPlanner.Businness
{
    public class CollectionBuilder
    {
        public Cumulation AddToWishlist(Cumulation collection, ICollectible collectible, AmountRange willingToPay)
        {
            collection.AddToWishlist(Wish.Build(collectible, willingToPay));

            return collection;
        }
    }
}
