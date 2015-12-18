using System;
using System.Collections.Generic;
using System.Linq;
using Cerritelli.CollectionPlanner;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.BehaviourTests.Stubs;
using Cerritelli.CollectionPlanner.Businness;
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
            private CollectionBuilder collectionBuilder;
            
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

                collectionBuilder = new CollectionBuilder();
            }

            [Test]
            public void be_able_to_add_a_collectible_to_his_wishlist()
            {
                var collectible = Catalog.Collectibles[SampleCollectibleId];
                var willingToPay = AmountRange.Build(5, 10, new Currency());
                var result = collectionBuilder.AddToWishlist(collectionist.Collections["Main"], collectible, willingToPay);

                var wishlistIsNotEmpty = result.Wishlist.Any();
                var wishlistContainsExpectedCollectible = result.Wishlist[SampleCollectibleId].Equals(collectible);

                Assert.That(wishlistIsNotEmpty);
                Assert.That(wishlistContainsExpectedCollectible);
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
                protected Wishlist WishlistWith;
                protected Wishlist WishlistWithout;
                protected WishlistScanner Scanner;

                [SetUp]
                public new void Setup()
                {
                    base.Setup();

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
            }
        }
    }
}