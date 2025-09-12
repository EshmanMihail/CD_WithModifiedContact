using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Calculation.OuterRingParameters
{
    public class Calculator_d0_b1
    {
        private Dictionary<int, List<(decimal, decimal)>> dictionary = new Dictionary<int, List<(decimal, decimal)>>();


        private List<(decimal, decimal)> values_d0_b1 = new List<(decimal, decimal)>()
        {
            // b    d0
            (6.3m, 2.8m),
            (8.0m, 3.2m),
            (11.0m, 5.0m),
            (14.0m, 6.3m),
            (16.0m, 7.1m),
            (22.0m, 9.0m)
        };

        public Calculator_d0_b1()
        {
            FillDictionary();
        }

        private void FillDictionary()
        {
            dictionary[93] = new List<(decimal, decimal)>
            {
                (-1, -1), (-1, -1), (250, 380), (-1, -1), (-1, -1), (-1, -1)
            };

            dictionary[13] = new List<(decimal, decimal)>
            {
                (-1, -1), (170, 225), (240, 260), (280, 310), (340, 480), (520, 980)
            };

            dictionary[14] = new List<(decimal, decimal)>
            {
                (180, 225), (240, 290), (310, 420), (460, 480), (520, 560), (-1, -1)
            };

            dictionary[73] = new List<(decimal, decimal)>
            {
                (-1, -1), (165, 180), (200, 225), (250, 270), (280, 370), (400, 1030)
            };

            dictionary[74] = new List<(decimal, decimal)>
            {
                (180, 210), (225, 280), (300, 400), (440, 460), (460, 700), (700, 980)
            };

            dictionary[50] = new List<(decimal, decimal)>
            {
                (52, 160), (170, 200), (215, 250), (270, 290), (310, 400), (440, 720)
            };

            dictionary[23] = new List<(decimal, decimal)>
            {
                (52, 150), (160, 215), (230, 250), (270, 320), (340, 500), (540, 980)
            };

            dictionary[60] = new List<(decimal, decimal)>
            {
                (90, 130), (140, 180), (190, 215), (240, 260), (280, 360), (380, 820)
            };

            dictionary[33] = new List<(decimal, decimal)>
            {
                (-1, -1), (-1, -1), (190, 215), (240, 260), (-1, -1), (-1, -1)
            };
        }

        public decimal Getd0(decimal D, string bearingName)
        {
            int ds = DiameterSeries(bearingName);
            int ws = WidthSeries(bearingName);

            int key = ds * 10 + ws;

            List<(decimal, decimal)> list = dictionary[key];

            for (int i = 0; i < list.Count; i++)
            {
                if (D >= list[i].Item1 && D <= list[i].Item2)
                {
                    return values_d0_b1[i].Item2;
                }
            }

            return -1;
        }

        public decimal Getb1(decimal D, string bearingName)
        {
            int ws = WidthSeries(bearingName);
            int ds = DiameterSeries(bearingName);

            int key = ds * 10 + ws;

            List<(decimal, decimal)> list = dictionary[key];

            for (int i = 0; i < list.Count; i++)
            {
                if (D >= list[i].Item1 && D <= list[i].Item2)
                {
                    return values_d0_b1[i].Item1;
                }
            }

            return -1;
        }

        private int WidthSeries(string bearingName)
        {
            string name = GetBearingSymbol(bearingName);

            string widthSeriesString = "" + name[0];

            return int.Parse(widthSeriesString);
        }

        private int DiameterSeries(string bearingName)
        {
            string name = GetBearingSymbol(bearingName);

            int diameterSeriesIndex = 4;
            if (name[4] == '0') diameterSeriesIndex = 5;

            string diameterSeriesString = "" + name[diameterSeriesIndex];

            return int.Parse(diameterSeriesString);
        }

        private string GetBearingSymbol(string bearingName)
        {
            string result = PadWithZeros(ExtractNumbers(DeletePrefix(bearingName)), 7);

            return result;
        }

        private string DeletePrefix(string bearingName)
        {
            string[] splitedString = bearingName.Split('-');

            if (splitedString.Length >= 2)
            {
                return splitedString[1];
            }

            return bearingName;
        }

        private string ExtractNumbers(string input)
        {
            StringBuilder numbers = new StringBuilder();

            foreach (char c in input)
            {
                if (!char.IsDigit(c)) break;
                else numbers.Append(c);
            }

            return numbers.ToString();
        }

        private string PadWithZeros(string input, int totalLength)
        {
            return input.PadLeft(totalLength, '0');
        }
    }
}
