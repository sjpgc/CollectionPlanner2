using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerritelli.CollectionPlanner
{
    public class Wishlist : List<Wish>
    {
        public ICollectible this[Guid collectibleId]
        {
            get
            {
                var firstOrDefault   = this.FirstOrDefault(wish => wish.DesiredCollectible.Id == collectibleId);
                return firstOrDefault != null ? firstOrDefault.DesiredCollectible : default(ICollectible);
            }
        }
    }
}