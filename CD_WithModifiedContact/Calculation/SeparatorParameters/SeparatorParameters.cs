using System;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation.LayoutParameters;
using LP = CD_WithModifiedContact.Calculation.LayoutParameters.LayoutParameters;
using RP = CD_WithModifiedContact.Calculation.RollerParameters.RollerParameters;
using IP = CD_WithModifiedContact.Calculation.InnerRingParameters.InnerRingParameters;
using ORP = CD_WithModifiedContact.Calculation.OuterRingParameters.OuterRingParameters;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public partial class SeparatorParameters : Parameters
    {
        private ShowMessage showMessage;
        public event Action StopCalculation;

        private InitialParameters initParams;
        private LP lp;
        private ORP orp;
        private RP rp;
        private IP ip;

        public SeparatorParameters(InitialParameters initParams, LP lp, ORP orp, RP rp, IP ip)
        {
            this.initParams = initParams;
            this.lp = lp;
            this.orp = orp;
            this.rp = rp;
            this.ip = ip;
        }

        private decimal epsilon1 { get; set; }
        private decimal dc {  get; set; }
        private decimal epsilon3 { get; set; }
        private decimal S { get; set; }
        private decimal Bc { get; set; }
        private decimal bc { get; set; }
        private decimal Dc { get; set; }
        private decimal deltaAngle { get; set; }
        private decimal Dc1 { get; set; }

        [ExecutionOrder(109)]
        private void CalculateEpsilon1()
        {
            try
            {
                epsilon1 = Epsilon1.GetValue(ip.d6);

                if (epsilon1 < 0)
                {
                    showMessage.Invoke($"Не найдено подходящего значения для epsilon1 из таблицы 6.");
                    StopCalculation.Invoke();
                    return;
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте epsilon1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(110)]
        private void Calculatedc()
        {
            try
            {
                dc = ParameterRounder.RoundToStep(ip.d6 + epsilon1, 0.05m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(111)]
        private void CalculateEpsilon3() // ?????? dc? in book Dc
        {
            try
            {
                decimal resultValue = -1;

                if (dc <= 120) resultValue = 0.4m;
                else if (dc > 120 && dc <= 250) resultValue = 0.6m;
                else if (dc > 250 && dc <= 500) resultValue = 0.8m;
                else if (dc > 500) resultValue = 1.2m;

                epsilon3 = resultValue;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте epsilon3: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(112)]
        private void CalculateS()
        {
            try
            {
                decimal resultValue = rp.Xm - 0.5m * epsilon3 - rp.l3 * (decimal)Math.Cos((double)lp.Fi1);

                S = ParameterRounder.RoundToStep(resultValue, 0.01m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте S: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(113)]
        private void CalculateBc()
        {
            try
            {
                Bc = ParameterRounder.RoundToStep(S + 1.5m * rp.l3, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Bc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(114)]
        private void Calculatebc()
        {
            try
            {
                bc = ParameterRounder.RoundToStep(0.5m * lp.Lw, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте bc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(115)]
        private void CalculateDc()
        {
            try
            {
                double D2_square = Math.Pow((double)orp.D2, 2);
                double Bc_square = Math.Pow((double)Bc, 2);

                decimal resultValue = (decimal)Math.Sqrt(D2_square - Bc_square);

                Dc = ParameterRounder.RoundToStep(resultValue, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(116)]
        private void CalculateRecalculationDc()
        {
            try
            {
                if (Dc - dc > lp.Dw)
                {
                    Dc = ParameterRounder.RoundToStep(ip.d6 + lp.Dw, 1.0m);
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в перерасчёте Dc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(117)]
        private void CalculateDeltaAngle()
        {
            try
            {
                deltaAngle = ParameterRounder.RoundRadiansToOneDegree(lp.Fi1);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте deltaAngle: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(118)]
        private void CalculateDc1()
        {
            try
            {
                decimal resultValue = Dc - 2 * (Bc - bc) * (decimal)Math.Tan((double)deltaAngle);

                Dc1 = ParameterRounder.RoundToStep(resultValue, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dc1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(1)]
        private void AddValueToFormulaCollection()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.epsilon1,    FormulaSymbols.epsilon1,   epsilon1),
                (FormulaDescriptions.dc,          FormulaSymbols.dc,         dc),
                (FormulaDescriptions.epsilon3,    FormulaSymbols.epsilon3,   epsilon3),
                (FormulaDescriptions.S,           FormulaSymbols.S,          S),
                (FormulaDescriptions.Bc,          FormulaSymbols.Bc,         Bc),
                (FormulaDescriptions.bc,          FormulaSymbols.bc,         bc),
                (FormulaDescriptions.Dc,          FormulaSymbols.Dc,         Dc),
                (FormulaDescriptions.deltaAngle,  FormulaSymbols.deltaAngle, deltaAngle),
                (FormulaDescriptions.Dc1,         FormulaSymbols.Dc1,        Dc1)
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
