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
        private void InitializeComboBoxBeginValues()
        {
            comboBoxLambdaRange.SelectedIndex = Constants.FirstValueIndex;
            comboBoxk.SelectedIndex = Constants.FirstValueIndex;
        }

        private void InitializeTextBoxEvents()
        {
            textBoxD.TextChanged += ConvertAndDisplayRangeOfX1;
            textBoxD.Leave += ConvertAndDisplayRangeOfX1;
            textBox_d.TextChanged += ConvertAndDisplayRangeOfX1;
            textBox_d.Leave += ConvertAndDisplayRangeOfX1;
            textBoxB.TextChanged += ConvertAndDisplayRangeOfX2;
            textBoxB.Leave += ConvertAndDisplayRangeOfX2;

            controlHelper = new ControlHelper(tableLayoutPanelInitParams);
            controlHelper.AllowOnlyDigits(10);
        }

        #region Textboxs D d B change and leave event methods
        private void ConvertAndDisplayRangeOfX1(object sender, EventArgs e)
        {
            rangeDisplayManager.HandleRangeCalculation(
                textBoxD,
                textBox_d,
                Constants.X1MinRange,
                Constants.X1MaxRange,
                labelX1Range,
                textBoxX1,
                string.Empty
            );
        }

        private void ConvertAndDisplayRangeOfX2(object sender, EventArgs e)
        {
            rangeDisplayManager.HandleRangeCalculation(
               textBoxB,
               null,
               Constants.X2MinRange,
               Constants.X2MaxRange,
               labelX2Range,
               textBoxX2,
               string.Empty
           );
        }
        #endregion

        private void AddInputControls()
        {
            foreach (Control control in tableLayoutPanelInitParams.Controls)
            {
                TextBox textBox = control as TextBox;
                if (control != null) inputControls.Add(control);
            }
            inputControls.Add(comboBoxk);
        }

        private void FillListView()
        {
            listViewBearingsName.Items.Clear();

            foreach (InitialParameters initParam in initParamsOfBearings)
            {
                ListViewItem item = new ListViewItem(initParam.Name)
                {
                    Tag = initParam.Id
                };

                listViewBearingsName.Items.Add(item);
            }
        }

        private void ShowUsedTextBoxes(List<Control> usedControls)
        {
            string controlsNames = "";
            foreach (Control c in usedControls)
            {
                controlsNames += c.Name + '\n';
            }
            MessageBox.Show(controlsNames);
        }
    }
}
