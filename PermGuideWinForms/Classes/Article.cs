using PermGuideWinForms.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public partial class Article
    {
        public Article(
            User user,
            string name,
            ProposalStatus status
        ) : this()
        {
            User = user;
            Name = name;
            ProposalStatus = status;
        }

        public void AddFile(User sender, MediaFile file)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            File.Add(file);
        }

        public MediaFile GetHtml()
        {
            var result = from v
                         in File
                         where v.MediaType == MediaType.Html
                         select v;

            return result.Single();
        }

        public void SetHtml(User sender, string content)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            GetHtml().SetText(content);
        }

        public void SetName(User sender, string value)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            Name = value;
        }
    }
}
