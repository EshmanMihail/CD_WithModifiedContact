using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.OuterRingParameters
{
    public class CalculatorB_and_e_for54Formula
    {
        private static readonly List<(decimal rsmin, decimal over, decimal before, decimal RsmaxRadial, decimal RsmaxAxial)> rsmaxList
            = new List<(decimal, decimal, decimal, decimal, decimal)>
            {
                ( 0.05m,    -1m,    -1m,   0.10m,   0.20m),
                ( 0.08m,    -1m,    -1m,   0.16m,   0.30m),
                ( 0.10m,    -1m,    -1m,   0.20m,   0.40m),
                ( 0.15m,    -1m,    -1m,   0.30m,   0.60m),
                ( 0.20m,    -1m,    -1m,   0.50m,   0.80m),
                ( 0.30m,    -1m,    40m,   0.60m,   1.00m),
                ( 0.30m,    40m,    -1m,   0.80m,   1.00m),
                ( 0.60m,    -1m,    40m,   1.00m,   2.00m),
                ( 0.60m,    40m,    -1m,   1.30m,   2.00m),
                ( 1.00m,    -1m,    50m,   1.50m,   3.00m),
                ( 1.00m,    50m,    -1m,   1.90m,   3.00m),
                ( 1.10m,    -1m,   120m,   2.00m,   3.50m),
                ( 1.10m,   120m,    -1m,   2.50m,   4.00m),
                ( 1.50m,    -1m,   120m,   2.30m,   4.00m),
                ( 1.50m,   120m,    -1m,   3.00m,   5.00m),
                ( 2.00m,    -1m,    80m,   3.00m,   4.50m),
                ( 2.00m,    80m,   220m,   3.50m,   5.00m),
                ( 2.00m,   220m,    -1m,   3.80m,   6.00m),
                ( 2.10m,   -1m,    280m,   4.00m,   6.50m),
                ( 2.10m,   280m,    -1m,   4.50m,   7.00m),
                ( 2.50m,    -1m,   100m,   3.80m,   6.00m),
                ( 2.50m,   100m,   280m,   4.50m,   6.00m),
                ( 2.50m,   280m,    -1m,   5.00m,   7.00m),
                ( 3.00m,    -1m,   280m,   5.00m,   8.00m),
                ( 3.00m,   280m,    -1m,   5.50m,   8.00m),
                ( 4.00m,    -1m,    -1m,   6.50m,   9.00m),
                ( 5.00m,    -1m,    -1m,   8.00m,  10.00m),
                ( 6.00m,    -1m,    -1m,  10.00m,  13.00m),
                ( 7.50m,    -1m,    -1m,  12.50m,  17.00m),
                ( 9.50m,    -1m,    -1m,  15.00m,  19.00m),
                ( 12.00m,   -1m,    -1m,  19.00m,  24.00m),
                ( 15.00m,   -1m,    -1m,  21.00m,  30.00m),
                ( 19.00m,   -1m,    -1m,  25.00m,  38.00m)
            };


        public static decimal GetRsmaxRadial(decimal rsmin, decimal d)
        {
            foreach (var item in rsmaxList)
            {
                if (item.rsmin != rsmin)
                    continue;

                bool noBounds = item.over == -1 && item.before == -1;
                bool onlyUpper = item.over == -1 && d <= item.before;
                bool onlyLower = item.before == -1 && d >= item.over;
                bool betweenBounds = d > item.over && d <= item.before;

                if (noBounds || onlyUpper || onlyLower || betweenBounds)
                    return item.RsmaxRadial;
            }

            return -1;
        }


        public static decimal GetRsmaxAxial(decimal rsmin, decimal d)
        {
            foreach (var item in rsmaxList)
            {
                if (item.rsmin != rsmin)
                    continue;

                bool noBounds = item.over == -1 && item.before == -1;
                bool onlyUpper = item.over == -1 && d <= item.before;
                bool onlyLower = item.before == -1 && d >= item.over;
                bool betweenBounds = d > item.over && d <= item.before;

                if (noBounds || onlyUpper || onlyLower || betweenBounds)
                    return item.RsmaxAxial;
            }

            return -1;
        }
    }
}
