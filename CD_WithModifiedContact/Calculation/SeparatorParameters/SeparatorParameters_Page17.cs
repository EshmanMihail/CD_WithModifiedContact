using System;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;

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
                decimal resultValue = lp.R * (decimal)Math.Sin((double)Fir);
                hk = ParameterRounder.RoundToStep(resultValue, 0.01m);
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
                double R_square = Math.Pow((double)lp.R, 2);
                double hk_square = Math.Pow((double)hk, 2);
                decimal sqrtValue = (decimal)Math.Sqrt(R_square -  hk_square);

                decimal resultValue = lp.Dw - 2 * (lp.R - sqrtValue);

                Dwk = ParameterRounder.RoundToStep(resultValue, 0.01m);
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
                decimal fractionValue = (lp.Dw - Dwk) / (2 * (decimal)Math.Tan((double)Fir));

                Hr = ParameterRounder.RoundToStep(rp.l3 - hk + fractionValue, 0.1m);
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
                decimal resultValue = dr - 2 * Hr * (decimal)Math.Tan((double)Fir);

                da = ParameterRounder.RoundToStep(resultValue, 0.01m);
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
                e2_1hatch = ParameterRounder.RoundToStep(lp.r0smin, 0.1m);
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
                double dr_square = Math.Pow((double)dr, 2);
                double DcMinusD0_square = Math.Pow((double)(Dc - D0), 2);

                decimal leftPart = (decimal)Math.Sqrt((dr_square -  DcMinusD0_square) / 2);

                double R_square = Math.Pow((double)lp.R, 2);
                decimal cosValue = (decimal)Math.Cos((double)Fic);
                double sencondValueSquare = Math.Pow((double)(Bc - S - lp.L1 * cosValue), 2);
                decimal sqrtValue = (decimal)Math.Sqrt(R_square - sencondValueSquare);

                decimal rightPart = lp.Dw - 2 * (lp.R - sqrtValue);
                
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
