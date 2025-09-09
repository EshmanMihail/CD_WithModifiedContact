using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Helpers
{
    public class FractionConverter
    {
        /// <summary>
        /// Преобразует строку дроби в десятичное число с заданным количеством знаков после запятой.
        /// </summary>
        /// <param name="fractionStr">Строка, представляющая дробь в формате "числитель:знаменатель".</param>
        /// <param name="decimalPlaces">Количество знаков после запятой для округления.</param>
        /// <returns>Десятичное число, представляющее дробь, округлённое до указанного количества знаков.</returns>
        public static decimal GetFraction(string fractionStr, int decimalPlaces)
        {
            if (fractionStr == "0" || fractionStr == "0:0")
            {
                return 0;
            }

            string numeratorStr = GetNumeratorString(fractionStr);
            string denominatorStr = GetDenominatorString(fractionStr);

            decimal numerator = decimal.Parse(numeratorStr);
            decimal denominator = decimal.Parse(denominatorStr);

            return Math.Round(numerator / denominator, decimalPlaces);
        }

        /// <summary>
        /// Извлекает числитель из дроби, представленной в виде строки.
        /// </summary>
        /// <param name="fraction">Строка, представляющая дробь в формате "числитель:знаменатель".</param>
        /// <returns>Строка, содержащая числитель дроби.</returns
        public static string GetNumeratorString(string fraction)
        {
            string numeratorString = "";
            for (int i = 0; i < fraction.Length; i++)
            {
                if (fraction[i] == ':') break;
                else numeratorString += fraction[i];
            }

            return numeratorString;
        }

        /// <summary>
        /// Извлекает знаменатель из дроби, представленной в виде строки.
        /// </summary>
        /// <param name="fraction">Строка, представляющая дробь в формате "числитель:знаменатель".</param>
        /// <returns>Строка, содержащая знаменатель дроби.</returns>
        public static string GetDenominatorString(string fraction)
        {
            string denominatorString = "";
            int startIndex = GetColonIndex(fraction) + 1;

            for (int i = startIndex; i < fraction.Length; ++i)
            {
                denominatorString += fraction[i];
            }

            return denominatorString;
        }

        /// <summary>
        /// Находит индекс двоеточия в строке дроби.
        /// </summary>
        /// <param name="fraction">Строка, представляющая дробь в формате "числитель:знаменатель".</param>
        /// <returns>Индекс двоеточия в строке; если двоеточие не найдено, возвращает 0.</returns>
        private static int GetColonIndex(string fraction)
        {
            int index = 0;
            for (int i = 0; i < fraction.Length; i++)
            {
                if (fraction[i] == ':')
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
