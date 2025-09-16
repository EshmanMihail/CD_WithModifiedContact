using CD_Radial_Spherical_Roller_withAsymetricalRollers.Calculation;
using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Calculation.OuterRingParameters;
using CD_WithModifiedContact.Calculation.RollerParameters;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Helpers.LayoutParamsHelper;
using CD_WithModifiedContact.Helpers.Xml;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CD_WithModifiedContact
{
    public partial class MainForm : Form
    {
        private DynamicTableManager tableManager;
        private GenericParameterProcessor processor;

        private List<InitialParameters> initParamsOfBearings;
        private InitialParameters chosenInitParams;
        private LayoutParameters layoutParameters;
        private OuterRingParameters outerRingParameters;
        private RollerParameters rollerParameters;


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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComboBoxBeginValues();

            InitializeTextBoxEvents();

            AddInputControls();

            initParamsOfBearings = bearingRepository.GetAll();

            tableManager = new DynamicTableManager();

            FillListView();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (listViewBearingsName.SelectedItems.Count > 0)
            {
                var selectedItem = listViewBearingsName.SelectedItems[0];
                string selectedId = selectedItem.Tag.ToString();

                CalculationController controller = new CalculationController();
                //controller.CalculateAllParameters(chosenInitParams);
                controller.CalculateAllParameters(GetInitialParameterObject(selectedId));

                controller.ShowCalculatedParameters(tableManager, new List<TabPage> { tabPage2, tabPage3, tabPage4 });
            }
            else MessageBox.Show("Выберите подшипкик!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
