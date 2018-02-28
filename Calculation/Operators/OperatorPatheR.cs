using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorPatheR:ExpressionComponent
    {
        public OperatorPatheR()
        {
            ComponentType = ExpressionComponentType.PatheR;
            Priority = 0;
            Identify = "\\)";
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorPatheR());
        }

        public override ExpressionComponent process(Stack<ExpressionComponent> args)
        {
            return new Operands.Null();
        }
    }
}
