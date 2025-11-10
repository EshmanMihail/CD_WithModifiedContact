using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers.LayoutParamsHelper;

namespace CD_WithModifiedContact.Helpers.ParamsTableHelper
{
    public class TablePresenter
    {
        private readonly List<TabPage> tabPages;

        private readonly DynamicTableManager tableManager;

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

        public void ShowRecalculatedResults(List<Parameters> results)
        {
            for (int i = 0; i < results.Count; i++)
            {
                var page = tabPages[i];

                if (page.Controls.Count == 0)
                {
                    tableManager.InitializeTabPageComponents(page);
                    tableManager.AddFormulasToTable(results[i].GetFormulasInfo());
                }

                tableManager.ResetTextBoxesAfterRecanculation(page, results[i].GetFormulasInfo());
            }
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
