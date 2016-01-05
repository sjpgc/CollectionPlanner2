using System;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.EventArguments;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public delegate void OfferMade(OfferMadeArgs args);

    public class Seller : IPersistable, IHaveAName
    {
        public event OfferMade OfferMade;
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        
        public Offer MakeOfferFor(Wish wish, Amount priceRequested)
        {
            var offer = new Offer
            {
                Id = Guid.NewGuid(),
                Wish = wish,
                PriceRequested = priceRequested
            };

            OnOfferMade(new OfferMadeArgs{Offer = offer});

            return offer;
        }

        protected virtual void OnOfferMade(OfferMadeArgs e)
        {
            var handler = OfferMade;
            if (handler != null) handler(e);
        }
    }
}