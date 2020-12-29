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

        }

        private void accordingToSpellingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
