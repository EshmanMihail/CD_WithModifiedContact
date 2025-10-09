using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact
{
    public partial class SketchForm1 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        public SketchForm1()
        {
            InitializeComponent();
        }

        private void SketchForm1_Load(object sender, EventArgs e) { }

        public void FillParamsOnSketch(InitialParameters initialParameters, List<Parameters> parameters)
        {
            this.initialParameters = initialParameters;
            allParameters = parameters;

            foreach (var p in parameters)
            {
                foreach (var f in p.GetFormulasInfo())
                {
                    if (f.Notation == FormulaSymbols.b1) labelb1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d0) labeld0.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.alpha0) labelalpha0.Text = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                }
            }

            FillInitParams();
        }

        private void FillInitParams()
        {
            label_B.Text = initialParameters.B.ToString();
            label_D.Text = initialParameters.D.ToString();
            labeld.Text = initialParameters.d.ToString();
            labelRsmin1.Text = initialParameters.r_s_min.ToString();
            labelRsmin2.Text = initialParameters.r_s_min.ToString();
            labelRsmin3.Text = initialParameters.r_s_min.ToString();

            labelRsminV1.Text = initialParameters.r_s_min.ToString();
            labelRsminV2.Text = initialParameters.r_s_min.ToString();
            labelRsminV3.Text = initialParameters.r_s_min.ToString();
        }

        private string GetVerticalValueString(decimal value)
        {
            string strValue = value.ToString();
            string result = "";

            for (int i = 0; i < strValue.Length; i++)
            {
                result += strValue[i] + '\n';
            }

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SketchForm2 sketchForm2 = new SketchForm2();
            sketchForm2.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm2.StartPosition = FormStartPosition.Manual;
            sketchForm2.Bounds = this.Bounds;

            sketchForm2.Show();

            this.Hide();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SketchForm7 sketchForm7 = new SketchForm7();
            sketchForm7.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm7.Location = this.Location;

            sketchForm7.Show();

            this.Hide();
            this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
