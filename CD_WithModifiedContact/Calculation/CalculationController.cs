using CD_WithModifiedContact.Helpers.LayoutParamsHelper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LP = CD_WithModifiedContact.Calculation.LayoutParameters.LayoutParameters;
using ORP = CD_WithModifiedContact.Calculation.OuterRingParameters.OuterRingParameters;
using RP = CD_WithModifiedContact.Calculation.RollerParameters.RollerParameters;
using IRP = CD_WithModifiedContact.Calculation.InnerRingParameters.InnerRingParameters;
using SP = CD_WithModifiedContact.Calculation.SeparatorParameters.SeparatorParameters;

namespace CD_WithModifiedContact.Calculation
{
    public class CalculationController
    {
        private InitialParameters initParams;
        private LP layoutParameters;
        private ORP outerRingParameters;
        private RP rollerParameters;
        private IRP innerRingParameters;
        private SP separatorParameters;

        public void CalculateAllParameters(InitialParameters chosenInitParams)
        {
            initParams = chosenInitParams;

            var steps = new List<Func<GenericParameterProcessor, bool>>
            {
                CalculateLayoutParameters,
                CalculateOuterRingParameters,
                CalculateRollerParameters,
                CalulateInnerRingParameters,
                CalculateSeparatorParameters
            };

            for (int i = 0; i < steps.Count; i++)
            {
                var processor = new GenericParameterProcessor();

                bool success = steps[i](processor);

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

        private bool CalulateInnerRingParameters(GenericParameterProcessor processor)
        {
            innerRingParameters = new IRP(initParams, layoutParameters, outerRingParameters, rollerParameters);

            innerRingParameters.MessageHendler(ShowCalculationError);
            innerRingParameters.StopCalculation += processor.StopCalculation;
            innerRingParameters.RecalculateRequested += Recalculation;

            return processor.TryProcessParameters(innerRingParameters);
        }

        private bool CalculateSeparatorParameters(GenericParameterProcessor processor)
        {
            separatorParameters = new SP(initParams, layoutParameters, outerRingParameters, rollerParameters, innerRingParameters);

            separatorParameters.MessageHendler(ShowCalculationError);
            separatorParameters.StopCalculation += processor.StopCalculation;

            return processor.TryProcessParameters(separatorParameters);
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
                case 3:
                    return innerRingParameters;
                case 4:
                    return separatorParameters;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс должен быть от 0 до 4.");
            }
        }

        private void Recalculation(string paramName, decimal newValue)
        {
            var recalculationRules = new Dictionary<string, string>
            {
                { "X1", "a < 0.75(d6 - d2)" },
                { "X2", "Xp > 0.495B" }
            };

            if (!recalculationRules.TryGetValue(paramName, out string reasonOfRecalculation))
            {
                MessageBox.Show($"Параметр {paramName} не поддерживается для перерасчета.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitialParameters newInitParams = initParams;
            if (paramName == "X1") newInitParams.X1 = newValue;
            if (paramName == "X2") newInitParams.X2 = newValue;

            var result = MessageBox.Show(
                $"Вызван перерасчёт: {reasonOfRecalculation}. Хотите продолжить перерасчет?",
                "Перерасчёт", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel) { return; }

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
