using System;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Wish : IPersistable
    {
        public Guid Id { get; set; }
        public ICollectible DesiredCollectible { get; set; }
        public AmountRange WishingToPay { get; set; }
    }
}