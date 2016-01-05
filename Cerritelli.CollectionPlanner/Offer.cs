using System;
using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Offer : IPersistable, IHappen
    {
        public Guid Id { get; set; }
        public Wish Wish { get; set; }
        public DateTime HappenedWhen { get; set; }
        public Amount PriceRequested { get; set; }
    }
}