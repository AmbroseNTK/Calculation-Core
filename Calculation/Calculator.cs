using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class Calculator
    {
        public Calculator()
        {
            expressions = new List<Expression>();
        }
        private List<Expression> expressions;
        private List<ExpressionComponent> parser;
        public void AddExpression(string rawExpr)
        {
            expressions.Add(new Expression(rawExpr));
        }

        public void Parse(Expression expression)
        {
            if (parser == null)
            {
                parser = new List<ExpressionComponent>();
                parser.Add(new Operands.Number());
                parser.Add(new Operands.String());
                parser.Add(new Operands.True());
                parser.Add(new Operands.False());
            }

            foreach (ExpressionComponent component in parser)
            {
                component.Parse(expression);
            }


        }
        public void Calculate()
        {
            foreach(Expression expression in expressions)
            {
                Parse(expression);
            }
        }
    }
}
