using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public class Epsilon2
    {
        private static readonly List<(decimal min, decimal max, decimal value)>
          table5 = new List<(decimal min, decimal max, decimal value)>()
        {
            (0, 10,  0.15m),
            (10, 18, 0.2m),
            (18, 30, 0.2m),
            (30, 40, 0.25m),
            (40, 50, 0.2m),
            (50, 60, 0.35m),
            (60, 80, 0.45m),
            (80, 100, 0.5m),
            (100, 120, 0.6m)
        };

        public static decimal GetValue(decimal Dw)
        {
            decimal result = -1;

            foreach(var range in table5)
            {
                if (range.min < Dw && Dw <= range.max)
                {
                    result = range.value;
                    break;
                }
            }

            return result;
        }
    }
}
