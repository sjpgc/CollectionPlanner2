using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Seller : IPersistable, IHaveAName
    {
        public IIdentity Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; } 
    }
}
