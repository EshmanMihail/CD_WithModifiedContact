using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

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

        public const decimal X1MinRange = 0.025m;
        public const decimal X1MaxRange = 0.045m;

        public const decimal X2MinRange = 0.48m;
        public const decimal X2MaxRange = 0.49m;

        public const decimal BmValue = 1.15m;

        public static readonly short FirstValueIndex = 0;

        public const decimal FrMinRange = 0.1m;
        public const decimal FrMaxRange = 0.15m;

        public static readonly List<string> anglesThatRoundForMinutes = new List<string>
        {
            FormulaSymbols.alpha0_1hatch, FormulaSymbols.alpha0_2hatch, FormulaSymbols.alpha0,
            FormulaSymbols.Fik, FormulaSymbols.lambda1, FormulaSymbols.Fic, FormulaSymbols.Fir
        };

        public static readonly List<string> anglesThatRoundForSeconds = new List<string>
        {
            FormulaSymbols.alpha1, FormulaSymbols.alpha2, FormulaSymbols.fi_1hatch,
            FormulaSymbols.fi1_1hatch, FormulaSymbols.Fi1, FormulaSymbols.Fi,
            FormulaSymbols.alphaK, FormulaSymbols.gamma1, FormulaSymbols.deltaAngle
        };

        public const decimal R0MinRange = 3.0m;
        public const decimal R0MaxRange = 6.0m;

        public static readonly List<string> valuesPage1 = new List<string>
        {
            FormulaSymbols.b1, FormulaSymbols.d0, FormulaSymbols.alpha0
        };
        public static readonly List<string> valuesPage2 = new List<string>
        {
            FormulaSymbols.Ch1, FormulaSymbols.b1, FormulaSymbols.d0, FormulaSymbols.R3,
            FormulaSymbols.Ch2, FormulaSymbols.D3, FormulaSymbols.D2, FormulaSymbols.D1,
            FormulaSymbols.r3smin, FormulaSymbols.R2
        };
        public static readonly List<string> valuesPage3 = new List<string>
        {
            FormulaSymbols.Lw, FormulaSymbols.Dwe, FormulaSymbols.L1_1hatch, FormulaSymbols.fi1_1hatch,
            FormulaSymbols.alpha0_2hatch, FormulaSymbols.RT, FormulaSymbols.Fi1, FormulaSymbols.Fik,
            FormulaSymbols.alphaK, FormulaSymbols.YB, FormulaSymbols.Yop2, FormulaSymbols.Ye,
            FormulaSymbols.P, FormulaSymbols.XB, FormulaSymbols.dp2, FormulaSymbols.Xop2,
            FormulaSymbols.Xp, FormulaSymbols.Xm, FormulaSymbols.Fi, FormulaSymbols.L1, FormulaSymbols.Dw,
            FormulaSymbols.Fi1, FormulaSymbols.Xe, FormulaSymbols.Xop1, FormulaSymbols.dp1,
            FormulaSymbols.alpha0, FormulaSymbols.Yop1, FormulaSymbols.Ym
        };
        public static readonly List<string> valuesPage4 = new List<string>
        {
            FormulaSymbols.l6, FormulaSymbols.l5, FormulaSymbols.f1, FormulaSymbols.dp3,
            FormulaSymbols.l4, FormulaSymbols.l3, FormulaSymbols.L1, FormulaSymbols.f,
            FormulaSymbols.R, FormulaSymbols.dp2, FormulaSymbols.r0smin, FormulaSymbols.B8,
            FormulaSymbols.d8, FormulaSymbols.dp1, FormulaSymbols.Dw, FormulaSymbols.R0,
            FormulaSymbols.l2, FormulaSymbols.Rp, FormulaSymbols.Lw
        };
        public static readonly List<string> valuesPage5 = new List<string>
        {
            FormulaSymbols.alphaK, FormulaSymbols.r3smin, FormulaSymbols.R3, FormulaSymbols.d2,
            FormulaSymbols.d1, FormulaSymbols.R2, FormulaSymbols.d3, FormulaSymbols.dm,
            FormulaSymbols.d5, FormulaSymbols.d4, FormulaSymbols.gamma1, FormulaSymbols.d3,
            FormulaSymbols.d6, FormulaSymbols.YB, FormulaSymbols.rB, FormulaSymbols.alpha1,
            FormulaSymbols.XB2, FormulaSymbols.XB, FormulaSymbols.XB1, FormulaSymbols.m0,
            FormulaSymbols.m1, FormulaSymbols.m2, FormulaSymbols.m3, FormulaSymbols.rm, FormulaSymbols.Dk1
        };
        public static readonly List<string> valuesPage6 = new List<string>
        {
            FormulaSymbols.dk, FormulaSymbols.dm, FormulaSymbols.R2, FormulaSymbols.h1,
            FormulaSymbols.h
        };
        public static readonly List<string> valuesPage7 = new List<string>
        {
            FormulaSymbols.Dc, FormulaSymbols.dc, FormulaSymbols.Dc1, FormulaSymbols.C1,
            FormulaSymbols.Bc, FormulaSymbols.Fic, FormulaSymbols.S1, FormulaSymbols.D0,
            FormulaSymbols.b1, FormulaSymbols.gamma, FormulaSymbols.Hr, FormulaSymbols.S,
            FormulaSymbols.d2_2hatch, FormulaSymbols.dr, FormulaSymbols.alphar, FormulaSymbols.da,
            FormulaSymbols.e2
        };
    }
}
