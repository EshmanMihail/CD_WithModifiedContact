using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public partial class SeparatorParameters
    {
        private decimal hk {  get; set; }
        private decimal Dwk { get; set; }
        private decimal Hr { get; set; }
        private decimal da {  get; set; }
        private decimal e2_1hatch { get; set; }

        [ExecutionOrder(130)]
        private void CalculateHk()
        {
            try
            {
                // Логика расчёта hk
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте hk: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(131)]
        private void CalculateDwk()
        {
            try
            {
                // Логика расчёта Dwk
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Dwk: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(132)]
        private void CalculateHr()
        {
            try
            {
                // Логика расчёта Hr
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Hr: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(133)]
        private void CalculateDa()
        {
            try
            {
                // Логика расчёта da
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте da: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(134)]
        private void CalculateE2_1hatch()
        {
            try
            {
                // Логика расчёта e2_1hatch
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте e2_1hatch: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(135)]
        private void CalculateCheckingSeparatorLock()
        {
            try
            {
                // Логика расчёта e2_1hatch
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте проверки замка сепаратора: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(136)]
        private void CalculateNote()
        {
            try
            {
                // Логика расчёта e2_1hatch
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте примечания: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(3)]
        private void AddValueToFormulaCollection_Page17()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.hk,         FormulaSymbols.hk,         hk),
                (FormulaDescriptions.Dwk,        FormulaSymbols.Dwk,        Dwk),
                (FormulaDescriptions.Hr,         FormulaSymbols.Hr,         Hr),
                (FormulaDescriptions.da,         FormulaSymbols.da,         da),
                (FormulaDescriptions.e2_1hatch,  FormulaSymbols.e2_1hatch,  e2_1hatch)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }

    }
}
