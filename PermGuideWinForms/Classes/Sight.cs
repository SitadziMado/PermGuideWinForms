using PermGuideWinForms.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public partial class Sight
    {
        public Sight(
            User user,
            string name,
            ProposalStatus status,
            string address, 
            string location
        ) : this()
        {
            User = user;
            Name = name;
            ProposalStatus = status;

            Address = address;
            Location = address;
        }

        public void SetAddress(User sender, string address)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            // Проверка
            Address = address;
        }

        public void SetLocation(User sender, string location)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            // Проверка
            Location = location;
        }
        
        public void SetArticle(
            User sender,
            Article article
        )
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            Article = article;
        }
    }
}
