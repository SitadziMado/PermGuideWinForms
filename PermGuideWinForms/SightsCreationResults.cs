using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public class ContentCreationResults
    {
        public ContentCreationResults()
        {
            Name = string.Empty;
            Address = string.Empty;
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}
