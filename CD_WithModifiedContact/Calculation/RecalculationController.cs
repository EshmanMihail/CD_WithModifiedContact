using System.Windows.Forms;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation
{
    public class RecalculationController
    {
        private CalculationController calculationController;
        private InitialParameters initParams;

        public RecalculationController(CalculationController calculationController, InitialParameters initParams)
        {
            this.calculationController = calculationController;
            this.initParams = initParams;
        }

        public void Recalculation(string paramName, decimal newValue)
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

            calculationController.CalculateAllParameters(newInitParams);
        }
    }
}
