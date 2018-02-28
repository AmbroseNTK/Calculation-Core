using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorWall : ExpressionComponent
    {
        public OperatorWall()
        {
            ComponentType = ExpressionComponentType.WallO;
            Priority = 0;
            
        }

        public override void Parse(Expression expression)
        {
            
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            return new Operands.Null();
        }
    }
}
