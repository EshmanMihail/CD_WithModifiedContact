namespace CD_WithModifiedContact
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelInitParams = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxBm = new System.Windows.Forms.TextBox();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.textBoxLambda = new System.Windows.Forms.TextBox();
            this.textBoxGr2 = new System.Windows.Forms.TextBox();
            this.textBoxGr1 = new System.Windows.Forms.TextBox();
            this.textBoxrsmin = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBox_d = new System.Windows.Forms.TextBox();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.textBoxAccuracyClass = new System.Windows.Forms.TextBox();
            this.textBoxBearingName = new System.Windows.Forms.TextBox();
            this.label_k = new System.Windows.Forms.Label();
            this.labelBm = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.labelX1 = new System.Windows.Forms.Label();
            this.labelLambda = new System.Windows.Forms.Label();
            this.labelGr2 = new System.Windows.Forms.Label();
            this.labelGr1 = new System.Windows.Forms.Label();
            this.labelrsmin = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.labelBrearing = new System.Windows.Forms.Label();
            this.labelAccuracyClass = new System.Windows.Forms.Label();
            this.label_d = new System.Windows.Forms.Label();
            this.comboBoxk = new System.Windows.Forms.ComboBox();
            this.groupBoxX1Ranger = new System.Windows.Forms.GroupBox();
            this.labelX1Range = new System.Windows.Forms.Label();
            this.groupBoxX2Range = new System.Windows.Forms.GroupBox();
            this.labelX2Range = new System.Windows.Forms.Label();
            this.groupBoxLambda = new System.Windows.Forms.GroupBox();
            this.comboBoxLambdaRange = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelBearings = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonChangeBearing = new System.Windows.Forms.Button();
            this.buttonDeleteBearing = new System.Windows.Forms.Button();
            this.buttonAddBearing = new System.Windows.Forms.Button();
            this.listViewBearingsName = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.errorProviderMainForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanelInitParams.SuspendLayout();
            this.groupBoxX1Ranger.SuspendLayout();
            this.groupBoxX2Range.SuspendLayout();
            this.groupBoxLambda.SuspendLayout();
            this.flowLayoutPanelBearings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMainForm)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1504, 736);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tabPage1.Controls.Add(this.tableLayoutPanelInitParams);
            this.tabPage1.Controls.Add(this.flowLayoutPanelBearings);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1496, 710);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Исходные параметры";
            // 
            // tableLayoutPanelInitParams
            // 
            this.tableLayoutPanelInitParams.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelInitParams.ColumnCount = 3;
            this.tableLayoutPanelInitParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelInitParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelInitParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxBm, 1, 11);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxX2, 1, 10);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxX1, 1, 9);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxLambda, 1, 8);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxGr2, 1, 7);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxGr1, 1, 6);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxrsmin, 1, 5);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxB, 1, 4);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBox_d, 1, 3);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxD, 1, 2);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxAccuracyClass, 1, 1);
            this.tableLayoutPanelInitParams.Controls.Add(this.textBoxBearingName, 1, 0);
            this.tableLayoutPanelInitParams.Controls.Add(this.label_k, 0, 12);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelBm, 0, 11);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelX2, 0, 10);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelX1, 0, 9);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelLambda, 0, 8);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelGr2, 0, 7);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelGr1, 0, 6);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelrsmin, 0, 5);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelB, 0, 4);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelD, 0, 2);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelBrearing, 0, 0);
            this.tableLayoutPanelInitParams.Controls.Add(this.labelAccuracyClass, 0, 1);
            this.tableLayoutPanelInitParams.Controls.Add(this.label_d, 0, 3);
            this.tableLayoutPanelInitParams.Controls.Add(this.comboBoxk, 1, 12);
            this.tableLayoutPanelInitParams.Controls.Add(this.groupBoxX1Ranger, 2, 9);
            this.tableLayoutPanelInitParams.Controls.Add(this.groupBoxX2Range, 2, 10);
            this.tableLayoutPanelInitParams.Controls.Add(this.groupBoxLambda, 2, 8);
            this.tableLayoutPanelInitParams.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanelInitParams.Location = new System.Drawing.Point(250, 0);
            this.tableLayoutPanelInitParams.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelInitParams.Name = "tableLayoutPanelInitParams";
            this.tableLayoutPanelInitParams.RowCount = 13;
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.690177F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692485F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692486F));
            this.tableLayoutPanelInitParams.Size = new System.Drawing.Size(996, 710);
            this.tableLayoutPanelInitParams.TabIndex = 2;
            // 
            // textBoxBm
            // 
            this.textBoxBm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxBm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBm.Location = new System.Drawing.Point(420, 606);
            this.textBoxBm.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxBm.Name = "textBoxBm";
            this.textBoxBm.Size = new System.Drawing.Size(280, 31);
            this.textBoxBm.TabIndex = 26;
            this.textBoxBm.Text = "1,15";
            this.textBoxBm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxX2
            // 
            this.textBoxX2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxX2.Location = new System.Drawing.Point(420, 552);
            this.textBoxX2.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(280, 31);
            this.textBoxX2.TabIndex = 25;
            this.textBoxX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxX1
            // 
            this.textBoxX1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxX1.Location = new System.Drawing.Point(420, 498);
            this.textBoxX1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(280, 31);
            this.textBoxX1.TabIndex = 24;
            this.textBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLambda
            // 
            this.textBoxLambda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLambda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLambda.Location = new System.Drawing.Point(420, 444);
            this.textBoxLambda.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxLambda.Name = "textBoxLambda";
            this.textBoxLambda.Size = new System.Drawing.Size(280, 31);
            this.textBoxLambda.TabIndex = 23;
            this.textBoxLambda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxGr2
            // 
            this.textBoxGr2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxGr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxGr2.Location = new System.Drawing.Point(420, 390);
            this.textBoxGr2.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxGr2.Name = "textBoxGr2";
            this.textBoxGr2.Size = new System.Drawing.Size(280, 31);
            this.textBoxGr2.TabIndex = 22;
            this.textBoxGr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxGr1
            // 
            this.textBoxGr1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxGr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxGr1.Location = new System.Drawing.Point(420, 336);
            this.textBoxGr1.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxGr1.Name = "textBoxGr1";
            this.textBoxGr1.Size = new System.Drawing.Size(280, 31);
            this.textBoxGr1.TabIndex = 21;
            this.textBoxGr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxrsmin
            // 
            this.textBoxrsmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxrsmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxrsmin.Location = new System.Drawing.Point(420, 282);
            this.textBoxrsmin.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxrsmin.Name = "textBoxrsmin";
            this.textBoxrsmin.Size = new System.Drawing.Size(280, 31);
            this.textBoxrsmin.TabIndex = 20;
            this.textBoxrsmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxB
            // 
            this.textBoxB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxB.Location = new System.Drawing.Point(420, 228);
            this.textBoxB.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(280, 31);
            this.textBoxB.TabIndex = 19;
            this.textBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_d
            // 
            this.textBox_d.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_d.Location = new System.Drawing.Point(420, 174);
            this.textBox_d.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_d.Name = "textBox_d";
            this.textBox_d.Size = new System.Drawing.Size(280, 31);
            this.textBox_d.TabIndex = 18;
            this.textBox_d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxD
            // 
            this.textBoxD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxD.Location = new System.Drawing.Point(420, 120);
            this.textBoxD.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(280, 31);
            this.textBoxD.TabIndex = 17;
            this.textBoxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAccuracyClass
            // 
            this.textBoxAccuracyClass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAccuracyClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAccuracyClass.Location = new System.Drawing.Point(420, 66);
            this.textBoxAccuracyClass.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxAccuracyClass.Name = "textBoxAccuracyClass";
            this.textBoxAccuracyClass.Size = new System.Drawing.Size(280, 31);
            this.textBoxAccuracyClass.TabIndex = 16;
            this.textBoxAccuracyClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxBearingName
            // 
            this.textBoxBearingName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxBearingName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBearingName.Location = new System.Drawing.Point(420, 12);
            this.textBoxBearingName.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxBearingName.Name = "textBoxBearingName";
            this.textBoxBearingName.Size = new System.Drawing.Size(280, 31);
            this.textBoxBearingName.TabIndex = 15;
            this.textBoxBearingName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_k
            // 
            this.label_k.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_k.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_k.Location = new System.Drawing.Point(1, 649);
            this.label_k.Margin = new System.Windows.Forms.Padding(0);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(418, 60);
            this.label_k.TabIndex = 13;
            this.label_k.Text = "Конусность k";
            this.label_k.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBm
            // 
            this.labelBm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBm.Location = new System.Drawing.Point(1, 595);
            this.labelBm.Margin = new System.Windows.Forms.Padding(0);
            this.labelBm.Name = "labelBm";
            this.labelBm.Size = new System.Drawing.Size(418, 53);
            this.labelBm.TabIndex = 11;
            this.labelBm.Text = "Коэффициент Bm";
            this.labelBm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX2
            // 
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX2.Location = new System.Drawing.Point(1, 541);
            this.labelX2.Margin = new System.Windows.Forms.Padding(0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(418, 53);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "Расстоние от центра до края ролика X2";
            this.labelX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX1
            // 
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX1.Location = new System.Drawing.Point(1, 487);
            this.labelX1.Margin = new System.Windows.Forms.Padding(0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(418, 53);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "Половина ширины среднего бортика X1";
            this.labelX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLambda
            // 
            this.labelLambda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLambda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLambda.Location = new System.Drawing.Point(1, 433);
            this.labelLambda.Margin = new System.Windows.Forms.Padding(0);
            this.labelLambda.Name = "labelLambda";
            this.labelLambda.Size = new System.Drawing.Size(418, 53);
            this.labelLambda.TabIndex = 8;
            this.labelLambda.Text = "Лн = Лв";
            this.labelLambda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGr2
            // 
            this.labelGr2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGr2.Location = new System.Drawing.Point(1, 379);
            this.labelGr2.Margin = new System.Windows.Forms.Padding(0);
            this.labelGr2.Name = "labelGr2";
            this.labelGr2.Size = new System.Drawing.Size(418, 53);
            this.labelGr2.TabIndex = 7;
            this.labelGr2.Text = "Размер зазора Gr2 наиб.";
            this.labelGr2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGr1
            // 
            this.labelGr1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGr1.Location = new System.Drawing.Point(1, 325);
            this.labelGr1.Margin = new System.Windows.Forms.Padding(0);
            this.labelGr1.Name = "labelGr1";
            this.labelGr1.Size = new System.Drawing.Size(418, 53);
            this.labelGr1.TabIndex = 6;
            this.labelGr1.Text = "Размер зазора Gr1 наим.";
            this.labelGr1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelrsmin
            // 
            this.labelrsmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelrsmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelrsmin.Location = new System.Drawing.Point(1, 271);
            this.labelrsmin.Margin = new System.Windows.Forms.Padding(0);
            this.labelrsmin.Name = "labelrsmin";
            this.labelrsmin.Size = new System.Drawing.Size(418, 53);
            this.labelrsmin.TabIndex = 5;
            this.labelrsmin.Text = "размер монтажной фаски rsmin";
            this.labelrsmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelB
            // 
            this.labelB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelB.Location = new System.Drawing.Point(1, 217);
            this.labelB.Margin = new System.Windows.Forms.Padding(0);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(418, 53);
            this.labelB.TabIndex = 4;
            this.labelB.Text = "Ширина внутр. кольца B";
            this.labelB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelD
            // 
            this.labelD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelD.Location = new System.Drawing.Point(1, 109);
            this.labelD.Margin = new System.Windows.Forms.Padding(0);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(418, 53);
            this.labelD.TabIndex = 2;
            this.labelD.Text = "Наружный диаметр D";
            this.labelD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBrearing
            // 
            this.labelBrearing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBrearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBrearing.Location = new System.Drawing.Point(1, 1);
            this.labelBrearing.Margin = new System.Windows.Forms.Padding(0);
            this.labelBrearing.Name = "labelBrearing";
            this.labelBrearing.Size = new System.Drawing.Size(418, 53);
            this.labelBrearing.TabIndex = 0;
            this.labelBrearing.Text = "Обозначение подшипника";
            this.labelBrearing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAccuracyClass
            // 
            this.labelAccuracyClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAccuracyClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccuracyClass.Location = new System.Drawing.Point(1, 55);
            this.labelAccuracyClass.Margin = new System.Windows.Forms.Padding(0);
            this.labelAccuracyClass.Name = "labelAccuracyClass";
            this.labelAccuracyClass.Size = new System.Drawing.Size(418, 53);
            this.labelAccuracyClass.TabIndex = 1;
            this.labelAccuracyClass.Text = "Класс точности";
            this.labelAccuracyClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_d
            // 
            this.label_d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_d.Location = new System.Drawing.Point(1, 163);
            this.label_d.Margin = new System.Windows.Forms.Padding(0);
            this.label_d.Name = "label_d";
            this.label_d.Size = new System.Drawing.Size(418, 53);
            this.label_d.TabIndex = 3;
            this.label_d.Text = "Диаметр отверстия d";
            this.label_d.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxk
            // 
            this.comboBoxk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxk.FormattingEnabled = true;
            this.comboBoxk.Items.AddRange(new object[] {
            "0",
            "1:12",
            "1:30"});
            this.comboBoxk.Location = new System.Drawing.Point(420, 662);
            this.comboBoxk.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxk.Name = "comboBoxk";
            this.comboBoxk.Size = new System.Drawing.Size(280, 33);
            this.comboBoxk.TabIndex = 12;
            // 
            // groupBoxX1Ranger
            // 
            this.groupBoxX1Ranger.Controls.Add(this.labelX1Range);
            this.groupBoxX1Ranger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxX1Ranger.Location = new System.Drawing.Point(701, 487);
            this.groupBoxX1Ranger.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxX1Ranger.Name = "groupBoxX1Ranger";
            this.groupBoxX1Ranger.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxX1Ranger.Size = new System.Drawing.Size(294, 53);
            this.groupBoxX1Ranger.TabIndex = 28;
            this.groupBoxX1Ranger.TabStop = false;
            this.groupBoxX1Ranger.Text = "диапазон";
            // 
            // labelX1Range
            // 
            this.labelX1Range.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX1Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX1Range.Location = new System.Drawing.Point(0, 13);
            this.labelX1Range.Margin = new System.Windows.Forms.Padding(0);
            this.labelX1Range.Name = "labelX1Range";
            this.labelX1Range.Size = new System.Drawing.Size(294, 40);
            this.labelX1Range.TabIndex = 1;
            this.labelX1Range.Text = "0,52...1,25";
            this.labelX1Range.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxX2Range
            // 
            this.groupBoxX2Range.Controls.Add(this.labelX2Range);
            this.groupBoxX2Range.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxX2Range.Location = new System.Drawing.Point(701, 541);
            this.groupBoxX2Range.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxX2Range.Name = "groupBoxX2Range";
            this.groupBoxX2Range.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxX2Range.Size = new System.Drawing.Size(294, 53);
            this.groupBoxX2Range.TabIndex = 29;
            this.groupBoxX2Range.TabStop = false;
            this.groupBoxX2Range.Text = "диапазон";
            // 
            // labelX2Range
            // 
            this.labelX2Range.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX2Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX2Range.Location = new System.Drawing.Point(0, 13);
            this.labelX2Range.Margin = new System.Windows.Forms.Padding(0);
            this.labelX2Range.Name = "labelX2Range";
            this.labelX2Range.Size = new System.Drawing.Size(294, 40);
            this.labelX2Range.TabIndex = 1;
            this.labelX2Range.Text = "0,44...0,51";
            this.labelX2Range.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxLambda
            // 
            this.groupBoxLambda.Controls.Add(this.comboBoxLambdaRange);
            this.groupBoxLambda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLambda.Location = new System.Drawing.Point(701, 433);
            this.groupBoxLambda.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxLambda.Name = "groupBoxLambda";
            this.groupBoxLambda.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxLambda.Size = new System.Drawing.Size(294, 53);
            this.groupBoxLambda.TabIndex = 30;
            this.groupBoxLambda.TabStop = false;
            this.groupBoxLambda.Text = "выберите диапазон";
            // 
            // comboBoxLambdaRange
            // 
            this.comboBoxLambdaRange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxLambdaRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxLambdaRange.FormattingEnabled = true;
            this.comboBoxLambdaRange.Items.AddRange(new object[] {
            "1,0...1,2",
            "0,9...1,5"});
            this.comboBoxLambdaRange.Location = new System.Drawing.Point(7, 16);
            this.comboBoxLambdaRange.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxLambdaRange.Name = "comboBoxLambdaRange";
            this.comboBoxLambdaRange.Size = new System.Drawing.Size(280, 33);
            this.comboBoxLambdaRange.TabIndex = 27;
            // 
            // flowLayoutPanelBearings
            // 
            this.flowLayoutPanelBearings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelBearings.Controls.Add(this.buttonCalculate);
            this.flowLayoutPanelBearings.Controls.Add(this.buttonChangeBearing);
            this.flowLayoutPanelBearings.Controls.Add(this.buttonDeleteBearing);
            this.flowLayoutPanelBearings.Controls.Add(this.buttonAddBearing);
            this.flowLayoutPanelBearings.Controls.Add(this.listViewBearingsName);
            this.flowLayoutPanelBearings.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelBearings.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelBearings.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelBearings.Name = "flowLayoutPanelBearings";
            this.flowLayoutPanelBearings.Size = new System.Drawing.Size(250, 710);
            this.flowLayoutPanelBearings.TabIndex = 0;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.BackColor = System.Drawing.Color.LightGreen;
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalculate.Location = new System.Drawing.Point(40, 3);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(160, 78);
            this.buttonCalculate.TabIndex = 6;
            this.buttonCalculate.Text = "Рассчитать🧮 ";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonChangeBearing
            // 
            this.buttonChangeBearing.BackColor = System.Drawing.Color.LightBlue;
            this.buttonChangeBearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeBearing.Location = new System.Drawing.Point(40, 87);
            this.buttonChangeBearing.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.buttonChangeBearing.Name = "buttonChangeBearing";
            this.buttonChangeBearing.Size = new System.Drawing.Size(160, 50);
            this.buttonChangeBearing.TabIndex = 4;
            this.buttonChangeBearing.Text = "Сохранть✔️";
            this.buttonChangeBearing.UseVisualStyleBackColor = false;
            this.buttonChangeBearing.Click += new System.EventHandler(this.buttonChangeBearing_Click);
            // 
            // buttonDeleteBearing
            // 
            this.buttonDeleteBearing.BackColor = System.Drawing.Color.Firebrick;
            this.buttonDeleteBearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteBearing.Location = new System.Drawing.Point(40, 143);
            this.buttonDeleteBearing.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.buttonDeleteBearing.Name = "buttonDeleteBearing";
            this.buttonDeleteBearing.Size = new System.Drawing.Size(160, 50);
            this.buttonDeleteBearing.TabIndex = 5;
            this.buttonDeleteBearing.Text = "Удалить❌";
            this.buttonDeleteBearing.UseVisualStyleBackColor = false;
            this.buttonDeleteBearing.Click += new System.EventHandler(this.buttonDeleteBearing_Click);
            // 
            // buttonAddBearing
            // 
            this.buttonAddBearing.BackColor = System.Drawing.Color.Coral;
            this.buttonAddBearing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddBearing.Location = new System.Drawing.Point(40, 199);
            this.buttonAddBearing.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.buttonAddBearing.Name = "buttonAddBearing";
            this.buttonAddBearing.Size = new System.Drawing.Size(160, 50);
            this.buttonAddBearing.TabIndex = 3;
            this.buttonAddBearing.Text = "добавить✚";
            this.buttonAddBearing.UseVisualStyleBackColor = false;
            this.buttonAddBearing.Click += new System.EventHandler(this.buttonAddBearing_Click);
            // 
            // listViewBearingsName
            // 
            this.listViewBearingsName.BackColor = System.Drawing.Color.LightSalmon;
            this.listViewBearingsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewBearingsName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewBearingsName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listViewBearingsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listViewBearingsName.GridLines = true;
            this.listViewBearingsName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBearingsName.HideSelection = false;
            this.listViewBearingsName.Location = new System.Drawing.Point(0, 252);
            this.listViewBearingsName.Margin = new System.Windows.Forms.Padding(0);
            this.listViewBearingsName.MultiSelect = false;
            this.listViewBearingsName.Name = "listViewBearingsName";
            this.listViewBearingsName.Size = new System.Drawing.Size(250, 704);
            this.listViewBearingsName.TabIndex = 0;
            this.listViewBearingsName.UseCompatibleStateImageBehavior = false;
            this.listViewBearingsName.View = System.Windows.Forms.View.Details;
            this.listViewBearingsName.SelectedIndexChanged += new System.EventHandler(this.listViewBearingsName_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Обозначения";
            this.columnHeader1.Width = 250;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1496, 710);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Компанованный расчёт";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1496, 710);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Расчёт наружного кольца";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1496, 710);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Расчёт ролика";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1496, 710);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Расчёт внутреннего кольца";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1496, 710);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Расчёт сепаратора";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // errorProviderMainForm
            // 
            this.errorProviderMainForm.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 736);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "подшипники роликовые радиальные сферические двухрядные с несимметричными роликами" +
    " с модифицированным контактом";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanelInitParams.ResumeLayout(false);
            this.tableLayoutPanelInitParams.PerformLayout();
            this.groupBoxX1Ranger.ResumeLayout(false);
            this.groupBoxX2Range.ResumeLayout(false);
            this.groupBoxLambda.ResumeLayout(false);
            this.flowLayoutPanelBearings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMainForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBearings;
        private System.Windows.Forms.Label labelBrearing;
        private System.Windows.Forms.Label labelAccuracyClass;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label label_d;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelrsmin;
        private System.Windows.Forms.Label labelGr1;
        private System.Windows.Forms.Label labelGr2;
        private System.Windows.Forms.Label labelLambda;
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.Label labelBm;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_k;
        private System.Windows.Forms.ComboBox comboBoxk;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxBearingName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInitParams;
        private System.Windows.Forms.TextBox textBoxBm;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.TextBox textBoxLambda;
        private System.Windows.Forms.TextBox textBoxGr2;
        private System.Windows.Forms.TextBox textBoxGr1;
        private System.Windows.Forms.TextBox textBoxrsmin;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBox_d;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.TextBox textBoxAccuracyClass;
        private System.Windows.Forms.ListView listViewBearingsName;
        private System.Windows.Forms.Button buttonAddBearing;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBoxX1Ranger;
        private System.Windows.Forms.Label labelX1Range;
        private System.Windows.Forms.GroupBox groupBoxX2Range;
        private System.Windows.Forms.Label labelX2Range;
        private System.Windows.Forms.GroupBox groupBoxLambda;
        private System.Windows.Forms.ComboBox comboBoxLambdaRange;
        private System.Windows.Forms.ErrorProvider errorProviderMainForm;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonChangeBearing;
        private System.Windows.Forms.Button buttonDeleteBearing;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
    }
}

