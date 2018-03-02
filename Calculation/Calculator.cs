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
        public void AddExpression(Expression expression)
        {
            expressions.Add(expression);
        }
        public void AutoLoadParser()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<Type> listParser = assembly.GetTypes()
                .Where(type => (type.Namespace == "Calculation.Operators")
                || (type.Namespace == "Calculation.Operands")
                || (type.Namespace == "Calculation.Functions")).ToList();

            listParser.ForEach(
                delegate (Type type)
                {
                    ExpressionComponent component = Activator.CreateInstance(type) as ExpressionComponent;
                    if (!parser.Contains(component))
                    {
                        parser.Add(component);
                    }

                }
            );

        }

        public void Parse(Expression expression)
        {
            if (parser == null)
            {
                parser = new List<ExpressionComponent>();

                parser.Add(new Operands.Number()); //Number is the most important component
                parser.Add(new Operators.OperatorGreaterThanOrEqual());
                parser.Add(new Operators.OperatorLessThanOrEqual());
                AutoLoadParser();
            }

            foreach (ExpressionComponent component in parser)
            {
                component.Parse(expression);
            }

            for(int i = 0; i < expression.ComponentList.Values.Count - 1; i++)
            {
                if(expression.ComponentList.Values.ToList()[i].ComponentType == expression.ComponentList.Values.ToList()[i + 1].ComponentType 
                    && expression.ComponentList.Values.ToList()[i].ComponentType == ExpressionComponentType.Number)
                {
                    if ((double)(expression.ComponentList.Values.ToList()[i + 1].Value) <= 0)
                    {
                        double key1 = expression.ComponentList.SingleOrDefault(component => component.Value == expression.ComponentList.Values.ToList()[i]).Key;
                        double key2 = expression.ComponentList.SingleOrDefault(component => component.Value == expression.ComponentList.Values.ToList()[i+1]).Key;
                        expression.ComponentList.Add((key1 + key2) / 2d, new Operators.OperatorAdd());
                    }
                }
            }
        }
        public void Calculate()
        {
            foreach(Expression expression in expressions)
            {
                Parse(expression);
                expression.ToPostfix();
                expression.Calculate();
            }
        }
    }
}
