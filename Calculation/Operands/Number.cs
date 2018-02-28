using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Calculation.Operands
{
    class Number : ExpressionComponent
    {
        public Number()
        {
            ComponentType = ExpressionComponentType.Number;
            Value = new Double();
          
        }
        public Number(double num)
        {
            ComponentType = ExpressionComponentType.Number;
            Value = num;
        }
        public Number(string strNum)
        {
            ComponentType = ExpressionComponentType.Number;
            double result = 0;
            if(Double.TryParse(strNum,out result))
            {
                Value = result;
            }
            else
            {
                //Parser failed
            }
        }
        public override void Parse(Expression expression)
        {
            MatchCollection collection = Regex.Matches(expression.RawExpression, "-?\\d+\\.*\\d*");
            foreach(Match match in collection)
            {
                for (int i = match.Index; i < match.Index + match.Length; i++)
                {
                    if (expression.MarkToken[i] != StringMarker.marker)
                    {
                        expression.MarkToken[i] = "NUMBER";
                    }
                }
                expression.AddComponent(match.Index, new Number(match.Value));
            }
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            return this;
        }
    }
}
