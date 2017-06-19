using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace MyTextBox
{
    public partial class TextArea : RichTextBox
    {

        #region Fields

        //Save the Caret position before and after TextChanged event
        private int previousCaret = 0;
        private int currentCaret = 0;
        //the control to focus when highlighing to avoid flickings 
        private Control controlToFocus = null;
        //Syntax color
        private Color defaultLanguageColor = Color.Black;
        private Color keyWordsColor = Color.Blue;
        private Color commentLinesColor = Color.Green;
        private Color commentBlocksColor = Color.DarkGreen;
        private Color preprocessorsColor = Color.Gray;
        private Color stringsColor = Color.Brown;
        //language
        private string language = "NormalText";

        //auto complete listbox
        private ListBox autoCompleteListBox = null;
        private bool autoCompleteEnabled = false;
        //private bool isShownAutoCompleteListBox = false;

        //first and last visible line currently in the screen
        private int firstVisibleLine = 0;
        private int lastVisibleLine = 0;
        //first and last visible character index currently in the screen
        private int firstVisibleCharIndex = 0;
        private int lastVisibleCharIndex = 0;

        //the control to focus when highlighing to avoid flickings 
        private BookMarkMargin bookMarkMargin = null;
        private DocumentMap documentMap = null;
        private NumberMargin numberMargin = null;

        //tab size
        private int tabSize = 4;

        //a boolean variable to help us prevent the record of undo action
        private bool blockRecordingUndo = false;

        //a boolean variable to help us prevent the record of undo action, hightlight, ...
        private bool blockAllAction = false;

        //this struct hold all information about an undo or redo action 
        private struct UndoRedoInfomation
        {
            public string Text;
            public string ActionName;
            public int SelectionStart;

            public string ReverseText;
            public string ReverseActionName;
        };
        //Undo and redo stack
        Stack<UndoRedoInfomation> undoStack = null;
        Stack<UndoRedoInfomation> redoStack = null;
        //current undo action
        UndoRedoInfomation currentUndoAction;

        //Code folding
        public int NumberOfLine { get { return Lines.Length; } private set { } }
        private List<SectionDelimiter> regexList = new List<SectionDelimiter>();
        public List<SectionPosition> nestedList = new List<SectionPosition>();
        private SortedDictionary<int, FoldedState> foldedList = new SortedDictionary<int, FoldedState>();
        private int lineOffset = 5;

        #region All fields related to printing action

        //Reference:https://support.microsoft.com/en-us/help/812425/how-to-print-the-content-of-a-richtextbox-control-by-using-visual-c-.net-or-visual-c-2005
        //Convert the unit that is used by the .NET framework (1/100 inch) 
        //and the unit that is used by Win32 API calls (twips 1/1440 inch)
        private const double anInch = 14.4;
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        };
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            // First character of range (0 for start of doc)
            public int cpMin;
            // Last character of range (-1 for end of doc)
            public int cpMax;
        };
        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;               // Actual DC to draw on //Handle device context
            public IntPtr hdcTarget;       // Target DC for determining text formatting
            public RECT rc;              // Region of the DC to draw to (in twips)
            public RECT rcPage;            //Region of the whole DC (page size) (in twips)
            public CHARRANGE chrg;      // Range of text to draw (see above declaration)
        };

        #endregion


        #endregion

        #region Properties

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Coder")]
        public Control ControlToFocus
        {
            get
            {
                return controlToFocus;
            }
            set
            {
                controlToFocus = value;
            }
        }

        public Color KeyWordsColor { get { return keyWordsColor; } set { keyWordsColor = value; } }
        public Color CommentLinesColor { get { return commentLinesColor; } set { commentLinesColor = value; } }
        public Color CommentBlocksColor { get { return commentBlocksColor; } set { commentBlocksColor = value; } }
        public Color PreprocessorsColor { get { return preprocessorsColor; } set { preprocessorsColor = value; } }
        public Color StringsColor { get { return stringsColor; } set { stringsColor = value; } }
        public Color DefaultLanguageColor { get { return defaultLanguageColor; } set { defaultLanguageColor = value; } }
        public int FirstVisibleLine { get { return firstVisibleLine; } set { firstVisibleLine = value; } }
        public int LastVisibleLine { get { return lastVisibleLine; } set { lastVisibleLine = value; } }
        public int FirstVisibleCharIndex { get { return firstVisibleCharIndex; } set { firstVisibleCharIndex = value; } }
        public int LastVisibleCharIndex { get { return lastVisibleCharIndex; } set { lastVisibleCharIndex = value; } }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Coder")]
        public BookMarkMargin BookMarkMargin { get { return bookMarkMargin; } set { bookMarkMargin = value; } }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Coder")]
        public DocumentMap DocumentMap { get { return documentMap; } set { documentMap = value; } }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Coder")]
        public NumberMargin NumberMargin { get { return numberMargin; } set { numberMargin = value; numberMargin.MouseClick += NumberMargin_MouseClick; } }
        public string Language { get { return language; } set { language = value; } }
        public int TabSize { get { return tabSize; } set { tabSize = value; } }
        public bool BlockAllAction { get { return blockAllAction; } set { blockAllAction = value; } }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public TextArea()
        {
            InitializeComponent();

            //some setups
            this.AcceptsTab = true;
            this.WordWrap = false;
            AutoComplete(true);

            //add completelistbox to this control
            this.Controls.Add(autoCompleteListBox);
            autoCompleteListBox.Visible = false;

            //Undo and redo stack
            undoStack = new Stack<UndoRedoInfomation>();
            redoStack = new Stack<UndoRedoInfomation>();

            //current undo action
            currentUndoAction = new UndoRedoInfomation();

            currentUndoAction.Text = "";
            currentUndoAction.ActionName = "";
            currentUndoAction.SelectionStart = 0;
            currentUndoAction.ReverseText = "";
            currentUndoAction.ReverseActionName = "";

            //add regex for code folding
            regexList.Add(new SectionDelimiter() { Start = "\\{", End = "\\}" });
            //set up for line margin click
        }

       

        /// <summary>
        /// Syntax Highlighting, show autocompletebox on text changed, ...
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (BlockAllAction == false)
            {
                //just a function to set tab size
                SetTabSizeOnTextArea(tabSize);

                //Calculate Undo stack
                //Redo will be calculated based on Undo actions
                AutoCalculateUndo();

                //Calculate syntax highlight
                AutoSyntaxHighLight(language);

                //auto indentation
                AutoIndentationAndBraceMatching(language);

                //Show autocomplete listbox
                AutoShowCompleteListBox(language);

                //Code folding
                AutoCodeFolding(language);

            }

            #region Refresh bookmark margin, number margin and document map on text changed
            //Just some essential calculations for number margin, document map, .... //
            //Get the first and last char index currently visible in the screen
            firstVisibleCharIndex = this.GetCharIndexFromPosition(new Point(0, 0));
            lastVisibleCharIndex = this.GetCharIndexFromPosition(new Point(this.Width, this.Height));

            //Get the first and last line currently visible in the screen
            firstVisibleLine = this.GetLineFromCharIndex(firstVisibleCharIndex);
            lastVisibleLine = this.GetLineFromCharIndex(lastVisibleCharIndex);

            //refresh number margin on text changed
            numberMargin.Invalidate();
            //if (numberMargin != null && numberMargin.IsNeededAutoNumbering)
            //{
            //    numberMargin.CalculateOnTextAreaTextChanged();
            //}

            //refresh bookmark margin on text changed
            if (BookMarkMargin != null && bookMarkMargin.IsNeededAutoBookMark)
            {
                bookMarkMargin.CalculateOnTextAreaTextChanged();
            }

            //refresh document on text changed
            if (documentMap != null && documentMap.IsNeededAutoDocumentMap)
            {
                documentMap.Refresh();
            }

            #endregion


        }

        #region All the calculations for Undo and Redo here (Control autocompletelistbox here too)

        /// <summary>
        /// Override ProcessCmdKey to have full control of autocompletelistbox
        /// And catch keys down to control Undo Action
        /// </summary>
        /// <param name="m"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            //Control ListBox//
            //If an auto complete list box has already shown
            if (autoCompleteListBox.Visible/*isShownAutoCompleteListBox*/)
            {
                switch (keyData)
                {
                    //move down to the next auto complete words
                    case Keys.Down:
                        {

                            if (autoCompleteListBox.SelectedIndex != autoCompleteListBox.Items.Count - 1)
                            {
                                autoCompleteListBox.SelectedIndex += 1;
                            }
                            return true;

                        }
                    //move up to the next auto complete words
                    case Keys.Up:
                        {
                            if (autoCompleteListBox.SelectedIndex != 0)
                            {
                                autoCompleteListBox.SelectedIndex -= 1;
                            }
                            return true;

                        }
                    //insert selected auto complete word
                    case Keys.Enter:
                    case Keys.Tab:
                        {
                            //set this to block the records of undo and redo 
                            blockRecordingUndo = true;

                            //Focus another control to avoil flicking
                            if (controlToFocus != null)
                            {
                                controlToFocus.Focus();
                            }

                            //Get the appropriate text to replace by auto complete word 
                            this.SelectionStart = GetWordStartPosition(SelectionStart);
                            this.SelectionLength = GetCurrentWord().Length;
                            this.SelectedText = autoCompleteListBox.SelectedItem.ToString() + " ";

                            //focus to this control for further typeing
                            this.Focus();


                            //make list box disappear by clear all the control from text area
                            //this.Controls.Clear();
                            //set this thing
                            //isShownAutoCompleteListBox = false;
                            autoCompleteListBox.Visible = false;

                            //allow continuously recording undo and redo action
                            blockRecordingUndo = false;

                            return true;
                        }
                }
            }


            //Control Undo action //
            //save the current undo action
            switch (keyData)
            {
                case Keys.Enter:
                    {
                        currentUndoAction.ActionName = "DeEnter";
                        currentUndoAction.SelectionStart = this.SelectionStart;
                        currentUndoAction.Text = this.SelectedText;
                        break;
                    }
                case Keys.Back:
                case Keys.Delete:
                    {
                        if (this.SelectedText != "")
                        {
                            currentUndoAction.ActionName = "DeSelectedDelete";
                            currentUndoAction.SelectionStart = this.SelectionStart;
                            currentUndoAction.Text = this.SelectedText;
                        }
                        else
                        {
                            currentUndoAction.SelectionStart = this.SelectionStart;
                            currentUndoAction.Text = "";
                            if (this.Text.Length > 0)
                            {
                                currentUndoAction.Text = this.Lines[this.GetLineFromCharIndex(this.SelectionStart)];
                            }
                            if (currentUndoAction.Text != "")
                            {
                                currentUndoAction.ActionName = "DeTextLineDelete";
                            }
                            else
                            {
                                currentUndoAction.ActionName = "DeLineDelete";
                            }
                        }

                        break;
                    }
                default:
                    {

                        if (this.SelectedText != "")
                        {
                            currentUndoAction.ActionName = "DeSelectedInsert";
                            currentUndoAction.SelectionStart = this.SelectionStart;
                            currentUndoAction.Text = this.SelectedText;
                        }
                        else
                        {
                            currentUndoAction.SelectionStart = this.SelectionStart;
                            currentUndoAction.ActionName = "DeCharInsert";
                            currentUndoAction.Text = "";
                            if (this.Text.Length > 0)
                            {
                                currentUndoAction.Text = this.Lines[this.GetLineFromCharIndex(this.SelectionStart)];
                            }
                        }


                        break;
                    }
            }
            //save current undo action
            if (keyData == (Keys.V | Keys.Control))
            {
                currentUndoAction.ActionName = "DeCtrlVInsert";
                currentUndoAction.SelectionStart = this.SelectionStart;
                currentUndoAction.Text = this.SelectedText;
                currentUndoAction.ReverseText = Clipboard.GetText(TextDataFormat.Text);
            }
            else
            {
                if (keyData == (Keys.X | Keys.Control))
                {
                    currentUndoAction.ActionName = "DeSelectedDelete";
                    currentUndoAction.SelectionStart = this.SelectionStart;
                    currentUndoAction.Text = this.SelectedText;
                }
                //Undo and Redo
                else
                {
                    if (keyData == (Keys.Z | Keys.Control))
                    {
                        //Undo
                        Undo();

                        //handled
                        return true;

                    }
                    else
                    {
                        //if we press ctrl Y, redo
                        if (keyData == (Keys.Y | Keys.Control))
                        {

                            //Redo
                            Redo();

                            //handled
                            return true;
                        }

                    }
                }
            }


            return base.ProcessCmdKey(ref m, keyData);

        }

        /// <summary>
        /// Calculate undo stack
        /// Note that each word, each enter key or backspace key is considered an undo action 
        /// </summary>
        private void AutoCalculateUndo()
        {

            if (blockRecordingUndo == true) return;


            //Clear redo stack, this is very important
            //Since this function is complemented in OnTextChanged event and RedoStack is completely based on Undo actions
            //that's why clear redo stack each time we go to this function make sense
            //I don't know what exactly to explain here, but you can just try undo and redo system of Visual and you will understand just fine
            redoStack.Clear();

            switch (currentUndoAction.ActionName)
            {
                case "DeEnter":
                    {
                        currentUndoAction.ReverseActionName = "Enter";
                        currentUndoAction.ReverseText = "\n";
                        break;
                    }
                case "DeSelectedDelete":
                    {
                        currentUndoAction.ReverseActionName = "SelectedDelete";
                        currentUndoAction.ReverseText = "";
                        break;
                    }
                case "DeTextLineDelete":
                    {
                        currentUndoAction.ReverseActionName = "TextLineDelete";
                        if (this.Text.Length > 0)
                        {
                            currentUndoAction.ReverseText = this.Lines[this.GetLineFromCharIndex(this.SelectionStart)];
                        }
                        else
                        {
                            currentUndoAction.ReverseText = "";
                        }
                        break;
                    }
                case "DeLineDelete":
                    {
                        currentUndoAction.ReverseActionName = "LineDelete";
                        currentUndoAction.ReverseText = "";
                        break;
                    }
                case "DeCtrlVInsert":
                    {
                        currentUndoAction.ReverseActionName = "CtrlVInsert";
                        break;
                    }
                case "DeSelectedInsert":
                    {
                        currentUndoAction.ReverseActionName = "SelectedInsert";
                        //string lineText = this.Lines[this.GetLineFromCharIndex(this.SelectionStart)];
                        //currentUndoAction.ReverseText = lineText.Substring(lineText.Length - 1);
                        currentUndoAction.ReverseText = this.Text[SelectionStart - 1].ToString();
                        break;
                    }
                case "DeCharInsert":
                    {
                        currentUndoAction.ReverseActionName = "CharInsert";
                        if (this.Text.Length > 0)
                            currentUndoAction.ReverseText = this.Lines[this.GetLineFromCharIndex(this.SelectionStart)];
                        else
                            currentUndoAction.ReverseText = "";
                        break;
                    }

            }


            //if undostack is empty, just add an undo action
            if (undoStack.Count <= 0)
            {
                undoStack.Push(currentUndoAction);
            }
            else
            {
                //if current undo action is enter or delete (this means in the previous action, we have pressed enter key or backspace key  
                if (currentUndoAction.ActionName == "DeEnter" || currentUndoAction.ActionName == "DeSelectedDelete"
                    || currentUndoAction.ActionName == "DeTextLineDelete" || currentUndoAction.ActionName == "DeLineDelete"
                    || currentUndoAction.ActionName == "DeCtrlVInsert" || currentUndoAction.ActionName == "DeSelectedInsert")
                {
                    undoStack.Push(currentUndoAction);
                }
                else //DeCharInsert
                {
                    //Note that undoAction means the previous action of us (also mean current undo action), not the current action
                    //And don't get confused between previous action and previous undo action (they are different from each other)
                    //get the peek of undoStack to check something later (the peek also means previous undo action)
                    UndoRedoInfomation previousUndoAction = undoStack.Peek();

                    if (this.GetLineFromCharIndex(currentUndoAction.SelectionStart) != this.GetLineFromCharIndex(previousUndoAction.SelectionStart))
                    {
                        undoStack.Push(currentUndoAction);
                        return;
                    }

                    //get last character of previous undo action
                    string lastCharOfPeek = "";
                    if (previousUndoAction.ReverseText.Length > 0)
                    {
                        lastCharOfPeek = previousUndoAction.ReverseText.Substring(previousUndoAction.ReverseText.Length - 1);
                    }

                    //get last character of current undo action
                    string lastCharOfUndoActionText = "";
                    if (currentUndoAction.ReverseText != "")
                    {
                        lastCharOfUndoActionText = currentUndoAction.ReverseText.Substring(currentUndoAction.ReverseText.Length - 1);
                    }

                    //If the last character of both undoAction.Text and undoStack.Peek().Text are the space or tab or character,
                    if ((lastCharOfUndoActionText == " " && lastCharOfPeek == " ") || (lastCharOfUndoActionText == "\t" && lastCharOfPeek == "\t")
                        || (Regex.IsMatch(lastCharOfUndoActionText, @"\S") && Regex.IsMatch(lastCharOfPeek, @"\S")))
                    {
                        currentUndoAction.Text = previousUndoAction.Text;
                        currentUndoAction.SelectionStart = previousUndoAction.SelectionStart;
                        undoStack.Pop();
                        undoStack.Push(currentUndoAction);
                    }
                    else
                    {
                        undoStack.Push(currentUndoAction);
                    }
                }
            }

        }

        /// <summary>
        /// Undo
        /// </summary>
        public new void Undo()
        {
            //set this to prevent recording undo and redo
            blockRecordingUndo = true;

            if (undoStack.Count > 0)
            {

                //focus another control to avoid flicking
                if (controlToFocus != null)
                {
                    controlToFocus.Focus();
                }

                //get the undo action 
                UndoRedoInfomation undoAction = undoStack.Pop();

                //redo action
                UndoRedoInfomation redoAction = new UndoRedoInfomation();
                redoAction.Text = undoAction.ReverseText;
                redoAction.ActionName = undoAction.ReverseActionName;
                redoAction.ReverseText = undoAction.Text;
                redoAction.ReverseActionName = undoAction.ActionName;
                redoAction.SelectionStart = undoAction.SelectionStart;
                //redoAction.ReverseSelectionStart = undoAction.SelectionStart;

                redoStack.Push(redoAction);

                if (this.Lines.Length > 0)
                {
                    switch (undoAction.ActionName)
                    {
                        case "DeEnter":
                            {
                                this.SelectionStart = undoAction.SelectionStart;
                                this.SelectionLength = 1;
                                //retrieve the text of this line
                                this.SelectedText = undoAction.Text;
                                break;
                            }
                        case "DeSelectedDelete":
                            {
                                this.SelectionStart = undoAction.SelectionStart;
                                //retrieve the text of this line
                                this.SelectedText = undoAction.Text;

                                //retrieve selection area
                                this.SelectionStart = undoAction.SelectionStart;
                                this.SelectionLength = undoAction.Text.Length;
                                break;
                            }
                        case "DeLineDelete":
                            {
                                this.SelectionStart = undoAction.SelectionStart;
                                this.SelectionLength = 0;
                                this.SelectedText = "\n";
                                break;
                            }
                        case "DeTextLineDelete":
                            {
                                this.SelectionStart = this.GetFirstCharIndexFromLine(this.GetLineFromCharIndex(undoAction.SelectionStart));
                                this.SelectionLength = this.Lines[this.GetLineFromCharIndex(undoAction.SelectionStart)].Length;
                                this.SelectedText = undoAction.Text;

                                break;
                            }
                        case "DeSelectedInsert":
                            {
                                this.SelectionStart = undoAction.SelectionStart;
                                this.SelectionLength = 1;
                                //retrieve the text of this line
                                this.SelectedText = undoAction.Text;

                                //retrieve selection area
                                this.SelectionStart = undoAction.SelectionStart;
                                this.SelectionLength = undoAction.Text.Length;

                                break;
                            }
                        case "DeCharInsert":
                            {
                                this.SelectionStart = this.GetFirstCharIndexFromLine(this.GetLineFromCharIndex(undoAction.SelectionStart));
                                this.SelectionLength = this.Lines[this.GetLineFromCharIndex(undoAction.SelectionStart)].Length;
                                this.SelectedText = undoAction.Text;
                                break;
                            }
                        case "DeCtrlVInsert":
                            {
                                this.SelectionStart = undoAction.SelectionStart;
                                this.SelectionLength = undoAction.ReverseText.Length;
                                //retrieve the text of this line
                                this.SelectedText = undoAction.Text;

                                //retrieve selection area
                                this.SelectionStart = undoAction.SelectionStart;
                                this.SelectionLength = undoAction.Text.Length;

                                break;
                            }
                    }

                }
                else
                {
                    this.AppendText(undoAction.Text);
                }

            }

            //focus 
            this.Focus();

            //set this to allow continuing recording undo and redo
            blockRecordingUndo = false;
        }

        /// <summary>
        /// Redo
        /// </summary>
        public new void Redo()
        {
            blockRecordingUndo = true;

            if (redoStack.Count > 0)
            {
                //Focus another control to avoid flicking
                controlToFocus.Focus();

                //get redo action
                UndoRedoInfomation redoAction = redoStack.Pop();

                //undo action
                UndoRedoInfomation undoAction = new UndoRedoInfomation();
                undoAction.Text = redoAction.ReverseText;
                undoAction.ActionName = redoAction.ReverseActionName;
                undoAction.ReverseText = redoAction.Text;
                undoAction.ReverseActionName = redoAction.ActionName;
                undoAction.SelectionStart = redoAction.SelectionStart;
                //undoAction.ReverseSelectionStart = redoAction.SelectionStart;
                undoStack.Push(undoAction);

                if (this.Lines.Length > 0)
                {
                    switch (redoAction.ActionName)
                    {
                        case "Enter":
                            {
                                this.SelectionStart = redoAction.SelectionStart;
                                this.SelectionLength = redoAction.ReverseText.Length;
                                this.SelectedText = redoAction.Text;
                                break;
                            }
                        case "SelectedDelete":
                            {
                                this.SelectionStart = redoAction.SelectionStart;
                                this.SelectionLength = redoAction.ReverseText.Length;
                                this.SelectedText = redoAction.Text;

                                //retrieve selection area
                                this.SelectionStart = redoAction.SelectionStart;
                                this.SelectionLength = redoAction.Text.Length;

                                break;
                            }
                        case "LineDelete":
                            {
                                this.SelectionStart = redoAction.SelectionStart - 1;
                                this.SelectionLength = 1;
                                this.SelectedText = "";
                                break;
                            }
                        case "TextLineDelete":
                            {
                                this.SelectionStart = this.GetFirstCharIndexFromLine(this.GetLineFromCharIndex(redoAction.SelectionStart));
                                this.SelectionLength = this.Lines[this.GetLineFromCharIndex(redoAction.SelectionStart)].Length;
                                this.SelectedText = redoAction.Text;
                                break;
                            }
                        case "SelectedInsert":
                            {
                                this.SelectionStart = redoAction.SelectionStart;
                                this.SelectionLength = redoAction.ReverseText.Length;
                                //retrieve the text of this line
                                this.SelectedText = redoAction.Text;

                                //retrieve selection area
                                this.SelectionStart = redoAction.SelectionStart;
                                this.SelectionLength = redoAction.Text.Length;

                                break;
                            }
                        case "CharInsert":
                            {
                                this.SelectionStart = this.GetFirstCharIndexFromLine(this.GetLineFromCharIndex(redoAction.SelectionStart));
                                this.SelectionLength = this.Lines[this.GetLineFromCharIndex(redoAction.SelectionStart)].Length;
                                this.SelectedText = redoAction.Text;
                                break;
                            }
                        case "CtrlVInsert":
                            {
                                this.SelectionStart = redoAction.SelectionStart;
                                this.SelectionLength = redoAction.ReverseText.Length;
                                //retrieve the text of this line
                                this.SelectedText = redoAction.Text;

                                //retrieve selection area
                                this.SelectionStart = redoAction.SelectionStart;
                                this.SelectionLength = redoAction.Text.Length;

                                break;
                            }
                    }

                }
                else
                {
                    this.AppendText(redoAction.Text);
                }

            }

            //focus
            this.Focus();

            //set triggered
            blockRecordingUndo = false;
        }

        public new bool CanUndo()
        {
            if (undoStack.Count > 0)
            {
                return true;
            }
            return false;
        }

        public new bool CanRedo()
        {
            if (redoStack.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void StopRecordingUndo()
        {
            blockRecordingUndo = true;
        }

        public void ContinueRecordingUndo()
        {
            blockRecordingUndo = false;
        }

        /// <summary>
        /// Ctrl + X
        /// </summary>
        public void DoCut()
        {
            currentUndoAction.ActionName = "DeSelectedDelete";
            currentUndoAction.SelectionStart = this.SelectionStart;
            currentUndoAction.Text = this.SelectedText;
            this.Cut();
        }

        /// <summary>
        /// Ctrl + V
        /// </summary>
        public void DoPaste()
        {
            currentUndoAction.ActionName = "DeCtrlVInsert";
            currentUndoAction.SelectionStart = this.SelectionStart;
            currentUndoAction.Text = this.SelectedText;
            currentUndoAction.ReverseText = Clipboard.GetText(TextDataFormat.Text);
            this.Paste();
        }

        /// <summary>
        /// Clear all the Text
        /// </summary>
        public void DoClear()
        {
            currentUndoAction.ActionName = "DeSelectedDelete";
            currentUndoAction.SelectionStart = 0;
            currentUndoAction.Text = this.Text;
            this.Clear();
        }

        #endregion

        #region Refresh bookmark margin, number margin and document map on resize, contents resized and Vscroll

        /// <summary>
        /// Refresh bookmark margin, document map, number margin on resize
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //Get the first and last char index currently visible in the screen
            firstVisibleCharIndex = this.GetCharIndexFromPosition(new Point(0, 0));
            lastVisibleCharIndex = this.GetCharIndexFromPosition(new Point(this.Width, this.Height));

            //Get the first and last line currently visible in the screen
            firstVisibleLine = this.GetLineFromCharIndex(firstVisibleCharIndex);
            lastVisibleLine = this.GetLineFromCharIndex(lastVisibleCharIndex);

            //Redraw the folding
            AutoCodeFolding(language);

            if (numberMargin != null && numberMargin.IsNeededAutoNumbering)
            {
                numberMargin.CalculateOnTextAreaResize();
            }

            if (BookMarkMargin != null && bookMarkMargin.IsNeededAutoBookMark)
            {
                bookMarkMargin.CalculateOnTextAreaResize();
            }

            if (documentMap != null && documentMap.IsNeededAutoDocumentMap)
            {
                documentMap.Refresh();
            }


        }

        /// <summary>
        /// Refresh bookmark margin, document map, number margin OnContentsResized
        /// </summary>
        /// <param name="e"></param>
        protected override void OnContentsResized(ContentsResizedEventArgs e)
        {
            base.OnContentsResized(e);
            //Get the first and last char index currently visible in the screen
            firstVisibleCharIndex = this.GetCharIndexFromPosition(new Point(0, 0));
            lastVisibleCharIndex = this.GetCharIndexFromPosition(new Point(this.Width, this.Height));

            //Get the first and last line currently visible in the screen
            firstVisibleLine = this.GetLineFromCharIndex(firstVisibleCharIndex);
            lastVisibleLine = this.GetLineFromCharIndex(lastVisibleCharIndex);

            //Redraw the folding
            AutoCodeFolding(language);

            if (numberMargin != null && numberMargin.IsNeededAutoNumbering)
            {
                numberMargin.CalculateOnTextAreaContentsResized();
            }

            if (BookMarkMargin != null && bookMarkMargin.IsNeededAutoBookMark)
            {
                bookMarkMargin.CalculateOnTextAreaContentsResized();
            }

            if (documentMap != null && documentMap.IsNeededAutoDocumentMap)
            {
                documentMap.Refresh();
            }


        }

        /// <summary>
        /// Refresh bookmark margin, document map, number margin OnVScroll
        /// </summary>
        /// <param name="e"></param>
        protected override void OnVScroll(EventArgs e)
        {
            base.OnVScroll(e);
            //Get the first and last char index currently visible in the screen
            firstVisibleCharIndex = this.GetCharIndexFromPosition(new Point(0, 0));
            lastVisibleCharIndex = this.GetCharIndexFromPosition(new Point(this.Width, this.Height));

            //Get the first and last line currently visible in the screen
            firstVisibleLine = this.GetLineFromCharIndex(firstVisibleCharIndex);
            lastVisibleLine = this.GetLineFromCharIndex(lastVisibleCharIndex);

            //Redraw the folding
            AutoCodeFolding(language);

            if (numberMargin != null && numberMargin.IsNeededAutoNumbering)
            {
                numberMargin.CalculateOnTextAreaVScroll();
            }

            if (BookMarkMargin != null && bookMarkMargin.IsNeededAutoBookMark)
            {
                bookMarkMargin.CalculateOnTextAreaVScroll();
            }


            if (documentMap != null && documentMap.IsNeededAutoDocumentMap)
            {
                documentMap.Refresh();
            }
        }

        #endregion

        #region All the things related to Auto Complete here

        /// <summary>
        /// Enable AutoComplete
        /// </summary>
        /// <param name="language"></param>
        public void AutoComplete(bool enabled)
        {
            if (enabled == true)
            {
                autoCompleteListBox = new ListBox();
                autoCompleteListBox.GotFocus -= ListBox_GotFocus;
                autoCompleteListBox.GotFocus += ListBox_GotFocus;
                autoCompleteEnabled = enabled;
            }
            else
            {
                autoCompleteListBox.GotFocus -= ListBox_GotFocus;
                autoCompleteEnabled = false;

            }
        }

        /// <summary>
        /// add keywords to list box 
        /// </summary>
        /// <param name="keywordsString"></param>
        private void AddKeyWordsToListBox(string keywordsString)
        {
            if (autoCompleteListBox == null) return;

            //clear for sure
            autoCompleteListBox.Items.Clear();

            //split keywords
            string[] keywords = keywordsString.Split(' ');

            //add items to listbox
            autoCompleteListBox.Items.AddRange(keywords);
        }

        private void AutoShowCompleteListBox(string selectedLanguage)
        {
            blockRecordingUndo = true;
            if (autoCompleteEnabled)
            {

                string currentWord = GetCurrentWord();

                if (currentWord != "")
                {
                    //if listbox hasn't shown 
                    if (autoCompleteListBox.Visible == false)
                    {
                        //calculate position to show autocompletelistbox
                        int wordStartPosition = GetWordStartPosition(SelectionStart);
                        Point rawPostionToShowListBox = GetPositionFromCharIndex(wordStartPosition);
                        autoCompleteListBox.Location = new Point(rawPostionToShowListBox.X, rawPostionToShowListBox.Y + (int)(this.FontHeight * this.ZoomFactor));

                        if (autoCompleteListBox.Location.Y + 80 > this.Height)
                        {
                            autoCompleteListBox.Location = new Point(rawPostionToShowListBox.X, rawPostionToShowListBox.Y - 70 - (int)(this.FontHeight * this.ZoomFactor));
                        }

                        SetListBoxKeyWords(selectedLanguage, currentWord[0]);


                    }

                    //set selected index
                    autoCompleteListBox.SelectedIndex = autoCompleteListBox.FindString(currentWord);

                    //show autocompletelistbox 
                    if (autoCompleteListBox.SelectedIndex >= 0)
                    {
                        autoCompleteListBox.Visible = true;
                    }
                    else
                    {
                        autoCompleteListBox.Visible = false;
                    }
                }
                else
                {
                    autoCompleteListBox.Visible = false;
                }
            }
            blockRecordingUndo = false;
        }

        private void SetListBoxKeyWords(string selectedLanguage, char firstCharOfWord)
        {
            switch (selectedLanguage)
            {
                case "NormalText":
                    {
                        break;
                    }

                case "C#":
                    {
                        switch (firstCharOfWord)
                        {
                            case 'a':
                                {
                                    AddKeyWordsToListBox("abstract as");
                                    break;
                                }
                            case 'b':
                                {
                                    AddKeyWordsToListBox("base bool break byte");
                                    break;
                                }
                            case 'c':
                                {
                                    AddKeyWordsToListBox("case catch char checked class const continue");
                                    break;
                                }
                            case 'd':
                                {
                                    AddKeyWordsToListBox("decimal default delegate do double");
                                    break;
                                }
                            case 'e':
                                {
                                    AddKeyWordsToListBox("else enum event explicit extern");
                                    break;
                                }
                            case 'f':
                                {
                                    AddKeyWordsToListBox("false finally fixed float for foreach");
                                    break;
                                }
                            case 'g':
                                {
                                    AddKeyWordsToListBox("goto");
                                    break;
                                }
                            case 'i':
                                {
                                    AddKeyWordsToListBox("if implicit in int interface internal is");
                                    break;
                                }
                            case 'l':
                                {
                                    AddKeyWordsToListBox("lock long");
                                    break;
                                }
                            case 'n':
                                {
                                    AddKeyWordsToListBox("namespace new null");
                                    break;
                                }
                            case 'o':
                                {
                                    AddKeyWordsToListBox("object operator out override");
                                    break;
                                }
                            case 'p':
                                {
                                    AddKeyWordsToListBox("params private protected public");
                                    break;
                                }
                            case 'r':
                                {
                                    AddKeyWordsToListBox("readonly ref return");
                                    break;
                                }
                            case 's':
                                {
                                    AddKeyWordsToListBox("sbyte sealed short sizeof stackalloc static string struct switch");
                                    break;
                                }
                            case 't':
                                {
                                    AddKeyWordsToListBox("this throw true try typeof");
                                    break;
                                }
                            case 'u':
                                {
                                    AddKeyWordsToListBox("uint ulong unchecked unsafe ushort using");
                                    break;
                                }
                            case 'v':
                                {
                                    AddKeyWordsToListBox("virtual void volatile");
                                    break;
                                }
                            case 'w':
                                {
                                    AddKeyWordsToListBox("while");
                                    break;
                                }
                        }
                        break;
                    }

                case "C++":
                    {
                        switch (firstCharOfWord)
                        {
                            case 'a':
                                {
                                    AddKeyWordsToListBox("asm auto");
                                    break;
                                }
                            case 'b':
                                {
                                    AddKeyWordsToListBox("bool break");
                                    break;
                                }
                            case 'c':
                                {
                                    AddKeyWordsToListBox("case catch char class const_cast continue");
                                    break;
                                }
                            case 'd':
                                {
                                    AddKeyWordsToListBox("default delete do double dynamic_cast");
                                    break;
                                }
                            case 'e':
                                {
                                    AddKeyWordsToListBox("else enum extern");
                                    break;
                                }
                            case 'f':
                                {
                                    AddKeyWordsToListBox("false float for friend");
                                    break;
                                }
                            case 'u':
                                {
                                    AddKeyWordsToListBox("union unsigned using");
                                    break;
                                }
                            case 'g':
                                {
                                    AddKeyWordsToListBox("goto");
                                    break;
                                }
                            case 'i':
                                {
                                    AddKeyWordsToListBox("if inline int");
                                    break;
                                }
                            case 'l':
                                {
                                    AddKeyWordsToListBox("long");
                                    break;
                                }
                            case 'm':
                                {
                                    AddKeyWordsToListBox("mutable");
                                    break;
                                }
                            case 'n':
                                {
                                    AddKeyWordsToListBox("namespace new");
                                    break;
                                }
                            case 'o':
                                {
                                    AddKeyWordsToListBox("operator");
                                    break;
                                }
                            case 'p':
                                {
                                    AddKeyWordsToListBox("private protected public");
                                    break;
                                }
                            case 'r':
                                {
                                    AddKeyWordsToListBox("register reinterpret_cast return");
                                    break;
                                }
                            case 's':
                                {
                                    AddKeyWordsToListBox("short	signed sizeof static static_cast struct switch");
                                    break;
                                }
                            case 't':
                                {
                                    AddKeyWordsToListBox("template this throw true try typedef typeid");
                                    break;
                                }
                            case 'v':
                                {
                                    AddKeyWordsToListBox("virtual void volatile");
                                    break;
                                }
                            case 'w':
                                {
                                    AddKeyWordsToListBox("wchar_t while");
                                    break;
                                }
                        }
                        break;
                    }

                case "C":
                    {
                        switch (firstCharOfWord)
                        {
                            case 'a':
                                {
                                    AddKeyWordsToListBox("auto");
                                    break;
                                }
                            case 'b':
                                {
                                    AddKeyWordsToListBox("break");
                                    break;
                                }
                            case 'c':
                                {
                                    AddKeyWordsToListBox("case char const continue");
                                    break;
                                }
                            case 'd':
                                {
                                    AddKeyWordsToListBox("default do double");
                                    break;
                                }
                            case 'e':
                                {
                                    AddKeyWordsToListBox("else enum extern");
                                    break;
                                }
                            case 'f':
                                {
                                    AddKeyWordsToListBox("float for");
                                    break;
                                }
                            case 'g':
                                {
                                    AddKeyWordsToListBox("goto");
                                    break;
                                }
                            case 'i':
                                {
                                    AddKeyWordsToListBox("if in");
                                    break;
                                }
                            case 'l':
                                {
                                    AddKeyWordsToListBox("long");
                                    break;
                                }
                            case 'r':
                                {
                                    AddKeyWordsToListBox("register return");
                                    break;
                                }
                            case 's':
                                {
                                    AddKeyWordsToListBox("short signed sizeof static struct switch");
                                    break;
                                }
                            case 't':
                                {
                                    AddKeyWordsToListBox("typedef");
                                    break;
                                }
                            case 'u':
                                {
                                    AddKeyWordsToListBox("union unsigned");
                                    break;
                                }
                            case 'v':
                                {
                                    AddKeyWordsToListBox("void volatile");
                                    break;
                                }
                            case 'w':
                                {
                                    AddKeyWordsToListBox("while");
                                    break;
                                }
                        }
                        break;
                    }

                case "VB":
                    {
                        switch (firstCharOfWord)
                        {
                            case 'a':
                                {
                                    AddKeyWordsToListBox("addhandler addressof alias and andalso as");
                                    break;
                                }
                            case 'b':
                                {
                                    AddKeyWordsToListBox("boolean byref byte byval");
                                    break;
                                }
                            case 'c':
                                {
                                    AddKeyWordsToListBox("catch cbool cbyte cchar cdate cdbl cdec char cint class clng cobj case " +
                                                           "const continue csbyte cshort csng cstr ctype cuint culng cushort");
                                    break;
                                }
                            case 'd':
                                {
                                    AddKeyWordsToListBox("date decimal declare default delegate dim directcast do double");
                                    break;
                                }
                            case 'e':
                                {
                                    AddKeyWordsToListBox("each else elseif end endif enum erase error event exit");
                                    break;
                                }
                            case 'f':
                                {
                                    AddKeyWordsToListBox("false finally for friend function");
                                    break;
                                }
                            case 'g':
                                {
                                    AddKeyWordsToListBox("get gettype getxmlnamespace global gosub goto");
                                    break;
                                }
                            case 'h':
                                {
                                    AddKeyWordsToListBox("handles");
                                    break;
                                }
                            case 'i':
                                {
                                    AddKeyWordsToListBox("if implements imports in inherits integer interface is isnot");
                                    break;
                                }
                            case 'l':
                                {
                                    AddKeyWordsToListBox("let lib like long loop");
                                    break;
                                }
                            case 'm':
                                {
                                    AddKeyWordsToListBox("me mod module mustinherit mustoverride mybase myclass");
                                    break;
                                }
                            case 'n':
                                {
                                    AddKeyWordsToListBox("namespace narrowing new not nothing notinheritable notoverridable");
                                    break;
                                }
                            case 'o':
                                {
                                    AddKeyWordsToListBox("object of on operator option optional or orelse out overloads overridable overrides");
                                    break;
                                }
                            case 'p':
                                {
                                    AddKeyWordsToListBox("paramarray partial private property protected public");
                                    break;
                                }
                            case 'r':
                                {
                                    AddKeyWordsToListBox("raiseevent readonly redim rem removehandler resume return");
                                    break;
                                }
                            case 's':
                                {
                                    AddKeyWordsToListBox("sByte select set shadows shared short single static step stop " +
                                                                          "string structure sub synclock");
                                    break;
                                }
                            case 't':
                                {
                                    AddKeyWordsToListBox("then throw to true try trycast typeOf");
                                    break;
                                }
                            case 'u':
                                {
                                    AddKeyWordsToListBox("uinteger ulong ushort using");
                                    break;
                                }
                            case 'v':
                                {
                                    AddKeyWordsToListBox("variant");
                                    break;
                                }
                            case 'w':
                                {
                                    AddKeyWordsToListBox("wend when while widening with withevents writeonly");
                                    break;
                                }
                            case 'x':
                                {
                                    AddKeyWordsToListBox("xor");
                                    break;
                                }
                        }
                        break;
                    }

            }
        }

        /// <summary>
        /// Focus to textArea when listbox got focus to prevent lost focus in textarea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_GotFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        /// <summary>
        /// hide listbox when mouse click
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            //basePositionToCheckHighLight = SelectionStart;

            //hide autocompleteListBox if mouse is clicked somewhere
            if (autoCompleteListBox != null)
            {
                //this.Controls.Clear();
                //isShownAutoCompleteListBox = false;
                autoCompleteListBox.Visible = false;
            }


        }

        #endregion

        #region All the things related to auto indentation and brace matching

        private void AutoIndentationAndBraceMatching(string selectedLaguange)
        {
            switch (selectedLaguange)
            {                
                case "C#":
                case "C":
                case "C++":
                    {
                        if (this.TextLength > 0 && this.SelectionLength == 0 && this.SelectionStart > 0)
                        {
                            //if current action is insert text -> autobracematching
                            if (currentUndoAction.ActionName == "DeCharInsert")
                            {
                                if (this.Text[this.SelectionStart - 1] == '{' || this.Text[this.SelectionStart - 1] == '(' ||
                                    this.Text[this.SelectionStart - 1] == '[' || this.Text[this.SelectionStart - 1] == '<')
                                {
                                    switch (this.Text[this.SelectionStart - 1])
                                    {
                                        case '{':
                                            {
                                                this.SelectedText = " }";
                                                currentUndoAction.ReverseText += " }";
                                                break;
                                            }
                                        case '(':
                                            {
                                                this.SelectedText = " )";
                                                currentUndoAction.ReverseText += " )";
                                                break;
                                            }
                                        case '[':
                                            {
                                                this.SelectedText = " ]";
                                                currentUndoAction.ReverseText += " ]";
                                                break;
                                            }
                                        case '<':
                                            {
                                                this.SelectedText = " >";
                                                currentUndoAction.ReverseText += " >";
                                                break;
                                            }

                                    }
                                    this.SelectionStart = this.SelectionStart - 1;
                                    undoStack.Pop();
                                    undoStack.Push(currentUndoAction);
                                }

                            }
                            else
                            {
                                //if current action is enter key -> auto indentation 
                                if (currentUndoAction.ActionName == "DeEnter")
                                {
                                    int previousLineNumber = this.GetLineFromCharIndex(this.SelectionStart) - 1;

                                    if (previousLineNumber < 0 || previousLineNumber > this.Lines.Count()) return;

                                    //get previous line
                                    string previousLine = this.Lines[previousLineNumber];

                                    //get the amount of indent of previous line
                                    //read more about regex here: https://autohotkey.com/docs/misc/RegEx-QuickRef.htm
                                    Match indent = Regex.Match(previousLine, @"^[ \t]*");

                                    //add indent
                                    this.SelectedText = indent.Value;


                                    //if selection start is '}', do some works (just test this yourself, I don't really know how to explain this)
                                    if (Regex.IsMatch(this.Lines[this.GetLineFromCharIndex(this.SelectionStart)], @"}\s*"))
                                    {
                                        this.SelectedText = "\t\n" + indent.Value;
                                        this.SelectionStart = this.GetFirstCharIndexOfCurrentLine() - 1;

                                        //this action act just like DeCtrlVInsert 
                                        UndoRedoInfomation undoAction = new UndoRedoInfomation();
                                        undoAction.ActionName = "DeCtrlVInsert";
                                        undoAction.SelectionStart = currentUndoAction.SelectionStart;
                                        undoAction.Text = "";
                                        undoAction.ReverseText = "\n" + indent.Value + "\t" + "\n" + indent.Value;
                                        undoAction.ReverseActionName = "CtrlVInsert";
                                        undoStack.Pop();
                                        undoStack.Push(undoAction);
                                    }
                                }
                            }
                        }

                        break;
                    }
            }

        }


        #endregion

        #region All the things related to Syntax Highlight

        ///// <summary>
        ///// set the base position to check highlight on selectionchanged
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnSelectionChanged(EventArgs e)
        //{
        //    base.OnSelectionChanged(e);

        //    //if (SelectionStart - basePositionToCheckHighLight <= 1)
        //    //{
        //    //    basePositionToCheckHighLight = SelectionStart;
        //    //}

        //}

        /// <summary>
        /// save the base position to check highlight
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            previousCaret = this.SelectionStart;
            base.OnPreviewKeyDown(e);
        }

        /// <summary>
        /// Auto Suntax highlight
        /// </summary>
        /// <param name="selectedLanguage"></param>
        private void AutoSyntaxHighLight(string selectedLanguage)
        {
            blockRecordingUndo = true;

            if (controlToFocus != null)
            {
                //Focus another control to avoil flicking
                controlToFocus.Focus();
            }

            // saving the original caret position
            int originalLength = SelectionLength;
            currentCaret = SelectionStart;

            //Syntax highlighting
            switch (selectedLanguage)
            {
                case "NormalText":
                    {
                        ClearStyle(defaultLanguageColor);
                        break;
                    }
                case "C#":
                    {
                        ClearStyle(defaultLanguageColor);

                        SetStyle(@"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const" +
                                         @"|continue|decimal|default|delegate|do|double|else|enum|event|explicit" +
                                         @"|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface" +
                                         @"|internal|is|lock|long|namespace|new|null|object|operator|out|override|params" +
                                         @"|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc" +
                                         @"|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe" +
                                         @"|ushort|using|virtual|void|volatile|while)\b", keyWordsColor);


                        SetStyle(@"\s*#\s*(define|error|import|undef|elif|if|include|using|else|ifdef|line|endif|ifndef|pragma)\s*\S*", preprocessorsColor);

                        SetStyle("\".*\"", stringsColor);


                        SetStyle(@"\/\/.*", commentLinesColor);

                        SetStyle(@"\/\*.*\*\/", commentBlocksColor);

                        break;
                    }
                case "C":
                    {
                        ClearStyle(defaultLanguageColor);

                        SetStyle(@"\b(auto|double|int|struct|break|else|long|switch|case|enum|register|typedef|char|extern|return|union|const" +
                                 @"|float|short|unsigned|continue|for|signed|void|default|goto|sizeof|volatile|do|if|static|while)\b",
                                    keyWordsColor);

                        SetStyle("\".*\"", stringsColor);

                        SetStyle(@"\/\/.*", commentLinesColor);

                        SetStyle(@"\/\*.*\*\/", commentBlocksColor);

                        break;

                    }
                case "C++":
                    {
                        ClearStyle(defaultLanguageColor);

                        SetStyle(@"\b(asm|auto|bool|break|case|catch|char|class|const_cast|continue|default|delete|do|double|else" +
                                      @"|enum|dynamic_cast|extern|false|float|for|union|unsigned|using|friend|goto|if|inline|int|long" +
                                      @"|mutable|virtual|namespace|new|operator|private|protected|public|register|void|reinterpret_cast" +
                                      @"|return|short|signed|sizeof|static|static_cast|volatile|struct|switch|template|this|throw|true|try" +
                                      @"|typedef|typeid|unsigned|wchar_t|while)\b",
                                      keyWordsColor);

                        SetStyle("\".*\"", stringsColor);

                        SetStyle(@"\/\/.*", commentLinesColor);

                        SetStyle(@"\/\*.*\*\/", commentBlocksColor);

                        break;

                    }
                case "VB":
                    {
                        ClearStyle(defaultLanguageColor);

                        SetStyle(@"\b(addhandler|addressof|alias|and|andalso|as|boolean|byref|byte|byval|call|case" +
                                   @"|catch|cbool|cbyte|cchar|cdate|cdbl|cdec|char|cint|class|clng|cobj|const|continue" +
                                   @"|csbyte|cshort|csng|cstr|ctype|cuint|culng|cushort|date|decimal|declare|default" +
                                   @"|delegate|dim|directcast|do|double|each|else|elseif|end|endif|enum|erase|error" +
                                   @"|event|exit|false|finally|for|friend|function|get|gettype|getxmlnamespace|global" +
                                   @"|gosub|goto|handles|if|implements|imports|in|inherits|integer|interface|is|isnot" +
                                   @"|let|lib|like|long|loop|me|mod|module|mustinherit|mustoverride|mybase|myclass|namespace" +
                                   @"|narrowing|new|not|nothing|notinheritable|notoverridable|object|of|on|operator|option" +
                                   @"|optional|or|orelse|out|overloads|overridable|overrides|paramarray|partial|private|property" +
                                   @"|protected|public|raiseevent|readonly|redim|rem|removehandler|resume|return|sbyte|select" +
                                   @"|set|shadows|shared|short|single|static|step|stop|string|structure|sub|synclock|then" +
                                   @"|throw|to|true|try|trycast|typeof|uinteger|ulong|ushort|using|variant|wend|when|while" +
                                   @"|widening|with|withevents|writeonly|xor)\b",
                                   keyWordsColor);

                        SetStyle(@"\s*#\s*(define|error|import|undef|elif|if|include|using|else|ifdef|line|endif|ifndef|pragma)\s*\S*", preprocessorsColor);

                        SetStyle("\".*\"", stringsColor);

                        SetStyle(@"\'.*", commentLinesColor);


                        break;
                    }

            }

            // restoring the original caret position
            SelectionStart = currentCaret;
            SelectionLength = originalLength;
            SelectionColor = defaultLanguageColor;
            previousCaret = currentCaret;

            //Set focus again
            this.Focus();


            blockRecordingUndo = false;
        }

        /// <summary>
        /// Set the style for current line or current selected text
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="color"></param>
        private void SetStyle(string pattern, Color foreColor/*, bool isSpreadedMultipleLines*/)
        {
            //save selectionStart and selection length for futher check comment or string ...
            int start = SelectionStart;
            int length = SelectionLength;

            //if(isSpreadedMultipleLines)
            //{

            //    SelectionStart = 0;
            //    SelectionLength = TextLength;
            //}

            //the text to check pattern
            string textToCheck = Text.Substring(SelectionStart, SelectionLength);

            //the offset of this text related to the TextArea
            int offset = SelectionStart;

            //Get Match Collection
            MatchCollection patternMatches = Regex.Matches(textToCheck, pattern);

            //loop through the MathCollection
            foreach (Match m in patternMatches)
            {
                //set selection start
                SelectionStart = m.Index + offset;
                //set selection length
                SelectionLength = m.Length;

                //Set color and font 
                SelectionColor = foreColor;

            }

            SelectionStart = start;
            SelectionLength = length;

        }

        /// <summary>
        /// Clear the style of current line or current selected text
        /// </summary>
        /// <param name="color"></param>
        private void ClearStyle(Color foreColor)
        {
            //
            if (previousCaret > currentCaret)
            {
                previousCaret = currentCaret - 1;
            }

            //Set SelectionStart
            // selection start should be the first character of the line that it contains the basePositionToCheckHighLight
            SelectionStart = GetFirstCharIndexOfLine(previousCaret);

            //Set selectionLength
            // selection end should be the last chareacter of current line that it contains the current caret
            SelectionLength = GetLastCharIndexOfLine(currentCaret) - SelectionStart;

            //Set color
            SelectionColor = foreColor;
            //Set font for sure
            SelectionFont = this.Font;
            //Set backColor for sure
            SelectionBackColor = this.BackColor;
        }

        /// <summary>
        /// Set style for all the text area
        /// </summary>
        /// <param name="selectedLanguage">the language to set style </param>
        /// <param name="IsNeededImmediately">perform this funtion immediately or not</param>
        public void TriggerTextAreaStyle(string selectedLanguage/*, bool IsNeededImmediately*/)
        {
            blockRecordingUndo = true;

            //Set SelectionStart
            // selection start should be the first character of the line that it contains the basePositionToCheckHighLight
            SelectionStart = TextLength;

            previousCaret = 0;

            //set language
            language = selectedLanguage;

            //if (IsNeededImmediately)
            {
                //Append text to trigger OnTextChangedEvent
                //somehow if autoSyntaxHighLight function is implemented in textchanged event, it will run as if immediately
                this.AppendText(" ");

                //Delete the space character just added
                this.SelectionStart = this.TextLength - 1;
                this.SelectionLength = 1;
                this.SelectedText = "";
            }
            //else
            //{
            //    //And if we just leave this function here, it will just run step by step
            //    OnTextChanged(EventArgs.Empty);
            //}

            blockRecordingUndo = false;

        }

        /// <summary>
        /// Get first char index of the real line from a specified char index 
        /// </summary>
        private int GetFirstCharIndexOfLine(int anyCharIndexInThisLine)
        {
            int firstCharIndex = anyCharIndexInThisLine;

            if (firstCharIndex < 0 || firstCharIndex > TextLength) return 0;

            while (firstCharIndex > 0 /*&& firstCharIndex <= this.TextLength*/ && Text[firstCharIndex - 1] != '\n')
            {
                firstCharIndex--;
            }

            return firstCharIndex;
        }

        /// <summary>
        /// Get last char index of the real line from a specified char index 
        /// </summary>
        private int GetLastCharIndexOfLine(int anyCharIndexInThisLine)
        {
            int lastCharIndex = anyCharIndexInThisLine;

            if (lastCharIndex < 0 || lastCharIndex > Text.Length) return TextLength;

            while (/*lastCharIndex >= 0 &&*/ lastCharIndex < Text.Length && Text[lastCharIndex] != '\n')
            {
                lastCharIndex++;
            }

            return lastCharIndex;
        }

        /// <summary>
        /// Get word start position at a specified position
        /// </summary>
        /// <param name="charIndex"></param>
        /// <returns></returns>
        private int GetWordStartPosition(int charIndex)
        {
            while ((charIndex > 0) && Text[charIndex - 1] != ' ' && Text[charIndex - 1] != '\t' && Text[charIndex - 1] != '\n')
            {
                charIndex--;
            }

            return charIndex;
        }

        /// <summary>
        /// Get word end position at a specified position
        /// </summary>
        /// <param name="charIndex"></param>
        /// <returns></returns>
        private int GetWordEndPosition(int charIndex)
        {
            while ((charIndex < TextLength) && Text[charIndex] != ' ' && Text[charIndex] != '\t' && Text[charIndex] != '\n')
            {
                charIndex++;
            }

            return charIndex;
        }

        /// <summary>
        /// Get current word
        /// </summary>
        /// <returns></returns>
        private string GetCurrentWord()
        {
            int wordStartPosition = GetWordStartPosition(SelectionStart);
            int wordEndPosition = GetWordEndPosition(SelectionStart);

            return this.Text.Substring(wordStartPosition, wordEndPosition - wordStartPosition);

        }

        #endregion

        #region Code folding
        /// <summary>
        /// Find folding in display
        /// </summary>
        /// <param name="selectedLanguage"></param>
        private void AutoCodeFolding(string selectedLanguage)
        {
            switch (selectedLanguage)
            {
                case "NormalText":
                case "VB":
                        break;    
            }
            //caculator the fold find region in the screen plus offset
            int firstLine = Math.Max(0, GetFirstVisiableLine() - lineOffset);
            int lastLine = Math.Min(GetLastVisiableLine() + lineOffset, NumberOfLine);
            int firstIndex = GetFirstCharIndexFromLine(firstLine);
            int lastIndex = GetFirstCharIndexFromLine(lastLine);
            // find the nested
            nestedList = FoldFinder.Instance.Find(this.Text, regexList, firstIndex, lastIndex);
        }
        /// <summary>
        /// add new folded to the list
        /// </summary>
        /// <param name="section"></param>
        private void NewFolded(SectionPosition section)
        {
            int maxIndex;
            //get the index for saving the folded
            if (foldedList.Count != 0)
            {
                maxIndex = foldedList.Last().Key + 1;
            }
            else
            {
                maxIndex = 1;
            }
            //fold the text
            Select(section.Start + 1, section.End - section.Start - 2);
            string nestedText = SelectedText;
            foldedList.Add(maxIndex, new FoldedState() { Header = maxIndex, Content = nestedText});
            blockAllAction = true;
            SelectedText = "folded" + maxIndex;
            blockAllAction = false;
        }
        /// <summary>
        /// handle fold/unfold on mouse click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberMargin_MouseClick(object sender, MouseEventArgs e)
        {
            //blockRecordingUndo = true;
            //save the cursor
            int selectionStart = SelectionStart;
            int selectionLength = SelectionLength;
            string nestedText;
            FoldedState currentFolded;
            //get the clicked line
            int clickedLine = GetLineFromMouseClick(new Point(1, e.Y));
            //find nested start with the line
            SectionPosition section = nestedList.Find((x) => { return GetLineFromCharIndex(x.Start) == clickedLine; });
            int foldedIndex;
            if (section != null)
            {
                //select the nested code
                Select(section.Start + 1, section.End - section.Start - 2);
                nestedText = SelectedText;
                //Check if it is folded
                if (nestedText.StartsWith("folded"))
                {
                    //check if folded index is a number
                    if (int.TryParse(nestedText.Substring(6), out foldedIndex))
                    {
                        //foldedIndex may not be in foldedList so we use try catch for safety
                        try
                        {
                            currentFolded = foldedList[foldedIndex];
                            blockAllAction = true;
                            SelectedText = currentFolded.Content;
                            blockAllAction = false;
                            foldedList.Remove(foldedIndex);
                            return;
                        }
                        catch
                        { }
                    }
                }
                // it is unfold so fold it
                {
                    NewFolded(section);
                }
            }
            //restore cursor
            this.SelectionStart = selectionStart;
            this.SelectionLength = selectionLength;
            //blockRecordingUndo = false;
        }
        /// <summary>
        /// foll all the text
        /// </summary>
        public void FoldAll()
        {
            blockRecordingUndo = true;

            if (controlToFocus != null)
            {
                //Focus another control to avoil flicking
                controlToFocus.Focus();
            }

            switch (language)
            {
                case "NormalText":
                case "VB":
                    return;
            }
            Fold();
            blockRecordingUndo = false;
            this.Focus();
        }
        //Unfold all
        public void UnfoldAll()
        {
            blockRecordingUndo = true;
            switch (language)
            {
                case "NormalText":
                case "VB":
                    return;
            }
            Unfold();
            blockRecordingUndo = false;
        }

        private void Unfold(int start = 0, int end = -1)
        {
            string nestedText;
            int foldedIndex;
            FoldedState currentFolded;
            nestedList = FoldFinder.Instance.Find(this.Text, regexList, start, end);
            for (int i = 0; i < nestedList.Count; i++)
            {
                SectionPosition section = nestedList[i];
                Select(section.Start + 1, section.End - section.Start - 2);
                nestedText = SelectedText;
                // check if the code is folded
                if (nestedText.StartsWith("folded"))
                {
                    if (int.TryParse(nestedText.Substring(6), out foldedIndex))
                    {
                        try
                        {
                            //Unfold the code
                            currentFolded = foldedList[foldedIndex];
                            blockAllAction = true;
                            SelectedText = currentFolded.Content;
                            foldedList.Remove(foldedIndex);
                            blockAllAction = false;
                            // Unfolded code may contain fold code, so we scan again
                            Unfold(section.Start + 1, section.Start + currentFolded.Content.Length);
                            // Unfolded change the location of the nested code, so we scan again, ignore recently unfolded code
                            nestedList = FoldFinder.Instance.Find(this.Text, regexList, start, end);
                            i = nestedList.FindIndex((x) => { return x.Start == section.Start; });
                        }
                        catch { }
                    }
                }
            }
        }

   
        private void Fold(int start = 0, int end = -1)
        {
            string nestedText;
            nestedList = FoldFinder.Instance.Find(this.Text, regexList, start, end);
            for (int i = 0; i < nestedList.Count; i++)
            {
                SectionPosition section = nestedList[i];
                Select(section.Start + 1, section.End - section.Start - 2);
                nestedText = SelectedText;
                // check if the code is folded
                if (!nestedText.StartsWith("folded"))
                {
                    NewFolded(section);
                    nestedList = FoldFinder.Instance.Find(this.Text, regexList, start, end);
                    //the folded text may contain another folded text, so we minus the number of folded text
                    i = i - FoldFinder.Instance.Find(nestedText, regexList).Count;
                }
            }
        }

        #endregion

        #region Printing

        // Render the contents of the RichTextBox for printing
        //Return the last character printed + 1 (printing start from this point for next page)
        public int Print(int charFrom, int charTo, PrintPageEventArgs e)
        {

            // Mark starting and ending character 
            CHARRANGE cRange;
            cRange.cpMin = charFrom;
            cRange.cpMax = charTo;

            // Calculate the area to render and print
            RECT rectToPrint;
            rectToPrint.Top = (int)(e.MarginBounds.Top * anInch);
            rectToPrint.Bottom = (int)(e.MarginBounds.Bottom * anInch);
            rectToPrint.Left = (int)(e.MarginBounds.Left * anInch);
            rectToPrint.Right = (int)(e.MarginBounds.Right * anInch);

            // Calculate the size of the page
            RECT rectPage;
            rectPage.Top = (int)(e.PageBounds.Top * anInch);
            rectPage.Bottom = (int)(e.PageBounds.Bottom * anInch);
            rectPage.Left = (int)(e.PageBounds.Left * anInch);
            rectPage.Right = (int)(e.PageBounds.Right * anInch);

            IntPtr hdc = e.Graphics.GetHdc();

            FORMATRANGE fmtRange;
            fmtRange.chrg = cRange;               // Indicate character from to character to 
            fmtRange.hdc = hdc;        // Use the same DC for measuring and rendering
            fmtRange.hdcTarget = hdc;             // Point at printer hDC
            fmtRange.rc = rectToPrint;           // Indicate the area on page to print
            fmtRange.rcPage = rectPage;           // Indicate whole size of page

            IntPtr res = IntPtr.Zero;

            IntPtr wparam = new IntPtr(1);

            // Move the pointer to the FORMATRANGE structure in memory
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, lparam, false);

            // Send the rendered data for printing 
            res = Win32.SendMessage2(Handle, Win32.EM_FORMATRANGE, wparam, lparam);

            // Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam);

            // Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc);

            // Return last + 1 character printer
            return res.ToInt32();
        }

        #endregion

        #region Some other public functions

        public void ZoomIn()
        {
            if (this.ZoomFactor == 5f) return;
            this.ZoomFactor = this.ZoomFactor + 0.1f;
        }

        public void ZoomOut()
        {
            if (this.ZoomFactor == 0.1f) return;
            this.ZoomFactor = this.ZoomFactor - 0.1f;

        }

        /// <summary>
        /// Find all the positions of a string 
        /// </summary>
        /// <param name="textToSearch"></param>
        /// <returns></returns>
        public List<int> FindAll(string textToSearch)
        {
            if (controlToFocus != null)
            {
                controlToFocus.Focus();
            }
            //list to hold all the positions
            List<int> listOfPositions = new List<int>();
            int position = -1;
            int searchStart = 0;
            int searchEnd = this.TextLength;

            // A valid starting index should be specified.
            // if index= -1, the end of search
            while (searchStart < this.Text.Length)
            {
                // A valid ending index
                // Find the position of search string in RichTextBox
                position = this.Find(textToSearch, searchStart, searchEnd, RichTextBoxFinds.None);

                // Determine whether the text was found in richTextBox1.
                if (position != -1)
                {
                    listOfPositions.Add(position);
                    searchStart = position + textToSearch.Length;
                }
                else
                {
                    break;
                }
            }

            this.Focus();

            return listOfPositions;
        }

        /// <summary>
        /// color background of all the positions in the list
        /// </summary>
        /// <param name="listOfPositions"></param>
        /// <param name="textLength"></param>
        /// <param name="backColor"></param>
        public void ColorBackGround(List<int> listOfPositions, int textLength, Color backColor)
        {
            if (controlToFocus != null)
            {
                controlToFocus.Focus();
            }

            BlockAllAction = true;

            // Highlighted backcolor of all found text
            if (this.Text.Length > 0)
            {
                if (listOfPositions.Count != 0)
                {
                    int index = 0;
                    //Coloring the found text      
                    while (index < listOfPositions.Count)
                    {
                        this.Select(listOfPositions[index], textLength);
                        this.SelectionBackColor = backColor;
                        index++;
                    }
                }
            }

            BlockAllAction = false;

            this.Focus();
        }

        /// <summary>
        /// Find all and color background
        /// </summary>
        /// <param name="textToSearch"></param>
        /// <param name="backColor"></param>
        public List<int> FindAndColorAll(string textToSearch, Color backColor)
        {
            if (controlToFocus != null)
            {
                controlToFocus.Focus();
            }

            BlockAllAction = true;

            //list to hold all the positions
            List<int> listOfPositions = new List<int>();

            int position = -1;
            int searchStart = 0;
            int searchEnd = this.TextLength;

            // A valid starting index should be specified.
            // if index= -1, the end of search
            while (searchStart < this.Text.Length)
            {
                // A valid ending index
                // Find the position of search string in RichTextBox
                position = this.Find(textToSearch, searchStart, searchEnd, RichTextBoxFinds.None);

                // Determine whether the text was found in richTextBox1.
                if (position != -1)
                {
                    listOfPositions.Add(position);
                    this.Select(position, textToSearch.Length);
                    this.SelectionBackColor = backColor;
                    searchStart = position + textToSearch.Length;
                }
                else
                {
                    break;
                }
            }

            BlockAllAction = false;

            this.Focus();

            return listOfPositions;
        }

        /// <summary>
        /// Clear background color of all the text by specified color
        /// Prevent recording Undo
        /// </summary>
        public void ClearBackColor(Color clearColor)
        {
            BlockAllAction = true;
            //Remove highlighted text of previous search        
            this.Select(0, this.TextLength);
            this.SelectionBackColor = clearColor;
            this.SelectionLength = 0;
            BlockAllAction = false;
        }

        /// <summary>
        /// Change selectedText (still recording undo)
        /// </summary>
        public void ReplaceSelectedText(string textToReplace)
        {
            //this action act just like DeCtrlVInsert 
            currentUndoAction.ActionName = "DeCtrlVInsert";
            currentUndoAction.SelectionStart = this.SelectionStart;
            currentUndoAction.Text = this.SelectedText;
            currentUndoAction.ReverseText = textToReplace;

            this.SelectedText = textToReplace;
        }

        #endregion

        #region Some other private functions

        /// <summary>
        /// We use this function to set the tab size on text area
        /// Since the default tab size is so large ( 8 character)
        /// </summary>
        /// <param name="textArea"></param>
        /// <param name="tabSize"></param>
        private void SetTabSizeOnTextArea(int tabSize)
        {
            //see the link below for more information
            //https://msdn.microsoft.com/en-us/library/bb761663(VS.85).aspx

            //wParam
            int wParam = 1;

            // Create our array to hold each tabstop
            int[] lParam = new int[wParam];

            // set tab size
            lParam[0] = tabSize * 4;

            // Send the message to the textbox control (203 = EM_SETTABSTOPS)
            Win32.SendMessage(this.Handle, 203, wParam, lParam);

        }

        #endregion

        #region Get Line For Lazy
        private int GetLineFromMouseClick(Point pt)
        {
            int charIndex = GetCharIndexFromPosition(pt);
            int lineIndex = GetLineFromCharIndex(charIndex);
            return lineIndex;
        }

        private int GetFirstVisiableLine()
        {
            int topIndex = GetCharIndexFromPosition(new Point(0, 0));
            int topLine = GetLineFromCharIndex(topIndex);
            return topLine;
        }

        public int GetLastVisiableLine()
        {
            int topIndex = GetCharIndexFromPosition(new Point(Width, Height));
            int topLine = GetLineFromCharIndex(topIndex);
            return topLine;
        }
        #endregion
    }
    
    
}