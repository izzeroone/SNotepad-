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
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
            
        }


        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            menuListBox.SelectedIndex = 0;
            this.Size = new Size(605, 365);
            languagePanel.Location = new Point(200, 30);
            othersPanel.Location = new Point(200, 30);
            
            //Theme
            if(StylesClass.Theme == "Default")
            {
                defaultThemeRadioButton.Checked = true;
            }
            else
            {
                if (StylesClass.Theme == "Dark")
                    darkThemeRadioButton.Checked = true;
                else
                    customThemeRadioButton.Checked = true;
            }


            //show status bar
            showStatusBarCheckBox.Checked = StylesClass.ShowStatusBar;
            //hide task bar
            hideTaskBarCheckBox.Checked = StylesClass.HideTaskBar;

            //Task bar
            newCheckBox.Checked = StylesClass.ShowNewIcon;
            openCheckBox.Checked = StylesClass.ShowOpenIcon;
            saveCheckBox.Checked = StylesClass.ShowSaveIcon;
            documentMapCheckBox.Checked = StylesClass.ShowDocumentMapIcon;
            findCheckBox.Checked = StylesClass.ShowFindIcon;
            findAndReplaceCheckBox.Checked = StylesClass.ShowFindAndReplaceIcon;
            upperCheckBox.Checked = StylesClass.ShowToUpperIcon;
            versionsCheckBox.Checked = StylesClass.ShowVersionsIcon;
            copyCheckBox.Checked = StylesClass.ShowCopyIcon;
            cutCheckBox.Checked = StylesClass.ShowCutIcon;
            pasteCheckBox.Checked = StylesClass.ShowPasteIcon;
            fontCheckBox.Checked = StylesClass.ShowFontIcon;
            boldCheckBox.Checked = StylesClass.ShowBoldIcon;
            italicCheckBox.Checked = StylesClass.ShowItalicIcon;
            underlineCheckBox.Checked = StylesClass.ShowNewIcon;

            //BackColor of text area
            backColorButton.BackColor = StylesClass.BackColor;

            //Laguage
            defaultLanguageColorButton.BackColor = StylesClass.DefaultLanguageColor;
            keywordsColorButton.BackColor = StylesClass.KeywordsColor;
            stringsColorButton.BackColor = StylesClass.StringsColor;
            commentLinesColorButton.BackColor = StylesClass.CommentLinesColor;
            commentBlocksColorButton.BackColor = StylesClass.CommentBlocksColor;
            defaultLaguageComboBox.Text = StylesClass.DefaultLanguage;

            //Others
            documentMapBackColorButton.BackColor = StylesClass.DocumentMapBackColor;
            documentMapForeColorButton.BackColor = StylesClass.DocumentMapForeColor;
            numberMarginBackColorButton.BackColor = StylesClass.NumberMarginBackColor;
            numberMarginForeColorButton.BackColor = StylesClass.NumberMarginForeColor;
            bookmarkMarginBackColorButton.BackColor = StylesClass.BookmarkMarginBackColor;
            bookmarkMarginForeColorButton.BackColor = StylesClass.BookmarkMarginForeColor;



            //event
            defaultThemeRadioButton.CheckedChanged += themeRadioButton_CheckedChanged;
            darkThemeRadioButton.CheckedChanged += themeRadioButton_CheckedChanged;
            customThemeRadioButton.CheckedChanged += themeRadioButton_CheckedChanged;

        }

        private void menuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (menuListBox.SelectedItem.ToString())
            {
                case "General":
                    {
                        languagePanel.Visible = false;
                        generalPanel.Visible = true;
                        othersPanel.Visible = false;
                        break;
                    }
                case "Language":
                    {
                        languagePanel.Visible = true;
                        generalPanel.Visible = false;
                        othersPanel.Visible = false;
                        break;
                    }
                case "Others":
                    {
                        languagePanel.Visible = false;
                        generalPanel.Visible = false;
                        othersPanel.Visible = true;
                        break;
                    }
            }
        }

        private void themeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == false) return;
            switch ((sender as RadioButton).Name)
            {
                case "defaultThemeRadioButton":
                    {
                        foreach(TabPage tabpage in TabControlClass.TabControl.TabPages)
                        {
                            TextArea textArea = (tabpage.Controls[0] as MyRichTextBox).TextArea;
                            textArea.DefaultLanguageColor = Color.Black;
                            textArea.BackColor = Color.White;
                            textArea.TriggerTextAreaStyle(textArea.Language);
                        }


                        StylesClass.SaveSetting("Settings/UserSettings/General/Theme", "Default");
                        break;
                    }
                case "darkThemeRadioButton":
                    {
                        foreach (TabPage tabpage in TabControlClass.TabControl.TabPages)
                        {
                            TextArea textArea = (tabpage.Controls[0] as MyRichTextBox).TextArea;
                            textArea.DefaultLanguageColor = Color.White;
                            textArea.BackColor = Color.Black;
                            textArea.TriggerTextAreaStyle(textArea.Language);
                        }


                        StylesClass.SaveSetting("Settings/UserSettings/General/Theme", "Dark");
                        break;
                    }
                case "customThemeRadioButton":
                    {
                        foreach (TabPage tabpage in TabControlClass.TabControl.TabPages)
                        {
                            TextArea textArea = (tabpage.Controls[0] as MyRichTextBox).TextArea;
                            textArea.DefaultLanguageColor = defaultLanguageColorButton.BackColor;
                            textArea.ClearBackColor(backColorButton.BackColor);
                            textArea.BackColor = backColorButton.BackColor;
                            textArea.TriggerTextAreaStyle(textArea.Language);
                        }


                        StylesClass.SaveSetting("Settings/UserSettings/General/Theme", "Custom");
                        break;
                    }
            }
        }

        private void backColorDialogButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            //if (customThemeRadioButton.Checked == false) return;
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.BackColor = backColorButton.BackColor;
                textArea.ClearBackColor(backColorButton.BackColor);
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/General/BackColor",backColorButton.BackColor.ToArgb().ToString());
            
        }

        private void showStatusBarCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.StatusBar.Visible = showStatusBarCheckBox.Checked ? true : false;

            //show status bar
            StylesClass.SaveSetting("Settings/UserSettings/General/ShowStatusBar",showStatusBarCheckBox.Checked.ToString());

        }

        private void hideTaskBarcheckBox_Click(object sender, EventArgs e)
        {
            MainForm.TaskBar.Visible = hideTaskBarCheckBox.Checked ? false : true;

            //show status bar
            StylesClass.SaveSetting("Settings/UserSettings/General/HideTaskBar", hideTaskBarCheckBox.Checked.ToString());

        }

        private void newCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.NewButton.Visible = newCheckBox.Checked ? true : false;

            StylesClass.SaveSetting("Settings/UserSettings/General/New",newCheckBox.Checked.ToString());
        }

        private void openCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.OpenButton.Visible = openCheckBox.Checked ? true : false;

            StylesClass.SaveSetting("Settings/UserSettings/General/Open", openCheckBox.Checked.ToString());
            

        }

        private void saveCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.SaveButton.Visible = saveCheckBox.Checked ? true : false;

            StylesClass.SaveSetting("Settings/UserSettings/General/Save", saveCheckBox.Checked.ToString());
            
        }

        private void findCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.FindButton.Visible = findCheckBox.Checked ? true : false;

            StylesClass.SaveSetting("Settings/UserSettings/General/Find", findCheckBox.Checked.ToString());
            
        }

        private void documentMapCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.MapButton.Visible = documentMapCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/DocumentMap", documentMapCheckBox.Checked.ToString());
            
        }

        private void findAndReplaceCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.FindAndReplaceButton.Visible = findAndReplaceCheckBox.Checked ? true : false;

            StylesClass.SaveSetting("Settings/UserSettings/General/FindAndReplace", findAndReplaceCheckBox.Checked.ToString());
            
        }

        private void upperCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.ToUpperButton.Visible = upperCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/ToUpper", upperCheckBox.Checked.ToString());
            
        }

        private void versionsCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.VersionsButton.Visible = versionsCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Versions", versionsCheckBox.Checked.ToString());
            
        }

        private void copyCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.CopyButton.Visible = copyCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Copy", copyCheckBox.Checked.ToString());
            
        }

        private void cutCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.CutButton.Visible = cutCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Cut", cutCheckBox.Checked.ToString());
            
        }

        private void pasteCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.PasteButton.Visible = pasteCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Paste", pasteCheckBox.Checked.ToString());
            
        }

        private void fontCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.FontButton.Visible = fontCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Font", fontCheckBox.Checked.ToString());
            
        }

        private void boldCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.BoldButton.Visible = boldCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Bold", boldCheckBox.Checked.ToString());
            
        }

        private void italicCheckBox_Click(object sender, EventArgs e)
        {
            MainForm.ItalicButton.Visible = italicCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Italic", italicCheckBox.Checked.ToString());
            
        }

        private void underlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.UnderLineButton.Visible = underlineCheckBox.Checked ? true : false;
            StylesClass.SaveSetting("Settings/UserSettings/General/Underline", underlineCheckBox.Checked.ToString());
            
        }

        private void ShowColorDialog(Button sender)
        {
     
            colorDialog.Color = sender.BackColor;
            colorDialog.ShowDialog();
            sender.BackColor = colorDialog.Color;
        }

        private void defaultColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.DefaultLanguageColor = defaultLanguageColorButton.BackColor;
                textArea.TriggerTextAreaStyle(textArea.Language);
            }


            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/TextArea/DefaultColor", defaultLanguageColorButton.BackColor.ToArgb().ToString());
            
        }

        private void keywordColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.KeyWordsColor = keywordsColorButton.BackColor;
                textArea.TriggerTextAreaStyle(textArea.Language);
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/TextArea/KeywordsColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void stringsColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.StringsColor = stringsColorButton.BackColor;
                textArea.TriggerTextAreaStyle(textArea.Language);
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/TextArea/StringsColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void commentLinesColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.CommentLinesColor = commentLinesColorButton.BackColor;
                textArea.TriggerTextAreaStyle(textArea.Language);
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/TextArea/CommentLinesColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void commentBlocksColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.CommentBlocksColor = commentBlocksColorButton.BackColor;
                textArea.TriggerTextAreaStyle(textArea.Language);
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/TextArea/CommentBlocksColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void documentMapBackColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.DocumentMap.BackColor = documentMapBackColorButton.BackColor;
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/DocumentMap/BackColor", (sender as Button).BackColor.ToArgb().ToString());
            

        }

        private void documentMapForeColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.DocumentMap.ForeColor = documentMapForeColorButton.BackColor;
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/DocumentMap/ForeColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void numberMarginBackColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.NumberMargin.BackColor = numberMarginBackColorButton.BackColor;
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/NumberMargin/BackColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void numberMarginForeColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.NumberMargin.NumberBrush = new SolidBrush(numberMarginForeColorButton.BackColor);
                textArea.NumberMargin.Refresh();
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings/NumberMargin/ForeColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void bookmarkMarginBackColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.BookMarkMargin.BackColor = bookmarkMarginBackColorButton.BackColor;
            }

            //save to xml
            StylesClass.SaveSetting("Settings/UserSettings//BookmarkMargin/BackColor", (sender as Button).BackColor.ToArgb().ToString());
            
        }

        private void bookmarkMarginForeColorButton_Click(object sender, EventArgs e)
        {
            ShowColorDialog((Button)sender);
            foreach (TabPage tabPage in TabControlClass.TabControl.TabPages)
            {
                TextArea textArea = (tabPage.Controls[0] as MyRichTextBox).TextArea;
                textArea.BookMarkMargin.BookMarkBrush = new SolidBrush(bookmarkMarginForeColorButton.BackColor);
                textArea.BookMarkMargin.Refresh();

                //save to xml
                StylesClass.SaveSetting("Settings/UserSettings/BookmarkMargin/ForeColor", (sender as Button).BackColor.ToArgb().ToString());
                
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void defaultLaguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StylesClass.SaveSetting("Settings/UserSettings/TextArea/DefaultLanguage", defaultLaguageComboBox.SelectedItem.ToString());
            
        }

        private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void setDefaultButton_Click(object sender, EventArgs e)
        {
            StylesClass.SaveAsDefaultStyles();
            
            MessageBox.Show("Close the program to apply the setting","",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
