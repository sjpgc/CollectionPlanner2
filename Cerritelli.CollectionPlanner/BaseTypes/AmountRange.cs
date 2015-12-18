namespace Cerritelli.CollectionPlanner.BaseTypes
{
    public struct AmountRange
    {
        public Amount LowerBound { get; set; }
        public Amount UpperBound { get; set; }

        public static AmountRange Build(decimal lower, decimal upper, Currency currency)
        {
            return new AmountRange
            {
                UpperBound = new Amount {Currency = currency, HowMuch = upper},
                LowerBound = new Amount {Currency = currency, HowMuch = lower}
            };
        } 
    }
}