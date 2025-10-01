using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers.LayoutParamsHelper;

namespace CD_WithModifiedContact.Helpers.ParamsTableHelper
{
    public class TablePresenter
    {
        private readonly DynamicTableManager tableManager;
        private readonly List<TabPage> tabPages;

        public TablePresenter(DynamicTableManager manager, List<TabPage> pages)
        {
            tableManager = manager;
            tabPages = pages;
        }

        public void ShowResults(List<Parameters> results)
        {
            ClearAllTabPages();
            for (int i = 0; i < results.Count; i++)
            {
                var page = tabPages[i];
                page.Controls.Clear();
                tableManager.InitializeTabPageComponents(page);
                tableManager.AddFormulasToTable(results[i].GetFormulasInfo());
            }
            MessageBox.Show("Расчёт окончен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearAllTabPages()
        {
            for (int i = 0; i < tabPages.Count; i++)
            {
                tabPages[i].Controls.Clear();
            }
        }
    }
}
