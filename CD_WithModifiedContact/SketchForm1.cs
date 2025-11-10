using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Helpers.SketchRenderHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CD_WithModifiedContact
{
    public partial class SketchForm1 : Form
    {
        private InitialParameters initialParameters;
        private List<Parameters> allParameters;

        List<TextItem> textItems;

        public SketchForm1()
        {
            InitializeComponent();
            textItems = new List<TextItem>();
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

                    if (f.Notation == FormulaSymbols.b1)
                    { 
                        labelb1.Text = f.Result.ToString();
                        AddTextItemToList(f.Result.ToString(), labelb1.Location);
                    }
                    if (f.Notation == FormulaSymbols.d0)
                    {
                        labeld0.Text = f.Result.ToString();
                        AddTextItemToList(f.Result.ToString(), labeld0.Location);
                    }
                    if (f.Notation == FormulaSymbols.alpha0)
                    {
                        string angle = ParameterRounder.RoundAngleToSeconds((double)f.Result).ToString();
                        labelalpha0.Text = angle;
                        AddTextItemToList(angle, labelalpha0.Location);
                    }
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

            AddTextItemToList(initialParameters.B.ToString(), label_B.Location);
            AddTextItemToList(initialParameters.D.ToString(), label_D.Location);
            AddTextItemToList(initialParameters.d.ToString(), labeld.Location);

            AddTextItemToList(initialParameters.r_s_min.ToString(), labelRsmin1.Location);
            AddTextItemToList(initialParameters.r_s_min.ToString(), labelRsmin2.Location);
            AddTextItemToList(initialParameters.r_s_min.ToString(), labelRsmin3.Location);

            AddTextItemToList(initialParameters.r_s_min.ToString(), labelRsminV1.Location, true);
            AddTextItemToList(initialParameters.r_s_min.ToString(), labelRsminV2.Location, true);
            AddTextItemToList(initialParameters.r_s_min.ToString(), labelRsminV3.Location, true);
        }

        private void AddTextItemToList(string textValue, Point point, bool isVertical = false)
        {
            textItems.Add(new TextItem
            {
                Text = isVertical ? ToVertical(textValue) : textValue,
                Position = point,
                Font = new Font("Arial", 14, FontStyle.Bold)
            });
        }

        private string ToVertical(string strValue)
        {
            string result = "";
            for (int i = 0; i < strValue.Length; i++)
            {
                if (strValue[i] == ',') result += strValue[i];
                else result += strValue[i] + "\n";
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
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Сохранить эскиз",
                Filter = "JPEG Image|*.jpg",
                DefaultExt = "jpg",
                FileName = "Page1_output.jpg"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SketchRenderer renderer = new SketchRenderer();
                renderer.RenderSketch(1, saveFileDialog.FileName, textItems);
                MessageBox.Show("Эскиз сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
