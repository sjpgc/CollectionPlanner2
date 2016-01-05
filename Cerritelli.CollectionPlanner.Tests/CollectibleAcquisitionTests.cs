using System;
using System.Collections.Generic;
using System.Linq;
using Cerritelli.CollectionPlanner;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.BehaviourTests.Stubs;
using Cerritelli.CollectionPlanner.Businness;
using Cerritelli.CollectionPlanner.EventArguments;
using NUnit.Framework;

namespace given_a_collectibles_catalog
{
    public class CatalogSetup
    {
        protected CollectibleCatalog Catalog;
        protected Guid SampleCollectibleId;

        [SetUp]
        public void Setup()
        {
            SampleCollectibleId = Guid.NewGuid();
            Catalog = new CollectibleCatalog
            {
                Collectibles = new Collectibles
                {
                    new Collectible {Id = SampleCollectibleId, Description = "copper collectible"},
                    new Collectible {Id = Guid.NewGuid(), Description = "silver collectible"}
                }
            };
        }
    }

    namespace and_a_collectionist
    {
        using given_a_collectibles_catalog;

        [TestFixture]
        public class the_collectionist_should : CatalogSetup
        {
            private Collectionist collectionist;
            private ICollectible collectibleAdded;

            [SetUp]
            public new void Setup()
            {
                base.Setup();

                collectionist = new Collectionist
                {
                    Collections = new Collections
                    {
                        new Cumulation{
                            Id = Guid.NewGuid(), 
                            Name = "Main",
                            Wishlist = new Wishlist
                            {
                                new Wish
                                {
                                    Id = Guid.NewGuid(),
                                    DesiredCollectible = new Collectible()
                                }
                            }
                        }
                    }
                };
            }

            [Test]
            public void be_able_to_add_a_collectible_to_his_wishlist()
            {
                var collectible = Catalog.Collectibles[SampleCollectibleId];
                var willingToPay = AmountRange.Build(5, 10, new Currency());

                var result = collectionist.AddToWishlist(collectionist.Collections["Main"], collectible, willingToPay);

                var wishlistIsNotEmpty = result.Wishlist.Any();
                var wishlistContainsExpectedCollectible = result.Wishlist[SampleCollectibleId].Equals(collectible);
                Assert.That(wishlistIsNotEmpty);
                Assert.That(wishlistContainsExpectedCollectible);
            }

            [Test]
            public void comunicate_he_added_a_collectible_to_a_wishlist()
            {
                var collectible = Catalog.Collectibles[SampleCollectibleId];
                var willingToPay = AmountRange.Build(5, 10, new Currency());
                collectionist.CollectibleAddedToWishlist += CollectibleHasBeenAddedToWishlist;

                collectionist.AddToWishlist(collectionist.Collections["Main"], collectible, willingToPay);

                var communicationHasHappened = collectible.Equals(collectibleAdded);
                Assert.That(communicationHasHappened);
            }
            
            [Test, Ignore]
            public void be_able_to_decline_an_offer()
            {
                
            }

            [Test, Ignore]
            public void be_able_to_make_a_counteroffer()
            {
                
            }

            [Test, Ignore]
            public void be_able_to_accept_an_offer()
            {
                
            }


            private void CollectibleHasBeenAddedToWishlist(AddedToWishlistArgs e)
            {
                collectibleAdded = e.LatestCollectibleAdded;
            }
        }
    }

    namespace and_a_seller
    {
        using given_a_collectibles_catalog;

        namespace and_wishlists_some_containing_collectibles_of_interest_to_the_seller
        {
            [TestFixture]
            public class the_seller_should : CatalogSetup
            {
                protected Seller Seller;
                protected Wishlist WishlistWith;
                protected Wishlist WishlistWithout;
                protected WishlistScanner Scanner;
                private Offer createdOffer;

                [SetUp]
                public new void Setup()
                {
                    base.Setup();

                    Seller = new Seller();

                    WishlistWith = new Wishlist
                    {
                         Wish.Build(Catalog.Collectibles[0], new AmountRange())
                    };

                    WishlistWithout = new Wishlist
                    {
                         Wish.Build(Catalog.Collectibles[1], new AmountRange())
                    };

                    Scanner = new WishlistScanner(new List<Wishlist>
                    {
                        WishlistWith,
                        WishlistWithout
                    });
                }

                [Test]
                public void be_able_to_see_which_wishlist_contain_a_specific_collectible()
                {
                    var sellerCollectible = Catalog.Collectibles[SampleCollectibleId];

                    var result = Scanner.FindWishlistsContaining(sellerCollectible).ToList();

                    var wishlistsFound = result.Any();
                    var allWishlistsContainCollectible = result.All(wList => wList[sellerCollectible.Id] != null);
                    Assert.That(wishlistsFound);
                    Assert.That(allWishlistsContainCollectible);
                }

                [Test]
                public void be_able_to_make_the_collectionist_an_offer()
                {
                    var priceRequested = new Amount { Currency = new Currency(), HowMuch = new decimal(55.65) };

                    var offer = Seller.MakeOfferFor(WishlistWith[0], priceRequested);

                    var offerIsForCorrectWish = offer.Wish.Id == WishlistWith[0].Id;
                    var offerIsWithCorrectPrice = offer.PriceRequested == priceRequested;
                    Assert.That(offerIsForCorrectWish);
                    Assert.That(offerIsWithCorrectPrice);

                }

                [Test]
                public void communicate_an_offer_has_been_made()
                {
                    var priceRequested = new Amount { Currency = new Currency(), HowMuch = new decimal(55.65) };
                    Seller.OfferMade += OfferHasBeenMade;

                    Seller.MakeOfferFor(WishlistWith[0], priceRequested);
                    Assert.That(createdOffer.Wish == WishlistWith[0]);
                    Assert.That(createdOffer.PriceRequested == priceRequested);
                }

                private void OfferHasBeenMade(OfferMadeArgs args)
                {
                    createdOffer = args.Offer;
                }

                [Test, Ignore]
                public void be_able_to_decline_an_offer()
                {

                }

                [Test, Ignore]
                public void be_able_to_make_a_counteroffer()
                {

                }

                [Test, Ignore]
                public void be_able_to_accept_an_offer()
                {

                }
            }
        }
    }
}