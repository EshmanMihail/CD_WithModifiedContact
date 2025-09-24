using System;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation.RollerParameters;

namespace CD_WithModifiedContact.Calculation.InnerRingParameters
{
    public partial class InnerRingParameters
    {
        public decimal d4 { get; set; }
        public decimal d5 { get; set; }
        public decimal dk { get; set; }
        public decimal h { get; set; }
        public decimal h1 { get; set; }
        public decimal Dk1 { get; set; }
        public decimal m { get; set; }
        public decimal m1 { get; set; }
        public decimal m2 { get; set; }
        public decimal m3 { get; set; }
        public decimal rm { get; set; }
        public decimal dm { get; set; }

        [ExecutionOrder(99)]
        private void CalculateD4()
        {
            try
            {
                decimal fraction = XB / (decimal)Math.Sin((double)gamma1);

                d4 = ParameterRounder.RoundToStep(2 * (fraction - rB), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d4: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(100)]
        private void CalculateD5()
        {
            try
            {
                decimal resultValue = d4 * (decimal)Math.Cos((double)gamma1);

                d5 = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d5: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(101)]
        private void CalculateDk()
        {
            try
            {
                decimal resultValue = 0;

                if (FractionConverter.GetFraction(initParams.k, 3) == 0) resultValue = initParams.d;
                else resultValue = initParams.d + initParams.B / FractionConverter.GetFraction(initParams.k, 6);

                dk = ParameterRounder.RoundToStep(resultValue, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dk: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(102)]
        private void CalculateH()
        {
            try
            {
                decimal resultValue = (d1 - initParams.d + 0.18m * lp.Dw) / 2;

                h = ParameterRounder.RoundToStep(resultValue, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте h: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(103)]
        private void CalculateH1()
        {
            try
            {
                decimal resultValue = 0;
                if (FractionConverter.GetFraction(initParams.k, 3) == 0) resultValue = h;
                else resultValue = h - initParams.B / FractionConverter.GetFraction(initParams.k, 3);

                h1 = ParameterRounder.RoundToStep(resultValue, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте h1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(104)]
        private void CalculateDk1()
        {
            try
            {
                decimal resultValue = 1.2m * lp.Dw;
                Dk1 = ParameterRounder.RoundToCustomValues(resultValue);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dk1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(105)]
        private void CalculateMasses()
        {
            try
            {
                m_m1_m2_m3.Get_m_m1_m2_m3(lp.Dw, lp.Lw, out decimal m, out decimal m1, out decimal m2, out decimal m3);

                this.m = m;
                this.m1 = m1;
                this.m2 = m2;
                this.m3 = m3;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте масс m0–m3: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(106)]
        private void CalculateM2()
        {
            decimal valueInBrackets = 0.5m * (d6 - d2) * (decimal)Math.Tan((double)Fik) + 0.02m * lp.Dw;

            if (m2 < valueInBrackets)
            {
                m2 = m_m1_m2_m3.GetNearestGaltel(valueInBrackets);
            }
        }

        [ExecutionOrder(107)]
        private void CalculateRm()
        {
            try
            {
                rm = ParameterRounder.RoundToStep(0.5m * m1, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте rm: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(108)]
        private void CalculateDm()
        {
            try
            {
                R0smax.GetValue(lp.r0smin, out decimal r0smax);
                decimal resultValue = (d1 + dk - 2 * r0smax) / 2;

                if (initParams.d <= 50) dm = ParameterRounder.RoundToStep(resultValue, 0.5m);
                else dm = ParameterRounder.RoundToStep(resultValue, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dm: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(3)]
        private void AddValueToFormulaCollection_Page14()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.d4,  FormulaSymbols.d4,  d4),
                (FormulaDescriptions.d5,  FormulaSymbols.d5,  d5),
                (FormulaDescriptions.dk,  FormulaSymbols.dk,  dk),
                (FormulaDescriptions.h,   FormulaSymbols.h,   h),
                (FormulaDescriptions.h1,  FormulaSymbols.h1,  h1),
                (FormulaDescriptions.Dk1, FormulaSymbols.Dk1, Dk1),
                (FormulaDescriptions.m0,  FormulaSymbols.m0,  m),
                (FormulaDescriptions.m1,  FormulaSymbols.m1,  m1),
                (FormulaDescriptions.m2,  FormulaSymbols.m2,  m2),
                (FormulaDescriptions.m3,  FormulaSymbols.m3,  m3),
                (FormulaDescriptions.rm,  FormulaSymbols.rm,  rm),
                (FormulaDescriptions.dm,  FormulaSymbols.dm,  dm)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }
    }
}
