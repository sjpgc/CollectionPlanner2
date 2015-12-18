using System;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Collectionist : IPersistable
    {
        public Collectionist()
        {
            Collections = new Collections();
        }

        public Guid Id { get; set; }
        public Contact Contact { get; set; }
        public Collections Collections { get; set; }
    }
}