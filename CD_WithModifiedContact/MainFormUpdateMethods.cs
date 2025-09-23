using System;
using System.Windows.Forms;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact
{
    public partial class MainForm
    {
        private void buttonChangeBearing_Click(object sender, EventArgs e)
        {
            if (listViewBearingsName.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите элемент для изменения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TextBoxValidator.CheckTextBoxesFilledAndSetErrors(errorProviderMainForm, tableLayoutPanelInitParams);
                if (TextBoxValidator.HasValidationErrors(errorProviderMainForm, tableLayoutPanelInitParams)) return;

                SaveChangedItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveChangedItem()
        {
            var selectedItem = listViewBearingsName.SelectedItems[0];
            string selectedId = selectedItem.Tag.ToString();

            UpdateItemData(selectedItem, selectedId);
        }

        private void UpdateItemData(ListViewItem selectedItem, string selectedId)
        {
            var updatedParams = GetInitialParameterObject(selectedId);

            CheckTextBoxesRangesAndSetErrors(updatedParams);
            if (TextBoxValidator.HasValidationErrors(errorProviderMainForm, tableLayoutPanelInitParams))
            {
                //MessageBox.Show(
                //    $"Возникла ошибка при проверки введённых данных {previousChosenItem.Text}.",
                //    "Ошибка",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Warning
                //);
            }

            selectedItem.Text = selectedItem.Text.Replace(" *", "");

            bearingRepository.Update(updatedParams);

            selectedItem.Text = updatedParams.Name;
            UpdateObjectInList(updatedParams);

            MessageBox.Show("Элемент успешно обновлён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private InitialParameters GetInitialParameterObject(string selectedId)
        {
            string newName = textBoxBearingName.Text;
            int accuracyClass = int.Parse(textBoxAccuracyClass.Text);
            decimal D = decimal.Parse(textBoxD.Text);
            decimal d = decimal.Parse(textBox_d.Text);
            decimal B = decimal.Parse(textBoxB.Text);
            decimal rsmin = decimal.Parse(textBoxrsmin.Text);
            decimal Gr1 = decimal.Parse(textBoxGr1.Text);
            decimal Gr2 = decimal.Parse(textBoxGr2.Text);
            decimal lambda = decimal.Parse(textBoxLambda.Text);
            decimal x1 = decimal.Parse(textBoxX1.Text);
            decimal x2 = decimal.Parse(textBoxX2.Text);
            decimal bm = decimal.Parse(textBoxBm.Text);
            string k = comboBoxk.Text;

            InitialParameters updatedParams = new InitialParameters(
                id: selectedId,
                name: newName,
                accuracyClass: accuracyClass,
                D: D,
                d: d,
                B: B,
                r_s_min: rsmin,
                gr1: Gr1,
                gr2: Gr2,
                lambda_B: lambda,
                x1: x1,
                x2: x2,
                bm: bm,
                k: k
            );

            return updatedParams;
        }

        private void UpdateObjectInList(InitialParameters updatedParams)
        {
            foreach (var param in initParamsOfBearings)
            {
                if (updatedParams.Id == param.Id)
                {
                    param.Name = updatedParams.Name;
                    param.AccuracyClass = updatedParams.AccuracyClass;
                    param.D = updatedParams.D;
                    param.d = updatedParams.d;
                    param.B = updatedParams.B;
                    param.r_s_min = updatedParams.r_s_min;
                    param.Gr1 = updatedParams.Gr1;
                    param.Gr2 = updatedParams.Gr2;
                    param.lambda_B = updatedParams.lambda_B;
                    param.lambda_H = updatedParams.lambda_B;
                    param.X1 = updatedParams.X1;
                    param.X2 = updatedParams.X2;
                    param.Bm = updatedParams.Bm;
                    param.k = updatedParams.k;
                }
            }
        }
    }
}
