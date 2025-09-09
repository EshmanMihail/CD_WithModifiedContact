using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CD_WithModifiedContact.Helpers.LayoutParamsHelper
{
    public class DynamicTableManager
    {
        private Control tabPage;
        private Panel panel;
        private TableLayoutPanel table;

        private const int ColumnsCout = 3;

        public DynamicTableManager(Control tabpage)
        {
            tabPage = tabpage;
            InitializeTabPageComponents();
        }

        private void InitializeTabPageComponents()
        {
            panel = InitializePanel();
            tabPage.Controls.Add(panel);

            table = InitializeTableLayoutPanel();
            panel.Controls.Add(table);

            table.Controls.Add(InitializeLabel("Описание параметра", true), 0, 0);
            table.Controls.Add(InitializeLabel("Обозначение параметра", false), 1, 0);
            table.Controls.Add(InitializeLabel("Значение", false), 2, 0);
        }

        private Panel InitializePanel()
        {
            Panel panel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                BackColor = Color.AntiqueWhite,
                BorderStyle = BorderStyle.FixedSingle
            };

            return panel;
        }

        private TableLayoutPanel InitializeTableLayoutPanel(int columnsCount = 3, int rowsCount = 4)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel()
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                ColumnCount = columnsCount,
                RowCount = rowsCount
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            return tableLayoutPanel;
        }

        private Label InitializeLabel(string text, bool autoSize)
        {
            Label label = new Label
            {
                AutoSize = autoSize,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 20, FontStyle.Bold),
            };
            if (!autoSize) label.Dock = DockStyle.Fill;

            return label;
        }

        public void AddFormulasToTable(List<FormulaDetails> formulaDetails)
        {
            foreach (var formula in formulaDetails)
            {
                table.RowCount += 1;
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                int newRowIndex = table.RowCount - 1;

                string result = IsAngle(formula.Notation) ? RoundAngle(formula.Notation, formula.Result) : formula.Result.ToString();

                AddRowToTable(formula.Description, formula.Notation, result, newRowIndex);
            }
        }

        private void AddRowToTable(string description, string notation, string result, int rowIndex)
        {
            table.Controls.Add(InitializeLabel(description, true), 0, rowIndex);
            table.Controls.Add(InitializeLabel(notation, false), 1, rowIndex);
            table.Controls.Add(InitializeLabel(result, false), 2, rowIndex);
        }

        private bool IsAngle(string value)
        {
            return Constants.anglesThatRoundForMinutes.Contains(value) ||
                   Constants.anglesThatRoundForSeconds.Contains(value);
        }

        private string RoundAngle(string notation, decimal value)
        {
            if (Constants.anglesThatRoundForMinutes.Contains(notation))
            {
                return ParameterRounder.RoundAngleToMinutes((double)value);
            }
            else if (Constants.anglesThatRoundForSeconds.Contains(notation))
            {
                return ParameterRounder.RoundAngleToSeconds((double)value);
            }

            return value.ToString();
        }
    }
}
