using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms
{
    public class ReviewResults
    {
        public ReviewResults()
        {
            Mark = 0;
            Review = string.Empty;
        }

        public int Mark { get; set; }
        public string Review { get; set; }
    }
}
