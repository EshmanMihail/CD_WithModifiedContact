using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Calculation.RollerParameters
{
    public partial class RollerParameters : Parameters
    {
        private InitialParameters initParams;
        private LayoutParameters.LayoutParameters layoutParams;
        private OuterRingParameters.OuterRingParameters outerRingParams;

        private ShowMessage showMessage;
        public event Action<string, decimal> RecalculateRequested;
        public event Action StopCalculation;

        public RollerParameters(InitialParameters initParams,
               LayoutParameters.LayoutParameters layoutParams,
               OuterRingParameters.OuterRingParameters outerRingParams)
        {
            this.initParams = initParams;
            this.layoutParams = layoutParams;
            this.outerRingParams = outerRingParams;
        }

        public decimal dp1 { get; set; }

        public decimal Xm { get; set; }

        public decimal Ym { get; set; }

        public decimal RT { get; set; }

        public decimal Rp { get; set; }

        public decimal f {  get; set; }

        public decimal l3 { get; set; }

        public decimal l4 { get; set; }

        public decimal l2 { get; set; }

        public decimal dp2 { get; set; }
        
        [ExecutionOrder(58)]
        private void CalculateDp1()
        {
            try
            {
                double valueUnderSqrt = Math.Pow((double)layoutParams.R, 2) - Math.Pow((double)layoutParams.L1, 2);
                decimal sqrtValue = (decimal)Math.Sqrt(valueUnderSqrt);

                decimal resultValue = layoutParams.Dw - 2 * (layoutParams.R - sqrtValue);

                dp1 = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dp₁: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(59)]
        private void CalculateXm()
        {
            try
            {
                decimal firstPart = (layoutParams.D1 / 2 - layoutParams.R) * (decimal)Math.Sin((double)layoutParams.alpha0);
                decimal secondPart = (layoutParams.R - layoutParams.Dw / 2) * (decimal)Math.Sin((double)layoutParams.Fi1);

                Xm = ParameterRounder.RoundToStep(firstPart + secondPart, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Xm: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(60)]
        private void CalculateYm()
        {
            try
            {
                decimal firstPart = (layoutParams.D1 / 2 - layoutParams.R) * (decimal)Math.Cos((double)layoutParams.alpha0);
                decimal secondPart = (layoutParams.R - layoutParams.Dw / 2) * (decimal)Math.Cos((double)layoutParams.Fi1);

                Ym = ParameterRounder.RoundToStep(firstPart + secondPart, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Ym: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(61)]
        private void CalculateRT()
        {
            try
            {
                double firstBrackets = (double)Ym / Math.Sin((double)layoutParams.Fi1) + (double)layoutParams.L1;
                double secondBrackets = (double)dp1 / 2d;

                decimal resultValue = (decimal)Math.Sqrt(Math.Pow(firstBrackets, 2) + Math.Pow(secondBrackets, 2));

                RT = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте RT: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(62)]
        private void CalculateRp()
        {
            try
            {
                Rp = ParameterRounder.RoundToStep(RT, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Rp: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(63)]
        private void CalculateF()
        {
            try
            {
                decimal sqrtValue = (decimal)Math.Sqrt(Math.Pow((double)Rp, 2) - Math.Pow((double)(0.5m * dp1), 2));

                decimal resultValue = Rp - sqrtValue;

                f = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте f: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(64)]
        private void CalculateL3()
        {
            try
            {
                l3 = ParameterRounder.RoundToStep(layoutParams.L1 + f, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте l₃: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(65)]
        private void CalculateL4()
        {
            try
            {
                l4 = ParameterRounder.RoundToStep(layoutParams.Lw + f, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте l₄: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(66)]
        private void CalculateL2()
        {
            try
            {
                l2 = ParameterRounder.RoundToStep(l4 - l3, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте l₂: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(67)]
        private void CalculateDp2()
        {
            try
            {
                double RR = Math.Pow((double)layoutParams.R, 2);
                double l2l2 = Math.Pow((double)l2, 2);
                decimal sqrtValue = (decimal)Math.Sqrt(RR - l2l2);

                decimal resultValue = layoutParams.Dw - 2 * (layoutParams.R - sqrtValue);

                dp2 = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dp₂: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(1)]
        private void AddValueToFormulaCollection_Page10()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.dp1, FormulaSymbols.dp1, dp1),
                (FormulaDescriptions.Xm,  FormulaSymbols.Xm,  Xm),
                (FormulaDescriptions.Ym,  FormulaSymbols.Ym,  Ym),
                (FormulaDescriptions.RT,  FormulaSymbols.RT,  RT),
                (FormulaDescriptions.Rp,  FormulaSymbols.Rp,  Rp),
                (FormulaDescriptions.f,   FormulaSymbols.f,   f),
                (FormulaDescriptions.l3,  FormulaSymbols.l3,  l3),
                (FormulaDescriptions.l4,  FormulaSymbols.l4,  l4),
                (FormulaDescriptions.l2,  FormulaSymbols.l2,  l2),
                (FormulaDescriptions.dp2, FormulaSymbols.dp2, dp2)
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
    }
}
