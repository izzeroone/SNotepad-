using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyTextBox;

namespace NotePad__
{
    public partial class FindForm : Form
    {

        //int preSearchText_Length = 0;
        int indexOfSearchText = -1;
        List<int> textsFound = new List<int>();
        Color AllFoundTextBackColor = Color.Aquamarine;
        //Color SelectedFoundTextBackColor = Color.Orange;
        //Color MyDefaultBackColor = Color.White;
        string previousText = "";

        public FindForm()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            TextArea currentTextArea = TabControlClass.CurrentTextArea;

            previousText = currentTextArea.Text;

            ////Remove highlighted text of previous search        
            currentTextArea.ClearBackColor(currentTextArea.BackColor);

            // Highlighted backcolor of all found text
            //TextFound = currentTextArea.FindAll(searchTermTextBox.Text);
            //currentTextArea.ColorBackGround(TextFound, searchTermTextBox.Text.Length, AllFoundTextBackColor);
            textsFound.Clear();
            textsFound = currentTextArea.FindAndColorAll(searchTermTextBox.Text, AllFoundTextBackColor);

            indexOfSearchText = -1;

            this.Focus();
        }

        private void findNextButton_Click(object sender, EventArgs e)
        {
            TextArea currentTextArea = TabControlClass.CurrentTextArea;

            if(previousText != currentTextArea.Text)
            {
                previousText = currentTextArea.Text;

                //get this again because we might have changed the text in text area and it made some of the found text position changed
                textsFound.Clear();
                textsFound = currentTextArea.FindAll(searchTermTextBox.Text);
            }

            //set this to prevent some disturb things
            currentTextArea.BlockAllAction = true;

            if (textsFound.Count != 0)
            {
                if (searchTermTextBox.Text.Length == 0)
                    return;
                ////Change backcolor of current found text  
                //if (indexOfSearchText != -1)
                //{
                //    currentTextArea.Select(TextFound[indexOfSearchText], searchTermTextBox.Text.Length);
                //    currentTextArea.SelectionBackColor = AllFoundTextBackColor;
                //}
                //Reset the index
                indexOfSearchText++;
                if (indexOfSearchText == textsFound.Count)
                {
                    indexOfSearchText = 0;
                }

                //Chose the highlight backcolor for select text        
                currentTextArea.Select(textsFound[indexOfSearchText], searchTermTextBox.Text.Length);
                //currentTextArea.SelectionBackColor = SelectedFoundTextBackColor;
            }

            currentTextArea.BlockAllAction = false;
            currentTextArea.Focus();
        }

        private void findPreviousButton_Click(object sender, EventArgs e)
        {
            TextArea currentTextArea = TabControlClass.CurrentTextArea;

            if (previousText != currentTextArea.Text)
            {
                previousText = currentTextArea.Text;

                //get this again because we might have changed the text in text area and it made some of the found text position changed
                textsFound.Clear();
                textsFound = currentTextArea.FindAll(searchTermTextBox.Text);
            }

            currentTextArea.BlockAllAction = true;

            if (textsFound.Count != 0)
            {
                if (searchTermTextBox.Text.Length == 0)
                    return;
                ////Change backcolor of current found text
                //if (indexOfSearchText != -1)
                //{
                //    currentTextArea.Select(TextFound[indexOfSearchText], searchTermTextBox.Text.Length);
                //    currentTextArea.SelectionBackColor = AllFoundTextBackColor;
                //}

                //Reset the index

                indexOfSearchText--;
                if (indexOfSearchText <= -1)
                {
                    indexOfSearchText = textsFound.Count - 1;
                }

                //Chose the highlight backcolor for select text        
                currentTextArea.Select(textsFound[indexOfSearchText], searchTermTextBox.Text.Length);
                //currentTextArea.SelectionBackColor = SelectedFoundTextBackColor;
            }

            currentTextArea.BlockAllAction = false;

            currentTextArea.Focus();
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            TextArea currentTextArea = TabControlClass.CurrentTextArea;
            currentTextArea.Focus();
            if (indexOfSearchText == -1 || searchTermTextBox.Text.Equals(replacementTextBox.Text) || currentTextArea.SelectionLength == 0)
            {
                return;
            }

            //currentTextArea.StopRecordingUndo();

            //get this again because we might have changed the text in text area and it made some of the found text position changed
            textsFound.Clear();
            textsFound = currentTextArea.FindAll(searchTermTextBox.Text);

            currentTextArea.Select(textsFound[indexOfSearchText], searchTermTextBox.Text.Length);

            //currentTextArea.SelectionBackColor = MyDefaultBackColor;
            //currentTextArea.SelectedText = replacementTextBox.Text;
            currentTextArea.ReplaceSelectedText(replacementTextBox.Text);

            //just select for nothing much
            currentTextArea.Select(textsFound[indexOfSearchText], replacementTextBox.Text.Length);

            //since we have changed the found text, the number of position of found text now is off by one
            //that's why we lessen indexOFSearchText by one for the purpose of find next 
            //indexOfSearchText--;


            //currentTextArea.ContinueRecordingUndo();

        }

        private void replaceAllButton_Click(object sender, EventArgs e)
        {
            if (searchTermTextBox.Text.Equals(replacementTextBox.Text))
            {
                return;
            }

            TextArea currentTextArea = TabControlClass.CurrentTextArea;
            //currentTextArea.StopRecordingUndo();


            ////get this again because we might have changed the text in text area and it made some of the found text position changed
            //TextFound.Clear();
            //TextFound = currentTextArea.FindAll(searchTermTextBox.Text);


            //int index = 0;
            //int offset = 0;

            //while (index < TextFound.Count)
            //{
            //    currentTextArea.Select(TextFound[index], searchTermTextBox.Text.Length);
            //    //currentTextArea.SelectionBackColor = MyDefaultBackColor;
            //    currentTextArea.SelectedText = replacementTextBox.Text;
            //    index++;
            //    if (index < TextFound.Count)
            //    {
            //        offset += searchTermTextBox.Text.Length - replacementTextBox.Text.Length;
            //        TextFound[index] = TextFound[index] - offset;

            //    }

            //}

            string textToReplace = currentTextArea.Text.Replace(searchTermTextBox.Text, replacementTextBox.Text);
            currentTextArea.Select(0, currentTextArea.TextLength);
            currentTextArea.ReplaceSelectedText(textToReplace);

            //currentTextArea.ContinueRecordingUndo();

        }

        private void FindForm_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 0.3;
            }
            catch { }
        }

        private void FindForm_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        public void ShowFindForm()
        {
            this.Text = "Find";
            replacementLabel.Visible = false;
            replacementTextBox.Visible = false;
            replaceButton.Visible = false;
            replaceAllButton.Visible = false;
            mathCaseCheckBox.Location = replacementLabel.Location;
            this.Width = 380;
            this.Show();
        }
        public void ShowFindAndReplaceForm()
        {
            this.Text = "Find And Replace";
            replacementLabel.Visible = true;
            replacementTextBox.Visible = true;
            replaceButton.Visible = true;
            replaceAllButton.Visible = true;
            mathCaseCheckBox.Location = new Point(12, 103);
            this.AutoSize = true;
            this.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.H | Keys.Control))
            {
                ShowFindAndReplaceForm();
                return true;
            }

            if (keyData == (Keys.F | Keys.Control))
            {
                ShowFindForm();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.ClearBackColor(textArea.BackColor);
            }
       
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
