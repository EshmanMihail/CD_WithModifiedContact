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
        private DynamicTableManager tableManager;
        CalculationController controller;
        private List<InitialParameters> initParamsOfBearings;

        private IBearingRepository bearingRepository;
        private List<Control> inputControls = new List<Control>();

        private ControlHelper controlHelper;
        private RangeDisplayManager rangeDisplayManager;
        private InitialParameterRangeValidator rangeValidator;

        private bool isFilling = false;

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
                List<TabPage> tabPagesList = new List<TabPage> { tabPage2, tabPage3, tabPage4, tabPage5, tabPage6 };
                TablePresenter tablePresenter = new TablePresenter(tableManager, tabPagesList);

                var selectedItem = listViewBearingsName.SelectedItems[0];
                string selectedId = selectedItem.Tag.ToString();

                controller.CalculateAllParameters(GetInitialParameterObject(selectedId));

                tablePresenter.ShowResults(controller.GetListOfParameters());
            }
            else MessageBox.Show("Выберите подшипкик!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
