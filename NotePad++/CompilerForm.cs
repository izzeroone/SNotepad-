using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Diagnostics;

namespace NotePad__
{
    public partial class CompilerForm : Form
    {
        public CompilerForm()
        {
            InitializeComponent();
        }

        public RichTextBox CodeTextBox
        {
            get
            {
                return codeRichTextBox;
            }
        }

        public ComboBox LanguageComboxBox
        {
            get
            {
                return laguageComboBox;
            }
        }

        private void ExcuteButton_Click(object sender, EventArgs e)
        {
           
            if (CodeDomProvider.IsDefinedLanguage(laguageComboBox.Text) == false)
            {
                MessageBox.Show("This laguage might haven't been supported","Something went wrong");
                return;
            }

            CodeDomProvider compiler = CodeDomProvider.CreateProvider(laguageComboBox.Text);

            // For Visual Basic Compiler try this :
            //Microsoft.VisualBasic.VBCodeProvider

            //ICodeCompiler compiler = codeProvider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();

            //parameters.CompilerOptions = "/target:winexe";

            parameters.GenerateExecutable = true;

            parameters.OutputAssembly = "Application.exe";

            if (mainClassTextBox.Text == "")
            {
                System.Windows.Forms.MessageBox.Show(this, "Main Class Name cannot be empty");
                return;
            }

            parameters.MainClass = mainClassTextBox.Text;

            //Include debug info
            parameters.IncludeDebugInformation = true;

            // Add available assemblies - this should be enough for the simplest
            // applications.
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                parameters.ReferencedAssemblies.Add(asm.Location);
            }

            String code = codeRichTextBox.Text;
            //System.Windows.Forms.MessageBox.Show(this, code);

            CompilerResults results = compiler.CompileAssemblyFromSource(parameters, code);

            if (results.Errors.Count > 0)
            {
                string errors = "Compilation failed:\n";
                foreach (CompilerError err in results.Errors)
                {
                    errors += err.ToString() + "\n";
                }
                System.Windows.Forms.MessageBox.Show(this, errors, "There were compilation errors");
            }
            else
            {
                #region Executing generated executable
                // try to execute application

                try
                {
                    if (!System.IO.File.Exists("Application.exe"))
                    {
                        MessageBox.Show(String.Format("Can't find {0}", "Application.exe"), "Can't execute.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ProcessStartInfo pInfo = new ProcessStartInfo("Application.exe");
                    Process.Start(pInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error while executing {0}", "Application.exe") + ex.ToString(),
                            "Can't execute.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

            }
        }

        private void CompilerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

    }
}
