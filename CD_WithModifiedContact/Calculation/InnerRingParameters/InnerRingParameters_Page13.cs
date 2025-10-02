using System;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;

namespace CD_WithModifiedContact.Calculation.InnerRingParameters
{
    public partial class InnerRingParameters
    {
        [PropertyMetadata(FormulaSymbols.a2)]
        public decimal a2 { get; set; }

        [PropertyMetadata(FormulaSymbols.a3)]
        public decimal a3 { get; set; }

        [PropertyMetadata(FormulaSymbols.lambda1)]
        public decimal lambda1 { get; set; }

        [PropertyMetadata(FormulaSymbols.delta)]
        public decimal delta { get; set; }

        [PropertyMetadata(FormulaSymbols.dp2_1hatch)]
        public decimal dp2_1hatch { get; set; }

        [PropertyMetadata(FormulaSymbols.a1)]
        public decimal a1 { get; set; }

        [PropertyMetadata(FormulaSymbols.d1)]
        public decimal d1 { get; set; }

        [PropertyMetadata(FormulaSymbols.d3)]
        public decimal d3 { get; set; }

        [PropertyMetadata(FormulaSymbols.F)]
        public decimal F { get; set; }

        [PropertyMetadata(FormulaSymbols.gamma1)]
        public decimal gamma1 { get; set; }



        private void CalculateRecalculation2()
        {
            if (a < 0.75m * (d6 - d2))
            {
                StopCalculation.Invoke();
                RecalculateRequested.Invoke("X1", initParams.X1 + 0.005m * (initParams.D - initParams.d));//newValue
            }
        }

        [ExecutionOrder(89, FormulaSymbols.a2)]
        private void CalculateA2()
        {
            try
            {
                a2 = ParameterRounder.RoundToStep(0.5m * (initParams.B - a), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте a2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(90, FormulaSymbols.a3)]
        private void CalculateA3()
        {
            try
            {
                a3 = ParameterRounder.RoundToStep(a2 + a, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте a3: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(91, FormulaSymbols.lambda1)]
        private void CalculateLambda1() // ещё раз проверить рассчёт с точностью как его делатб
        {
            try
            {
                lambda1 = ParameterRounder.RoundRadiansToHalfDegree(lp.Fi1);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте lambda1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(92, FormulaSymbols.delta)]
        private void CalculateDelta()
        {
            try
            {
                decimal firstFraction = (0.1m * rp.dp2 - lp.r0smin) / (decimal)Math.Cos((double)lambda1);

                decimal valueWithSin = 2 * rp.l2 * (decimal)Math.Sin((double)lp.Fi1);
                decimal valueWithCos = rp.dp2 * (decimal)Math.Cos((double)lp.Fi1);

                decimal numerator = d6 - rp.Ym + valueWithSin + valueWithCos - 0.1m * rp.dp2 - lp.r0smin;

                decimal denominator = 2 * lp.Lw * (decimal)Math.Cos((double)lp.Fi1);

                decimal resultValue = firstFraction * (decimal)Math.Sin(Math.Atan((double)(numerator / denominator)) - 1/*lambda*/);

                delta = ParameterRounder.RoundUpToTenth(resultValue);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте delta: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(93, FormulaSymbols.dp2_1hatch)]
        private void CalculateDp2_1hatch()
        {
            try
            {
                decimal sqrtValue = (decimal)Math.Sqrt(Math.Pow((double)rB, 2) - Math.Pow((double)rp.l2, 2));

                decimal resultValue = lp.Dw - 2 * (rB - sqrtValue);

                dp2_1hatch = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dp2_1hatch: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(94, FormulaSymbols.a1)]
        private void CalculateA1()
        {
            try
            {
                decimal valueWithCos = (rp.l2 + delta) * (decimal)Math.Cos((double)lp.Fi1);
                decimal valueWithSin = 0.5m * dp2_1hatch * (decimal)Math.Sin((double)lp.Fi1);

                decimal resultValue = 0.5m * initParams.B - rp.Xm - valueWithCos + valueWithSin;

                a1 = ParameterRounder.RoundToStep(resultValue, 0.01m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте a1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(95, FormulaSymbols.d1)]
        private void CalculateD1()
        {
            try
            {
                double rbSquare = Math.Pow((double)rB, 2);
                double bracketsSquare = Math.Pow((double)(XB - 0.5m * initParams.B + a1), 2);

                decimal sqrtValue = (decimal)Math.Sqrt(rbSquare - bracketsSquare);

                d1 = ParameterRounder.RoundToStep(2 * (YB - sqrtValue), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(96, FormulaSymbols.d3)]
        private void CalculateD3()
        {
            try
            {
                decimal resultValue = d1 + 0.2m * rp.dp2;

                if (initParams.Name == "4003000")
                {
                    if (initParams.d <= 50) d3 = ParameterRounder.RoundToStep(resultValue, 0.33m);
                    else d3 = ParameterRounder.RoundToStep(resultValue, 0.35m);
                }
                else
                {
                    if (initParams.d <= 50) d3 = ParameterRounder.RoundToStep(resultValue, 0.5m);
                    else d3 = ParameterRounder.RoundToStep(resultValue, 0.1m);
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d3: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(97, FormulaSymbols.F)]
        private void CalculateF()
        {
            try
            {
                F = ParameterRounder.RoundToStep(lp.Lw + delta, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте F: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(98, FormulaSymbols.gamma1)]
        private void CalculateGamma1()
        {
            try
            {
                if (YB == 0)
                {
                    showMessage.Invoke("Ошибка при подсчёте Gamma1.\nДеление на ноль: YB не должен быть равен 0.");
                    StopCalculation.Invoke();
                    return;
                }

                double ratio = (double)(XB / YB);
                double radians = Math.Atan(ratio);

                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Gamma1.\nРезультат arctg некорректен.");
                    StopCalculation.Invoke();
                    return;
                }

                gamma1 = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте gamma1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(2, "")]
        private void AddValueToFormulaCollection_Page13()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.a2,         FormulaSymbols.a2,         a2),
                (FormulaDescriptions.a3,         FormulaSymbols.a3,         a3),
                (FormulaDescriptions.lambda1,    FormulaSymbols.lambda1,    lambda1),
                (FormulaDescriptions.delta,      FormulaSymbols.delta,      delta),
                (FormulaDescriptions.dp2_1hatch, FormulaSymbols.dp2_1hatch, dp2_1hatch),
                (FormulaDescriptions.a1,         FormulaSymbols.a1,         a1),
                (FormulaDescriptions.d1,         FormulaSymbols.d1,         d1),
                (FormulaDescriptions.d3,         FormulaSymbols.d3,         d3),
                (FormulaDescriptions.F,          FormulaSymbols.F,          F),
                (FormulaDescriptions.gamma1,     FormulaSymbols.gamma1,     gamma1)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }
    }
}
