using System;

namespace Cerritelli.CollectionPlanner.BaseTypes
{
    public class Currency : IEquatable<Currency>
    {
        public string Symbol { get; set; }

        public bool Equals(Currency other)
        {
            return other.Symbol == Symbol;
        }
    }
}