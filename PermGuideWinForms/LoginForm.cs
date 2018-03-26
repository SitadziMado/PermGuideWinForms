using PermGuideWinForms.Classes;
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
    public partial class LoginForm : Form
    {
        private MainForm mParent;

        public LoginForm(MainForm parent)
        {
            InitializeComponent();
            mParent = parent;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var user = mParent.Manager.Login(
                    LoginTextBox.Text,
                    PasswordTextBox.Text
                );

                mParent.User = user;

                Close();
            }
            catch (UserNotRegisteredException)
            {
                Utility.Info(
                    "Не удалось войти, проверьте корректность введенных данных."
                );
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                var user = mParent.Manager.Register(
                    LoginTextBox.Text,
                    PasswordTextBox.Text,
                    NicknameTextBox.Text
                );

                mParent.User = user;

                Close();
            }
            catch (UserNotRegisteredException)
            {
                Utility.Info("Не удалось зарегистрировать пользователя.");
            }
        }
    }
}
