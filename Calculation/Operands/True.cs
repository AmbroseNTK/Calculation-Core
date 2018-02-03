using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operands
{
    class True : ExpressionComponent
    {
        public True()
        {
            ComponentType = ExpressionComponentType.Boolean;
            Identify = "true";
        }
        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new True());
        }
    }
}
