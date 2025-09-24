using System;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public partial class SeparatorParameters
    {
        private decimal Fic {  get; set; }
        private decimal D0 { get; set; }
        private decimal C1 { get; set; }
        private decimal epsilon2 { get; set; }
        private decimal dr {  get; set; }
        private decimal alphar { get; set; }
        private decimal S1 { get; set; }
        private decimal e2 { get; set; }
        private decimal Fir { get; set; }

        [ExecutionOrder(119)]
        private void CalculateRecalculationDc1()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в перерасчёте Dc1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(120)]
        private void CalculateFic()
        {
            try
            {
                // Логика расчёта Fic
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fic: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(121)]
        private void CalculateD0()
        {
            try
            {
                // Логика расчёта D0
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте D0: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(122)]
        private void CalculateC1()
        {
            try
            {
                // Логика расчёта C1
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте C1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(123)]
        private void CalculateEpsilon2()
        {
            try
            {
                // Логика расчёта epsilon2
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте epsilon2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(124)]
        private void CalculateDr()
        {
            try
            {
                // Логика расчёта dr
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dr: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(125)]
        private void CalculateAlphar()
        {
            try
            {
                // Логика расчёта alphar
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте alphar: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(126)]
        private void CalculateS1()
        {
            try
            {
                // Логика расчёта S1
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте S1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(127)]
        private void CalculateE2()
        {
            try
            {
                // Логика расчёта e2
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте e2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(128)]
        private void CalculateFir()
        {
            try
            {
                // Логика расчёта Fir
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fir: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(129)]
        private void CalculateRecalculationFir()
        {
            try
            {

            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в перерасчёте Fir: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(2)]
        private void AddValueToFormulaCollection_Page16()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.Fic,      FormulaSymbols.Fic,      Fic),
                (FormulaDescriptions.D0,       FormulaSymbols.D0,       D0),
                (FormulaDescriptions.C1,       FormulaSymbols.C1,       C1),
                (FormulaDescriptions.epsilon2, FormulaSymbols.epsilon2, epsilon2),
                (FormulaDescriptions.dr,       FormulaSymbols.dr,       dr),
                (FormulaDescriptions.alphar,   FormulaSymbols.alphar,   alphar),
                (FormulaDescriptions.S1,       FormulaSymbols.S1,       S1),
                (FormulaDescriptions.e2,       FormulaSymbols.e2,       e2),
                (FormulaDescriptions.Fir,      FormulaSymbols.Fir,      Fir)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }
    }
}
