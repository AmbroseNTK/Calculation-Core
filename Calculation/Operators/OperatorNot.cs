using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorNot : ExpressionComponent
    {
        public OperatorNot()
        {
            ComponentType = ExpressionComponentType.Operator;
            TypeOfOperator = OperatorType.Unary;
            Identify = "!";
            Priority = 0;
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorNot());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            if (args.Count == 1)
            {
                if (args.Peek().ComponentType == ExpressionComponentType.Boolean)
                {
                    bool val = (Boolean)args.Pop().Value;
                    if (val)
                        return new Operands.False();
                    return new Operands.True();
                }
                else
                {
                    //Type error
                }
            }
            // Arg error
            return new Operands.Null();
        }
    }
}
