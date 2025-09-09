using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Helpers
{
    public class LambdaHelper
    {
        /// <summary>
        /// Рассчитывает среднее значение из диапазона и возвращает его.
        /// </summary>
        public decimal GetLambdaAvgValue(string rangeString)
        {
            GetChosenRange(rangeString, out decimal minRangeValue, out decimal maxRangeValue);
            return (minRangeValue + maxRangeValue) / 2;
        }

        /// <summary>
        /// Извлекает минимальное и максимальное значения из строки диапазона.
        /// </summary>
        private void GetChosenRange(string rangeString, out decimal minValue, out decimal maxValue)
        {
            rangeString.Trim();
            minValue = GetMinValue(rangeString);
            maxValue = GetMaxValue(rangeString);
        }

        public decimal GetMinValue(string rangeString)
        {
            string minValueString = "";
            for (int i = 0; i < rangeString.Length; i++)
            {
                if (rangeString[i] == '.' || rangeString[i] == ' ') break;
                else minValueString += rangeString[i];
            }
            return decimal.Parse(minValueString);
        }

        public decimal GetMaxValue(string rangeString)
        {
            string maxValueString = "";
            for (int i = rangeString.Length - 1; i >= 0; i--)
            {
                if (rangeString[i] == '.' || rangeString[i] == ' ') break;
                else maxValueString += rangeString[i];
            }
            return decimal.Parse(Reverse(maxValueString));
        }

        private string Reverse(string stringOfNumber)
        {
            string resalt = "";
            for (int i = stringOfNumber.Length - 1; i >= 0; i--)
            {
                if (stringOfNumber[i] == '.' || stringOfNumber[i] == ' ') break;
                else resalt += stringOfNumber[i];
            }
            return resalt;
        }
    }
}
