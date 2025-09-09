using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private decimal Ch1 { get; set; }

        private decimal D2 { get; set; }

        private decimal d0 { get; set; }

        private decimal b1 { get; set; }

        private decimal Ch2 { get; set; }

        private decimal D3 { get; set; }

        private decimal R2 { get; set; }

        private decimal r3smin { get; set; }

        private decimal R3 { get; set; }

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

        }

        private void Calculateb1()
        {

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

        public void MessageHendler(ShowMessage messageMethod)
        {
            showMessage = messageMethod;
        }
    }
}
