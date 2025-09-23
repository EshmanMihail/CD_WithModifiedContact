using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.OuterRingParameters
{
    public class R3smin
    {
        private static Dictionary<decimal, decimal> table = new Dictionary<decimal, decimal>()
        {
            {1.1m, 0.5m },
            {1.5m, 0.5m },
            {2.0m, 0.7m },
            {2.1m, 0.9m },
            {3.0m, 0.9m },
            {4.0m, 1.1m },
            {5.0m, 1.3m },
            {6.0m, 1.8m },
            {7.5m, 2.3m }
        };

        public static decimal GetValue(decimal rsmin)
        {
            return table[rsmin];
        }
    }
}
