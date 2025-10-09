using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD_WithModifiedContact
{
    public partial class SketchForm7 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        public SketchForm7()
        {
            InitializeComponent();
        }

        private void SketchForm7_Load(object sender, EventArgs e)
        {
            SetLabelsAutoSize(this, 5);
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
                    if (f.Notation == FormulaSymbols.dr) labeldr1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.dr) labeldr2.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.dr) labeldr3.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.dr) labeldr4.Text = f.Result.ToString();

                    else if (f.Notation == FormulaSymbols.Dc) label_Dc.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.dc) labeldc.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Dc1) labelDc1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Bc) labelBc.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Fic) labelFic.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    else if (f.Notation == FormulaSymbols.S1) labelS1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.D0) labelD0.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.bc) label_bc.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.gamma) labelgamma.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    else if (f.Notation == FormulaSymbols.Hr) labelHr.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.da) labelda.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.e2) labele2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.C1) labelC1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Fir) labelFir.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    else if (f.Notation == FormulaSymbols.S) labelS.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.d2_2hatch) labeld2_2hatch.Text = f.Result.ToString();
                }
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            SketchForm1 sketchForm1 = new SketchForm1();
            sketchForm1.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm1.Location = this.Location;

            sketchForm1.Show();

            this.Hide();
            this.Dispose();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            SketchForm6 sketchForm6 = new SketchForm6();
            sketchForm6.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm6.Location = this.Location;

            sketchForm6.Show();

            this.Hide();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
