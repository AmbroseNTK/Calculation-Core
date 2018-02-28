using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operands
{
    class False:ExpressionComponent
    {
        public False()
        {
            ComponentType = ExpressionComponentType.Boolean;
            Identify = "false";
            Value = false;
        }
        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new False());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            return this;
        }
    }
}
