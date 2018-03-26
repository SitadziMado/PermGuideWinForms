using PermGuideWinForms.Classes;
using PermGuideWinForms.Queries;
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
    public partial class MainForm : Form
    {
        public User User { get; set; }
        public DatabaseManager Manager { get; set; }

        private User[] mUsers;
        private Sight[] mSights;
        private Excursion[] mExcursions;
        private Sight[] mExcursionSights;
        private Article[] mArticles;
        private Timetable[] mTimetables;
        private QueryConstructor mConstructor;

        private static readonly string[] mSigns = new string[]
        {
            "==", "!=", "<", ">", "<=", ">="
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Manager = new DatabaseManager();
            Manager.TestQueryConstructor();

            var form = new LoginForm(this);
            form.ShowDialog();

            if (User == null)
                Close();

            UpdateInfo();
        }

        private Content SelectContent(
            string caption,
            IEnumerable<Content> content
        )
        {
            var results = new ContentSelectionResults();

            var window = new ContentSelectionForm(
                caption,
                content,
                results
            );

            window.ShowDialog();

            if (results.IsEmpty)
                throw new NoContentSelectedException();

            return results.Content;
        }

        private void UpdateInfo()
        {
            UpdateUserInfo();
            UpdateSightsInfo();
            UpdateExcursionsInfo();
            UpdateArticlesInfo();
            UpdateQueryInfo();
        }

        private void UpdateUserInfo()
        {
            UpdateData.Enabled = false;
            PasswordTextBox.Text = "";
            NicknameTextBox.Text = User.Nickname;

            UsersListBox.Visible = User.IsAdmin;
            LowerButton.Visible = User.IsAdmin;
            HigherButton.Visible = User.IsAdmin;
            BanButton.Visible = User.IsAdmin;
            UnbanButton.Visible = User.IsAdmin;

            if (User.IsAdmin)
            {
                UsersListBox.Items.Clear();

                var users = from v
                            in Manager.GetUsers()
                            where v != User
                            select v;

                mUsers = users.ToArray();

                var userStrings = from v
                                  in mUsers
                                  select $"{v.Login} : {v.Status.ToString()}";

                UsersListBox.Items.AddRange(userStrings.ToArray());
            }
        }

        private void UpdateSightsInfo()
        {
            SightsListBox.Items.Clear();

            var sights = from v
                         in Manager.GetSights()
                         select v;

            mSights = sights.ToArray();

            var sightStrings = from v
                               in mSights
                               select v.Name;

            SightsListBox.Items.AddRange(sightStrings.ToArray());

            AcceptSightButton.Visible = RejectSightButton.Visible = User.IsModerator;

            ToggleSightFields(false);
        }

        private void UpdateExcursionsInfo()
        {
            ExcursionsListBox.Items.Clear();

            var excursions = from v
                             in Manager.GetExcursions()
                             select v;

            mExcursions = excursions.ToArray();

            var excursionStrings = from v
                                   in mExcursions
                                   select v.Name;

            ExcursionsListBox.Items.AddRange(excursionStrings.ToArray());

            AcceptExcursionButton.Visible = RejectExcursionButton.Visible = User.IsModerator;

            ToggleExcursionFields(false);
        }

        private void UpdateArticlesInfo()
        {
            ArticlesListBox.Items.Clear();

            var articles = from v
                         in Manager.GetArticles()
                         select v;

            mArticles = articles.ToArray();

            var articleStrings = from v
                                 in mArticles
                                 select v.Name;

            ArticlesListBox.Items.AddRange(articleStrings.ToArray());

            AcceptArticleButton.Visible = RejectArticleButton.Visible = User.IsModerator;

            ToggleArticleFields(false);
        }

        private void ToggleSightFields(bool value)
        {
            SightNameTextBox.Enabled = false; // value;
            SightAuthorTextBox.Enabled = false; //  = value;
            SightAddressTextBox.Enabled = value;
            SightArticleNameLabel.Enabled = value;
            SightArticleSelectButton.Enabled = value;
            SightEditButton.Enabled = value;
            SightEditButton.Enabled = value;
        }

        private void ToggleExcursionFields(bool value)
        {
            ExcursionNameTextBox.Enabled = false; // value;
            ExcursionAuthorTextBox.Enabled = false; //  = value;
            ExcursionArticleNameLabel.Enabled = value;
            ExcursionArticleSelectButton.Enabled = value;
            ExcursionEditButton.Enabled = value;
            ExcursionEditButton.Enabled = value;
            ExcursionAddSightButton.Enabled = value;
            ExcursionRemoveSightButton.Enabled = value;
        }

        private void ToggleArticleFields(bool value)
        {
            ArticleNameTextBox.Enabled = false; // value;
            ArticleAuthorTextBox.Enabled = false; //  = value;
            ArticleEditButton.Enabled = value;
        }

        private void UpdateExcursionSightsInfo()
        {
            try
            {
                var cur = mExcursions[ExcursionsListBox.SelectedIndex];

                ExcursionSightsListBox.Items.Clear();

                var sights = from v
                             in cur.Sight
                             select v;

                mExcursionSights = sights.ToArray();

                var excursionSightStrings = from v
                                            in mExcursionSights
                                            select v.Name;

                ExcursionSightsListBox.Items.AddRange(excursionSightStrings.ToArray());
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void UpdateQueryInfo()
        {
            EntitiesComboBox.Items.Clear();
            var entities = Manager.EnumerateDbTypes().ToArray();
            EntitiesComboBox.Items.AddRange(entities);
        }

        private Sight CurrentSight
            => mSights[SightsListBox.SelectedIndex];

        private Excursion CurrentExcursion => mExcursions[ExcursionsListBox.SelectedIndex];

        private Sight CurrentExcursionSight
            => mExcursionSights[ExcursionSightsListBox.SelectedIndex];

        private Article CurrentArticle
            => mArticles[ArticlesListBox.SelectedIndex];

        private User CurrentUser
            => mUsers[UsersListBox.SelectedIndex];

        private ContentCreationResults CreateContent(bool isSight)
        {
            var results = new ContentCreationResults();

            var window = new ContentCreationForm(isSight, results);
            window.ShowDialog();

            return results;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateData.Enabled = PasswordTextBox.TextLength != 0;
        }

        private void SightsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentSight;

                bool owner = User.Owns(
                    cur
                );

                ToggleSightFields(owner);

                SightArticleNameLabel.Text = "<Нет>";

                SightNameTextBox.Text = cur.Name; // value;
                SightAuthorTextBox.Text = cur.User.Login;
                SightAddressTextBox.Text = cur.Address;
                SightArticleNameLabel.Text = cur.Article?.Name;
                AcceptSightButton.Enabled = RejectSightButton.Enabled =
                    cur.ProposalStatus != ProposalStatus.Added;
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void SightEditButton_Click(object sender, EventArgs e)
        {
            var cur = CurrentSight;

            cur.SetAddress(User, SightAddressTextBox.Text);
            cur.SetLocation(User, SightAddressTextBox.Text);

            Manager.Container.SaveChanges();

            ToggleSightFields(false);
        }

        private void SightSelectArticleButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentSight;

                var content = SelectContent(
                    "Выберите статью",
                    mArticles
                ) as Article;
                
                cur.SetArticle(User, content);
                Manager.Container.SaveChanges();

                UpdateSightsInfo();
            }
            catch (NoContentSelectedException)
            {

            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ArticlesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentArticle;

                bool owner = User.Owns(
                    cur
                );

                ToggleArticleFields(owner);

                ArticleNameTextBox.Text = cur.Name; // value;
                ArticleAuthorTextBox.Text = cur.User.Login;
                // ArticleBrowser.Navigate(cur.GetHtml().Uri);
                ArticleTextBox.Text = cur.GetHtml().GetText();
                AcceptArticleButton.Enabled = RejectArticleButton.Enabled = 
                    cur.ProposalStatus != ProposalStatus.Added;
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ArticleAddButton_Click(object sender, EventArgs e)
        {
            var results = CreateContent(false);

            if (results.Name != string.Empty)
            {
                Manager.AddArticle(
                    User,
                    results.Name
                );

                Manager.Container.SaveChanges();

                UpdateArticlesInfo();
            }
        }

        private void SightAddButton_Click(object sender, EventArgs e)
        {
            var results = CreateContent(true);
            
            if (results.Name != string.Empty)
            {
                Manager.AddSight(
                    User,
                    results.Name,
                    results.Address,
                    results.Address
                );

                Manager.Container.SaveChanges();

                UpdateSightsInfo();
            }
        }

        private void ExcursionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;

                bool owner = User.Owns(
                    cur
                );

                ToggleExcursionFields(owner);

                ExcursionArticleNameLabel.Text = "<Нет>";

                ExcursionNameTextBox.Text = cur.Name; // value;
                ExcursionAuthorTextBox.Text = cur.User.Login;
                ExcursionArticleNameLabel.Text = cur.Article?.Name;
                AcceptExcursionButton.Enabled = RejectExcursionButton.Enabled = 
                    cur.ProposalStatus != ProposalStatus.Added;

                UpdateExcursionSightsInfo();
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ExcursionAddSightButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;

                try
                {
                    var content = SelectContent(
                        "Выберите место",
                        mSights
                    ) as Sight;

                    cur.Sight.Add(content);
                    Manager.Container.SaveChanges();

                    UpdateExcursionSightsInfo();
                }
                catch (NoContentSelectedException)
                {

                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ExcursionRemoveSightButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;
                var curSight = CurrentExcursionSight;

                cur.Sight.Remove(curSight);
                Manager.Container.SaveChanges();

                UpdateExcursionSightsInfo();
            }
            catch (IndexOutOfRangeException)
            {
                Utility.Info("Место не выбрано.");
            }
        }

        private void ExcursionArticleSelectButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;

                try
                {
                    var content = SelectContent(
                        "Выберите статью",
                        mArticles
                    ) as Article;

                    cur.SetArticle(User, content);
                    Manager.Container.SaveChanges();

                    UpdateExcursionsInfo();
                }
                catch (NoContentSelectedException)
                {

                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ExcursionEditButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExcursionSightsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;

                bool owner = User.Owns(
                    cur
                );

                ExcursionAddSightButton.Enabled = owner;
                ExcursionRemoveSightButton.Enabled = owner;
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ExcursionAddButton_Click(object sender, EventArgs e)
        {
            var results = CreateContent(false);

            if (results.Name != string.Empty)
            {
                Manager.AddExcursion(
                    User,
                    results.Name
                );

                Manager.Container.SaveChanges();

                UpdateExcursionsInfo();
            }
        }

        private void ConstructQuery(BaseNode node, int x, ref int y)
        {
            const int Horz = 100;
            const int Vert = 25;

            int index = 0;

            var label = new Label()
            {
                Text = node.Property?.Name,
                Left = x * Horz,
                Top = y * Vert,
                Width = 100,
                Height = 25
            };
            var button = new Button()
            {
                Text = mSigns[index],
                Left = x * Horz + label.Width,
                Top = y * Vert, 
                Width = 35, 
                Height = 25
            };
            var text = new TextBox()
            {
                Left = x * Horz + label.Width + button.Width,
                Top = y * Vert,
                Width = 100,
                Height = 25
            };

            button.Click += (object sender, EventArgs e) =>
            {
                var self = sender as Button;
                index = (++index) % mSigns.Length;
                self.Text = mSigns[index];
                node.ComparisonOperator = BooleanOperator.FromString(
                    self.Text
                );
            };

            text.TextChanged += (object sender, EventArgs e) =>
            {
                var self = sender as TextBox;
                node.Criterium = self.Text;
            };

            QueryFlowLayout.Controls.Add(label);
            QueryFlowLayout.Controls.Add(button);
            QueryFlowLayout.Controls.Add(text);
            
            foreach (var kv in node.Nodes)
            {
                ++y;
                ConstructQuery(kv.Value, x + 1, ref y);
            }
        }

        private void Review(Content content)
        {
            var results = new ReviewResults();

            var window = new ReviewForm(
                content.Name,
                results
            );

            window.ShowDialog();

            if (results.Mark == 0)
                throw new NoContentSelectedException();

            Manager.LeaveReview(
                content, 
                User, 
                results.Mark,
                results.Review
            );
            Manager.Container.SaveChanges();
        }

        private void EntitiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var typename = (string)EntitiesComboBox.SelectedItem;

            var type = QueryConstructor.GetThisAssemblyType(
                typename
            );

            mConstructor = new QueryConstructor(typename, type);

            QueryFlowLayout.Controls.Clear();

            int y = 0;
            ConstructQuery(mConstructor.Root, 0, ref y);

            QueryButton.Enabled = true;
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            switch (EntitiesComboBox.SelectedItem)
            {
                case "Article":
                    mConstructor.Query(Manager.GetArticles());
                    break;
                case "Content":
                    mConstructor.Query(Manager.Container.ContentSet);
                    break;
                case "Excursion":
                    mConstructor.Query(Manager.GetExcursions());
                    break;
                case "MediaFile":
                    mConstructor.Query(Manager.Container.MediaFileSet);
                    break;
                case "Review":
                    mConstructor.Query(Manager.Container.ReviewSet);
                    break;
                case "Sight":
                    mConstructor.Query(Manager.GetSights());
                    break;
                case "User":
                    mConstructor.Query(Manager.Container.UserSet);
                    break;
                default:
                    break;
            }
        }

        private void ChangeStatus(Content content, ProposalStatus status = ProposalStatus.Added)
        {
            try
            {
                content.SetStatus(User, ProposalStatus.Added);
                Manager.Container.SaveChanges();
            }
            catch (AccessDeniedException)
            {
                Utility.Warn(
                    "У Вас недостаточно полномочий для работы с заявками."
                );
            }
        }

        private void AcceptSightButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentSight;
                ChangeStatus(cur);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void RejectSightButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentSight;
                ChangeStatus(cur, ProposalStatus.Rejected);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void AcceptExcursionButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;
                ChangeStatus(cur);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void RejectExcursionButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;
                ChangeStatus(cur, ProposalStatus.Rejected);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void AcceptArticleButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentArticle;
                ChangeStatus(cur);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void RejectArticleButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentArticle;
                ChangeStatus(cur, ProposalStatus.Rejected);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ArticleEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                var window = new ArticleEditorForm(CurrentArticle);
                window.ShowDialog();

                Manager.Container.SaveChanges();
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void UsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LowerButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentUser;

                cur.ChangeStatus(User, false);
            }
            catch (IndexOutOfRangeException)
            {
                
            }
        }

        private void HigherButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentUser;

                cur.ChangeStatus(User, true);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ReviewSightButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentSight;
                Review(cur);
            }
            catch (NoContentSelectedException)
            {

            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void ReviewExcursionButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cur = CurrentExcursion;
                Review(cur);
            }
            catch (NoContentSelectedException)
            {

            }
            catch (IndexOutOfRangeException)
            {

            }
        }
    }
}
