using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Helpers
{
    public class ParameterRounder
    {
        public static decimal RoundToStep(decimal value, decimal step)
        {
            return Math.Round(value / step) * step;
        }

        public static string RoundAngleToMinutes(double value)
        {
            double degrees = value * (180 / Math.PI);
            double decimalPartNumber = double.Parse(GetDecimalPartOfValue(degrees));
            string roundedMinutes = GetIntegerPartOfNumber(decimalPartNumber * 60);

            return GetIntegerPartOfNumber(degrees) + '°' + roundedMinutes + '`';
        }

        public static string RoundAngleToSeconds(double value)
        {
            double degrees = value * (180 / Math.PI);
            
            string decimalPart = GetDecimalPartOfValue(degrees);

            double decimalPartNumber = double.Parse(decimalPart);
            double minutes = decimalPartNumber * 60;

            string decimalPartOfMinutes = GetDecimalPartOfValue(minutes);
            double decimalPartOfMinutesNumber = double.Parse(decimalPartOfMinutes);

            double seconds = decimalPartOfMinutesNumber * 60;
            double roundedSeconds = Math.Round(seconds);

            return GetIntegerPartOfNumber(degrees) + '°' + GetIntegerPartOfNumber((double)minutes) + '`' + roundedSeconds.ToString() + "``";
        }

        public static string GetIntegerPartOfNumber(double value)
        {
            string integerPart = "";

            string valueStr = value.ToString();

            for (int i = 0; i < valueStr.Length; i++)
            {
                if (valueStr[i] == ',' || valueStr[i] == '.') break;

                if (valueStr[i] != ' ') integerPart += valueStr[i];
            }

            return integerPart;
        }

        private static string GetDecimalPartOfValue(double value)
        {
            string decimalPart = "0,";

            string valueStr = value.ToString();

            bool startWriteDecimalPart = false;
            for (int i = 0; i < valueStr.Length; i++)
            {
                if (startWriteDecimalPart && valueStr[i] != ' ') decimalPart += valueStr[i];

                if (valueStr[i] == ',' || valueStr[i] == '.')
                {
                    startWriteDecimalPart = true;
                }
            }

            return decimalPart;
        }

    }
}
