using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.OuterRingParameters
{
    public partial class OuterRingParameters : Parameters
    {
        private InitialParameters initParams;
        private LayoutParameters.LayoutParameters layoutParams;

        private ShowMessage showMessage;

        public OuterRingParameters(InitialParameters initParams, LayoutParameters.LayoutParameters layoutParams)
        {
            this.initParams = initParams;
            this.layoutParams = layoutParams;
        }

        public decimal Ch1 { get; set; }

        public decimal D2 { get; set; }

        public decimal d0 { get; set; }

        public decimal b1 { get; set; }

        public decimal Ch2 { get; set; }

        public decimal D3 { get; set; }

        public decimal R2 { get; set; }

        public decimal r3smin { get; set; }

        public decimal R3 { get; set; }


        private void CalculateCh1()
        {
            try
            {
                Ch1 = ParameterRounder.RoundToStep(0.5m * initParams.B, 0.5m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Ch1: {ex.Message}");
            }
        }

        private void CalculateD2()
        {
            try
            {
                decimal valueUnderSqrt = layoutParams.D1 * layoutParams.D1 - initParams.B * initParams.B;

                decimal valueSqrt = (decimal)(Math.Sqrt((double)valueUnderSqrt));

                D2 = ParameterRounder.RoundToStep(valueSqrt, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте D2: {ex.Message}");
            }
        }

        private void Calculated0()
        {
            try
            {
                Calculator_d0_b1 c = new Calculator_d0_b1();
                d0 = c.Getd0(initParams.D, initParams.Name);

                if (d0 == -1)
                    showMessage.Invoke(
                            "Ошибка при вычислении d₀: соответствующее значение не найдено в таблице 21 ГОСТ 24696.");
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте d₀: {ex.Message}");
            }
        }

        private void Calculateb1()
        {
            try
            {
                Calculator_d0_b1 c = new Calculator_d0_b1();
                b1 = c.Getb1(initParams.D, initParams.Name);

                if (b1 == -1)
                    showMessage.Invoke(
                        "Ошибка при вычислении b₁: соответствующее значение не найдено в таблице 21 ГОСТ 24696.");

            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте b₁: {ex.Message}");
            }
        }

        private void CalculateCh2()
        {
            try
            {
                Ch2 = ParameterRounder.RoundToStep(0.5m * initParams.B, 0.5m);
            }
            catch(Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте Ch2: {ex.Message}");
            }
        }

        private void CalculateD3()
        {
            try
            {
                decimal D = initParams.D;
                decimal value = -1m;

                if (D <= 200) value = D - 2;
                else if (D > 200 && D <= 300) value = D - 3;
                else if (D >= 300 && D < 800) value = D - 6;
                else if (D > 800) value = D - 8;

                D3 = ParameterRounder.RoundToStep(value, 1.0m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте D3: {ex.Message}");
            }
        }

        private void CalculateR2()
        {
            decimal B = initParams.r_s_min + CalculatorB_and_e_for54Formula.GetRsmaxRadial(initParams.r_s_min, initParams.d);
            decimal e = initParams.r_s_min + CalculatorB_and_e_for54Formula.GetRsmaxAxial(initParams.r_s_min, initParams.d);

            if (B == -1 || e == -1)
            {
                showMessage.Invoke($"Ошибка в расчёте R2:\nНе найдено значение rsmax из таблицы по госту 3478.");
            }

            decimal sqrtValue = (decimal)Math.Sqrt((double)(B * B + e * e));

            double rad19 = 19 * (Math.PI / 180);
            decimal denomenator = (decimal)(4 * Math.Sin(Math.Atan((double)(B / e) - rad19)));

            R2 = ParameterRounder.RoundToStep(sqrtValue / denomenator, 1.0m);
        }

        private void CalculateR3smin()
        {
            try
            {
                r3smin = R3smin.GetValue(initParams.r_s_min);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте r3smin: {ex.Message}");
            }
        }

        private void CalculateR3()
        {
            try
            {
                R3 = ParameterRounder.RoundToStep(2 * r3smin, 0.1m);
            }
            catch (Exception ex)
            {
                showMessage.Invoke($"Ошибка в расчёте R3: {ex.Message}");
            }
        }

        private void AddValueToFormulaCollection()
        {
            var formulaDetailsList = new List<(string Description, string Symbol, decimal Value)>
            {
                (FormulaDescriptions.Ch1,    FormulaSymbols.Ch1,     Ch1),
                (FormulaDescriptions.D2,     FormulaSymbols.D2,      D2),
                (FormulaDescriptions.d0,     FormulaSymbols.d0,      d0),
                (FormulaDescriptions.b1,     FormulaSymbols.b1,      b1),
                (FormulaDescriptions.Ch2,    FormulaSymbols.Ch2,     Ch2),
                (FormulaDescriptions.D3,     FormulaSymbols.D3,      D3),
                (FormulaDescriptions.R2,     FormulaSymbols.R2,      R2),
                (FormulaDescriptions.r3smin, FormulaSymbols.r3smin,  r3smin),
                (FormulaDescriptions.R3,     FormulaSymbols.R3,      R3)
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
