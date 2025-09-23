using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation;
using CD_Radial_Spherical_Roller_withAsymetricalRollers.Calculation;

namespace CD_WithModifiedContact
{
    public partial class AddForm : Form
    {
        private MainForm mainForm;

        private ControlHelper controlHelper;
        private LambdaHelper lambdaHelper;
        private RangeDisplayManager rangeDisplayManager;
        private InitialParameterRangeValidator rangeValidator;

        public AddForm()
        {
            InitializeComponent();

            lambdaHelper = new LambdaHelper();
            rangeDisplayManager = new RangeDisplayManager();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            comboBoxLambdaRange.SelectedIndex = 0;
            comboBoxk.SelectedIndex = 0;

            controlHelper = new ControlHelper(tableLayoutPanelInitParams);
            controlHelper.AllowOnlyDigits(10);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TextBoxValidator.CheckTextBoxesFilledAndSetErrors(errorProvider1, tableLayoutPanelInitParams);
            if (TextBoxValidator.HasValidationErrors(errorProvider1, tableLayoutPanelInitParams)) return;

            try
            {
                var newBearing = CreateInitialParameterObject();

                CheckTextBoxesRangesAndSetErrors(newBearing);
                if (TextBoxValidator.HasValidationErrors(errorProvider1, tableLayoutPanelInitParams)) return;

                mainForm.AddNewBearing(newBearing);

                ShowConfirmationAndClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private InitialParameters CreateInitialParameterObject()
        {
            string nameOfBearing = textBoxBearingName.Text;
            int accuracyClass = int.Parse(textBoxAccuracyClass.Text.Trim());
            decimal D = decimal.Parse(textBoxD.Text.Trim());
            decimal d = decimal.Parse(textBox_d.Text.Trim());
            decimal B = decimal.Parse(textBoxB.Text.Trim());
            decimal rsmin = decimal.Parse(textBoxrsmin.Text.Trim());
            decimal Gr1 = decimal.Parse(textBoxGr1.Text.Trim());
            decimal Gr2 = decimal.Parse(textBoxGr2.Text.Trim());
            decimal lambda = decimal.Parse((textBoxLambda.Text).Trim());
            decimal x1 = decimal.Parse(textBoxX1.Text.Trim());
            decimal x2 = decimal.Parse(textBoxX2.Text.Trim());
            decimal bm = decimal.Parse(textBoxBm.Text.Trim());
            string k = comboBoxk.Text;

            InitialParameters newBearing = new InitialParameters(
                nameOfBearing, accuracyClass,
                D, d, B, rsmin, Gr1, Gr2,
                lambda, x1, x2, bm, k
            );

            return newBearing;
        }

        private void CheckTextBoxesRangesAndSetErrors(InitialParameters updatedParams)
        {
            rangeValidator = new InitialParameterRangeValidator(updatedParams, errorProvider1);
            rangeValidator.ValidateAndSetErrors(comboBoxLambdaRange.Text, textBoxLambda, textBoxX1, textBoxX2);
        }

        private void ShowConfirmationAndClearTextBoxes()
        {
            DialogResult result = MessageBox.Show(
                "Информация о подшипнике добавлена.\nОчистить текстовые поля?",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            List<Control> formControls = controlHelper.GetControls();

            foreach (Control el in formControls)
            {
                TextBox textBox = el as TextBox;
                if (textBox != null && textBox.Name != "textBoxBm") el.Text = "";
            }
        }


        private void textBoxD_Leave(object sender, EventArgs e)
        {
            ConvertAndDisplayRangeOfX1();
        }

        private void textBox_d_Leave(object sender, EventArgs e)
        {
            ConvertAndDisplayRangeOfX1();
        }

        private void ConvertAndDisplayRangeOfX1()
        {
            rangeDisplayManager.HandleRangeCalculation(
                textBoxD,
                textBox_d,
                Constants.X1MinRange,
                Constants.X1MaxRange,
                labelX1Range,
                textBoxX1,
                "Значение Х1 было взято среднее из диапазона"
            );
        }

        private void textBoxB_Leave(object sender, EventArgs e)
        {
            rangeDisplayManager.HandleRangeCalculation(
                textBoxB,
                null,
                Constants.X2MinRange,
                Constants.X2MaxRange,
                labelX2Range,
                textBoxX2,
                "Для значение Х2 было взято среднее из диапазона"
            );
        }

        private void comboBoxLambdaRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLambdaValue();
        }

        private void GetLambdaValue()
        {
            try
            {
                string rangeString = comboBoxLambdaRange.Text;
                decimal avg = lambdaHelper.GetLambdaAvgValue(rangeString);

                textBoxLambda.Text = avg.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        public void GetMainFormInstance(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
