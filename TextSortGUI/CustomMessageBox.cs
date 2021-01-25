using System;
using System.Drawing;
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

        private void BtnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}