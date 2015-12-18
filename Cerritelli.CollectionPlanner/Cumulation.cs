using System;
using System.Collections.Generic;
using System.Linq;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    /// <summary>
    /// This class represents a collection, however
    /// it's been called "Cumulation" to prevent confusion with a word that has a clearly defined role in many coding languages: "collection" precisely
    /// </summary>
    public class Cumulation : IPersistable, IHaveAName, IHaveADescription
    {
        public Cumulation()
        {
            Wishlist = new Wishlist();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Acquisition> Acquisitions { get; set; } 
        public Wishlist Wishlist { get; set; }   

        public Cumulation AddNewAcquisition(Acquisition acquisition)
        {
            // TODO: implement

            return this;
        }

        public Cumulation AddToWishlist(Wish wish)
        {
            Wishlist.Add(wish);
            return this;
        }
    }

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