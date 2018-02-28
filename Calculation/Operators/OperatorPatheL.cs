using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorPatheL:ExpressionComponent
    {
        public OperatorPatheL()
        {
            ComponentType = ExpressionComponentType.PatheL;
            Priority = 0;
            Identify = "\\(";
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorPatheL());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            return new Operands.Null();
        }
    }
}
