using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TextSortGUI
{
    public partial class MainForm : Form
    {
        public bool TextWasChanged = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Open File",
                Filter = "Text Files (*txt)|*txt"  // filtering .txt files because we are working only with text files
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(open.FileName));

                TextBox.Text = sr.ReadToEnd();
                
                TextWasChanged = false;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Title = "Save File",
                Filter = "Text Files (*txt)|*txt"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter s_w = new StreamWriter(File.Create(save.FileName));

                s_w.Write(TextBox.Text);
                s_w.Dispose();
            }
        }

        public void SaveFileFunction()
        {
            SaveFileDialog Savefilefunction = new SaveFileDialog
            {
                Title = "Save File",
                Filter = "Text Files (*txt)|*txt" // filtering .txt files because we are only working with text files
            };

            if (Savefilefunction.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(File.Create(Savefilefunction.FileName));

                sw.Write(TextBox.Text);
                sw.Dispose();
            }
        }

        private void UppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.SelectedText = TextBox.SelectedText.ToUpper();
        }

        private void AccordingToSpellingToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;
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
