using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Calculation;
using Calculation.Operators;

namespace Calculation
{
    public enum ExpressionComponentType
    {
        Number,
        String,
        Boolean,
        Null,
        Operator,
        PatheL,
        PatheR,
        WallO,
        Function,
        Keyword
    }

    public abstract class ExpressionComponent
    {
        public ExpressionComponent()
        {
            priority = 0;
            identify = "";
            componentType = ExpressionComponentType.Null;
            value = 0;
            Args = new Stack<ExpressionComponent>();
            typeOfOperator = OperatorType.Many;
        }
        private int priority;
        private string identify;
        private ExpressionComponentType componentType;
        private object value;
        private Stack<ExpressionComponent> args;
        private OperatorType typeOfOperator;

        public int Priority { get => priority; set => priority = value; }
        public string Identify { get => identify; set => identify = value; }
        public ExpressionComponentType ComponentType { get => componentType; set => componentType = value; }
        public object Value { get => value; set => this.value = value; }
        public Stack<ExpressionComponent> Args { get => args; set => args = value; }
        public OperatorType TypeOfOperator { get => typeOfOperator; set => typeOfOperator = value; }

        public abstract void Parse(Expression expression);
        public virtual void ParseByLookingFor(Expression expression, ExpressionComponent component)
        {
            MatchCollection collection = Regex.Matches(expression.RawExpression, identify);
            foreach (Match match in collection)
            {
                //Warning!!! Clone object
                expression.AddComponent(match.Index, component);
            }
        }
        public ExpressionComponent Process()
        {
            return Process(Args);
        }
        public abstract ExpressionComponent Process(Stack<ExpressionComponent> args);
    }
}
