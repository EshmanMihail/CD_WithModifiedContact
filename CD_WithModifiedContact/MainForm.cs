using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Helpers.Xml;
using CD_WithModifiedContact.Helpers.ParamsTableHelper;
using CD_WithModifiedContact.Helpers.LayoutParamsHelper;
using CD_Radial_Spherical_Roller_withAsymetricalRollers.Calculation;

namespace CD_WithModifiedContact
{
    public partial class MainForm : Form
    {
        private bool isFilling = false;

        private DynamicTableManager tableManager;
        private CalculationController controller;

        private List<InitialParameters> initParamsOfBearings;

        private IBearingRepository bearingRepository;
        private RangeDisplayManager rangeDisplayManager;
        private List<Control> inputControls = new List<Control>();

        private ControlHelper controlHelper;
        private InitialParameterRangeValidator rangeValidator;

        public MainForm()
        {
            InitializeComponent();

            rangeDisplayManager = new RangeDisplayManager();
            bearingRepository = new XmlBearingRepository(Constants.FullFilePath);

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;

            tableManager = new DynamicTableManager();
            controller = new CalculationController();

            tableManager.RecalculateRequested += (s, ev) => controller.RecanculationChangedValues();
            tableManager.RecalculateRequested += (s, ev) => ResetTableWithRecalculatedParameters();

            tableManager.SketchRequested += buttonSketch_Click;

            tableManager.ParameterValueChanged += controller.AddChangedParameter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComboBoxBeginValues();

            InitializeTextBoxEvents();

            AddInputControls();

            initParamsOfBearings = bearingRepository.GetAll();
             
            FillListView();
        }

        private void buttonCalculate_Click(object sender, EventArgs eventArgs)
        {
            if (listViewBearingsName.SelectedItems.Count > 0)
            {
                var selectedItem = listViewBearingsName.SelectedItems[0];
                string selectedId = selectedItem.Tag.ToString();

                controller.CalculateAllParameters(GetInitialParameterObject(selectedId));

                FillTableWithCalculatedParameters();
            }
            else ErrorHandler.ShowError("Выберите подшипкик!");
        }

        private void FillTableWithCalculatedParameters()
        {
            List<TabPage> tabPagesList = new List<TabPage> { tabPage2, tabPage3, tabPage4, tabPage5, tabPage6 };
            TablePresenter tablePresenter = new TablePresenter(tableManager, tabPagesList);

            if (controller != null) tablePresenter.ShowResults(controller.GetListOfParameters());
        }

        private void ResetTableWithRecalculatedParameters()
        {
            List<TabPage> tabPagesList = new List<TabPage> { tabPage2, tabPage3, tabPage4, tabPage5, tabPage6 };
            TablePresenter tablePresenter = new TablePresenter(tableManager, tabPagesList);

            if (controller != null) tablePresenter.ShowRecalculatedResults(controller.GetListOfParameters());
            MessageBox.Show("Перерасчёт завершён.");
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage page = tabControl.TabPages[e.Index];

           
            Color backColor = e.State.HasFlag(DrawItemState.Selected) // Цвет фона вкладки
                ? Color.AntiqueWhite   // активная вкладка
                : Color.LightSalmon;  // неактивная вкладка

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Цвет текста
            TextRenderer.DrawText(
                e.Graphics,
                page.Text,
                e.Font,
                e.Bounds,
                Color.Black,// цвет текста
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void buttonSketch_Click(object sender, EventArgs e)
        {
            SketchForm1 sketchForm1 = new SketchForm1();
            sketchForm1.Show();

            var selectedItem = listViewBearingsName.SelectedItems[0];
            string selectedId = selectedItem.Tag.ToString();
            sketchForm1.FillParamsOnSketch(GetInitialParameterObject(selectedId), controller.GetListOfParameters());
        }
    }
}
