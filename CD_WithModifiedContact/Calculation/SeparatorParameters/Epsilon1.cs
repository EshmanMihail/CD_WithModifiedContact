using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public class Epsilon1
    {
        private static readonly List<(decimal min, decimal max, decimal value)>
          table6 = new List<(decimal min, decimal max, decimal value)>()
        {
            (30, 50,  0.1m),
            (50, 80,  0.1m),
            (80, 120, 0.1m),
            (120, 180, 0.15m),
            (180, 250, 0.2m),
            (250, 315, 0.2m),
            (315, 400, 0.25m),
            (400, 500, 0.25m),
            (500, 630, 0.3m),
            (630, 800, 0.3m),
            (800, 1000, 0.35m)
        };

        public static decimal GetValue(decimal d6)
        {
            decimal result = -1;

            foreach (var range in table6)
            {
                if (range.min < d6 && d6 <= range.max)
                {
                    result = range.value;
                    break;
                }
            }

            return result;
        }
    }
}
