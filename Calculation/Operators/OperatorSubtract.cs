using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorSubtract : ExpressionComponent
    {
        public OperatorSubtract()
        {
            ComponentType = ExpressionComponentType.Operator;
            Priority = 1;
            Identify = "\\-";
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorSubtract());
        }

        public override ExpressionComponent process(Stack<ExpressionComponent> args)
        {

            return new Operands.Null();
        }
    }
}
