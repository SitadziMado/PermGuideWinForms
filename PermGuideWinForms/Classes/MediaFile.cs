using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public partial class MediaFile
    {
        public MediaFile(
            User user, 
            string uri, 
            MediaType type
        ) : this()
        {
            User = user;
            Uri = uri;
            MediaType = type;
        }

        public static MediaFile FromString(
            User user, 
            string content
        )
        {
            if (!Directory.Exists("media"))
                Directory.CreateDirectory("media");

            var path = $"media\\{Guid.NewGuid().ToString()}";
            using (var file = File.Create(path))
            {
                ;
            }

            var mediaFile = new MediaFile(
                user,
                path,
                MediaType.Html
            );

            mediaFile.SetText(content);

            return mediaFile;
        }

        public string GetText()
        {
            return File.ReadAllText(Uri);
        }

        public void SetText(string content)
        {
            using (var stream = File.Open(Uri, FileMode.Open))
            {
                var buffer = Encoding.UTF8.GetBytes(content);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        public void AddArticle(Article article)
        {
            Article.Add(article);
        }
    }
}
