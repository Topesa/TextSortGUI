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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Title = "Save File",
                Filter = "Text Files (*txt)|*txt"  // filtering .txt files because we are working only with text files
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(File.Create(save.FileName));

                sw.Write(TextBox.Text);
                sw.Dispose();
            }
        }

        private void uppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.SelectedText = TextBox.SelectedText.ToUpper();
        }

        private void accordingToSpellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            TextBox.SelectedText = TextBox.SelectedText; 

            Regex regexCasing = new Regex("(?:[.,?!]\\s[a-z]|^(?:\\s+)?[a-z])", RegexOptions.Multiline);

            // /[.:?!]\\s[a-z]/   matches letters following a space and punctuation
            // /^(?:\\s+)?[a-z]/  matches the first letter in a string

            text = text.ToLower(); // all characters to lower case

            text = regexCasing.Replace(text, s => (s.Value.ToUpper()));  // capitalize each match in the regular expression, using a lambda expression

            TextBox.Text = text;
        }
    }
}
