using System;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.InnerRingParameters
{
    public class m_m1_m2_m3
    {
        private static List<(decimal, decimal, decimal, decimal)> m_m1_m2_m3_list = new List<(decimal, decimal, decimal, decimal)>()
        {
            (0.5m, 1.1m, 1.3m, 0.5m ),
            (0.5m, 1.1m, 1.6m, 0.5m ),
            (0.7m, 1.5m, 2.0m, 0.5m ),
            (0.9m, 2.1m, 2.8m, 0.8m ),
            (1.0m, 2.7m, 3.2m, 0.9m )
        };

        public static void Get_m_m1_m2_m3(decimal Dw, decimal Lw, out decimal m, out decimal m1, out decimal m2, out decimal m3)
        {
            decimal nominalSize = (Dw <= Lw) ? Dw : Lw;

            if (nominalSize > 0 && nominalSize <= 18)
            {
                var values = m_m1_m2_m3_list[0];
                m = values.Item1;
                m1 = values.Item2;
                m2 = values.Item3;
                m3 = values.Item4;
            }
            else if (nominalSize > 18 && nominalSize <= 30)
            {
                var values = m_m1_m2_m3_list[1];
                m = values.Item1;
                m1 = values.Item2;
                m2 = values.Item3;
                m3 = values.Item4;
            }
            else if (nominalSize > 30 && nominalSize <= 50)
            {
                var values = m_m1_m2_m3_list[2];
                m = values.Item1;
                m1 = values.Item2;
                m2 = values.Item3;
                m3 = values.Item4;
            }
            else if (nominalSize > 50 && nominalSize <= 80)
            {
                var values = m_m1_m2_m3_list[3];
                m = values.Item1;
                m1 = values.Item2;
                m2 = values.Item3;
                m3 = values.Item4;
            }
            else if (nominalSize > 80 && nominalSize <= 120)
            {
                var values = m_m1_m2_m3_list[4];
                m = values.Item1;
                m1 = values.Item2;
                m2 = values.Item3;
                m3 = values.Item4;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(nominalSize), "Размер вне допустимого диапазона (0–120).");
            }
        }

        public static decimal GetNearestGaltel(decimal bracketsValue)
        {
            decimal result = m_m1_m2_m3_list[m_m1_m2_m3_list.Count - 1].Item3;

            for (int i = 0; i < m_m1_m2_m3_list.Count - 1; i++)
            {
                if (m_m1_m2_m3_list[i].Item3 >= bracketsValue)
                {
                    result = m_m1_m2_m3_list[i].Item3;
                }
            }

            return result;
        }
    }
}
