using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public partial class SeparatorParameters
    {
        [PropertyMetadataAttribute(FormulaSymbols.hk)]
        private decimal hk { get; set; }

        [PropertyMetadataAttribute(FormulaSymbols.Dwk)]
        private decimal Dwk { get; set; }

        [PropertyMetadataAttribute(FormulaSymbols.Hr)]
        private decimal Hr { get; set; }

        [PropertyMetadataAttribute(FormulaSymbols.da)]
        private decimal da { get; set; }

        [PropertyMetadataAttribute(FormulaSymbols.e2_1hatch)]
        private decimal e2_1hatch { get; set; }



        [ExecutionOrder(130, FormulaSymbols.hk)]
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

        [ExecutionOrder(131, FormulaSymbols.Dwk)]
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

        [ExecutionOrder(132, FormulaSymbols.Hr)]
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

        [ExecutionOrder(133, FormulaSymbols.da)]
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

        [ExecutionOrder(134, FormulaSymbols.e2_1hatch)]
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

        [ExecutionOrder(135, "")]
        private void CalculateCheckingSeparatorLock()
        {
            try
            {
                //var sb = new StringBuilder();
                //sb.AppendLine($"dr = {dr}");
                //sb.AppendLine($"Dc = {Dc}");
                //sb.AppendLine($"D0 = {D0}");
                //sb.AppendLine($"dw = {lp.Dw}");
                //sb.AppendLine($"R = {lp.R}");
                //sb.AppendLine($"Bc = {Bc}");
                //sb.AppendLine($"S = {S}");
                //sb.AppendLine($"L1 = {lp.L1}");
                //sb.AppendLine($"Fic (rad) = {Fic}");

                //MessageBox.Show(sb.ToString(), "Промежуточные значения", MessageBoxButtons.OK, MessageBoxIcon.Information);

                double dr_square = Math.Pow((double)dr, 2);
                double DcMinusD0_square = Math.Pow((double)(Dc - D0), 2);

                decimal leftPart = (decimal)Math.Sqrt((dr_square -  DcMinusD0_square) / 2);

                double R_square = Math.Pow((double)lp.R, 2);
                decimal cosValue = (decimal)Math.Cos((double)Fic);
                double sencondValueSquare = Math.Pow((double)(Bc - S - lp.L1 * cosValue), 2);
                decimal sqrtValue = (decimal)Math.Sqrt(R_square - sencondValueSquare);

                decimal rightPart = lp.Dw - 2 * (lp.R - sqrtValue);
                //System.Windows.Forms.MessageBox.Show($"{leftPart} < {rightPart}");
                if (leftPart >= rightPart) // условие не выполняется
                {
                    showMessage.Invoke($"При проверки замка сепаратора, условие не выполняется\n" +
                        $"следует увеличить диаметр {FormulaSymbols.Dc1} или высоту сепаратора {FormulaSymbols.Bc}.");

                    decimal difference = (decimal)Math.Abs(rightPart - leftPart);

                    string message = $"Для ролика диаметром {lp.Dw}, разница в неравенстве, при проверки замка сепаратора, должна быть не менее:";
                    bool isRight = true;
                    if (lp.Dw <= 10 && difference >= 0.3m)
                    {
                        isRight = false;
                        message += "0.3мм";
                    }
                    else if (lp.Dw > 10 && lp.Dw <= 18 && difference >= 0.5m)
                    {
                        isRight = false;
                        message += "0.5мм";
                    }
                    else if (lp.Dw > 18 && lp.Dw <= 30 && difference >= 0.8m)
                    {
                        isRight = false;
                        message += "0.8мм";
                    }
                    else if (lp.Dw > 30 && lp.Dw <= 50 && difference >= 1.0m)
                    {
                        isRight = false;
                        message += "1.0мм";
                    }

                    if (!isRight)
                    {
                        showMessage.Invoke(message);
                    }
                }
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте проверки замка сепаратора: {ex.Message}");
                StopCalculation.Invoke();
            }
        }

        [ExecutionOrder(3, "")]
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
