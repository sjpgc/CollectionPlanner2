using System;

namespace Cerritelli.CollectionPlanner.EventArguments
{
    public class AddedToWishlistArgs : EventArgs
    {
        public ICollectible LatestCollectibleAdded { get; set; }
    }
}