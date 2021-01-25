using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TextSortGUI
{
    public partial class MainForm : Form
    {
        private bool TextWasChanged = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetWindowTitle(string FileName)
        {
            Text = string.Format("{0} - TextSortGUI", Path.GetFileName(FileName));
        }

        private void ClearWindowsTitle()
        {
            Text = string.Format("TextSortGUI");
        }

        private void NewFunction()
        {
            if (TextWasChanged)
            {
                DialogResult newSave = MessageBox.Show("Do you want to Save file?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (newSave == DialogResult.Yes)
                {
                    SaveFileFunction();
                }
                else if (newSave == DialogResult.No)
                {
                    TextBox.Clear();
                    TextWasChanged = false;
                    ClearWindowsTitle();
                }
            }
        }

        private void OpenFileFunction()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Open File",
                Filter = "Text Files (*txt)|*txt",  // filtering .txt files because we are working only with text files
                FileName = ""
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(open.FileName));

                SetWindowTitle(open.FileName);

                TextBox.Text = sr.ReadToEnd();
                TextWasChanged = false;
                sr.Dispose();
            }
        }

        private void SaveFileFunction()
        {
            SaveFileDialog Savefilefunction = new SaveFileDialog
            {
                Title = "Save File",
                Filter = "Text Files (*txt)|*txt", // filtering .txt files because we are only working with text files
                FileName = "Untitled",
            };

            if (Savefilefunction.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(File.Create(Savefilefunction.FileName));

                sw.Write(TextBox.Text);
                sw.Dispose();
            }
        }

        private void AccordingToSpellingFunction()
        {
            if (TextBox.SelectedText.Length < 1)
            {
                return;
            }

            Regex RegexCasing = new Regex("(?:[.,?!]\\s[a-z]|^(?:\\s+)?[a-z])", RegexOptions.Multiline);

            // /[.,?!]\\s[a-z]/   matches letters following a space and punctuation
            // /^(?:\\s+)?[a-z]/  matches the first letter in a string

            string Select_Text = TextBox.SelectedText;

            Select_Text = Select_Text.ToLower();

            Select_Text = RegexCasing.Replace(Select_Text, s => (s.Value.ToUpper()));

            TextBox.SelectedText = Select_Text;
        }

        private void ToolStripVisibilityFunction()
        {
            if (!string.IsNullOrWhiteSpace(TextBox.Text))
            {
                uppercaseToolStripMenuItem.Enabled = true;
                accordingToSpellingToolStripMenuItem.Enabled = true;
            }
            else
            {
                uppercaseToolStripMenuItem.Enabled = false;
                accordingToSpellingToolStripMenuItem.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFunction();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileFunction();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileFunction();
        }

        private void UppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.SelectedText = TextBox.SelectedText.ToUpper();
        }

        private void AccordingToSpellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccordingToSpellingFunction();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;

            ToolStripVisibilityFunction();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CustomMessageBox Cmb = new CustomMessageBox();

            if (TextWasChanged)
            {
                switch (Cmb.ShowDialog())
                {
                    case DialogResult.Yes:
                        SaveFileFunction();
                        break;

                    case DialogResult.No:
                        TextWasChanged = false;
                        break;

                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}