using System;
using System.Linq;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public partial class SeparatorParameters
    {
        [PropertyMetadata(FormulaSymbols.Fic)]
        private decimal Fic { get; set; }

        [PropertyMetadata(FormulaSymbols.D0)]
        private decimal D0 { get; set; }

        [PropertyMetadata(FormulaSymbols.C1)]
        private decimal C1 { get; set; }

        [PropertyMetadata(FormulaSymbols.epsilon2)]
        private decimal epsilon2 { get; set; }

        [PropertyMetadata(FormulaSymbols.dr)]
        private decimal dr { get; set; }

        [PropertyMetadata(FormulaSymbols.alphar)]
        private decimal alphar { get; set; }

        [PropertyMetadata(FormulaSymbols.S1)]
        private decimal S1 { get; set; }

        [PropertyMetadata(FormulaSymbols.e2)]
        private decimal e2 { get; set; }

        [PropertyMetadata(FormulaSymbols.Fir)]
        private decimal Fir { get; set; }



        [ExecutionOrder(119, "")]
        private void CalculateRecalculationDc1()
        {
            try
            {
                double Dc1_square = Math.Pow((double)Dc1, 2);
                double Bc_square = Math.Pow((double)Bc, 2);
                decimal sqrtValue = (decimal)Math.Sqrt(Dc1_square + 4 * Bc_square);

                while (sqrtValue >= orp.D2)
                {
                    Dc1--;

                    Dc1_square = Math.Pow((double)Dc1, 2);
                    Bc_square = Math.Pow((double)Bc, 2);
                    sqrtValue = (decimal)Math.Sqrt(Dc1_square + 4 * Bc_square);
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в перерасчёте Dc1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(120, FormulaSymbols.Fic)]
        private void CalculateFic()
        {
            try
            {
                Fic = lp.Fi1;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fic: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(121, FormulaSymbols.D0)]
        private void CalculateD0()
        {
            try
            {
                decimal innerBrackets = Bc - rp.Xm + 0.5m * epsilon3;

                decimal bracketsValue = rp.Ym - innerBrackets * (decimal)Math.Tan((double)Fic);

                D0 = ParameterRounder.RoundToStep(2 * bracketsValue, 0.01m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте D0: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(122, FormulaSymbols.C1)]
        private void CalculateC1()
        {
            try
            {
                double radians = Math.PI / (double)lp.z;
                double sinValue = Math.Sin(radians);

                decimal resultValue = D0 * (decimal)sinValue;

                C1 = ParameterRounder.RoundToStep(resultValue, 0.001m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте C1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(123, FormulaSymbols.epsilon2)]
        private void CalculateEpsilon2()
        {
            try
            {
                epsilon2 = Epsilon2.GetValue(lp.Dw);

                if (epsilon2 < 0)
                {
                    showMessage.Invoke($"Не найдено подходящего значения для epsilon2 из таблицы 5.");
                    StopCalculation.Invoke();
                    return;
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте epsilon2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(124, FormulaSymbols.dr)]
        private void CalculateDr()
        {
            try
            {
                //Для гнезда коническо-цилиндрической формы epsilon2 увеличить на 0.1мм
                if (FractionConverter.GetFraction(initParams.k, 6) != 0) epsilon2 += 0.1m;

                dr = ParameterRounder.RoundToStep(lp.Dw + epsilon2, 0.05m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте dr: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(125, FormulaSymbols.alphar)]
        private void CalculateAlphar()
        {
            try
            {
                decimal radians = (decimal)Math.Asin((double)(rp.dp1 / (2 * rp.Rp)));

                decimal degrees = radians * (decimal)(180 / Math.PI);
                decimal resultValue = 180 - 2 * degrees;

                //alphar = ParameterRounder.RoundRadiansToOneDegree(resultValue);
                alphar = ParameterRounder.RoundToStep(resultValue, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте alphar: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(126, FormulaSymbols.S1)]
        private void CalculateS1()
        {
            try
            {
                decimal ficDegrees = ParameterRounder.RoundToStep(Fic * (decimal)(180 / Math.PI), 1.0m);

                double tanAngleDegrees = (double)(ficDegrees - (180 - alphar) / 2);
                double tanAngleRadians = tanAngleDegrees * Math.PI / 180.0;

                decimal tanValue = (decimal)Math.Tan(tanAngleRadians);

                decimal resultValue = 0.5m * (ip.a - epsilon3 + (dc - ip.d2_2hatch) * tanValue);

                S1 = ParameterRounder.RoundToStep(resultValue, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте S1: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(127, FormulaSymbols.e2)]
        private void CalculateE2()
        {
            try
            {
                e2 = ParameterRounder.RoundToStep((lp.Dw - rp.dp1) / 2, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте e2: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(128, FormulaSymbols.Fir)]
        private void CalculateFir()
        {
            try
            {
                double radians = Math.Asin((double)(2 * lp.L1 / (3 * lp.R)));

                if (double.IsNaN(radians) || double.IsInfinity(radians))
                {
                    showMessage.Invoke("Ошибка при подсчёте Fir.\nЗначение для arcsin должно быть в пределах от -1 до 1.");
                    StopCalculation.Invoke();
                    return;
                }

                Fir = (decimal)radians;
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Fir: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(129, "")]
        private void CalculateRecalculationFir()
        {
            try
            {
                double degrees = (double)Fir * 180.0 / Math.PI;

                var presets = new List<double>
                {
                    2.0 + 52.0 / 60.0,   // 2°52′ = 2.8667°
                    3.0 + 35.0 / 60.0,   // 3°35′ = 3.5833°
                    4.0 +  5.0 / 60.0,   // 4°05′ = 4.0833°
                    4.0 + 46.0 / 60.0,   // 4°46′ = 4.7667°
                    5.0 + 43.0 / 60.0    // 5°43′ = 5.7167°
                };

                double nearestDeg = presets.OrderBy(p => Math.Abs(p - degrees)).First();

                bool cylindricalAllowed = nearestDeg < 3.0;
                if (cylindricalAllowed)
                {
                    showMessage.Invoke($"{FormulaSymbols.Fir} < 3°, гнездо может быть цилиндрической формы.");
                }

                Fir = (decimal)(nearestDeg * Math.PI / 180.0); // обратно в радианы
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в перерасчёте Fir: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(2, "")]
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
