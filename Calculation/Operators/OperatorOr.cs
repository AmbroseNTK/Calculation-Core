using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorOr:ExpressionComponent
    {
        public OperatorOr()
        {
            ComponentType = ExpressionComponentType.Operator;
            Identify = "or";
            Priority = -1;
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorOr());
        }

        public override ExpressionComponent process(Stack<ExpressionComponent> args)
        {
            if (args.Count == 2)
            {
                ExpressionComponent arg1 = args.Pop();
                ExpressionComponent arg2 = args.Pop();
                if (arg1.ComponentType == arg2.ComponentType && arg1.ComponentType == ExpressionComponentType.Boolean)
                {
                    if ((bool)arg1.Value == true || (bool)arg2.Value == true)
                        return new Operands.True();
                    else
                        return new Operands.False();
                }
            }
            return new Operands.Null();
        }
    }
}
