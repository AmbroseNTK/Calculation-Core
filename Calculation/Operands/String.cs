using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operands
{
    class String : ExpressionComponent
    {
        public String()
        {
            ComponentType = ExpressionComponentType.String;
            Value = "";
        }
        public String(string str)
        {
            ComponentType = ExpressionComponentType.String;
            Value = str;
        }
        public override void Parse(Expression expression)
        {
            string current = "";
            string previous = expression.RawExpression.Length == 0 ? "" : expression.MarkToken[0];
            int anchor = 0;
            for(int i = 1; i < expression.RawExpression.Length; i++)
            {
                if(expression.MarkToken[i]!=previous && expression.MarkToken[i] == StringMarker.marker)
                {
                    anchor = i;
                }
                else if(expression.MarkToken[i]!=previous && expression.MarkToken[i] != StringMarker.marker)
                {
                    if (current != "")
                    {
                        expression.AddComponent(anchor, new Operands.String(current));
                        current = "";
                    }
                }
                if (expression.MarkToken[i] == previous && expression.MarkToken[i]==StringMarker.marker)
                {
                   
                    current += expression.RawExpression[i];
                }
                previous = expression.MarkToken[i];
            }
            
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {
            return this;
        }
    }
}
