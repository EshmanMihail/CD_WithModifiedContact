using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Calculation.LayoutParameters
{
    public partial class LayoutParameters
    {
        public decimal alpha0 { get; set; }
        private decimal Xd { get; set; }
        private decimal Yd { get; set; }
        private decimal Xop1 { get; set; }
        private decimal Yop1 { get; set; }
        public decimal Fi1 { get; set; }
        private decimal Fi { get; set; }
        private decimal alphaK { get; set; }
        public decimal L1 { get; set; }

        [ExecutionOrder(40)]
        private void CalculateAlpha0()
        {
            try
            {
                decimal fraction = Xe / Ye;
                double radians = Math.Atan((double)fraction);
                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Alpha0.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }  

                alpha0 = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Alpha0: {ex.Message}");
                StopCalculation.Invoke();
            }
        }
        
        [ExecutionOrder(41)]
        private void CalculateXd()
        {
            try
            {
                decimal value = 0.5m * D1 * (decimal)Math.Sin((double)alpha0);
                Xd = ParameterRounder.RoundToStep(value, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Xd: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(42)]
        private void CalculateYd()
        {
            try
            {
                decimal value = 0.5m * D1 * (decimal)Math.Cos((double)alpha0);
                Yd = ParameterRounder.RoundToStep(value, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Yd: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(43)]
        private void CalculateXop1()
        {
            try
            {
                Xop1 = ParameterRounder.RoundToStep(Xd - R * (decimal)Math.Sin((double)alpha0), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Xop1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(44)]
        private void CalculateYop1()
        {
            try
            {
                Yop1 = ParameterRounder.RoundToStep(Yd - R * (decimal)Math.Cos((double)alpha0), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Yop1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(45)]
        private void CalculateFi1()
        {
            try
            {
                double fraction = (double)((Xop2 - Xop1) / (Yop2 - Yop1));
                double radians = Math.Atan(fraction);
                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Fi1.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }

                Fi1 = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fi1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(46)]
        private void CalculateFi()
        {
            try
            {
                Fi = fi_1hatch - (fi1_1hatch - Fi1);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fi: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(47)]
        private void CalculateAlphaK()
        {
            try
            {
                alphaK = Fi1 - Fi;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте AlphaK: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(48)]
        private void CalculateL1()
        {
            try
            {
                decimal value = 0.5m * Lw - R * (decimal)Math.Sin((double)Fi);
                L1 = ParameterRounder.RoundToStep(value, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте L1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(4)]
        private void AddValueToFormulaCollection_Page8()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.alpha0,       FormulaSymbols.alpha0,       alpha0),
                (FormulaDescriptions.Xd,           FormulaSymbols.Xd,           Xd),
                (FormulaDescriptions.Yd,           FormulaSymbols.Yd,           Yd),
                (FormulaDescriptions.Xop1,         FormulaSymbols.Xop1,         Xop1),
                (FormulaDescriptions.Yop1,         FormulaSymbols.Yop1,         Yop1),
                (FormulaDescriptions.Fi1,          FormulaSymbols.Fi1,          Fi1),
                (FormulaDescriptions.Fi,           FormulaSymbols.Fi,           Fi),
                (FormulaDescriptions.alphaK,       FormulaSymbols.alphaK,       alphaK),
                (FormulaDescriptions.L1,           FormulaSymbols.L1,           L1)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }
    }
}
