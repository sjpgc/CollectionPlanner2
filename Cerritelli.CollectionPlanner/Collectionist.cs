using System.Collections.Generic;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Collectionist : IPersistable
    {
        public IIdentity Id { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<Cumulation> Collections { get; set; }
    }
}