namespace NotePad__
{
    partial class FindForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            this.findNextButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.mathCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.searchTermTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.replacementTextBox = new System.Windows.Forms.TextBox();
            this.replacementLabel = new System.Windows.Forms.Label();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.findPreviousButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findNextButton
            // 
            this.findNextButton.Location = new System.Drawing.Point(361, 74);
            this.findNextButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(116, 26);
            this.findNextButton.TabIndex = 8;
            this.findNextButton.Text = "Find &Next";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.findNextButton_Click);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(361, 38);
            this.findButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(116, 26);
            this.findButton.TabIndex = 7;
            this.findButton.Text = "&Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // mathCaseCheckBox
            // 
            this.mathCaseCheckBox.AutoSize = true;
            this.mathCaseCheckBox.Location = new System.Drawing.Point(16, 127);
            this.mathCaseCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mathCaseCheckBox.Name = "mathCaseCheckBox";
            this.mathCaseCheckBox.Size = new System.Drawing.Size(104, 21);
            this.mathCaseCheckBox.TabIndex = 9;
            this.mathCaseCheckBox.Text = "Match Case";
            this.mathCaseCheckBox.UseVisualStyleBackColor = true;
            this.mathCaseCheckBox.Visible = false;
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.Location = new System.Drawing.Point(16, 38);
            this.searchTermTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.Size = new System.Drawing.Size(335, 22);
            this.searchTermTextBox.TabIndex = 6;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(94, 17);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Search Term:";
            // 
            // replacementTextBox
            // 
            this.replacementTextBox.Location = new System.Drawing.Point(16, 95);
            this.replacementTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.replacementTextBox.Name = "replacementTextBox";
            this.replacementTextBox.Size = new System.Drawing.Size(335, 22);
            this.replacementTextBox.TabIndex = 11;
            // 
            // replacementLabel
            // 
            this.replacementLabel.AutoSize = true;
            this.replacementLabel.Location = new System.Drawing.Point(12, 74);
            this.replacementLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.replacementLabel.Name = "replacementLabel";
            this.replacementLabel.Size = new System.Drawing.Size(126, 17);
            this.replacementLabel.TabIndex = 12;
            this.replacementLabel.Text = "Replacement Text:";
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(485, 70);
            this.replaceAllButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(116, 26);
            this.replaceAllButton.TabIndex = 14;
            this.replaceAllButton.Text = "Replace &All";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.replaceAllButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(485, 37);
            this.replaceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(116, 26);
            this.replaceButton.TabIndex = 13;
            this.replaceButton.Text = "&Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // findPreviousButton
            // 
            this.findPreviousButton.Location = new System.Drawing.Point(360, 108);
            this.findPreviousButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.findPreviousButton.Name = "findPreviousButton";
            this.findPreviousButton.Size = new System.Drawing.Size(117, 26);
            this.findPreviousButton.TabIndex = 15;
            this.findPreviousButton.Text = "Find &Previous";
            this.findPreviousButton.UseVisualStyleBackColor = true;
            this.findPreviousButton.Click += new System.EventHandler(this.findPreviousButton_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(647, 159);
            this.Controls.Add(this.findPreviousButton);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.replacementTextBox);
            this.Controls.Add(this.replacementLabel);
            this.Controls.Add(this.findNextButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.mathCaseCheckBox);
            this.Controls.Add(this.searchTermTextBox);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find And Replace";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FindForm_Activated);
            this.Deactivate += new System.EventHandler(this.FindForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button findNextButton;
        internal System.Windows.Forms.Button findButton;
        internal System.Windows.Forms.CheckBox mathCaseCheckBox;
        internal System.Windows.Forms.TextBox searchTermTextBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox replacementTextBox;
        internal System.Windows.Forms.Label replacementLabel;
        internal System.Windows.Forms.Button replaceAllButton;
        internal System.Windows.Forms.Button replaceButton;
        internal System.Windows.Forms.Button findPreviousButton;
    }
}
