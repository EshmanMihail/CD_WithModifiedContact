using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace CD_WithModifiedContact.Calculation.LayoutParameters
{
    public partial class LayoutParameters
    {
        private decimal fi1_1hatch { get; set; }
        private decimal L1_1hatch { get; set; }
        private decimal Dwe { get; set; }
        private decimal d_hatch_p1 { get; set; }
        private decimal Xa { get; set; }
        private decimal Ya { get; set; }
        private decimal Xop2 { get; set; }
        private decimal Yop2 { get; set; }
        private decimal P { get; set; }
        private decimal Xe { get; set; }
        private decimal Ye { get; set; }
        
        [ExecutionOrder(29)]
        private void CalculateFi1_1hatch()
        {
            try
            {
                fi1_1hatch = alpha0_2hatch - fi_1hatch;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fi1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(30)]
        private void CalculateL1_1hatch()
        {
            try
            {
                L1_1hatch = ParameterRounder.RoundToStep(0.5m * Lw - R * (decimal)Math.Sin((double)fi_1hatch), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте L1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(31)]
        private void CalculateDwe()
        {
            try
            {
                double valueUnderSqrt = Math.Pow((double)R, 2) - Math.Pow((double)(0.5m * Lw - L1_1hatch), 2);

                double sqrtValue = Math.Sqrt(valueUnderSqrt);

                double valueInBrackets = (double)R - sqrtValue;

                Dwe = ParameterRounder.RoundToStep(Dw - 2m * (decimal)valueInBrackets, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dwe: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(32)]
        private void CalculateD_hatch_p1()
        {
            try
            {
                double valueUnderSqrt = Math.Pow((double)R, 2) - Math.Pow((double)L1_1hatch, 2);

                double sqrtValue = Math.Sqrt(valueUnderSqrt);

                decimal valueInBrackets = R - (decimal)sqrtValue;

                d_hatch_p1 = ParameterRounder.RoundToStep(Dw - 2m * valueInBrackets, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dp1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(33)]
        private void CalculateXa()
        {
            try
            {
                decimal resValue = 0.5m * D1 * (decimal)Math.Sin((double)alpha0_2hatch) - Dwe * (decimal)Math.Sin((double)fi1_1hatch);
                Xa = ParameterRounder.RoundToStep(resValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Xa: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(34)]
        private void CalculateYa()
        {
            try
            {
                decimal resValue = 0.5m * D1 * (decimal)Math.Cos((double)alpha0_2hatch) - Dwe * (decimal)Math.Cos((double)fi1_1hatch);
                Ya = ParameterRounder.RoundToStep(resValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Ya: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(35)]
        private void CalculateXop2()
        {
            try
            {
                decimal resValue = Xa + R * (decimal)Math.Sin((double)(fi1_1hatch - fi_1hatch));
                Xop2 = ParameterRounder.RoundToStep(resValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Xop2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(36)]
        private void CalculateYop2()
        {
            try
            {
                decimal resValue = Ya + R * (decimal)Math.Cos((double)(fi1_1hatch - fi_1hatch));
                Yop2 = ParameterRounder.RoundToStep(resValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Yop2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(37)]
        private void CalculateP()
        {
            try
            {
                P = ParameterRounder.RoundToStep(0.08m * d_hatch_p1, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте P: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(38)]
        private void CalculateXe()
        {
            try
            {
                decimal resValue = Xa + P * (decimal)Math.Sin((double)(fi1_1hatch - fi_1hatch));
                Xe = ParameterRounder.RoundToStep(resValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Xe: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(39)]
        private void CalculateYe()
        {
            try
            {
                decimal resValue = Ya + P * (decimal)Math.Cos((double)(fi1_1hatch - fi_1hatch));
                Ye = ParameterRounder.RoundToStep(resValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Ye: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(3)]
        private void AddValueToFormulaCollection_Page7()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.fi1_1hatch,       FormulaSymbols.fi1_1hatch,       fi1_1hatch),
                (FormulaDescriptions.L1_1hatch,        FormulaSymbols.L1_1hatch,        L1_1hatch),
                (FormulaDescriptions.Dwe,              FormulaSymbols.Dwe,              Dwe),
                (FormulaDescriptions.d_hatch_p1,       FormulaSymbols.d_hatch_p1,       d_hatch_p1),
                (FormulaDescriptions.XA,               FormulaSymbols.XA,               Xa),
                (FormulaDescriptions.Ya,               FormulaSymbols.Ya,               Ya),
                (FormulaDescriptions.Xop2,             FormulaSymbols.Xop2,             Xop2),
                (FormulaDescriptions.Yop2,             FormulaSymbols.Yop2,             Yop2),
                (FormulaDescriptions.P,                FormulaSymbols.P,                P),
                (FormulaDescriptions.Xe,               FormulaSymbols.Xe,               Xe),
                (FormulaDescriptions.Ye,               FormulaSymbols.Ye,               Ye)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }
    }
}