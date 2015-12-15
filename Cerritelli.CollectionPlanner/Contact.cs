using Cerritelli.CollectionPlanner.BaseTypes;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    public class Contact : IPersistable, IHaveAName
    {
        public IIdentity Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}