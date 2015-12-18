using Cerritelli.CollectionPlanner.BaseTypes;

namespace Cerritelli.CollectionPlanner.Businness
{
    public class CollectionBuilder
    {
        private WishBuilder wishBuilder;

        public CollectionBuilder()
        {
           wishBuilder = new WishBuilder();
        }

        public Cumulation AddToWishlist(Cumulation collection, ICollectible collectible, AmountRange willingToPay)
        {
            collection.AddToWishlist(wishBuilder.Build(collectible, willingToPay));

            return collection;
        }
    }
}
