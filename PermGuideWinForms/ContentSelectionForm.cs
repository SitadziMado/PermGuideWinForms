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
    public partial class ContentSelectionForm : Form
    {
        private Content[] mContent;
        private ContentSelectionResults mResults;

        public ContentSelectionForm(
            string caption, 
            IEnumerable<Content> content,
            ContentSelectionResults results
        )
        {
            InitializeComponent();
            Text = caption;
            mContent = content.ToArray();
            mResults = results;

            ContentListBox.Items.Clear();

            var strings = from v
                          in mContent
                          select v.Name;

            ContentListBox.Items.AddRange(strings.ToArray());
        }
        
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            mResults.Content = mContent[ContentListBox.SelectedIndex];
            mResults.IsEmpty = false;
            Close();
        }

        private void DeclineButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcceptButton.Enabled = true;
        }
    }
}
