using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CD_WithModifiedContact
{
    public partial class MainForm
    {
        private void buttonDeleteBearing_Click(object sender, EventArgs e)
        {
            if (listViewBearingsName.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите элемент для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemToRemove = listViewBearingsName.SelectedItems[0];

            string selectedBearingName = itemToRemove.Text;
            string selectedBearingId = itemToRemove.Tag.ToString();

            DialogResult result = MessageBox.Show(
                $"Удалить информацию о подшипнике {selectedBearingName}?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                listViewBearingsName.Items.Remove(itemToRemove);

                bearingRepository.Delete(selectedBearingId);

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
    }
}
