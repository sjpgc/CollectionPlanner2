using System;
using Cerritelli.CollectionPlanner.BaseTypes;

namespace Cerritelli.CollectionPlanner.Businness
{
    public class WishBuilder
    {
        public Wish Build(ICollectible collectible, AmountRange willingToPay)
        {
            return new Wish
            {
                Id = Guid.NewGuid(),
                DesiredCollectible = collectible,
                WishingToPay = willingToPay
            };
        }
    }
}