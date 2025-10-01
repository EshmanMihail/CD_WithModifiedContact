using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using LP = CD_WithModifiedContact.Calculation.LayoutParameters.LayoutParameters;
using RP = CD_WithModifiedContact.Calculation.RollerParameters.RollerParameters;
using SP = CD_WithModifiedContact.Calculation.SeparatorParameters.SeparatorParameters;
using IRP = CD_WithModifiedContact.Calculation.InnerRingParameters.InnerRingParameters;
using ORP = CD_WithModifiedContact.Calculation.OuterRingParameters.OuterRingParameters;

namespace CD_WithModifiedContact.Calculation
{
    public class CalculationController
    {
        private List<Parameters> parameters = new List<Parameters>();

        private InitialParameters initParams;

        private Dictionary<string, string> recalculationRules = new Dictionary<string, string>
        {
            { "X1", "a < 0.75(d6 - d2)" },
            { "X2", "Xp > 0.495B" }
        };

        public void CalculateAllParameters(InitialParameters chosenInitParams)
        {
            if (parameters.Count > 0) parameters.Clear();
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
                
                processor.ExecuteFormulasValueMethods(parameters[i]);

                if (!success) break;
            }
        }

        private bool CalculateLayoutParameters(GenericParameterProcessor processor)
        {
            LP layoutParameters = new LP(initParams);
            parameters.Add(layoutParameters);

            layoutParameters.MessageHendler(ErrorHandler.ShowError);
            layoutParameters.StopCalculation += processor.StopCalculation;

            return processor.TryProcessParameters(layoutParameters);
        }

        private bool CalculateOuterRingParameters(GenericParameterProcessor processor)
        {
            ORP outerRingParameters = new ORP(initParams, (LP)parameters[0]);
            parameters.Add(outerRingParameters);

            outerRingParameters.MessageHendler(ErrorHandler.ShowError);
            outerRingParameters.StopCalculation += processor.StopCalculation;

            return processor.TryProcessParameters(outerRingParameters);
        }

        private bool CalculateRollerParameters(GenericParameterProcessor processor)
        {
            RP rollerParameters = new RP(initParams, (LP)parameters[0], (ORP)parameters[1]);
            parameters.Add(rollerParameters);

            rollerParameters.MessageHendler(ErrorHandler.ShowError);
            rollerParameters.StopCalculation += processor.StopCalculation;
            rollerParameters.RecalculateRequested += Recalculation;

            return processor.TryProcessParameters(rollerParameters);
        }

        private bool CalulateInnerRingParameters(GenericParameterProcessor processor)
        {
            IRP innerRingParameters = new IRP(initParams, (LP)parameters[0], (ORP)parameters[1], (RP)parameters[2]);
            parameters.Add(innerRingParameters);

            innerRingParameters.MessageHendler(ErrorHandler.ShowError);
            innerRingParameters.StopCalculation += processor.StopCalculation;
            innerRingParameters.RecalculateRequested += Recalculation;

            return processor.TryProcessParameters(innerRingParameters);
        }

        private bool CalculateSeparatorParameters(GenericParameterProcessor processor)
        {
            SP separatorParameters = new SP(initParams, (LP)parameters[0], (ORP)parameters[1], (RP)parameters[2], (IRP)parameters[3]);
            parameters.Add(separatorParameters);

            separatorParameters.MessageHendler(ErrorHandler.ShowError);
            separatorParameters.StopCalculation += processor.StopCalculation;

            return processor.TryProcessParameters(separatorParameters);
        }

        public void Recalculation(string paramName, decimal newValue)
        {
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

        public List<Parameters> GetListOfParameters()
        {
            return parameters;
        }
    }
}
