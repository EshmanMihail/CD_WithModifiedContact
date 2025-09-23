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
                // Логика расчёта epsilon1
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
                // Логика расчёта dc
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(111)]
        private void CalculateEpsilon3()
        {
            try
            {
                // Логика расчёта epsilon3
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
                // Логика расчёта S
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
                // Логика расчёта Bc
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
                // Логика расчёта bc
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
                // Логика расчёта Dc
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dc: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(117)]
        private void CalculateDeltaAngle()
        {
            try
            {
                // Логика расчёта deltaAngle
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
                // Логика расчёта Dc1
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dc1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(1)]
        private void AddNewValuesToFormulaCollection()
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
