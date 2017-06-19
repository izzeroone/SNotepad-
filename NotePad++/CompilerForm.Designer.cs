namespace NotePad__
{
    partial class CompilerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilerForm));
            this.label2 = new System.Windows.Forms.Label();
            this.mainClassTextBox = new System.Windows.Forms.TextBox();
            this.ExcuteButton = new System.Windows.Forms.Button();
            this.codeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.laguageComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(703, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Main Class Name";
            // 
            // mainClassTextBox
            // 
            this.mainClassTextBox.Location = new System.Drawing.Point(857, 84);
            this.mainClassTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainClassTextBox.Name = "mainClassTextBox";
            this.mainClassTextBox.Size = new System.Drawing.Size(201, 22);
            this.mainClassTextBox.TabIndex = 11;
            this.mainClassTextBox.Text = "Helloworld.HelloWorld";
            // 
            // ExcuteButton
            // 
            this.ExcuteButton.BackColor = System.Drawing.SystemColors.Control;
            this.ExcuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExcuteButton.Location = new System.Drawing.Point(804, 245);
            this.ExcuteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExcuteButton.Name = "ExcuteButton";
            this.ExcuteButton.Size = new System.Drawing.Size(213, 30);
            this.ExcuteButton.TabIndex = 9;
            this.ExcuteButton.Text = "&Compile and Execute";
            this.ExcuteButton.UseVisualStyleBackColor = false;
            this.ExcuteButton.Click += new System.EventHandler(this.ExcuteButton_Click);
            // 
            // codeRichTextBox
            // 
            this.codeRichTextBox.Location = new System.Drawing.Point(29, 39);
            this.codeRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.codeRichTextBox.Name = "codeRichTextBox";
            this.codeRichTextBox.Size = new System.Drawing.Size(651, 234);
            this.codeRichTextBox.TabIndex = 14;
            this.codeRichTextBox.Text = resources.GetString("codeRichTextBox.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(703, 43);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Language";
            // 
            // laguageComboBox
            // 
            this.laguageComboBox.FormattingEnabled = true;
            this.laguageComboBox.Items.AddRange(new object[] {
            "NormalText",
            "C",
            "C++",
            "CSharp",
            "VisualBasic"});
            this.laguageComboBox.Location = new System.Drawing.Point(857, 39);
            this.laguageComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.laguageComboBox.Name = "laguageComboBox";
            this.laguageComboBox.Size = new System.Drawing.Size(101, 24);
            this.laguageComboBox.TabIndex = 15;
            this.laguageComboBox.Text = "NormalText";
            // 
            // CompilerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 318);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.laguageComboBox);
            this.Controls.Add(this.codeRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainClassTextBox);
            this.Controls.Add(this.ExcuteButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompilerForm";
            this.Text = "ComplilerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompilerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mainClassTextBox;
        private System.Windows.Forms.Button ExcuteButton;
        private System.Windows.Forms.RichTextBox codeRichTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox laguageComboBox;
    }
}
