using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextSortGUI
{
    public partial class CustomMessageBox : Form
    {
                
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
            string Full_Regular = "Do you want to save this document before application closes?" + Environment.NewLine + "Click ";

            string Bold_Yes = "Yes ";
            string Bold_No = "No ";
            string Save_Regular = "to save and close or ";
            string Save_Regular2 = "to close without saving.";

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText(Full_Regular);

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            richTextBox1.AppendText(Bold_Yes);

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText(Save_Regular);

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            richTextBox1.AppendText(Bold_No);

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.AppendText(Save_Regular2);

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            MainForm f1 = new MainForm();

            f1.SaveFileFunction();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CustomMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
