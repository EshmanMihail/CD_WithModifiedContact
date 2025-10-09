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
    public partial class SketchForm5 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        public SketchForm5()
        {
            InitializeComponent();
        }

        private void SketchForm5_Load(object sender, EventArgs e)
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
                    if (f.Notation == FormulaSymbols.m0) labelm.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.m1) labelm1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.m2) labelm2.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.m3) labelm3.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.m0) label_m.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.m1) label_m1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.m2) label_m2.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.m3) label_m3.Text = f.Result.ToString();

                    if (f.Notation == FormulaSymbols.rm) labelrm1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.rm) labelrm2.Text = f.Result.ToString();

                    if (f.Notation == FormulaSymbols.Dk1) labelDk11.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.Dk1) labelDk12.Text = f.Result.ToString();

                    if (f.Notation == FormulaSymbols.Fik) labelFik.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    if (f.Notation == FormulaSymbols.F) labelF.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.r3smin) labelR3smin1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.r3smin) labelR3smin2.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.R3) labelR3.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.R2) labelR2.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d1) labeld11.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d1) labeld12.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d2) labelD21.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d2) labelD22.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.dm) labelDm.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d3) labeld31.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d3) labeld32.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d5) labeld5.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d6) labeld6.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d4) labeld4.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.gamma1) labelgamma1.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    if (f.Notation == FormulaSymbols.h) labelh.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.YB) labelYb.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.rB) labelrb.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.XB2) labelXb2.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.XB) labelXb0.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.XB1) labelXb1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.alpha1) labelalpha1.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                }
            }
            FillInitParams();
        }

        private void FillInitParams()
        {
            labeld1.Text = initialParameters.d.ToString();
            labeld2.Text = initialParameters.d.ToString();

            labelRsmin1.Text = initialParameters.r_s_min.ToString();
            labelRsmin2.Text = initialParameters.r_s_min.ToString();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            SketchForm6 sketchForm6 = new SketchForm6();
            sketchForm6.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm6.Location = this.Location;

            sketchForm6.Show();

            this.Hide();
            this.Dispose();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            SketchForm4 sketchForm4 = new SketchForm4();
            sketchForm4.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm4.Location = this.Location;

            sketchForm4.Show();

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
