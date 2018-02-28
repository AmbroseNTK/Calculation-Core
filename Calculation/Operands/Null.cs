using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operands
{
    class Null : ExpressionComponent
    {
        public Null()
        {
            ComponentType = ExpressionComponentType.Null;
            Identify = "null";
            Priority = 0;
        }
        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new Null());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            return this;
        }
    }
}
