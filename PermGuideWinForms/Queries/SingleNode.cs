using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms.Queries
{
    internal class SingleNode : BaseNode
    {
        public override bool IsSatisfying(object entity)
        {
            bool result = true;

            try
            {
                var fst = Property.GetValue(entity);

                if (Criterium != string.Empty)
                {
                    var snd = Convert.ChangeType(
                        Criterium,
                        Property.PropertyType
                    );

                    // Использовать заданный оператор
                    // result = snd.Equals(fst);
                    result = ComparisonOperator.Apply(snd, fst);
                }

                SatisfyForNodes(entity, ref result);
            }
            catch
            {
                // result = false;
            }

            return result;
        }
    }
}
