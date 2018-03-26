using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PermGuideWinForms
{
    public partial class ContentCreationForm : Form
    {
        private ContentCreationResults mResults;

        public ContentCreationForm(bool isSight, ContentCreationResults results)
        {
            InitializeComponent();
            mResults = results;

            AddressTextBox.Visible = AddressLabel.Visible = isSight;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            mResults.Name = NameTextBox.Text;
            mResults.Address = AddressTextBox.Text;

            Close();
        }

        private void DeclineButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            AcceptButton.Enabled = NameTextBox.TextLength != 0;
        }
    }
}
