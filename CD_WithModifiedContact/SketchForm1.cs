using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CD_WithModifiedContact
{
    public partial class SketchForm1 : Form
    {
        private InitialParameters initialParameters;

        private List<FormulaDetails> otherParams;

        public SketchForm1()
        {
            InitializeComponent();
        }

        private void SketchForm1_Load(object sender, EventArgs e)
        {
            otherParams = new List<FormulaDetails>();
        }

        public void FillParamsOnSkretch(InitialParameters initialParameters, List<Parameters> parameters)
        {
            this.initialParameters = initialParameters;

            otherParams.Clear();
            foreach (var p in parameters)
            {
                foreach (var f in p.GetFormulasInfo())
                {
                    if (f.Notation == FormulaSymbols.b1) labelb1.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.d0) labeld0.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.alpha0) labelalpha0.Text = f.Result.ToString();
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
    }
}
