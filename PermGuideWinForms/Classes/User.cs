using PermGuideWinForms.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public partial class User
    {
        public User(
            string login,
            string password, 
            UserStatus status, 
            BanStatus banStatus
        ) : this()
        {
            Login = login;
            SetData(password);
            Status = status;
            BanStatus = banStatus;
        }

        public void SetData(string password, string nickname = "")
        {
            if (password != "")
            {
                Password = password.Encrypt();
                Nickname = nickname;
            }
            else
            {
                throw new ArgumentException("Пароль не должен быть пустым.");
            }
        }

        public void SetStatus(User sender, UserStatus status)
        {
            if (!sender.IsAdmin)
                throw new AccessDeniedException();

            Status = status;
        }

        public void SetBanned(User sender, BanStatus banStatus)
        {
            if (!sender.IsAdmin)
                throw new AccessDeniedException();

            BanStatus = banStatus;
        }

        public void ChangeStatus(User user, bool upgrade)
        {
            if (upgrade)
            {
                switch (Status)
                {
                    case UserStatus.User:
                        Status = UserStatus.Moderator;
                        break;
                    case UserStatus.Moderator:
                        Status = UserStatus.Administrator;
                        break;
                    case UserStatus.Administrator:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (Status)
                {
                    case UserStatus.User:
                        break;
                    case UserStatus.Moderator:
                        Status = UserStatus.User;
                        break;
                    case UserStatus.Administrator:
                        Status = UserStatus.Moderator;
                        break;
                    default:
                        break;
                }
            }
        }

        public bool Owns(Content content) => this == content.User;
        public bool IsAdmin => Status == UserStatus.Administrator;
        public bool IsModerator => IsAdmin || Status == UserStatus.Moderator;
    }
}
