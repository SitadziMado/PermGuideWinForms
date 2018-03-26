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
    public partial class ReviewForm : Form
    {
        private ReviewResults mResults;
        private Label[] mStars;

        public ReviewForm(string caption, ReviewResults results)
        {
            InitializeComponent();
            mResults = results;
            NameLabel.Text = caption;
            mStars = new Label[]
            {
                FstStar, SndStar, TrdStar, FrtStar, FthStar  
            };
        }

        private void FstStar_Click(object sender, EventArgs e)
        {
            AcceptButton.Enabled = true;

            var self = (Label)sender;

            mResults.Mark = int.Parse((string)self.Tag);

            for (int i = 0; i < mResults.Mark; ++i)
                mStars[i].ForeColor = Color.DarkOrange;

            for (int i = mResults.Mark; i < mStars.Length; ++i)
                mStars[i].ForeColor = Color.DimGray;
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            mResults.Mark = 0;
            Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            mResults.Review = ContentTextBox.Text;
            Close();
        }
    }
}
