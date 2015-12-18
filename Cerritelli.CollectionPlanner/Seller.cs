using System;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Seller : IPersistable, IHaveAName
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; } 
    }
}
