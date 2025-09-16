using CD_WithModifiedContact.Helpers.LayoutParamsHelper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LP = CD_WithModifiedContact.Calculation.LayoutParameters.LayoutParameters;
using ORP = CD_WithModifiedContact.Calculation.OuterRingParameters.OuterRingParameters;
using RP = CD_WithModifiedContact.Calculation.RollerParameters.RollerParameters;

namespace CD_WithModifiedContact.Calculation
{
    public class CalculationController
    {
        private InitialParameters initParams;
        private LP layoutParameters;
        private ORP outerRingParameters;
        private RP rollerParameters;

        public void CalculateAllParameters(InitialParameters chosenInitParams)
        {
            initParams = chosenInitParams;
            var processor = new GenericParameterProcessor();

            var steps = new List<Func<bool>>
            {
                () => CalculateLayoutParameters(processor),
                () => CalculateOuterRingParameters(processor),
                () => CalculateRollerParameters(processor)
            };

            for (int i = 0; i < steps.Count; i++)
            {
                bool success = steps[i]();
                processor.ExecuteFormulasValueMethods(GetParameterObjectByOrder(i));

                if (!success) break;
            }
        }

        private bool CalculateLayoutParameters(GenericParameterProcessor processor)
        {
            layoutParameters = new LP(initParams);

            layoutParameters.MessageHendler(ShowCalculationError);
            layoutParameters.StopCalculation += processor.StopCalculation;

            return processor.TryProcessParameters(layoutParameters);
        }

        private bool CalculateOuterRingParameters(GenericParameterProcessor processor)
        {
            outerRingParameters = new ORP(initParams, layoutParameters);

            outerRingParameters.MessageHendler(ShowCalculationError);
            outerRingParameters.StopCalculation += processor.StopCalculation;

            return processor.TryProcessParameters(outerRingParameters);
        }

        private bool CalculateRollerParameters(GenericParameterProcessor processor)
        {
            rollerParameters = new RP(initParams, layoutParameters, outerRingParameters);

            rollerParameters.MessageHendler(ShowCalculationError);
            rollerParameters.StopCalculation += processor.StopCalculation;
            rollerParameters.RecalculateRequested += Recalculation;

            return processor.TryProcessParameters(rollerParameters);
        }

        private Parameters GetParameterObjectByOrder(int index)
        {
            switch (index)
            {
                case 0:
                    return layoutParameters;
                case 1:
                    return outerRingParameters;
                case 2:
                    return rollerParameters;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс должен быть от 0 до 2.");
            }
        }

        private void Recalculation(string paramName, decimal newValue)
        {
            InitialParameters newInitParams = initParams;

            if (paramName == "X1") newInitParams.X1 = newValue;
            else if (paramName == "X2") newInitParams.X2 = newValue;

            CalculateAllParameters(newInitParams);
        }

        public void ShowCalculatedParameters(DynamicTableManager tableManager, List<TabPage> tabPages)
        {
            for (int i = 0; i < tabPages.Count; i++)
            {
                tabPages[i].Controls.Clear();

                var obj = GetParameterObjectByOrder(i);
                if (obj != null)
                {
                    tableManager.InitializeTabPageComponents(tabPages[i]);
                    tableManager.AddFormulasToTable(obj.GetFormulasInfo());
                }
            }

            MessageBox.Show("Расчёт окончен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowCalculationError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
