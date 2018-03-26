using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms.Queries
{
    internal class CollectionNode : BaseNode
    {
        public override bool IsSatisfying(object entity)
        {
            bool result = true;

            try
            {
                var fst = Property.GetValue(entity) as IEnumerable;

                foreach (var emb in fst)
                {
                    if (!result)
                        break;

                    SatisfyForNodes(emb, ref result);
                }
            }
            catch
            {
                // result = false;
            }

            return result;
        }
    }

}
