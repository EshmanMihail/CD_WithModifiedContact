using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Helpers.LayoutParamsHelper
{
    public class DynamicTableManager
    {
        private Panel panel;
        private Control tabPage;
        private TableLayoutPanel table;

        private bool _isInitializing;
        private const int ColumnsCout = 3;
        
        public event EventHandler SketchRequested;
        public event EventHandler RecalculateRequested;
        public event Action<string, decimal> ParameterValueChanged;

        public void InitializeTabPageComponents(Control tabPage)
        {
            this.tabPage = tabPage;

            panel = InitializePanel();
            this.tabPage.Controls.Add(panel);

            var buttonsPanel = InitializeButtonsPanel();
            this.tabPage.Controls.Add(buttonsPanel);

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

        private Panel InitializeButtonsPanel()
        {
            var panelButtons = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.AntiqueWhite,
                BorderStyle = BorderStyle.FixedSingle
            };

            var recalcButton = new Button
            {
                Text = "Перерасчёт",
                Size = new Size(150, 40),
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, 5)
            };
            recalcButton.Click += (s, e) => RecalculateRequested?.Invoke(this, EventArgs.Empty);

            var sketchButton = new Button
            {
                Text = "Эскиз",
                Size = new Size(150, 40),
                BackColor = Color.LightSkyBlue,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(recalcButton.Right + 10, 5)
            };
            sketchButton.Click += (s, e) => SketchRequested?.Invoke(this, EventArgs.Empty);

            panelButtons.Controls.Add(recalcButton);
            panelButtons.Controls.Add(sketchButton);

            return panelButtons;
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
            _isInitializing = true;

            typeof(Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance)
            .SetValue(table, true, null);

            table.SuspendLayout();

            foreach (var formula in formulaDetails)
            {
                table.RowCount += 1;
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                int newRowIndex = table.RowCount - 1;

                string result = IsAngle(formula.Notation) ? RoundAngle(formula.Notation, formula.Result) : formula.Result.ToString();

                AddRowWithTextBox(formula.Description, formula.Notation, result, newRowIndex);
            }

            table.ResumeLayout();

            _isInitializing = false;
        }

        private void AddRowWithTextBox(string description, string notation, string initialValue, int rowIndex)
        {
            table.Controls.Add(InitializeLabel(description, true), 0, rowIndex);
            table.Controls.Add(InitializeLabel(notation, false), 1, rowIndex);
            table.Controls.Add(InitializeTextBox(initialValue, notation), 2, rowIndex);
        }

        private TextBox InitializeTextBox(string text, string notation)
        {
            TextBox textBox = new TextBox
            {
                Text = text,
                Tag = notation,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 14, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(3)
            };

            textBox.AccessibleDescription = text;

            ControlHelper.AttachDigitOnlyHandler(textBox);

            var changedBackColor = Color.FromArgb(0xD0, 0xF0, 0xFF);

            textBox.TextChanged += (s, e) =>
            {
                if (_isInitializing) return;

                bool isDifferent = !string.Equals(textBox.Text.Trim(), textBox.AccessibleDescription?.Trim(), StringComparison.Ordinal);
                textBox.BackColor = isDifferent ? changedBackColor : SystemColors.Window;

                if (decimal.TryParse(textBox.Text, out var value))
                {
                    ParameterValueChanged?.Invoke((string)textBox.Tag, value);
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (decimal.TryParse(textBox.Text, out var val))
                    textBox.Text = val.ToString("G");
            };

            return textBox;
        }


        #region reset table after recalculation
        public void ResetTextBoxesAfterRecanculation(TabPage tabPage, List<FormulaDetails> formulaDetails)
        {
            _isInitializing = true;

            var panel = tabPage.Controls.OfType<Panel>().FirstOrDefault();
            var table = panel?.Controls.OfType<TableLayoutPanel>().FirstOrDefault();

            ClearTextBoxesOnTab(panel, table);

            List<TextBox> textBoxes = GetTextBoxesInThirdColumn(table);

            for (int i = 0; i < formulaDetails.Count; i++)
            {
                string newText = IsAngle(formulaDetails[i].Notation) ?
                    RoundAngle(formulaDetails[i].Notation, formulaDetails[i].Result) : formulaDetails[i].Result.ToString();

                textBoxes[i].Text = newText;
            }

            _isInitializing = false;
        }

        private void ClearTextBoxesOnTab(Panel panel, TableLayoutPanel table)
        {
            if (table == null) return;

            bool prev = _isInitializing;
            try
            {
                _isInitializing = true;

                foreach (Control c in table.Controls)
                {
                    if (c is TextBox tb)
                    {
                        tb.Text = string.Empty;
                        tb.AccessibleDescription = string.Empty;
                        //tb.BackColor = SystemColors.Window;
                    }
                }
            }
            finally
            {
                _isInitializing = prev;
            }
        }

        private List<TextBox> GetTextBoxesInThirdColumn(TableLayoutPanel table)
        {
            var list = new List<TextBox>();
            int cols = table.ColumnCount;
            int rows = table.RowCount;

            int targetCol = 2;

            for (int r = 0; r < rows; r++)
            {
                var ctl = table.GetControlFromPosition(targetCol, r);
                if (ctl is TextBox tb) list.Add(tb);
            }

            return list;
        }
        #endregion


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
