using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculation.Operands;

namespace Calculation.Operators
{
    class OperatorAdd : ExpressionComponent
    {
        public OperatorAdd()
        {
            ComponentType = ExpressionComponentType.Operator;
            Priority = 1;
            Identify = "+";
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorAdd());
        }

        public override ExpressionComponent process(Stack<ExpressionComponent> args)
        {
            if (args.Count == 1)
            {
                if (args.Peek().ComponentType == ExpressionComponentType.String)
                    return args.Pop();
                else if (args.Peek().ComponentType == ExpressionComponentType.Number)
                    return new Number(0 + (double)(args.Pop().Value));
            }
            else if (args.Count == 2)
            {
                ExpressionComponent arg1 = args.Pop();
                ExpressionComponent arg2 = args.Pop();
                if(arg1.ComponentType == ExpressionComponentType.String && arg2.ComponentType == ExpressionComponentType.String)
                {
                    return new Operands.String(arg1.Value.ToString() + arg2.Value.ToString());
                }
                else if (arg1.ComponentType == ExpressionComponentType.Number && arg2.ComponentType == ExpressionComponentType.Number)
                {
                    return new Operands.Number((double)(arg1.Value) + (double)(arg2.Value));
                }
            }
            return new Null();
        }
    }
}
