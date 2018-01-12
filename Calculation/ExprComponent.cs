using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculation.Interfaces;

namespace Calculation
{
    public enum ComponentType
    {
        WallOperator,
        Bracket,
        StringOperand,
        LogicOperand,
        NumberOperand,
        Operator,
        Function
    }
    abstract class ExprComponent
    {
        private ComponentType componentType;
        private string textValue;
        private int position;
        public ExprComponent()
        {
            textValue = string.Empty;
        }
        public ExprComponent(ComponentType componentType)
        {
            this.componentType = componentType;
            this.textValue = string.Empty;
        }
        public ExprComponent(ComponentType componentType, string textValue)
        {
            this.componentType = componentType;
            this.textValue = textValue;
        }

        public ComponentType ComponentType { get => componentType; set => componentType = value; }
        public string TextValue { get => textValue; set => textValue = value; }
        public int Position { get => position; set => position = value; }

        public abstract int GetPriority();
        public abstract void Process(ref Expression expression);

        public abstract Dictionary<int, ExprComponent> Parse(Expression expression);
        public virtual dynamic GetValue() => 0;
    }
}
