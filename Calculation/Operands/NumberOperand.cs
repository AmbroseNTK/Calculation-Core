using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operands
{
    class NumberOperand : ExprComponent
    {
        public NumberOperand()
        {
        }

        public NumberOperand( string textValue) : base(ComponentType.NumberOperand, textValue)
        {

        }

        public override int GetPriority()
        {
            return 0;
        }

        public override Dictionary<int, ExprComponent> Parse(Expression expression)
        {
            throw new NotImplementedException();
        }

        public override void Process(ref Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
