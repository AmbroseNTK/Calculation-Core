using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Functions
{
    class Sum : ExpressionComponent
    {
        public Sum()
        {
            ComponentType = ExpressionComponentType.Function;
            Identify = "sum";
            Priority = 0;
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new Sum());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            double result = 0;
            while (args.Count != 0)
            {
                if (args.Peek().ComponentType == ExpressionComponentType.Number)
                {
                    result += (double)args.Pop().Value;
                }
                else
                {

                    //Type error
                    return new Operands.Null();
                }
            }
            return new Operands.Number(result);
        }
    }
}
