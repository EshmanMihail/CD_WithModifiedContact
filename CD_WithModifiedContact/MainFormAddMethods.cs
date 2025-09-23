using System;
using System.Windows.Forms;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact
{
    public partial class MainForm
    {
        private void buttonAddBearing_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
            addForm.GetMainFormInstance(this);
        }

        public void AddNewBearing(InitialParameters parameters)
        {
            initParamsOfBearings.Add(parameters);

            ListViewItem newItem = new ListViewItem(parameters.Name)
            {
                Tag = parameters.Id
            };

            listViewBearingsName.Items.Add(newItem);

            bearingRepository.Add(parameters);
        }
    }
}
