using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorAnd:ExpressionComponent
    {
        public OperatorAnd()
        {
            ComponentType = ExpressionComponentType.Operator;
            Identify = "and";
            Priority = -1;
            TypeOfOperator = OperatorType.Binary;
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorAnd());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            if (args.Count == 2)
            {
                ExpressionComponent arg1 = args.Pop();
                ExpressionComponent arg2 = args.Pop();
                if (arg1.ComponentType == arg2.ComponentType && arg1.ComponentType == ExpressionComponentType.Boolean)
                {
                    if ((bool)arg1.Value == false || (bool)arg2.Value == false)
                        return new Operands.False();
                    else
                        return new Operands.True();
                }
            }
            return new Operands.Null();
        }
    }
}
