using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorLessThanOrEqual:ExpressionComponent
    {
        public OperatorLessThanOrEqual()
        {
            ComponentType = ExpressionComponentType.Operator;
            Identify = "<=";
            Priority = 0;
            TypeOfOperator = OperatorType.Binary;
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorLessThanOrEqual());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            if (args.Count == 2)
            {
                ExpressionComponent arg1 = args.Pop();
                ExpressionComponent arg2 = args.Pop();
                if (arg1.ComponentType == arg2.ComponentType && arg1.ComponentType == ExpressionComponentType.Number)
                {
                    if ((double)(arg1.Value) <= (double)(arg2.Value))
                        return new Operands.True();
                    else
                        return new Operands.False();
                }
            }
            return new Operands.Null();
        }
    }
}
