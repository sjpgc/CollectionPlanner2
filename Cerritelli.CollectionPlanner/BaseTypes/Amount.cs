using System;

namespace Cerritelli.CollectionPlanner.BaseTypes
{
    public class Amount : IEquatable<Amount>
    {
        public decimal HowMuch { get; set; }
        public Currency Currency { get; set; }
        
        public bool Equals(Amount other)
        {
            return other.Currency == Currency && other.HowMuch == HowMuch;
        }
    }
}
