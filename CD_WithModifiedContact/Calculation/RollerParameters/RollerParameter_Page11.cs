using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Calculation.RollerParameters
{
    public partial class RollerParameters
    {
        private decimal dp3 {  get; set; }
        private decimal f1 { get; set; }
        private decimal l5 { get; set; }
        private decimal rp {  get; set; }
        private decimal Xp { get; set; }
        private decimal d8 { get; set; }
        private decimal B8 { get; set; }
        private decimal R0 { get; set; }
        private decimal l6 { get; set; }

        private void CalculateDp3()
        {
            try
            {
                decimal resultValue = 0.84m * dp1;

                if (initParams.D <= 30) dp3 = ParameterRounder.RoundToStep(resultValue, 0.5m);
                else dp3 = ParameterRounder.RoundToStep(resultValue, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dp₃: {ex.Message}");
            }
        }

        private void CalculateF1()
        {
            try
            {
                double valueUnderSqrt = Math.Pow((double)Rp, 2) - Math.Pow(0.5d * (double)dp3, 2);

                decimal sqrtValue = (decimal)Math.Sqrt(valueUnderSqrt);

                f1 = ParameterRounder.RoundToStep(Rp - sqrtValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте f₁: {ex.Message}");
            }
        }

        private void CalculateL5()
        {
            try
            {
                l5 = ParameterRounder.RoundToStep(l3 - f1, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте l₅: {ex.Message}");
            }
        }

        private void Calculaterp()
        {
            try
            {
                rp = ParameterRounder.RoundToStep(Rp - layoutParams.Lw, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте rₚ: {ex.Message}");
            }
        }

        private void CalculateXp()
        {
            try
            {
                decimal valueWithCos = l2 * (decimal)Math.Cos((double)layoutParams.Fi1);
                decimal valueWithSin = 0.5m * dp2 * (decimal)Math.Sin((double)layoutParams.Fi1);

                decimal resultValue = Xm + valueWithCos + valueWithSin;

                if (resultValue > 0.495m * initParams.B)
                {

                }
                else Xp = ParameterRounder.RoundToStep(resultValue, 0.01m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Xₚ: {ex.Message}");
            }
        }

        private void CalculateD8()
        {
            try
            {
                d8 = ParameterRounder.RoundToStep(0.67m * dp1, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d₈: {ex.Message}");
            }
        }

        private void CalculateB8()
        {
            try
            {
                R0smax.GetValue(layoutParams.r0smin, out decimal resultValue);
                B8 = ParameterRounder.RoundToStep(resultValue, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте B₈: {ex.Message}");
            }
        }

        private void CalculateR0()
        {
            try
            {
                decimal minValue = Constants.R0MinRange * layoutParams.r0smin;

                decimal maxValue = Constants.R0MaxRange * layoutParams.r0smin;

                decimal avgValue = (minValue + maxValue) / 2;

                R0 = ParameterRounder.RoundToStep(avgValue, 0.1m);

                showMessage.Invoke($"Значение R₀ было взято среднее из диапазона.");
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте R₀: {ex.Message}");
            }
        }

        private void CalculateL6()
        {
            try
            {
                l6 = ParameterRounder.RoundToStep(layoutParams.Lw + f1, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте l₆: {ex.Message}");
            }
        }

        [ExecutionOrder(2)]
        private void AddValueToFormulaCollection_Page8()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.dp3, FormulaSymbols.dp3, dp3),
                (FormulaDescriptions.f1,  FormulaSymbols.f1,  f1),
                (FormulaDescriptions.l5,  FormulaSymbols.l5,  l5),
                (FormulaDescriptions.rp,  FormulaSymbols.rp,  rp),
                (FormulaDescriptions.Xp,  FormulaSymbols.Xp,  Xp),
                (FormulaDescriptions.d8,  FormulaSymbols.d8,  d8),
                (FormulaDescriptions.B8,  FormulaSymbols.B8,  B8),
                (FormulaDescriptions.R0,  FormulaSymbols.R0,  R0),
                (FormulaDescriptions.l6,  FormulaSymbols.l6,  l6)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }
    }
}
