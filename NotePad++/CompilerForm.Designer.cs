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
            this.label2.Location = new System.Drawing.Point(527, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Main Class Name";
            // 
            // mainClassTextBox
            // 
            this.mainClassTextBox.Location = new System.Drawing.Point(643, 68);
            this.mainClassTextBox.Name = "mainClassTextBox";
            this.mainClassTextBox.Size = new System.Drawing.Size(152, 20);
            this.mainClassTextBox.TabIndex = 11;
            this.mainClassTextBox.Text = "Helloworld.HelloWorld";
            // 
            // ExcuteButton
            // 
            this.ExcuteButton.BackColor = System.Drawing.SystemColors.Control;
            this.ExcuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExcuteButton.Location = new System.Drawing.Point(603, 199);
            this.ExcuteButton.Name = "ExcuteButton";
            this.ExcuteButton.Size = new System.Drawing.Size(160, 24);
            this.ExcuteButton.TabIndex = 9;
            this.ExcuteButton.Text = "&Compile and Execute";
            this.ExcuteButton.UseVisualStyleBackColor = false;
            this.ExcuteButton.Click += new System.EventHandler(this.ExcuteButton_Click);
            // 
            // codeRichTextBox
            // 
            this.codeRichTextBox.Location = new System.Drawing.Point(22, 32);
            this.codeRichTextBox.Name = "codeRichTextBox";
            this.codeRichTextBox.Size = new System.Drawing.Size(489, 191);
            this.codeRichTextBox.TabIndex = 14;
            this.codeRichTextBox.Text = resources.GetString("codeRichTextBox.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(527, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
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
            this.laguageComboBox.Location = new System.Drawing.Point(643, 32);
            this.laguageComboBox.Name = "laguageComboBox";
            this.laguageComboBox.Size = new System.Drawing.Size(77, 21);
            this.laguageComboBox.TabIndex = 15;
            this.laguageComboBox.Text = "NormalText";
            // 
            // CompilerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 258);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.laguageComboBox);
            this.Controls.Add(this.codeRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainClassTextBox);
            this.Controls.Add(this.ExcuteButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompilerForm";
            this.Text = "ComplilerForm";
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