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
    public partial class Form1 : Form
    {
        private string text = string.Empty;

        public Form1()
        {
            InitializeComponent();
            Text = "TextSortGUI";
        }


        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Open File",
                Filter = "Text Files (*txt)|*txt"  // filtering .txt files because we are working only with text files
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(File.OpenRead(open.FileName));

                text = sr.ReadToEnd(); // need separated variable for AccordingToTheSpelling 
                TextBox.Text = text;

                sr.Dispose();
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

        private void SaveButton_Click(object sender, EventArgs e)
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

        private void uppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.SelectedText = TextBox.SelectedText.ToUpper();
        }

        private void accordingToSpellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            TextBox.SelectedText = TextBox.SelectedText; 

            Regex RegexCasing = new Regex("(?:[.,?!]\\s[a-z]|^(?:\\s+)?[a-z])", RegexOptions.Multiline);

            // /[.,?!]\\s[a-z]/   matches letters following a space and punctuation
            // /^(?:\\s+)?[a-z]/  matches the first letter in a string

            text = text.ToLower(); // all characters to lower case

            text = RegexCasing.Replace(text, s => (s.Value.ToUpper()));  // capitalize each match in the regular expression

            TextBox.Text = text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var Result = MessageBox.Show("Do you want to close the program without saving?", "Exit", MessageBoxButtons.YesNoCancel);

            switch (Result)
            {
                case DialogResult.Yes:
                    break;

                case DialogResult.No:
                    SaveFileFunction();
                    e.Cancel = true;
                    break;

                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
              
            }

        }
    }
}
