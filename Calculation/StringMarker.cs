using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    class StringMarker
    {
        public static string marker = "STRING";
        public static void Marking(Expression expression)
        {
            
            bool inStr = false;
            for (int i = 0; i < expression.RawExpression.Length; i++)
            {
                if (expression.RawExpression[i] == '"')
                {

                    if (i > 0 && expression.RawExpression[i - 1] == '\\')
                    {
                        expression.MarkToken[i] = marker;
                        continue;
                    }

                    inStr = !inStr;
                }
                expression.MarkToken[i] = inStr ? marker : "";
            }
        }
    }
}
