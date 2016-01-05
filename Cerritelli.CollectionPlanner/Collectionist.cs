using System;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.EventArguments;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public delegate void CollectibleAddedToWishlist(AddedToWishlistArgs e);

    public class Collectionist : IPersistable
    {
        public event CollectibleAddedToWishlist CollectibleAddedToWishlist;

        public Collectionist()
        {
            Collections = new Collections();
        }

        public Guid Id { get; set; }
        public Contact Contact { get; set; }
        public Collections Collections { get; set; }

        public Cumulation AddToWishlist(Cumulation collection, ICollectible collectible, AmountRange willingToPay)
        {
            collection.AddToWishlist(Wish.Build(collectible, willingToPay));
            OnCollectibleAddedToWishlist(new AddedToWishlistArgs{LatestCollectibleAdded = collectible});
            return collection;
        }

        protected virtual void OnCollectibleAddedToWishlist(AddedToWishlistArgs addedToWishlistArgs)
        {
            var handler = CollectibleAddedToWishlist;
            if (handler != null) handler(addedToWishlistArgs);
        }
    }
}