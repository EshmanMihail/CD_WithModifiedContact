using System;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;

namespace CD_WithModifiedContact.Calculation.LayoutParameters
{
    public delegate void ShowMessage(string message);
    //page 5
    public partial class LayoutParameters : Parameters
    {
        private InitialParameters initParams;

        private ShowMessage showMessage;

        public event Action StopCalculation;

        public LayoutParameters(InitialParameters initParams)
        {
            this.initParams = initParams;
        }

        [PropertyMetadata(FormulaSymbols.Dw)]
        public decimal Dw { get; set; }

        [PropertyMetadata(FormulaSymbols.alpha0_1hatch)]
        private decimal alpha0_1hatch { get; set; }

        [PropertyMetadata(FormulaSymbols.D1)]
        public decimal D1 { get; set; }

        [PropertyMetadata(FormulaSymbols.alpha0_2hatch)]
        private decimal alpha0_2hatch { get; set; }

        [PropertyMetadata(FormulaSymbols.rh)]
        public decimal rh { get; set; }

        [PropertyMetadata(FormulaSymbols.gamma)]
        private decimal gamma { get; set; }

        [PropertyMetadata(FormulaSymbols.fc)]
        private decimal fc { get; set; }

        [PropertyMetadata(FormulaSymbols.z)]
        public decimal z { get; set; }

        [PropertyMetadata(FormulaSymbols.Lw)]
        public decimal Lw { get; set; }

        [PropertyMetadata(FormulaSymbols.r0smin)]
        public decimal r0smin { get; set; }


        [ExecutionOrder(8, FormulaSymbols.Dw)]
        private void CalculateDw()
        {
            try
            {
                decimal dw = 0.25m * (initParams.D - initParams.d);

                if (dw <= 30)
                {
                    Dw = ParameterRounder.RoundToStep(dw, 0.5m);
                }
                else
                {
                    Dw = ParameterRounder.RoundToStep(dw, 1.0m);
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dw: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(9, FormulaSymbols.alpha0_1hatch)]
        private void CalculateAlpha0_1hatch()
        {
            try
            {
                double fractionValue = (double)((initParams.X1 + initParams.X2) / (0.9m * initParams.D - Dw));

                double radians = Math.Asin(fractionValue);
                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Alpha`.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }

                alpha0_1hatch = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Alpha`: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(10, FormulaSymbols.D1)]
        private void CalculateD1()
        {
            try
            {
                decimal denominator = (decimal)(4d * Math.Cos((double)alpha0_1hatch));

                decimal d1 = (3m * initParams.D + initParams.d + initParams.B * FractionConverter.GetFraction(initParams.k, 2)) / denominator;

                D1 = ParameterRounder.RoundToStep(d1, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте D1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(11, FormulaSymbols.alpha0_2hatch)]
        private void CalculateAlpha0_2hatch()
        {
            try
            {
                double fractionValue = (double)((initParams.X1 + initParams.X2) / (D1 - Dw));

                double radians = Math.Asin(fractionValue);
                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Alpha``.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }

                alpha0_2hatch = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Alpha``: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(12, FormulaSymbols.rh)]
        private void CalculateRh()
        {
            try
            {
                rh = ParameterRounder.RoundToStep(0.5m * D1, 0.5m);
            }
            catch(Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте rh: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(13, FormulaSymbols.gamma)]
        private void CalculateGamma()
        {
            try
            {
                gamma = ParameterRounder.RoundToStep(Dw / (D1 - Dw), 0.01m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте gamma: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(14, FormulaSymbols.fc)]
        private void CalculateFc()
        {
            try
            {
                fc = Fc.GetValue(Dw, D1 - Dw, alpha0_1hatch);

                if (fc == -1)
                {
                    showMessage.Invoke($"Ошибка в расчёте fc. Ошибка: значение вне диапазона! ГОСТ 18855 табл. 7");
                    StopCalculation.Invoke();
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте fc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(15, FormulaSymbols.z)]
        private void CalculateZ()
        {
            try
            {
                decimal fraction = ((decimal)Math.PI * (D1 - Dw) * (decimal)Math.Cos((double)alpha0_2hatch)) / (1.12m * Dw);

                string integerPartStr = ParameterRounder.GetIntegerPartOfNumber((double)fraction);

                int integerPart = int.Parse(integerPartStr);

                if (integerPart % 2 == 0) z = integerPart;
                else z = ParameterRounder.RoundToStep(fraction, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте z: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(16, FormulaSymbols.Lw)]
        private void CalculateLw()
        {
            try
            {
                double radians = Math.Asin((double)(2 * initParams.X2 / D1)) - (double)alpha0_2hatch;

                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Lw.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }

                decimal roundedResult = ParameterRounder.RoundToStep(D1 * (decimal)Math.Sin(radians), 0.1m);

                Lw = roundedResult;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Lw: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(17, FormulaSymbols.r0smin)]
        private void CalculateR0smin()
        {
            try
            {
                R0smin.GetValue(Dw, Lw, out decimal r0sminres);

                r0smin = r0sminres;

                if (r0smin == 0)
                {
                    showMessage.Invoke("Ошибка при подсчёте r0smin.\nЗначение не входит не в один из заданных диапазонов.");
                    StopCalculation.Invoke();
                    return;
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте R0smin: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(1, "")]
        private void AddValueToFormulaCollection()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.Dw,            FormulaSymbols.Dw,            Dw),
                (FormulaDescriptions.alpha0_1hatch, FormulaSymbols.alpha0_1hatch, alpha0_1hatch),
                (FormulaDescriptions.D1,            FormulaSymbols.D1,            D1),
                (FormulaDescriptions.alpha0_2hatch, FormulaSymbols.alpha0_2hatch, alpha0_2hatch),
                (FormulaDescriptions.rh,            FormulaSymbols.rh,            rh),
                (FormulaDescriptions.gamma,         FormulaSymbols.gamma,         gamma),
                (FormulaDescriptions.fc,            FormulaSymbols.fc,            fc),
                (FormulaDescriptions.z,             FormulaSymbols.z,             z),
                (FormulaDescriptions.Lw,            FormulaSymbols.Lw,            Lw),
                (FormulaDescriptions.r0smin,        FormulaSymbols.r0smin,        r0smin)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }

        public void MessageHendler(ShowMessage messageMethod)
        {
            showMessage = messageMethod;
        }

        public void ClearFormulasInfo()
        {
            resultOfCalculations.Clear();
        }
    }
}
