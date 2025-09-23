using System;
using System.IO;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Helpers
{
    public class Constants
    {
        public static readonly string FilePath = Path.Combine(
           AppDomain.CurrentDomain.BaseDirectory,
           "Data",
           "BearingsData.xml"
        );

        public static readonly string FullFilePath = Path.GetFullPath(FilePath);

        public static readonly decimal X1MinRange = 0.025m;
        public static readonly decimal X1MaxRange = 0.045m;

        public static readonly decimal X2MinRange = 0.48m;
        public static readonly decimal X2MaxRange = 0.49m;

        public static readonly decimal BmValue = 1.15m;

        public static readonly short FirstValueIndex = 0;

        public static readonly decimal FrMinRange = 0.1m;
        public static readonly decimal FrMaxRange = 0.15m;

        public static readonly List<string> anglesThatRoundForMinutes = new List<string>
        {
            FormulaSymbols.alpha0_1hatch, FormulaSymbols.alpha0_2hatch, FormulaSymbols.alpha0,
            FormulaSymbols.Fik
        };

        public static readonly List<string> anglesThatRoundForSeconds = new List<string>
        {
            FormulaSymbols.alpha1, FormulaSymbols.alpha2, FormulaSymbols.fi_1hatch,
            FormulaSymbols.fi1_1hatch, FormulaSymbols.Fi1, FormulaSymbols.Fi,
            FormulaSymbols.alphaK, FormulaSymbols.gamma1
        };

        public static readonly decimal R0MinRange = 3.0m;
        public static readonly decimal R0MaxRange = 6.0m;
    }
}
