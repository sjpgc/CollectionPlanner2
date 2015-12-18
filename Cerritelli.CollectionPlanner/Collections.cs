using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerritelli.CollectionPlanner
{
    public class Collections : List<Cumulation>
    {
        public Cumulation this[Guid id]
        {
            get { return this.SingleOrDefault(cumulation => cumulation.Id == id); }
        }

        public Cumulation this[string name]
        {
            get { return this.SingleOrDefault(cumulation => cumulation.Name == name); }
        }
    }
}
