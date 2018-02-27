using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorDivision:ExpressionComponent
    {
        public OperatorDivision()
        {
            ComponentType = ExpressionComponentType.Operator;
            Priority = 2;
            Identify = "\\/";
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorDivision());
        }

        public override ExpressionComponent process(Stack<ExpressionComponent> args)
        {
            if (args.Count == 2)
            {
                ExpressionComponent arg1 = args.Pop();
                ExpressionComponent arg2 = args.Pop();
                if (arg1.ComponentType == ExpressionComponentType.Number && arg2.ComponentType == ExpressionComponentType.Number)
                {
                    return new Operands.Number((double)(arg1.Value) / (double)(arg2.Value));
                }
            }

            return new Operands.Null();
        }
    }
}
