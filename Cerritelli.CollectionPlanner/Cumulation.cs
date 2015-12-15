using System.Collections.Generic;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    /// <summary>
    /// This class represents a collection, however
    /// it's been called "Cumulation" to prevent confusion with a word that has a clearly defined role in many coding languages: "collection" precisely
    /// </summary>
    public class Cumulation : IPersistable, IHaveAName, IHaveADescription
    {
        public IIdentity Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Acquisition> Acquisitions { get; set; } 
        public IEnumerable<Wish> Wishlist { get; set; }   

        public Cumulation AddNewAcquisition(Acquisition acquisition)
        {
            // TODO: implement

            return this;
        }

        public Cumulation AddToWishlist(Wish wish)
        {
            // TODO: implement

            return this;
        }
    }
}