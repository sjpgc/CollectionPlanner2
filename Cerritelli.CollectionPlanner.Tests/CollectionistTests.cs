using System;
using System.Collections.Generic;
using System.Linq;
using Cerritelli.CollectionPlanner;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.BehaviourTests.Stubs;
using Cerritelli.CollectionPlanner.Businness;
using NUnit.Framework;

namespace given_a_collectionist_and_a_collectibles_catalog
{
    [TestFixture]
    public class the_collectionist_should
    {
        private CollectibleCatalog catalog;
        private Collectionist collectionist;
        private CollectionBuilder collectionBuilder;
        private Guid sampleCollectibleId;

        [SetUp]
        public void Setup()
        {
            sampleCollectibleId = Guid.NewGuid();
            catalog = new CollectibleCatalog();
            catalog.Collectibles = new Collectibles
            {
                new Collectible{Id = sampleCollectibleId, Description = "copper collectible"},
                new Collectible{Id = Guid.NewGuid(), Description = "silver collectible"}
            };

            collectionist = new Collectionist
            {
                Collections = new Collections
                {
                    new Cumulation{Id = Guid.NewGuid(), Name = "Main"}
                }
            };

            collectionBuilder = new CollectionBuilder();
        }

        [Test]
        public void be_able_to_add_a_collectible_to_his_wishlist()
        {
            var collectible = catalog.Collectibles[sampleCollectibleId];
            var willingToPay = AmountRange.Build(5, 10, new Currency());
            var result = collectionBuilder.AddToWishlist(collectionist.Collections["Main"], collectible, willingToPay);

            Assert.That(result.Wishlist.Any());
            Assert.AreEqual(collectible, result.Wishlist.First().DesiredCollectible);
        }

    }
}
