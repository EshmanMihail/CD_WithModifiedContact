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
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CD_WithModifiedContact
{
    public partial class MainForm : Form
    {
        private DynamicTableManager paramsTable;
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

        private bool isItemModified = false;
        private ListViewItem previousChosenItem = null;
        private string previousChosenItemId = "";


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

            processor = new GenericParameterProcessor();
            paramsTable = new DynamicTableManager();

            FillListView();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (listViewBearingsName.SelectedItems.Count > 0)
            {
                CalculateLayoutParameters();

                CalculateOuterRingParameters();

                CalculateRollerParameters();
            }
            else MessageBox.Show("Выберите подшипкик!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CalculateLayoutParameters()
        {
            layoutParameters = new LayoutParameters(chosenInitParams);

            layoutParameters.MessageHendler(ShowCalculationError);

            processor.ProcessParameters(layoutParameters);

            tabPage2.Controls.Clear();
            paramsTable.InitializeTabPageComponents(tabPage2);
            paramsTable.AddFormulasToTable(layoutParameters.GetFormulasInfo());
        }

        private void CalculateOuterRingParameters()
        {
            outerRingParameters = new OuterRingParameters(chosenInitParams, layoutParameters);

            outerRingParameters.MessageHendler(ShowCalculationError);
            
            processor.ProcessParameters(outerRingParameters);

            tabPage3.Controls.Clear();
            paramsTable.InitializeTabPageComponents(tabPage3);
            paramsTable.AddFormulasToTable(outerRingParameters.GetFormulasInfo());
        }

        private void CalculateRollerParameters()
        {
            rollerParameters = new RollerParameters(chosenInitParams, layoutParameters, outerRingParameters);

            rollerParameters.MessageHendler(ShowCalculationError);

            processor.ProcessParameters(rollerParameters);

            tabPage4.Controls.Clear();
            paramsTable.InitializeTabPageComponents(tabPage4);
            paramsTable.AddFormulasToTable(rollerParameters.GetFormulasInfo());
        }

        private void ShowCalculationError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
