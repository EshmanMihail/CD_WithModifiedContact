using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact
{
    public partial class SketchForm2 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        public SketchForm2()
        {
            InitializeComponent();
        }

        private void SketchForm2_Load(object sender, EventArgs e) { }

        public void FillParamsOnSketch(InitialParameters initialParameters, List<Parameters> parameters)
        {
            this.initialParameters = initialParameters;
            allParameters = parameters;

            foreach (var p in parameters)
            {
                foreach (var f in p.GetFormulasInfo())
                {
                    if (f.Notation == FormulaSymbols.r3smin) labelR3sminV1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.r3smin) labelR3smin.Text = f.Result.ToString();

                    if (f.Notation == FormulaSymbols.Ch1) labelCH1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.b1) labelb1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.d0) labeld0.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.R3) labelR3.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.Ch2) labelCh2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.D1) labelD1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.D2) labelD2.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.D3) labelD3.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.R2) labelR2.Text = f.Result.ToString();
                }
            }

            FillInitParams();
        }

        private void FillInitParams()
        {
            label_B.Text = initialParameters.B.ToString();
            label_D.Text = initialParameters.D.ToString();
            labelRsmin.Text = initialParameters.r_s_min.ToString();
            labelRsminV.Text = initialParameters.r_s_min.ToString();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            SketchForm3 sketchForm3 = new SketchForm3();
            sketchForm3.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm3.Location = this.Location;

            sketchForm3.Show();

            this.Hide();
            this.Dispose();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            SketchForm1 sketchForm1 = new SketchForm1();
            sketchForm1.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm1.StartPosition = FormStartPosition.Manual;
            sketchForm1.Bounds = this.Bounds;
            
            sketchForm1.Show();

            this.Hide();
            this.Dispose();
        }
    }
}
