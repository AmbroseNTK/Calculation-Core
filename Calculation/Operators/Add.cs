using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Calculation;
using Calculation.Operands;
using Calculation.Exceptions;

namespace Calculation.Operators
{
    class Add : ExprComponent
    {
        public Add():base(ComponentType.Operator)
        {
        }

        public override int GetPriority()
        {
            return 1;
        }

        public override Dictionary<int, ExprComponent> Parse(Expression expression)
        {
            Dictionary<int, ExprComponent> result = new Dictionary<int, ExprComponent>();
            MatchCollection matchCollection = Regex.Matches(expression.Text, @"\+");
            foreach(Match match in matchCollection)
            {
                ExprComponent exprComponent = new Add();
                exprComponent.Position = match.Index;
                result.Add(match.Index, exprComponent);
            }
            return result;
        }

        public override void Process(ref Expression expression)
        {
            try
            {
                double numB = expression.ResultStack.Pop().GetValue();
                double numA = expression.ResultStack.Pop().GetValue() ?? 0;
                NumberOperand result = new NumberOperand((numA + numB).ToString());
                expression.ResultStack.Push(result);
            }
            catch
            {
                throw new AddOperatorException(this.Position);
            }
        }
    }
}
