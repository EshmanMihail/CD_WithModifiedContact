using CD_Radial_Spherical_Roller_withAsymetricalRollers.Calculation;
using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD_WithModifiedContact
{
    public partial class MainForm
    {
        private void listViewBearingsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForUnsavedChanges();

            if (listViewBearingsName.SelectedItems.Count > 0)
            {
                string chosenBearingName = listViewBearingsName.SelectedItems[0].Text.Replace(" *", "");

                InitialParameters initParamsForChosenBearing = FindObjectByName(chosenBearingName);
                chosenInitParams = initParamsForChosenBearing;

                if (initParamsForChosenBearing != null)
                    FillTextBoxesByChosenInformation(initParamsForChosenBearing);

                previousChosenItem = listViewBearingsName.SelectedItems[0];
                previousChosenItemId = previousChosenItem.Tag.ToString();
            }

            ChangeParametersInTextBoxRange();
        }

        private void CheckForUnsavedChanges()
        {
            if (isItemModified)
            {
                var result = ShowUnsavedChangesWarning();

                if (result == DialogResult.Yes)
                {
                    UpdateItemData(previousChosenItem, previousChosenItemId);
                }
                else
                {
                    previousChosenItem.Text = previousChosenItem.Text.Replace(" *", "");
                    isItemModified = false;
                }
            }
        }

        private DialogResult ShowUnsavedChangesWarning()
        {
            return MessageBox.Show(
                "Есть несохранённые изменения. Желаете сохранить их?",
                "Предупреждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
        }

        private void CheckTextBoxesRangesAndSetErrors(InitialParameters updatedParams)
        {
            rangeValidator = new InitialParameterRangeValidator(updatedParams, errorProviderMainForm);
            rangeValidator.ValidateAndSetErrors(comboBoxLambdaRange.Text, textBoxLambda, textBoxX1, textBoxX2);
        }

        private InitialParameters FindObjectByName(string chosenBearingName)
        {
            if (initParamsOfBearings.Count > 0)
            {
                foreach (InitialParameters inp in initParamsOfBearings)
                {
                    if (inp.Name == chosenBearingName)
                    {
                        return inp;
                    }
                }
            }
            return null;
        }

        private void FillTextBoxesByChosenInformation(InitialParameters initParamsForChosenBearing)
        {
            ConfigureTextBoxModificationTracking(false);

            textBoxBearingName.Text = initParamsForChosenBearing.Name;
            textBoxAccuracyClass.Text = initParamsForChosenBearing.AccuracyClass.ToString();
            textBoxD.Text = initParamsForChosenBearing.D.ToString();
            textBox_d.Text = initParamsForChosenBearing.d.ToString();
            textBoxB.Text = initParamsForChosenBearing.B.ToString();
            textBoxrsmin.Text = initParamsForChosenBearing.r_s_min.ToString();
            textBoxGr1.Text = initParamsForChosenBearing.Gr1.ToString();
            textBoxGr2.Text = initParamsForChosenBearing.Gr2.ToString();
            textBoxLambda.Text = initParamsForChosenBearing.lambda_B.ToString();
            textBoxX1.Text = initParamsForChosenBearing.X1.ToString();
            textBoxX2.Text = initParamsForChosenBearing.X2.ToString();
            textBoxBm.Text = initParamsForChosenBearing.Bm.ToString();
            comboBoxk.Text = initParamsForChosenBearing.k.ToString();

            ConfigureTextBoxModificationTracking(true);
        }

        private void ChangeParametersInTextBoxRange()
        {
            rangeDisplayManager.HandleRangeCalculation(
                textBoxD,
                textBox_d,
                Constants.X1MinRange,
                Constants.X1MaxRange,
                labelX1Range,
                textBoxX1,
                ""
            );

            rangeDisplayManager.HandleRangeCalculation(
                textBoxB,
                null,
                Constants.X2MinRange,
                Constants.X2MaxRange,
                labelX2Range,
                textBoxX2,
                ""
            );
        }
    }
}
