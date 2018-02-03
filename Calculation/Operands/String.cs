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
            int archor = 0;
            bool previous = expression.StringMarkArr.Length == 0 ? false : expression.StringMarkArr[0];
            for(int i = 1; i < expression.RawExpression.Length; i++)
            {
                if (expression.StringMarkArr[i] != previous)
                {
                    if (expression.StringMarkArr[i])
                    {
                        archor = i;
                    }
                    else if (!expression.StringMarkArr[i])
                    {
                        current = expression.RawExpression.Substring(archor + 1, i - archor - 1);
                        expression.AddComponent(archor, new String(current));
                    }
                }
                previous = expression.StringMarkArr[i];
            }
        }
    }
}
