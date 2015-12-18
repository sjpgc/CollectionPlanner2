using System.Collections.Generic;
using System.Linq;

namespace Cerritelli.CollectionPlanner.Businness
{
    public class WishlistScanner
    {
        private readonly IEnumerable<Wishlist> _wishlistsToScan;

        public WishlistScanner(IEnumerable<Wishlist> wishlistsToScan)
        {
            _wishlistsToScan = wishlistsToScan;
        }

        public IEnumerable<Wishlist> FindWishlistsContaining(ICollectible collectible)
        {
            return _wishlistsToScan.Where(wLst => wLst[collectible.Id] != null);
        } 
    }
}
