using PermGuideWinForms.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public partial class Excursion
    {
        public Excursion(
            User user, 
            string name,
            ProposalStatus status
        ) : this()
        {
            User = user;
            Name = name;
            ProposalStatus = status;
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
