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
            Value = true;
        }
        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new True());
        }

        public override ExpressionComponent process(Stack<ExpressionComponent> args)
        {
            return this;
        }
    }
}
