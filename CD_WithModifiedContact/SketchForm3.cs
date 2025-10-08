using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CD_WithModifiedContact
{
    public partial class SketchForm3 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        public SketchForm3()
        {
            InitializeComponent();
        }

        private void SketchForm3_Load(object sender, EventArgs e)
        {
            SetLabelsAutoSize(this, 5);
        }

        private void SetLabelsAutoSize(Control parent, int offsetY)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.AutoSize = true;
                    lbl.Top += offsetY;
                }
                // если у вас есть контейнеры (Panel, GroupBox и т.п.), обойти их содержимое
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
                    if (f.Notation == FormulaSymbols.alphaK) labelAlphaK1.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    if (f.Notation == FormulaSymbols.alphaK) labelAlphaK2.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();

                    if (f.Notation == FormulaSymbols.Lw) labelLw.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.Lw) labelLwDel2.Text = (f.Result / 2m).ToString();

                    else if (f.Notation == FormulaSymbols.Dwe) labelDwe.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.L1_1hatch) labelL1_1hatch.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.RT) labelRt.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.YB) labelYb.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Yop2) labelYop2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Ye) labelYe.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.P) labelP.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.XB) labelXb.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.dp2) labelDp2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Xop2) labelXop2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Xp) labelXp.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Xm) labelXm.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.L1) labelL1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Dw) labelDw.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Xe) labelXe.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Xop1) labelXop1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Ym) labelYm.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.dp1) labelDp1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Yop1) labelYop1.Text = f.Result.ToString();
                    
                    if (f.Notation == FormulaSymbols.Fi1) label_Fi11.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    if (f.Notation == FormulaSymbols.Fi1) label_Fi12.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();

                    else if (f.Notation == FormulaSymbols.Fi) labelFi.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    else if (f.Notation == FormulaSymbols.Fik) labelFik.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    else if (f.Notation == FormulaSymbols.fi1_1hatch) labelFi1_1hatch.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    else if (f.Notation == FormulaSymbols.alpha0) labelAlpha0.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                    else if (f.Notation == FormulaSymbols.alpha0_2hatch) labelAlpha0_2hatch.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                }
            }

            FillInitParams();
        }

        private void FillInitParams()
        {
            labelX1.Text = initialParameters.X1.ToString();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {

        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            SketchForm2 sketchForm2 = new SketchForm2();
            sketchForm2.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm2.Location = this.Location;

            sketchForm2.Show();

            this.Hide();
            this.Dispose();
        }
    }
}
