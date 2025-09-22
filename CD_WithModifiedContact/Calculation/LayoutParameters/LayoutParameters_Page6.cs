using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CD_WithModifiedContact.Calculation.LayoutParameters
{
    public partial class LayoutParameters
    {
        private decimal Lwe { get; set; }
        private decimal Cr { get; set; }
        private decimal C0r { get; set; }
        private decimal Fr { get; set; }
        private decimal F0 { get; set; }
        private decimal M_cube_1plusCosT{ get; set; }
        private decimal cosTH { get; set; }
        public decimal R { get; set; }
        private decimal alpha1 { get; set; }
        private decimal alpha2 { get; set; }
        private decimal fi_1hatch { get; set; }

        [ExecutionOrder(18)]
        private void CalculateLwe()
        {
            try
            {
                Lwe = ParameterRounder.RoundToStep(Lw - 2 * r0smin, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Lwe: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(19)]
        private void CalculateCr()
        {
            try
            {
                double powerOfBrackets = 7d / 9d;
                double powerOfz = 3d / 4d;
                double powerOfDw = 29d / 27d;

                decimal valueInBrackets = 2m * Lwe * (decimal)Math.Cos((double)alpha0_2hatch);
                valueInBrackets = (decimal)Math.Pow((double)valueInBrackets, powerOfBrackets);

                decimal zValue = (decimal)Math.Pow((double)z, powerOfz);

                decimal DwValue = (decimal)Math.Pow((double)Dw, powerOfDw);

                Cr = ParameterRounder.RoundToStep(initParams.Bm * fc * valueInBrackets * zValue * DwValue, 100);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Cr: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(20)]
        private void CalculateC0r()
        {
            try
            {
                decimal result = 44 * ((D1 - 2 * Dw) / (D1 - Dw)) * 2 * Lwe * Dw * z * (decimal)Math.Cos((double)alpha0_2hatch);
                C0r = ParameterRounder.RoundToStep(result, 100);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте C0r: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(21)]
        private void CalculateFr()
        {
            try
            {
                decimal minValue = Cr * Constants.FrMinRange;
                decimal maxValue = Cr * Constants.FrMaxRange;

                Fr = ParameterRounder.RoundToStep((minValue + maxValue) / 2, 100);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fr: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(22)]
        private void CalculateF0()
        {
            try
            {
                decimal fraction = (2.5m * Fr) / (z * (decimal)Math.Cos((double)alpha0_2hatch));

                F0 = ParameterRounder.RoundToStep(fraction, 10);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте F0: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(23)]
        private void CalculateM_cube_1plusCosT()
        {
            try
            {
                decimal lambdaPowered = (decimal)Math.Pow((double)initParams.lambda_H, 3);
                decimal LwePowered = (decimal)Math.Pow((double)Lwe, 3);

                decimal fraction = (lambdaPowered * LwePowered) / (Dw * F0 * (1m + gamma));

                M_cube_1plusCosT = ParameterRounder.RoundToStep(38077 * fraction, 0.00001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте M_cube_1plusCosT: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(24)]
        private void CalculateCosTH()
        {
            try
            {
                cosTH = CosTH.GetValue(M_cube_1plusCosT);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте CosTH: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(25)]
        private void CalculateR()
        {
            try
            {
                decimal firstFraction = 1 / rh;
                decimal secondFraction = 2 / (Dw * (1 + gamma));
                decimal thirdFraction = (1 - cosTH) / (1 + cosTH);

                decimal commonValue = firstFraction + secondFraction * thirdFraction;

                decimal resultValue = (decimal)Math.Pow((double)commonValue, -1);

                if (resultValue <= 50) R = ParameterRounder.RoundToStep(resultValue, 0.1m);
                else if (resultValue > 50 && resultValue <= 150) R = ParameterRounder.RoundToStep(resultValue, 0.5m);
                else R = ParameterRounder.RoundToStep(resultValue, 1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте R: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(26)]
        private void CalculateAlpha1()
        {
            try
            {
                decimal fraction = 2 * R / D1 * (decimal)Math.Tan((double)alpha0_2hatch);

                double radians = Math.Atan((double)fraction);

                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Alpha1.\nЗначение для arctan должно быть в пределах от -pi/2 до pi/2.");
                    StopCalculation.Invoke();
                    return;
                }

                alpha1 = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Alpha1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(27)]
        private void CalculateAlpha2()
        {
            try
            {
                double value = (double)(Dw / (2m * R));
                double fraction = (1 - value) * Math.Sin((double)alpha1);

                double radians = Math.Asin(fraction);

                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Alpha2.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }

                alpha2 = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Alpha2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(28)]
        private void CalculateFi1Hatch()
        {
            try
            {
                fi_1hatch = alpha1 - alpha2;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте fi`: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(2)]
        private void AddValueToFormulaCollection_Page6()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.Lwe,              FormulaSymbols.Lwe,              Lwe),
                (FormulaDescriptions.Cr,               FormulaSymbols.Cr,               Cr),
                (FormulaDescriptions.C0r,              FormulaSymbols.C0r,              C0r),
                (FormulaDescriptions.Fr,               FormulaSymbols.Fr,               Fr),
                (FormulaDescriptions.F0,               FormulaSymbols.F0,               F0),
                (FormulaDescriptions.M_cube_1plusCosT, FormulaSymbols.M_cube_1plusCosT, M_cube_1plusCosT),
                (FormulaDescriptions.cosTH,            FormulaSymbols.cosTH,            cosTH),
                (FormulaDescriptions.R,                FormulaSymbols.R,                R),
                (FormulaDescriptions.alpha1,           FormulaSymbols.alpha1,           alpha1),
                (FormulaDescriptions.alpha2,           FormulaSymbols.alpha2,           alpha2),
                (FormulaDescriptions.fi_1hatch,        FormulaSymbols.fi_1hatch,        fi_1hatch)
            };

            foreach (var (description, symbol, value) in formulaDetailsList)
            {
                resultOfCalculations.Add(new FormulaDetails(description, symbol, value));
            }
        }
    }
}
