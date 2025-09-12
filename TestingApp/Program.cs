using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestingApp
{
    internal class Program
    {
        private static Dictionary<decimal, decimal> keyValues = new Dictionary<decimal, decimal>()
        {
            { 0.01m, 52.1m },
            { 0.02m, 60.8m },
            { 0.03m, 66.5m },
            { 0.04m, 70.7m },
            { 0.05m, 74.1m },
            { 0.06m, 76.9m },
            { 0.07m, 79.2m },
            { 0.08m, 81.2m },
            { 0.09m, 82.8m },
            { 0.10m, 84.2m },
            { 0.11m, 85.4m },
            { 0.12m, 86.4m },
            { 0.13m, 87.1m },
            { 0.14m, 87.7m },
            { 0.15m, 88.2m },
            { 0.16m, 88.5m },
            { 0.17m, 88.7m },
            { 0.18m, 88.8m },
            { 0.19m, 88.8m },
            { 0.20m, 88.7m },
            { 0.21m, 88.5m },
            { 0.22m, 88.2m },
            { 0.23m, 87.9m },
            { 0.24m, 87.5m },
            { 0.25m, 87.0m },
            { 0.26m, 86.4m },
            { 0.27m, 85.8m },
            { 0.28m, 85.2m },
            { 0.29m, 84.5m },
            { 0.30m, 83.8m }
        };

        static void Main(string[] args)
        {
            string input = "4563A1GTDS";
            string name = GetBearingSymbol(input);
            Console.WriteLine(name); // Вывод: 4563
        }

        private static string GetBearingSymbol(string bearingName)
        {
            string result = PadWithZeros(ExtractNumbers(DeletePrefix(bearingName)), 7);

            return result;
        }

        private static string DeletePrefix(string bearingName)
        {
            string[] splitedString = bearingName.Split('-');

            if (splitedString.Length >= 2)
            {
                return splitedString[1];
            }

            return bearingName;
        }

        private static string ExtractNumbers(string input)
        {
            StringBuilder numbers = new StringBuilder();

            foreach (char c in input)
            {
                if (!char.IsDigit(c)) break;
                else numbers.Append(c);
            }

            return numbers.ToString();
        }

        private static string PadWithZeros(string input, int totalLength)
        {
            return input.PadLeft(totalLength, '0');
        }

        public static decimal GetValue(decimal value)
        {
            decimal formulaValue = value;

            var minValue = keyValues.Keys.Min();
            var maxValue = keyValues.Keys.Max();

            if (formulaValue < minValue || formulaValue > maxValue)
            {
                return -1;
            }

            if (keyValues.TryGetValue(formulaValue, out decimal result))
            {
                return result;
            }

            var lowerPoint = keyValues.Keys.Where(k => k < formulaValue).OrderByDescending(k => k).FirstOrDefault();
            var upperPoint = keyValues.Keys.Where(k => k > formulaValue).OrderBy(k => k).FirstOrDefault();

            Console.WriteLine($"({lowerPoint}::{upperPoint})");

            decimal y1 = keyValues[lowerPoint];
            decimal y2 = keyValues[upperPoint];
            decimal x1 = lowerPoint;
            decimal x2 = upperPoint;

            decimal interpolatedValue = y1 + (formulaValue - x1) * (y2 - y1) / (x2 - x1);

            return interpolatedValue;
        }
    }
}
