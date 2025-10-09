using System;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact
{
    public partial class SketchForm4 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        public SketchForm4()
        {
            InitializeComponent();
        }

        private void SketchForm4_Load(object sender, EventArgs e)
        {
            SetLabelsAutoSize(this, 8);
        }

        private void SetLabelsAutoSize(Control parent, int offsetY)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is System.Windows.Forms.Label lbl)
                {
                    lbl.AutoSize = true;
                    lbl.Top += offsetY;
                }
                if (c.HasChildren)
                {
                    SetLabelsAutoSize(c, offsetY);
                }
            }
        }

        public void FillParamsOnSketch(InitialParameters initialParameters, List<Parameters> parameters)
        {
            this.initialParameters = initialParameters;
            allParameters = parameters;

            foreach (var p in parameters)
            {
                foreach (var f in p.GetFormulasInfo())
                {
                    if (f.Notation == FormulaSymbols.r0smin) labelR0smin1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.r0smin) labelR0smin2.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.r0smin) labelR0smin3.Text = f.Result.ToString();

                    if (f.Notation == FormulaSymbols.R0) labelR01.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.R0) labelR02.Text = f.Result.ToString();

                    if (f.Notation == FormulaSymbols.l6) labelL6.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.l5) labelL5.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.f1) labelF1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.dp3) labelDp3.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.l4) labelL4.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.l3) labelL3.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.L1) labelL1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.f) labelF.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.R) labelR.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.dp2) labelDp2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.B8) labelb8.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.d8) labeld8.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.dp1) labelDp1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Dw) labelDw.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.l2) labelL2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Lw) labelLw.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Rp) labelRp.Text = f.Result.ToString();
                }
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            SketchForm5 sketchForm5 = new SketchForm5();
            sketchForm5.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm5.Location = this.Location;

            sketchForm5.Show();

            this.Hide();
            this.Dispose();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            SketchForm3 sketchForm3 = new SketchForm3();
            sketchForm3.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm3.Location = this.Location;

            sketchForm3.Show();

            this.Hide();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
