using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Calculation.LayoutParameters
{
    public class R0smin
    {
        public static void GetValue(decimal Dw, decimal Lw, out decimal r0smin)
        {
            decimal nominalSize = (Dw <= Lw) ? Dw : Lw;

            r0smin = 0;

            if (nominalSize > 0 && nominalSize <= 18)
            {
                r0smin = 0.3m;
            }
            else if (nominalSize > 18 && nominalSize <= 30)
            {
                r0smin = 0.5m;
            }
            else if (nominalSize > 30 && nominalSize <= 50)
            {
                r0smin = 0.7m;
            }
            else if (nominalSize > 50 && nominalSize <= 80)
            {
                r0smin = 0.9m;
            }
            else if (nominalSize > 80 && nominalSize <= 120)
            {
                r0smin = 1.1m;
            }
        }
    }
}
