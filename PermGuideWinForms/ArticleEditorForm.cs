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
    public partial class ArticleEditorForm : Form
    {
        private Article mArticle;

        public ArticleEditorForm(Article article)
        {
            InitializeComponent();
            mArticle = article;
            ArticleTextBox.Text = mArticle.GetHtml().GetText();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            mArticle.GetHtml().SetText(ArticleTextBox.Text);
            Close();
        }
    }
}
