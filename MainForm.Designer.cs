namespace WallRail2025
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OkApplyModifyGetOnOffCancel = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ParametersTabPage = new System.Windows.Forms.TabPage();
            this.materialCatalog1 = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
            this.label13 = new System.Windows.Forms.Label();
            this.FinishBox = new System.Windows.Forms.TextBox();
            this.ClassBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.MaterialCatalog = new Tekla.Structures.Dialog.UIControls.MaterialCatalog();
            this.SelectedMaterialBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SelectedProfileBox = new System.Windows.Forms.TextBox();
            this.ProfileCatalog = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.RailGeometryType = new System.Windows.Forms.TextBox();
            this.Straight = new System.Windows.Forms.RadioButton();
            this.Leveled = new System.Windows.Forms.RadioButton();
            this.RailOffset = new System.Windows.Forms.TextBox();
            this.TopReturnLength = new System.Windows.Forms.TextBox();
            this.BottomReturnLength = new System.Windows.Forms.TextBox();
            this.TopExtension = new System.Windows.Forms.TextBox();
            this.BottomExtension = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TopHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SlopedHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BottomHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.saveLoad = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ParametersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel, null);
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.OkApplyModifyGetOnOffCancel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.saveLoad, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(1306, 1091);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // OkApplyModifyGetOnOffCancel
            // 
            this.structuresExtender.SetAttributeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetAttributeTypeName(this.OkApplyModifyGetOnOffCancel, null);
            this.structuresExtender.SetBindPropertyName(this.OkApplyModifyGetOnOffCancel, null);
            this.OkApplyModifyGetOnOffCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkApplyModifyGetOnOffCancel.Location = new System.Drawing.Point(11, 1026);
            this.OkApplyModifyGetOnOffCancel.Margin = new System.Windows.Forms.Padding(11);
            this.OkApplyModifyGetOnOffCancel.Name = "OkApplyModifyGetOnOffCancel";
            this.OkApplyModifyGetOnOffCancel.Size = new System.Drawing.Size(1284, 54);
            this.OkApplyModifyGetOnOffCancel.TabIndex = 19;
            this.OkApplyModifyGetOnOffCancel.OkClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_OkClicked);
            this.OkApplyModifyGetOnOffCancel.ApplyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ApplyClicked);
            this.OkApplyModifyGetOnOffCancel.ModifyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_ModifyClicked);
            this.OkApplyModifyGetOnOffCancel.GetClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_GetClicked);
            this.OkApplyModifyGetOnOffCancel.OnOffClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_OnOffClicked);
            this.OkApplyModifyGetOnOffCancel.CancelClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel_CancelClicked);
            // 
            // tabControl
            // 
            this.structuresExtender.SetAttributeName(this.tabControl, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl, null);
            this.tabControl.Controls.Add(this.ParametersTabPage);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(6, 107);
            this.tabControl.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1294, 902);
            this.tabControl.TabIndex = 18;
            // 
            // ParametersTabPage
            // 
            this.structuresExtender.SetAttributeName(this.ParametersTabPage, null);
            this.structuresExtender.SetAttributeTypeName(this.ParametersTabPage, null);
            this.structuresExtender.SetBindPropertyName(this.ParametersTabPage, null);
            this.ParametersTabPage.Controls.Add(this.materialCatalog1);
            this.ParametersTabPage.Controls.Add(this.label13);
            this.ParametersTabPage.Controls.Add(this.FinishBox);
            this.ParametersTabPage.Controls.Add(this.ClassBox);
            this.ParametersTabPage.Controls.Add(this.label12);
            this.ParametersTabPage.Controls.Add(this.NameBox);
            this.ParametersTabPage.Controls.Add(this.label11);
            this.ParametersTabPage.Controls.Add(this.MaterialCatalog);
            this.ParametersTabPage.Controls.Add(this.SelectedMaterialBox);
            this.ParametersTabPage.Controls.Add(this.label10);
            this.ParametersTabPage.Controls.Add(this.label9);
            this.ParametersTabPage.Controls.Add(this.SelectedProfileBox);
            this.ParametersTabPage.Controls.Add(this.ProfileCatalog);
            this.ParametersTabPage.Controls.Add(this.RailGeometryType);
            this.ParametersTabPage.Controls.Add(this.Straight);
            this.ParametersTabPage.Controls.Add(this.Leveled);
            this.ParametersTabPage.Controls.Add(this.RailOffset);
            this.ParametersTabPage.Controls.Add(this.TopReturnLength);
            this.ParametersTabPage.Controls.Add(this.BottomReturnLength);
            this.ParametersTabPage.Controls.Add(this.TopExtension);
            this.ParametersTabPage.Controls.Add(this.BottomExtension);
            this.ParametersTabPage.Controls.Add(this.label8);
            this.ParametersTabPage.Controls.Add(this.label7);
            this.ParametersTabPage.Controls.Add(this.label6);
            this.ParametersTabPage.Controls.Add(this.label5);
            this.ParametersTabPage.Controls.Add(this.label4);
            this.ParametersTabPage.Controls.Add(this.TopHeight);
            this.ParametersTabPage.Controls.Add(this.label3);
            this.ParametersTabPage.Controls.Add(this.SlopedHeight);
            this.ParametersTabPage.Controls.Add(this.label2);
            this.ParametersTabPage.Controls.Add(this.BottomHeight);
            this.ParametersTabPage.Controls.Add(this.label1);
            this.ParametersTabPage.Controls.Add(this.pictureBox1);
            this.ParametersTabPage.Location = new System.Drawing.Point(4, 33);
            this.ParametersTabPage.Margin = new System.Windows.Forms.Padding(6);
            this.ParametersTabPage.Name = "ParametersTabPage";
            this.ParametersTabPage.Padding = new System.Windows.Forms.Padding(6);
            this.ParametersTabPage.Size = new System.Drawing.Size(1286, 865);
            this.ParametersTabPage.TabIndex = 2;
            this.ParametersTabPage.Text = "Rail";
            this.ParametersTabPage.UseVisualStyleBackColor = true;
            this.ParametersTabPage.Click += new System.EventHandler(this.ParametersTabPage_Click);
            // 
            // materialCatalog1
            // 
            this.structuresExtender.SetAttributeName(this.materialCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.materialCatalog1, null);
            this.materialCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.materialCatalog1, null);
            this.materialCatalog1.ButtonText = "albl_Select__";
            this.materialCatalog1.Location = new System.Drawing.Point(336, 497);
            this.materialCatalog1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.materialCatalog1.Name = "materialCatalog1";
            this.materialCatalog1.SelectedMaterial = "";
            this.materialCatalog1.Size = new System.Drawing.Size(161, 50);
            this.materialCatalog1.TabIndex = 32;
            // 
            // label13
            // 
            this.structuresExtender.SetAttributeName(this.label13, null);
            this.structuresExtender.SetAttributeTypeName(this.label13, null);
            this.label13.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label13, null);
            this.label13.Location = new System.Drawing.Point(266, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 25);
            this.label13.TabIndex = 31;
            this.label13.Text = "Finish";
            // 
            // FinishBox
            // 
            this.structuresExtender.SetAttributeName(this.FinishBox, "FinishBox");
            this.structuresExtender.SetAttributeTypeName(this.FinishBox, "String");
            this.structuresExtender.SetBindPropertyName(this.FinishBox, "Text");
            this.FinishBox.Location = new System.Drawing.Point(271, 393);
            this.FinishBox.Name = "FinishBox";
            this.FinishBox.Size = new System.Drawing.Size(226, 29);
            this.FinishBox.TabIndex = 30;
            // 
            // ClassBox
            // 
            this.structuresExtender.SetAttributeName(this.ClassBox, "ClassBox");
            this.structuresExtender.SetAttributeTypeName(this.ClassBox, "Integer");
            this.structuresExtender.SetBindPropertyName(this.ClassBox, "Text");
            this.ClassBox.Location = new System.Drawing.Point(271, 319);
            this.ClassBox.Name = "ClassBox";
            this.ClassBox.Size = new System.Drawing.Size(226, 29);
            this.ClassBox.TabIndex = 29;
            // 
            // label12
            // 
            this.structuresExtender.SetAttributeName(this.label12, null);
            this.structuresExtender.SetAttributeTypeName(this.label12, null);
            this.label12.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label12, null);
            this.label12.Location = new System.Drawing.Point(266, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 25);
            this.label12.TabIndex = 28;
            this.label12.Text = "Class";
            // 
            // NameBox
            // 
            this.structuresExtender.SetAttributeName(this.NameBox, "NameBox");
            this.structuresExtender.SetAttributeTypeName(this.NameBox, "String");
            this.structuresExtender.SetBindPropertyName(this.NameBox, "Text");
            this.NameBox.Location = new System.Drawing.Point(271, 240);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(226, 29);
            this.NameBox.TabIndex = 27;
            // 
            // label11
            // 
            this.structuresExtender.SetAttributeName(this.label11, null);
            this.structuresExtender.SetAttributeTypeName(this.label11, null);
            this.label11.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label11, null);
            this.label11.Location = new System.Drawing.Point(266, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 25);
            this.label11.TabIndex = 26;
            this.label11.Text = "Name";
            // 
            // MaterialCatalog
            // 
            this.structuresExtender.SetAttributeName(this.MaterialCatalog, "MaterialCatalog");
            this.structuresExtender.SetAttributeTypeName(this.MaterialCatalog, "String");
            this.MaterialCatalog.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.MaterialCatalog, "Text");
            this.MaterialCatalog.ButtonText = "...";
            this.MaterialCatalog.Location = new System.Drawing.Point(506, 161);
            this.MaterialCatalog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaterialCatalog.Name = "MaterialCatalog";
            this.MaterialCatalog.SelectedMaterial = "";
            this.MaterialCatalog.Size = new System.Drawing.Size(51, 29);
            this.MaterialCatalog.TabIndex = 25;
            this.MaterialCatalog.SelectClicked += new System.EventHandler(this.MaterialCatalog_SelectClicked);
            this.MaterialCatalog.SelectionDone += new System.EventHandler(this.MaterialCatalog_SelectionDone);
            // 
            // SelectedMaterialBox
            // 
            this.structuresExtender.SetAttributeName(this.SelectedMaterialBox, "SelectedMaterialBox");
            this.structuresExtender.SetAttributeTypeName(this.SelectedMaterialBox, "String");
            this.structuresExtender.SetBindPropertyName(this.SelectedMaterialBox, "Text");
            this.SelectedMaterialBox.Location = new System.Drawing.Point(271, 161);
            this.SelectedMaterialBox.Name = "SelectedMaterialBox";
            this.SelectedMaterialBox.Size = new System.Drawing.Size(226, 29);
            this.SelectedMaterialBox.TabIndex = 24;
            // 
            // label10
            // 
            this.structuresExtender.SetAttributeName(this.label10, null);
            this.structuresExtender.SetAttributeTypeName(this.label10, null);
            this.label10.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label10, null);
            this.label10.Location = new System.Drawing.Point(266, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "Material";
            // 
            // label9
            // 
            this.structuresExtender.SetAttributeName(this.label9, null);
            this.structuresExtender.SetAttributeTypeName(this.label9, null);
            this.label9.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label9, null);
            this.label9.Location = new System.Drawing.Point(266, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Profile";
            // 
            // SelectedProfileBox
            // 
            this.structuresExtender.SetAttributeName(this.SelectedProfileBox, "SelectedProfileBox");
            this.structuresExtender.SetAttributeTypeName(this.SelectedProfileBox, "String");
            this.structuresExtender.SetBindPropertyName(this.SelectedProfileBox, "Text");
            this.SelectedProfileBox.Location = new System.Drawing.Point(271, 85);
            this.SelectedProfileBox.Name = "SelectedProfileBox";
            this.SelectedProfileBox.Size = new System.Drawing.Size(226, 29);
            this.SelectedProfileBox.TabIndex = 21;
            // 
            // ProfileCatalog
            // 
            this.structuresExtender.SetAttributeName(this.ProfileCatalog, null);
            this.structuresExtender.SetAttributeTypeName(this.ProfileCatalog, null);
            this.ProfileCatalog.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.ProfileCatalog, null);
            this.ProfileCatalog.ButtonText = "...";
            this.ProfileCatalog.Location = new System.Drawing.Point(506, 85);
            this.ProfileCatalog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ProfileCatalog.Name = "ProfileCatalog";
            this.ProfileCatalog.SelectedProfile = "";
            this.ProfileCatalog.Size = new System.Drawing.Size(51, 29);
            this.ProfileCatalog.TabIndex = 20;
            this.ProfileCatalog.SelectClicked += new System.EventHandler(this.ProfileCatalog_SelectClicked);
            this.ProfileCatalog.SelectionDone += new System.EventHandler(this.ProfileCatalog_SelectionDone);
            // 
            // RailGeometryType
            // 
            this.structuresExtender.SetAttributeName(this.RailGeometryType, "RailGeometryType");
            this.structuresExtender.SetAttributeTypeName(this.RailGeometryType, "String");
            this.structuresExtender.SetBindPropertyName(this.RailGeometryType, "Text");
            this.RailGeometryType.Location = new System.Drawing.Point(182, 681);
            this.RailGeometryType.Margin = new System.Windows.Forms.Padding(6);
            this.RailGeometryType.Name = "RailGeometryType";
            this.RailGeometryType.Size = new System.Drawing.Size(57, 29);
            this.RailGeometryType.TabIndex = 19;
            this.RailGeometryType.Visible = false;
            this.RailGeometryType.TextChanged += new System.EventHandler(this.RailGeometryType_TextChanged);
            // 
            // Straight
            // 
            this.structuresExtender.SetAttributeName(this.Straight, null);
            this.structuresExtender.SetAttributeTypeName(this.Straight, null);
            this.Straight.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.Straight, null);
            this.Straight.Location = new System.Drawing.Point(42, 716);
            this.Straight.Margin = new System.Windows.Forms.Padding(4);
            this.Straight.Name = "Straight";
            this.Straight.Size = new System.Drawing.Size(104, 29);
            this.Straight.TabIndex = 18;
            this.Straight.TabStop = true;
            this.Straight.Text = "Straight";
            this.Straight.UseVisualStyleBackColor = true;
            this.Straight.CheckedChanged += new System.EventHandler(this.Straight_CheckedChanged);
            // 
            // Leveled
            // 
            this.structuresExtender.SetAttributeName(this.Leveled, null);
            this.structuresExtender.SetAttributeTypeName(this.Leveled, null);
            this.Leveled.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.Leveled, null);
            this.Leveled.Location = new System.Drawing.Point(42, 681);
            this.Leveled.Margin = new System.Windows.Forms.Padding(4);
            this.Leveled.Name = "Leveled";
            this.Leveled.Size = new System.Drawing.Size(106, 29);
            this.Leveled.TabIndex = 17;
            this.Leveled.TabStop = true;
            this.Leveled.Text = "Leveled";
            this.Leveled.UseVisualStyleBackColor = true;
            this.Leveled.CheckedChanged += new System.EventHandler(this.Leveled_CheckedChanged);
            // 
            // RailOffset
            // 
            this.structuresExtender.SetAttributeName(this.RailOffset, "RailOffset");
            this.structuresExtender.SetAttributeTypeName(this.RailOffset, "Double");
            this.structuresExtender.SetBindPropertyName(this.RailOffset, "Text");
            this.RailOffset.Location = new System.Drawing.Point(42, 626);
            this.RailOffset.Margin = new System.Windows.Forms.Padding(4);
            this.RailOffset.Name = "RailOffset";
            this.RailOffset.Size = new System.Drawing.Size(189, 29);
            this.RailOffset.TabIndex = 16;
            // 
            // TopReturnLength
            // 
            this.structuresExtender.SetAttributeName(this.TopReturnLength, "TopReturnLength");
            this.structuresExtender.SetAttributeTypeName(this.TopReturnLength, "Double");
            this.structuresExtender.SetBindPropertyName(this.TopReturnLength, "Text");
            this.TopReturnLength.Location = new System.Drawing.Point(46, 550);
            this.TopReturnLength.Margin = new System.Windows.Forms.Padding(4);
            this.TopReturnLength.Name = "TopReturnLength";
            this.TopReturnLength.Size = new System.Drawing.Size(187, 29);
            this.TopReturnLength.TabIndex = 15;
            // 
            // BottomReturnLength
            // 
            this.structuresExtender.SetAttributeName(this.BottomReturnLength, "BottomReturnLength");
            this.structuresExtender.SetAttributeTypeName(this.BottomReturnLength, "Double");
            this.structuresExtender.SetBindPropertyName(this.BottomReturnLength, "Text");
            this.BottomReturnLength.Location = new System.Drawing.Point(46, 465);
            this.BottomReturnLength.Margin = new System.Windows.Forms.Padding(4);
            this.BottomReturnLength.Name = "BottomReturnLength";
            this.BottomReturnLength.Size = new System.Drawing.Size(193, 29);
            this.BottomReturnLength.TabIndex = 14;
            // 
            // TopExtension
            // 
            this.structuresExtender.SetAttributeName(this.TopExtension, "TopExtension");
            this.structuresExtender.SetAttributeTypeName(this.TopExtension, "Double");
            this.structuresExtender.SetBindPropertyName(this.TopExtension, "Text");
            this.TopExtension.Location = new System.Drawing.Point(46, 393);
            this.TopExtension.Margin = new System.Windows.Forms.Padding(4);
            this.TopExtension.Name = "TopExtension";
            this.TopExtension.Size = new System.Drawing.Size(193, 29);
            this.TopExtension.TabIndex = 13;
            // 
            // BottomExtension
            // 
            this.structuresExtender.SetAttributeName(this.BottomExtension, "BottomExtension");
            this.structuresExtender.SetAttributeTypeName(this.BottomExtension, "Double");
            this.structuresExtender.SetBindPropertyName(this.BottomExtension, "Text");
            this.BottomExtension.Location = new System.Drawing.Point(46, 319);
            this.BottomExtension.Margin = new System.Windows.Forms.Padding(4);
            this.BottomExtension.Name = "BottomExtension";
            this.BottomExtension.Size = new System.Drawing.Size(193, 29);
            this.BottomExtension.TabIndex = 12;
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(40, 596);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "8. Rail Offset";
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(40, 522);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "7. Top Return Length";
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(40, 438);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "6. Bottom Return Length";
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(42, 366);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "5. Top Extension";
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(40, 292);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "4. Bottom Extension";
            // 
            // TopHeight
            // 
            this.structuresExtender.SetAttributeName(this.TopHeight, "TopHeight");
            this.structuresExtender.SetAttributeTypeName(this.TopHeight, "Double");
            this.structuresExtender.SetBindPropertyName(this.TopHeight, "Text");
            this.TopHeight.Location = new System.Drawing.Point(46, 240);
            this.TopHeight.Margin = new System.Windows.Forms.Padding(4);
            this.TopHeight.Name = "TopHeight";
            this.TopHeight.Size = new System.Drawing.Size(193, 29);
            this.TopHeight.TabIndex = 6;
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(40, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "3. Top Height";
            // 
            // SlopedHeight
            // 
            this.structuresExtender.SetAttributeName(this.SlopedHeight, "SlopedHeight");
            this.structuresExtender.SetAttributeTypeName(this.SlopedHeight, "Double");
            this.structuresExtender.SetBindPropertyName(this.SlopedHeight, "Text");
            this.SlopedHeight.Location = new System.Drawing.Point(46, 161);
            this.SlopedHeight.Margin = new System.Windows.Forms.Padding(4);
            this.SlopedHeight.Name = "SlopedHeight";
            this.SlopedHeight.Size = new System.Drawing.Size(193, 29);
            this.SlopedHeight.TabIndex = 4;
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(40, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Sloped Hight";
            // 
            // BottomHeight
            // 
            this.structuresExtender.SetAttributeName(this.BottomHeight, "BottomHeight");
            this.structuresExtender.SetAttributeTypeName(this.BottomHeight, "Double");
            this.structuresExtender.SetBindPropertyName(this.BottomHeight, "Text");
            this.BottomHeight.Location = new System.Drawing.Point(42, 85);
            this.BottomHeight.Margin = new System.Windows.Forms.Padding(4);
            this.BottomHeight.Name = "BottomHeight";
            this.BottomHeight.Size = new System.Drawing.Size(193, 29);
            this.BottomHeight.TabIndex = 2;
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Bottom Height";
            // 
            // pictureBox1
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox1, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox1, null);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(623, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(653, 816);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.structuresExtender.SetAttributeName(this.tabPage1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage1, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage1, null);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1286, 865);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Brackets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // saveLoad
            // 
            this.structuresExtender.SetAttributeName(this.saveLoad, null);
            this.structuresExtender.SetAttributeTypeName(this.saveLoad, null);
            this.saveLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.saveLoad, null);
            this.saveLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveLoad.HelpFileType = Tekla.Structures.Dialog.UIControls.SaveLoad.HelpFileTypeEnum.General;
            this.saveLoad.HelpKeyword = "";
            this.saveLoad.HelpUrl = "";
            this.saveLoad.Location = new System.Drawing.Point(11, 11);
            this.saveLoad.Margin = new System.Windows.Forms.Padding(11);
            this.saveLoad.Name = "saveLoad";
            this.saveLoad.SaveAsText = "";
            this.saveLoad.Size = new System.Drawing.Size(1284, 79);
            this.saveLoad.TabIndex = 0;
            this.saveLoad.UserDefinedHelpFilePath = null;
            // 
            // MainForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(1306, 1091);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Model Plug-in";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ParametersTabPage.ResumeLayout(false);
            this.ParametersTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad;
        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel OkApplyModifyGetOnOffCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ParametersTabPage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BottomHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SlopedHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TopHeight;
        private System.Windows.Forms.TextBox RailOffset;
        private System.Windows.Forms.TextBox TopReturnLength;
        private System.Windows.Forms.TextBox BottomReturnLength;
        private System.Windows.Forms.TextBox TopExtension;
        private System.Windows.Forms.TextBox BottomExtension;
        private System.Windows.Forms.RadioButton Leveled;
        private System.Windows.Forms.RadioButton Straight;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox RailGeometryType;
        private System.Windows.Forms.TextBox SelectedProfileBox;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog ProfileCatalog;
        private System.Windows.Forms.Label label9;
        private Tekla.Structures.Dialog.UIControls.MaterialCatalog MaterialCatalog;
        private System.Windows.Forms.TextBox SelectedMaterialBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox ClassBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox FinishBox;
        private Tekla.Structures.Dialog.UIControls.MaterialCatalog materialCatalog1;
    }
}