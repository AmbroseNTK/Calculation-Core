using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

        public void AutoLoadParser()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<Type> listParser = assembly.GetTypes()
                .Where(type => (type.Namespace == "Calculation.Operators") 
                || (type.Namespace == "Calculation.Operands") 
                || (type.Namespace == "Calculation.Functions")).ToList();

            parser = new List<ExpressionComponent>();
            listParser.ForEach(type => parser.Add(Activator.CreateInstance(type) as ExpressionComponent));
            


        }

        public void Parse(Expression expression)
        {
            if (parser == null)
            {
                AutoLoadParser();
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
