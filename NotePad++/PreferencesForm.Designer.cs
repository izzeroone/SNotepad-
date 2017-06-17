namespace NotePad__
{
    partial class PreferencesForm
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
            this.menuListBox = new System.Windows.Forms.ListBox();
            this.generalPanel = new System.Windows.Forms.Panel();
            this.showStatusBarCheckBox = new System.Windows.Forms.CheckBox();
            this.hideTaskBarCheckBox = new System.Windows.Forms.CheckBox();
            this.taskBarGroupBox = new System.Windows.Forms.GroupBox();
            this.fontCheckBox = new System.Windows.Forms.CheckBox();
            this.underlineCheckBox = new System.Windows.Forms.CheckBox();
            this.upperCheckBox = new System.Windows.Forms.CheckBox();
            this.versionsCheckBox = new System.Windows.Forms.CheckBox();
            this.italicCheckBox = new System.Windows.Forms.CheckBox();
            this.boldCheckBox = new System.Windows.Forms.CheckBox();
            this.documentMapCheckBox = new System.Windows.Forms.CheckBox();
            this.findAndReplaceCheckBox = new System.Windows.Forms.CheckBox();
            this.pasteCheckBox = new System.Windows.Forms.CheckBox();
            this.cutCheckBox = new System.Windows.Forms.CheckBox();
            this.copyCheckBox = new System.Windows.Forms.CheckBox();
            this.findCheckBox = new System.Windows.Forms.CheckBox();
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.openCheckBox = new System.Windows.Forms.CheckBox();
            this.newCheckBox = new System.Windows.Forms.CheckBox();
            this.themeGroupBox = new System.Windows.Forms.GroupBox();
            this.customThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.darkThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.defaultThemeRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.backColorButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.closeButton = new System.Windows.Forms.Button();
            this.languagePanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.defaultLaguageComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.commentBlocksColorButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.keywordsColorButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.defaultLanguageColorButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.commentLinesColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.stringsColorButton = new System.Windows.Forms.Button();
            this.othersPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.bookmarkMarginForeColorButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.bookmarkMarginBackColorButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.documentMapForeColorButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.documentMapBackColorButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.numberMarginForeColorButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numberMarginBackColorButton = new System.Windows.Forms.Button();
            this.generalPanel.SuspendLayout();
            this.taskBarGroupBox.SuspendLayout();
            this.themeGroupBox.SuspendLayout();
            this.languagePanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.othersPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuListBox
            // 
            this.menuListBox.BackColor = System.Drawing.SystemColors.Control;
            this.menuListBox.FormattingEnabled = true;
            this.menuListBox.Items.AddRange(new object[] {
            "General",
            "Language",
            "Others"});
            this.menuListBox.Location = new System.Drawing.Point(25, 30);
            this.menuListBox.Name = "menuListBox";
            this.menuListBox.Size = new System.Drawing.Size(96, 225);
            this.menuListBox.TabIndex = 0;
            this.menuListBox.SelectedIndexChanged += new System.EventHandler(this.menuListBox_SelectedIndexChanged);
            // 
            // generalPanel
            // 
            this.generalPanel.Controls.Add(this.showStatusBarCheckBox);
            this.generalPanel.Controls.Add(this.hideTaskBarCheckBox);
            this.generalPanel.Controls.Add(this.taskBarGroupBox);
            this.generalPanel.Controls.Add(this.themeGroupBox);
            this.generalPanel.Location = new System.Drawing.Point(175, 30);
            this.generalPanel.Name = "generalPanel";
            this.generalPanel.Size = new System.Drawing.Size(411, 225);
            this.generalPanel.TabIndex = 1;
            this.generalPanel.Visible = false;
            // 
            // showStatusBarCheckBox
            // 
            this.showStatusBarCheckBox.AutoSize = true;
            this.showStatusBarCheckBox.Checked = true;
            this.showStatusBarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showStatusBarCheckBox.Location = new System.Drawing.Point(3, 205);
            this.showStatusBarCheckBox.Name = "showStatusBarCheckBox";
            this.showStatusBarCheckBox.Size = new System.Drawing.Size(102, 17);
            this.showStatusBarCheckBox.TabIndex = 3;
            this.showStatusBarCheckBox.Text = "Show status bar";
            this.showStatusBarCheckBox.UseVisualStyleBackColor = true;
            this.showStatusBarCheckBox.Click += new System.EventHandler(this.showStatusBarCheckBox_Click);
            // 
            // hideTaskBarCheckBox
            // 
            this.hideTaskBarCheckBox.AutoSize = true;
            this.hideTaskBarCheckBox.Location = new System.Drawing.Point(191, 205);
            this.hideTaskBarCheckBox.Name = "hideTaskBarCheckBox";
            this.hideTaskBarCheckBox.Size = new System.Drawing.Size(89, 17);
            this.hideTaskBarCheckBox.TabIndex = 2;
            this.hideTaskBarCheckBox.Text = "Hide task bar";
            this.hideTaskBarCheckBox.UseVisualStyleBackColor = true;
            this.hideTaskBarCheckBox.Click += new System.EventHandler(this.hideTaskBarcheckBox_Click);
            // 
            // taskBarGroupBox
            // 
            this.taskBarGroupBox.Controls.Add(this.fontCheckBox);
            this.taskBarGroupBox.Controls.Add(this.underlineCheckBox);
            this.taskBarGroupBox.Controls.Add(this.upperCheckBox);
            this.taskBarGroupBox.Controls.Add(this.versionsCheckBox);
            this.taskBarGroupBox.Controls.Add(this.italicCheckBox);
            this.taskBarGroupBox.Controls.Add(this.boldCheckBox);
            this.taskBarGroupBox.Controls.Add(this.documentMapCheckBox);
            this.taskBarGroupBox.Controls.Add(this.findAndReplaceCheckBox);
            this.taskBarGroupBox.Controls.Add(this.pasteCheckBox);
            this.taskBarGroupBox.Controls.Add(this.cutCheckBox);
            this.taskBarGroupBox.Controls.Add(this.copyCheckBox);
            this.taskBarGroupBox.Controls.Add(this.findCheckBox);
            this.taskBarGroupBox.Controls.Add(this.saveCheckBox);
            this.taskBarGroupBox.Controls.Add(this.openCheckBox);
            this.taskBarGroupBox.Controls.Add(this.newCheckBox);
            this.taskBarGroupBox.Location = new System.Drawing.Point(191, 3);
            this.taskBarGroupBox.Name = "taskBarGroupBox";
            this.taskBarGroupBox.Size = new System.Drawing.Size(207, 196);
            this.taskBarGroupBox.TabIndex = 1;
            this.taskBarGroupBox.TabStop = false;
            this.taskBarGroupBox.Text = "Task Bar";
            // 
            // fontCheckBox
            // 
            this.fontCheckBox.AutoSize = true;
            this.fontCheckBox.Checked = true;
            this.fontCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fontCheckBox.Location = new System.Drawing.Point(127, 86);
            this.fontCheckBox.Name = "fontCheckBox";
            this.fontCheckBox.Size = new System.Drawing.Size(47, 17);
            this.fontCheckBox.TabIndex = 18;
            this.fontCheckBox.Text = "Font";
            this.fontCheckBox.UseVisualStyleBackColor = true;
            this.fontCheckBox.Visible = false;
            this.fontCheckBox.Click += new System.EventHandler(this.fontCheckBox_Click);
            // 
            // underlineCheckBox
            // 
            this.underlineCheckBox.AutoSize = true;
            this.underlineCheckBox.Checked = true;
            this.underlineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.underlineCheckBox.Location = new System.Drawing.Point(126, 153);
            this.underlineCheckBox.Name = "underlineCheckBox";
            this.underlineCheckBox.Size = new System.Drawing.Size(71, 17);
            this.underlineCheckBox.TabIndex = 17;
            this.underlineCheckBox.Text = "Underline";
            this.underlineCheckBox.UseVisualStyleBackColor = true;
            this.underlineCheckBox.Visible = false;
            this.underlineCheckBox.CheckedChanged += new System.EventHandler(this.underlineCheckBox_CheckedChanged);
            // 
            // upperCheckBox
            // 
            this.upperCheckBox.AutoSize = true;
            this.upperCheckBox.Checked = true;
            this.upperCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.upperCheckBox.Location = new System.Drawing.Point(15, 153);
            this.upperCheckBox.Name = "upperCheckBox";
            this.upperCheckBox.Size = new System.Drawing.Size(71, 17);
            this.upperCheckBox.TabIndex = 14;
            this.upperCheckBox.Text = "To Upper";
            this.upperCheckBox.UseVisualStyleBackColor = true;
            this.upperCheckBox.Click += new System.EventHandler(this.upperCheckBox_Click);
            // 
            // versionsCheckBox
            // 
            this.versionsCheckBox.AutoSize = true;
            this.versionsCheckBox.Checked = true;
            this.versionsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.versionsCheckBox.Location = new System.Drawing.Point(15, 174);
            this.versionsCheckBox.Name = "versionsCheckBox";
            this.versionsCheckBox.Size = new System.Drawing.Size(66, 17);
            this.versionsCheckBox.TabIndex = 13;
            this.versionsCheckBox.Text = "Versions";
            this.versionsCheckBox.UseVisualStyleBackColor = true;
            this.versionsCheckBox.Click += new System.EventHandler(this.versionsCheckBox_Click);
            // 
            // italicCheckBox
            // 
            this.italicCheckBox.AutoSize = true;
            this.italicCheckBox.Checked = true;
            this.italicCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.italicCheckBox.Location = new System.Drawing.Point(126, 131);
            this.italicCheckBox.Name = "italicCheckBox";
            this.italicCheckBox.Size = new System.Drawing.Size(48, 17);
            this.italicCheckBox.TabIndex = 16;
            this.italicCheckBox.Text = "Italic";
            this.italicCheckBox.UseVisualStyleBackColor = true;
            this.italicCheckBox.Visible = false;
            this.italicCheckBox.Click += new System.EventHandler(this.italicCheckBox_Click);
            // 
            // boldCheckBox
            // 
            this.boldCheckBox.AutoSize = true;
            this.boldCheckBox.Checked = true;
            this.boldCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boldCheckBox.Location = new System.Drawing.Point(126, 109);
            this.boldCheckBox.Name = "boldCheckBox";
            this.boldCheckBox.Size = new System.Drawing.Size(47, 17);
            this.boldCheckBox.TabIndex = 15;
            this.boldCheckBox.Text = "Bold";
            this.boldCheckBox.UseVisualStyleBackColor = true;
            this.boldCheckBox.Visible = false;
            this.boldCheckBox.Click += new System.EventHandler(this.boldCheckBox_Click);
            // 
            // documentMapCheckBox
            // 
            this.documentMapCheckBox.AutoSize = true;
            this.documentMapCheckBox.Checked = true;
            this.documentMapCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.documentMapCheckBox.Location = new System.Drawing.Point(15, 84);
            this.documentMapCheckBox.Name = "documentMapCheckBox";
            this.documentMapCheckBox.Size = new System.Drawing.Size(98, 17);
            this.documentMapCheckBox.TabIndex = 12;
            this.documentMapCheckBox.Text = "Document map";
            this.documentMapCheckBox.UseVisualStyleBackColor = true;
            this.documentMapCheckBox.Click += new System.EventHandler(this.documentMapCheckBox_Click);
            // 
            // findAndReplaceCheckBox
            // 
            this.findAndReplaceCheckBox.AutoSize = true;
            this.findAndReplaceCheckBox.Checked = true;
            this.findAndReplaceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findAndReplaceCheckBox.Location = new System.Drawing.Point(15, 131);
            this.findAndReplaceCheckBox.Name = "findAndReplaceCheckBox";
            this.findAndReplaceCheckBox.Size = new System.Drawing.Size(110, 17);
            this.findAndReplaceCheckBox.TabIndex = 11;
            this.findAndReplaceCheckBox.Text = "Find and Replace";
            this.findAndReplaceCheckBox.UseVisualStyleBackColor = true;
            this.findAndReplaceCheckBox.Click += new System.EventHandler(this.findAndReplaceCheckBox_Click);
            // 
            // pasteCheckBox
            // 
            this.pasteCheckBox.AutoSize = true;
            this.pasteCheckBox.Checked = true;
            this.pasteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pasteCheckBox.Location = new System.Drawing.Point(127, 63);
            this.pasteCheckBox.Name = "pasteCheckBox";
            this.pasteCheckBox.Size = new System.Drawing.Size(53, 17);
            this.pasteCheckBox.TabIndex = 10;
            this.pasteCheckBox.Text = "Paste";
            this.pasteCheckBox.UseVisualStyleBackColor = true;
            this.pasteCheckBox.Click += new System.EventHandler(this.pasteCheckBox_Click);
            // 
            // cutCheckBox
            // 
            this.cutCheckBox.AutoSize = true;
            this.cutCheckBox.Checked = true;
            this.cutCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cutCheckBox.Location = new System.Drawing.Point(127, 39);
            this.cutCheckBox.Name = "cutCheckBox";
            this.cutCheckBox.Size = new System.Drawing.Size(42, 17);
            this.cutCheckBox.TabIndex = 9;
            this.cutCheckBox.Text = "Cut";
            this.cutCheckBox.UseVisualStyleBackColor = true;
            this.cutCheckBox.Click += new System.EventHandler(this.cutCheckBox_Click);
            // 
            // copyCheckBox
            // 
            this.copyCheckBox.AutoSize = true;
            this.copyCheckBox.Checked = true;
            this.copyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyCheckBox.Location = new System.Drawing.Point(127, 17);
            this.copyCheckBox.Name = "copyCheckBox";
            this.copyCheckBox.Size = new System.Drawing.Size(50, 17);
            this.copyCheckBox.TabIndex = 8;
            this.copyCheckBox.Text = "Copy";
            this.copyCheckBox.UseVisualStyleBackColor = true;
            this.copyCheckBox.Click += new System.EventHandler(this.copyCheckBox_Click);
            // 
            // findCheckBox
            // 
            this.findCheckBox.AutoSize = true;
            this.findCheckBox.Checked = true;
            this.findCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findCheckBox.Location = new System.Drawing.Point(15, 107);
            this.findCheckBox.Name = "findCheckBox";
            this.findCheckBox.Size = new System.Drawing.Size(46, 17);
            this.findCheckBox.TabIndex = 7;
            this.findCheckBox.Text = "Find";
            this.findCheckBox.UseVisualStyleBackColor = true;
            this.findCheckBox.Click += new System.EventHandler(this.findCheckBox_Click);
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Checked = true;
            this.saveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveCheckBox.Location = new System.Drawing.Point(15, 61);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(51, 17);
            this.saveCheckBox.TabIndex = 6;
            this.saveCheckBox.Text = "Save";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            this.saveCheckBox.Click += new System.EventHandler(this.saveCheckBox_Click);
            // 
            // openCheckBox
            // 
            this.openCheckBox.AutoSize = true;
            this.openCheckBox.Checked = true;
            this.openCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openCheckBox.Location = new System.Drawing.Point(15, 39);
            this.openCheckBox.Name = "openCheckBox";
            this.openCheckBox.Size = new System.Drawing.Size(52, 17);
            this.openCheckBox.TabIndex = 5;
            this.openCheckBox.Text = "Open";
            this.openCheckBox.UseVisualStyleBackColor = true;
            this.openCheckBox.Click += new System.EventHandler(this.openCheckBox_Click);
            // 
            // newCheckBox
            // 
            this.newCheckBox.AutoSize = true;
            this.newCheckBox.Checked = true;
            this.newCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.newCheckBox.Location = new System.Drawing.Point(15, 16);
            this.newCheckBox.Name = "newCheckBox";
            this.newCheckBox.Size = new System.Drawing.Size(48, 17);
            this.newCheckBox.TabIndex = 4;
            this.newCheckBox.Text = "New";
            this.newCheckBox.UseVisualStyleBackColor = true;
            this.newCheckBox.Click += new System.EventHandler(this.newCheckBox_Click);
            // 
            // themeGroupBox
            // 
            this.themeGroupBox.Controls.Add(this.customThemeRadioButton);
            this.themeGroupBox.Controls.Add(this.darkThemeRadioButton);
            this.themeGroupBox.Controls.Add(this.defaultThemeRadioButton);
            this.themeGroupBox.Controls.Add(this.label1);
            this.themeGroupBox.Controls.Add(this.backColorButton);
            this.themeGroupBox.Location = new System.Drawing.Point(3, 3);
            this.themeGroupBox.Name = "themeGroupBox";
            this.themeGroupBox.Size = new System.Drawing.Size(170, 196);
            this.themeGroupBox.TabIndex = 0;
            this.themeGroupBox.TabStop = false;
            this.themeGroupBox.Text = "Theme";
            // 
            // customThemeRadioButton
            // 
            this.customThemeRadioButton.AutoSize = true;
            this.customThemeRadioButton.Location = new System.Drawing.Point(17, 86);
            this.customThemeRadioButton.Name = "customThemeRadioButton";
            this.customThemeRadioButton.Size = new System.Drawing.Size(96, 17);
            this.customThemeRadioButton.TabIndex = 6;
            this.customThemeRadioButton.Text = "Custom Theme";
            this.customThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // darkThemeRadioButton
            // 
            this.darkThemeRadioButton.AutoSize = true;
            this.darkThemeRadioButton.Location = new System.Drawing.Point(17, 43);
            this.darkThemeRadioButton.Name = "darkThemeRadioButton";
            this.darkThemeRadioButton.Size = new System.Drawing.Size(84, 17);
            this.darkThemeRadioButton.TabIndex = 5;
            this.darkThemeRadioButton.Text = "Dark Theme";
            this.darkThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // defaultThemeRadioButton
            // 
            this.defaultThemeRadioButton.AutoSize = true;
            this.defaultThemeRadioButton.Checked = true;
            this.defaultThemeRadioButton.Location = new System.Drawing.Point(17, 20);
            this.defaultThemeRadioButton.Name = "defaultThemeRadioButton";
            this.defaultThemeRadioButton.Size = new System.Drawing.Size(95, 17);
            this.defaultThemeRadioButton.TabIndex = 4;
            this.defaultThemeRadioButton.TabStop = true;
            this.defaultThemeRadioButton.Text = "Default Theme";
            this.defaultThemeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Background Color";
            // 
            // backColorButton
            // 
            this.backColorButton.BackColor = System.Drawing.Color.White;
            this.backColorButton.Location = new System.Drawing.Point(112, 110);
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(41, 23);
            this.backColorButton.TabIndex = 0;
            this.backColorButton.UseVisualStyleBackColor = false;
            this.backColorButton.Click += new System.EventHandler(this.backColorDialogButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(257, 291);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // languagePanel
            // 
            this.languagePanel.Controls.Add(this.groupBox2);
            this.languagePanel.Location = new System.Drawing.Point(606, 30);
            this.languagePanel.Name = "languagePanel";
            this.languagePanel.Size = new System.Drawing.Size(233, 225);
            this.languagePanel.TabIndex = 3;
            this.languagePanel.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.defaultLaguageComboBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.commentBlocksColorButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.keywordsColorButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.defaultLanguageColorButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.commentLinesColorButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.stringsColorButton);
            this.groupBox2.Location = new System.Drawing.Point(13, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 196);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Laguage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Default Language";
            // 
            // defaultLaguageComboBox
            // 
            this.defaultLaguageComboBox.FormattingEnabled = true;
            this.defaultLaguageComboBox.Items.AddRange(new object[] {
            "NormalText",
            "C",
            "C++",
            "C#",
            "VB"});
            this.defaultLaguageComboBox.Location = new System.Drawing.Point(122, 160);
            this.defaultLaguageComboBox.Name = "defaultLaguageComboBox";
            this.defaultLaguageComboBox.Size = new System.Drawing.Size(77, 21);
            this.defaultLaguageComboBox.TabIndex = 10;
            this.defaultLaguageComboBox.Text = "NormalText";
            this.defaultLaguageComboBox.SelectedIndexChanged += new System.EventHandler(this.defaultLaguageComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Comment Blocks Color";
            // 
            // commentBlocksColorButton
            // 
            this.commentBlocksColorButton.BackColor = System.Drawing.Color.DarkGreen;
            this.commentBlocksColorButton.Location = new System.Drawing.Point(122, 131);
            this.commentBlocksColorButton.Name = "commentBlocksColorButton";
            this.commentBlocksColorButton.Size = new System.Drawing.Size(41, 23);
            this.commentBlocksColorButton.TabIndex = 8;
            this.commentBlocksColorButton.UseVisualStyleBackColor = false;
            this.commentBlocksColorButton.Click += new System.EventHandler(this.commentBlocksColorButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Keywords Color";
            // 
            // keywordsColorButton
            // 
            this.keywordsColorButton.BackColor = System.Drawing.Color.Blue;
            this.keywordsColorButton.Location = new System.Drawing.Point(122, 44);
            this.keywordsColorButton.Name = "keywordsColorButton";
            this.keywordsColorButton.Size = new System.Drawing.Size(41, 23);
            this.keywordsColorButton.TabIndex = 6;
            this.keywordsColorButton.UseVisualStyleBackColor = false;
            this.keywordsColorButton.Click += new System.EventHandler(this.keywordColorButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Default Color";
            // 
            // defaultLanguageColorButton
            // 
            this.defaultLanguageColorButton.BackColor = System.Drawing.Color.Black;
            this.defaultLanguageColorButton.Location = new System.Drawing.Point(122, 15);
            this.defaultLanguageColorButton.Name = "defaultLanguageColorButton";
            this.defaultLanguageColorButton.Size = new System.Drawing.Size(41, 23);
            this.defaultLanguageColorButton.TabIndex = 4;
            this.defaultLanguageColorButton.UseVisualStyleBackColor = false;
            this.defaultLanguageColorButton.Click += new System.EventHandler(this.defaultColorButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Comment Lines Color";
            // 
            // commentLinesColorButton
            // 
            this.commentLinesColorButton.BackColor = System.Drawing.Color.Green;
            this.commentLinesColorButton.Location = new System.Drawing.Point(122, 101);
            this.commentLinesColorButton.Name = "commentLinesColorButton";
            this.commentLinesColorButton.Size = new System.Drawing.Size(41, 23);
            this.commentLinesColorButton.TabIndex = 2;
            this.commentLinesColorButton.UseVisualStyleBackColor = false;
            this.commentLinesColorButton.Click += new System.EventHandler(this.commentLinesColorButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Strings Color";
            // 
            // stringsColorButton
            // 
            this.stringsColorButton.BackColor = System.Drawing.Color.Brown;
            this.stringsColorButton.Location = new System.Drawing.Point(122, 72);
            this.stringsColorButton.Name = "stringsColorButton";
            this.stringsColorButton.Size = new System.Drawing.Size(41, 23);
            this.stringsColorButton.TabIndex = 0;
            this.stringsColorButton.UseVisualStyleBackColor = false;
            this.stringsColorButton.Click += new System.EventHandler(this.stringsColorButton_Click);
            // 
            // othersPanel
            // 
            this.othersPanel.Controls.Add(this.groupBox1);
            this.othersPanel.Location = new System.Drawing.Point(845, 30);
            this.othersPanel.Name = "othersPanel";
            this.othersPanel.Size = new System.Drawing.Size(274, 225);
            this.othersPanel.TabIndex = 4;
            this.othersPanel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.bookmarkMarginForeColorButton);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.bookmarkMarginBackColorButton);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.documentMapForeColorButton);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.documentMapBackColorButton);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.numberMarginForeColorButton);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numberMarginBackColorButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Others";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(169, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Bookmark margin foreground color";
            // 
            // bookmarkMarginForeColorButton
            // 
            this.bookmarkMarginForeColorButton.BackColor = System.Drawing.Color.Red;
            this.bookmarkMarginForeColorButton.Location = new System.Drawing.Point(188, 157);
            this.bookmarkMarginForeColorButton.Name = "bookmarkMarginForeColorButton";
            this.bookmarkMarginForeColorButton.Size = new System.Drawing.Size(41, 23);
            this.bookmarkMarginForeColorButton.TabIndex = 10;
            this.bookmarkMarginForeColorButton.UseVisualStyleBackColor = false;
            this.bookmarkMarginForeColorButton.Click += new System.EventHandler(this.bookmarkMarginForeColorButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Bookmark margin background color";
            // 
            // bookmarkMarginBackColorButton
            // 
            this.bookmarkMarginBackColorButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bookmarkMarginBackColorButton.Location = new System.Drawing.Point(188, 130);
            this.bookmarkMarginBackColorButton.Name = "bookmarkMarginBackColorButton";
            this.bookmarkMarginBackColorButton.Size = new System.Drawing.Size(41, 23);
            this.bookmarkMarginBackColorButton.TabIndex = 8;
            this.bookmarkMarginBackColorButton.UseVisualStyleBackColor = false;
            this.bookmarkMarginBackColorButton.Click += new System.EventHandler(this.bookmarkMarginBackColorButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Document map foreground color";
            // 
            // documentMapForeColorButton
            // 
            this.documentMapForeColorButton.BackColor = System.Drawing.Color.Black;
            this.documentMapForeColorButton.Location = new System.Drawing.Point(188, 43);
            this.documentMapForeColorButton.Name = "documentMapForeColorButton";
            this.documentMapForeColorButton.Size = new System.Drawing.Size(41, 23);
            this.documentMapForeColorButton.TabIndex = 6;
            this.documentMapForeColorButton.UseVisualStyleBackColor = false;
            this.documentMapForeColorButton.Click += new System.EventHandler(this.documentMapForeColorButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Document map background color";
            // 
            // documentMapBackColorButton
            // 
            this.documentMapBackColorButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.documentMapBackColorButton.Location = new System.Drawing.Point(188, 15);
            this.documentMapBackColorButton.Name = "documentMapBackColorButton";
            this.documentMapBackColorButton.Size = new System.Drawing.Size(41, 23);
            this.documentMapBackColorButton.TabIndex = 4;
            this.documentMapBackColorButton.UseVisualStyleBackColor = false;
            this.documentMapBackColorButton.Click += new System.EventHandler(this.documentMapBackColorButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Number margin foreground color";
            // 
            // numberMarginForeColorButton
            // 
            this.numberMarginForeColorButton.BackColor = System.Drawing.Color.Black;
            this.numberMarginForeColorButton.Location = new System.Drawing.Point(188, 100);
            this.numberMarginForeColorButton.Name = "numberMarginForeColorButton";
            this.numberMarginForeColorButton.Size = new System.Drawing.Size(41, 23);
            this.numberMarginForeColorButton.TabIndex = 2;
            this.numberMarginForeColorButton.UseVisualStyleBackColor = false;
            this.numberMarginForeColorButton.Click += new System.EventHandler(this.numberMarginForeColorButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Number margin background color";
            // 
            // numberMarginBackColorButton
            // 
            this.numberMarginBackColorButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.numberMarginBackColorButton.Location = new System.Drawing.Point(188, 71);
            this.numberMarginBackColorButton.Name = "numberMarginBackColorButton";
            this.numberMarginBackColorButton.Size = new System.Drawing.Size(41, 23);
            this.numberMarginBackColorButton.TabIndex = 0;
            this.numberMarginBackColorButton.UseVisualStyleBackColor = false;
            this.numberMarginBackColorButton.Click += new System.EventHandler(this.numberMarginBackColorButton_Click);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 326);
            this.Controls.Add(this.othersPanel);
            this.Controls.Add(this.languagePanel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.generalPanel);
            this.Controls.Add(this.menuListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.generalPanel.ResumeLayout(false);
            this.generalPanel.PerformLayout();
            this.taskBarGroupBox.ResumeLayout(false);
            this.taskBarGroupBox.PerformLayout();
            this.themeGroupBox.ResumeLayout(false);
            this.themeGroupBox.PerformLayout();
            this.languagePanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.othersPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox menuListBox;
        private System.Windows.Forms.Panel generalPanel;
        private System.Windows.Forms.CheckBox showStatusBarCheckBox;
        private System.Windows.Forms.CheckBox hideTaskBarCheckBox;
        private System.Windows.Forms.GroupBox taskBarGroupBox;
        private System.Windows.Forms.GroupBox themeGroupBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backColorButton;
        private System.Windows.Forms.RadioButton defaultThemeRadioButton;
        private System.Windows.Forms.RadioButton darkThemeRadioButton;
        private System.Windows.Forms.CheckBox findCheckBox;
        private System.Windows.Forms.CheckBox saveCheckBox;
        private System.Windows.Forms.CheckBox openCheckBox;
        private System.Windows.Forms.CheckBox newCheckBox;
        private System.Windows.Forms.CheckBox pasteCheckBox;
        private System.Windows.Forms.CheckBox cutCheckBox;
        private System.Windows.Forms.CheckBox copyCheckBox;
        private System.Windows.Forms.CheckBox findAndReplaceCheckBox;
        private System.Windows.Forms.CheckBox documentMapCheckBox;
        private System.Windows.Forms.CheckBox versionsCheckBox;
        private System.Windows.Forms.CheckBox upperCheckBox;
        private System.Windows.Forms.CheckBox underlineCheckBox;
        private System.Windows.Forms.CheckBox italicCheckBox;
        private System.Windows.Forms.CheckBox boldCheckBox;
        private System.Windows.Forms.CheckBox fontCheckBox;
        private System.Windows.Forms.Panel languagePanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button commentLinesColorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stringsColorButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button keywordsColorButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button defaultLanguageColorButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button commentBlocksColorButton;
        private System.Windows.Forms.ComboBox defaultLaguageComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel othersPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bookmarkMarginBackColorButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button documentMapForeColorButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button documentMapBackColorButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button numberMarginForeColorButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button numberMarginBackColorButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bookmarkMarginForeColorButton;
        private System.Windows.Forms.RadioButton customThemeRadioButton;
    }
}