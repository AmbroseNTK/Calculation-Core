using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorLessThan : ExpressionComponent
    {
        public OperatorLessThan()
        {
            ComponentType = ExpressionComponentType.Operator;
            Identify = "<";
            Priority = 0;
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorLessThan());
        }

        public override ExpressionComponent process(Stack<ExpressionComponent> args)
        {
            if (args.Count == 2)
            {
                ExpressionComponent arg1 = args.Pop();
                ExpressionComponent arg2 = args.Pop();
                if (arg1.ComponentType == arg2.ComponentType && arg1.ComponentType == ExpressionComponentType.Number)
                {
                    if ((double)(arg1.Value) < (double)(arg2.Value))
                        return new Operands.True();
                    else
                        return new Operands.False();
                }
            }
            return new Operands.Null();
        }
    }
}
