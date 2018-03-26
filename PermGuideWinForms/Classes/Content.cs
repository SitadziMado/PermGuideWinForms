using PermGuideWinForms.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public partial class Content
    {
        public Content(User user)
        {
            User = user;
        }
        
        public void SetStatus(
            User sender,
            ProposalStatus status
        )
        {
            if (!sender.IsModerator)
                throw new AccessDeniedException();

            ProposalStatus = status;
        }
    }
}
