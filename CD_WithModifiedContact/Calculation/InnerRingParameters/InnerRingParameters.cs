using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using LP = CD_WithModifiedContact.Calculation.LayoutParameters.LayoutParameters;
using ORP = CD_WithModifiedContact.Calculation.OuterRingParameters.OuterRingParameters;
using RP = CD_WithModifiedContact.Calculation.RollerParameters.RollerParameters;


namespace CD_WithModifiedContact.Calculation.InnerRingParameters
{
    public partial class InnerRingParameters : Parameters
    {
        private ShowMessage showMessage;
        public event Action StopCalculation;
        public event Action<string, decimal> RecalculateRequested;

        private InitialParameters initParams;
        private LP lp;
        private ORP orp;
        private RP rp;

        public InnerRingParameters(InitialParameters initParams, LP lp, ORP orp, RP rp)
        {
            this.initParams = initParams;
            this.lp = lp;
            this.orp = orp;
            this.rp = rp;
        }

        private decimal d2_2hatch {  get; set; }
        private decimal d6 {  get; set; }
        private decimal Fik { get; set; }
        private decimal rB { get; set; }
        private decimal XB { get; set; }
        private decimal XB1 { get; set; }
        private decimal XB2 { get; set; }
        private decimal YB { get; set; }
        private decimal a { get; set; }
        private decimal d2 {  get; set; }

        [ExecutionOrder(78)]
        private void CalculateD2_2hatch()
        {
            try
            {
                decimal firstValue = rp.Ym + lp.L1 * (decimal)Math.Sin((double)lp.Fi1);
                decimal secondValue = 0.5m * rp.dp1 * (decimal)Math.Sin((double)lp.Fi1);

                d2_2hatch = ParameterRounder.RoundToStep(2 * (firstValue - secondValue), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d2_2hatch: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(79)]
        private void CalculateD6()
        {
            try
            {
                decimal resultValue = d2_2hatch + 0.33m * rp.dp1;

                if (initParams.d <= 50) d6 = ParameterRounder.RoundToStep(resultValue, 0.5m);
                else d6 = ParameterRounder.RoundToStep(resultValue, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d6: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(80)]
        private void CalculateFik() // est kakieto otklonenia, na katorie zabil poka
        {
            try
            {
                double fractionValue = (double)((d2_2hatch + d6) / (4 * rp.RT));
                double radians = Math.Asin(fractionValue);

                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Fik.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }

                Fik = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fik: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(81)]
        private void CalculateRB()
        {
            try
            {
                rB = ParameterRounder.RoundToStep(lp.rh, 0.5m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте rB: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(82)]
        private void CalculateXB()
        {
            try
            {
                decimal secondPart = (rB - lp.R) * (decimal)Math.Sin((double)lp.alphaK);
                XB = ParameterRounder.RoundToStep(lp.Xop2 + secondPart, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте XB: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(83)]
        private void CalculateXB1()
        {
            try
            {
                XB1 = ParameterRounder.RoundToStep(0.5m * initParams.B - XB, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте XB1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(84)]
        private void CalculateXB2()
        {
            try
            {
                XB2 = ParameterRounder.RoundToStep(0.5m * initParams.B + XB, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте XB2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(85)]
        private void CalculateYB()
        {
            try
            {
                decimal resultValue = lp.Yop2 + (rB - lp.R) * (decimal)Math.Cos((double)lp.alphaK);
                YB = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте YB: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(86)]
        private void CalculateA()
        {
            try
            {
                decimal firstPart = 2 * (rp.Xm - lp.L1 * (decimal)Math.Cos((double)lp.Fi1));

                decimal innerBrackets = rB - (decimal)Math.Sqrt(Math.Pow((double)rB, 2) + Math.Pow((double)lp.L1, 2));

                double sinFraction = Math.Pow((double)(d6 - d2_2hatch), 2) / (16 * (double)rp.RT * Math.Cos((double)lp.alphaK));
                decimal sinValue = (decimal)Math.Sin((double)lp.Fi1 - sinFraction);

                decimal secondPart = lp.Dw - 2 * innerBrackets * sinValue;

                a = ParameterRounder.RoundToStep(firstPart - secondPart, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте a: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(87)]
        private void CalculateD2()
        {
            try
            {
                double rbSquare = Math.Pow((double)rB, 2);
                double bracketsSquare = Math.Pow((double)(XB - 0.5m * a), 2);
                decimal sqrtValue = (decimal)Math.Sqrt(rbSquare - bracketsSquare);

                d2 = ParameterRounder.RoundToStep(2 * (YB - sqrtValue), 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(1)]
        private void AddValueToFormulaCollection()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.d2_2hatch, FormulaSymbols.d2_2hatch, d2_2hatch),
                (FormulaDescriptions.d6,        FormulaSymbols.d6,        d6),
                (FormulaDescriptions.Fik,       FormulaSymbols.Fik,       Fik),
                (FormulaDescriptions.rB,        FormulaSymbols.rB,        rB),
                (FormulaDescriptions.XB,        FormulaSymbols.XB,        XB),
                (FormulaDescriptions.XB1,       FormulaSymbols.XB1,       XB1),
                (FormulaDescriptions.XB2,       FormulaSymbols.XB2,       XB2),
                (FormulaDescriptions.YB,        FormulaSymbols.YB,        YB),
                (FormulaDescriptions.a,         FormulaSymbols.a,         a),
                (FormulaDescriptions.d2,        FormulaSymbols.d2,        d2)
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
