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
    public partial class SketchForm6 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        public SketchForm6()
        {
            InitializeComponent();
        }

        private void SketchForm6_Load(object sender, EventArgs e)
        {

        }

        public void FillParamsOnSketch(InitialParameters initialParameters, List<Parameters> parameters)
        {
            this.initialParameters = initialParameters;
            allParameters = parameters;

            foreach (var p in parameters)
            {
                foreach (var f in p.GetFormulasInfo())
                {
                    if (f.Notation == FormulaSymbols.R2) labelR21.Text = f.Result.ToString();
                    if (f.Notation == FormulaSymbols.R2) labelR22.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.h1) labelh1.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.dm) labelDm.Text = f.Result.ToString();
                    else if (f.Notation == FormulaSymbols.h) labelh.Text = f.Result.ToString();
                }
            }

            FillinitParams();
        }

        private void FillinitParams()
        {
            labelRsmin1.Text = initialParameters.r_s_min.ToString();
            labelRsmin2.Text = initialParameters.r_s_min.ToString();
            labelRsmin3.Text = initialParameters.r_s_min.ToString();
            labelRsmin4.Text = initialParameters.r_s_min.ToString();
            labeld.Text = initialParameters.d.ToString();
            labelk.Text = initialParameters.k;
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            SketchForm7 sketchForm7 = new SketchForm7();
            sketchForm7.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm7.Location = this.Location;

            sketchForm7.Show();

            this.Hide();
            this.Dispose();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            SketchForm5 sketchForm5 = new SketchForm5();
            sketchForm5.FillParamsOnSketch(initialParameters, allParameters);

            sketchForm5.Location = this.Location;

            sketchForm5.Show();

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
