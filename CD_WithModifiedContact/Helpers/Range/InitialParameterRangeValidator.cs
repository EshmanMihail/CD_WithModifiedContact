using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers;
using System;
using System.Windows.Forms;

namespace CD_Radial_Spherical_Roller_withAsymetricalRollers.Calculation
{
    public class InitialParameterRangeValidator
    {
        private readonly InitialParameters initialParameters;
        private readonly LambdaHelper lambdaHelper;
        private readonly ErrorProvider errorProvider;

        public InitialParameterRangeValidator(InitialParameters initialParameters, ErrorProvider errorProvider)
        {
            this.initialParameters = initialParameters;
            this.errorProvider = errorProvider;

            lambdaHelper = new LambdaHelper();
        }

        public void ValidateAndSetErrors(string lambdaRange, TextBox lambdaTextBox, TextBox x1TextBox, TextBox x2TextBox)
        {
            CheckLambdaRange(lambdaRange, lambdaTextBox);
            CheckX1_Range(initialParameters.D, initialParameters.d, initialParameters.X1, x1TextBox);
            CheckX2_Range(initialParameters.B, initialParameters.X2, x2TextBox);
        }

        private void CheckLambdaRange(string rangeString, TextBox lambdaTextBox)
        {
            decimal minValue = lambdaHelper.GetMinValue(rangeString);
            decimal maxValue = lambdaHelper.GetMaxValue(rangeString);

            if (minValue > initialParameters.lambda_B)
            {
                errorProvider.SetError(lambdaTextBox, "Лямбда Н меньше заданного диапазона.");
            }
            else if (initialParameters.lambda_B > maxValue)
            {
                errorProvider.SetError(lambdaTextBox, "Лямбда Н больше заданного диапазона.");
            }
            else
            {
                errorProvider.SetError(lambdaTextBox, string.Empty);
            }
        }

        private void CheckX1_Range(decimal D, decimal d, decimal currentX1, TextBox x1TextBox)
        {
            decimal difference = D - d;
            decimal minRangeValue = Math.Round(difference * Constants.X1MinRange, 2);
            decimal maxRangeValue = Math.Round(difference * Constants.X1MaxRange, 2);

            if (minRangeValue > Math.Round(currentX1, 2))
            {
                errorProvider.SetError(x1TextBox, "X1 меньше заданного диапазона!");
            }
            else if (Math.Round(currentX1, 2) > maxRangeValue)
            {
                errorProvider.SetError(x1TextBox, "X1 больше заданного диапазона!");
            }
            else
            {
                errorProvider.SetError(x1TextBox, string.Empty);
            }
        }

        private void CheckX2_Range(decimal B, decimal currentX2, TextBox x2TextBox)
        {
            decimal minRangeValue = Math.Round(B * Constants.X2MinRange, 2);
            decimal maxRangeValue = Math.Round(B * Constants.X2MaxRange, 2);

            if (minRangeValue > Math.Round(currentX2, 2))
            {
                errorProvider.SetError(x2TextBox, "Х2 меньше заданного диапазона!");
            }
            else if (Math.Round(currentX2, 2) > maxRangeValue)
            {
                errorProvider.SetError(x2TextBox, "Х2 больше заданного диапазона!");
            }
            else
            {
                errorProvider.SetError(x2TextBox, string.Empty);
            }
        }
    }
}