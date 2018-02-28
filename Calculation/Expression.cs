using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculation;

namespace Calculation
{
    public class Expression
    {

        public Expression()
        {
            rawExpression = "";
            ComponentList = new SortedDictionary<double, ExpressionComponent>();
            parser = new List<ExpressionComponent>();
        }
        
        public Expression(string rawExpr)
        {
            RawExpression = rawExpr;
            ComponentList = new SortedDictionary<double, ExpressionComponent>();
            parser = new List<ExpressionComponent>();
        }

        private string rawExpression;
        private SortedDictionary<double, ExpressionComponent> componentList;
        private Dictionary<int, string> markToken;
        private List<ExpressionComponent> postfix;
        private Stack<ExpressionComponent> result;
        private List<ExpressionComponent> parser;
        public string RawExpression {
            get => rawExpression;
            set
            {
                rawExpression = value;
                markToken = new Dictionary<int, string>();
                for(int i = 0; i < rawExpression.Length; i++)
                {
                    markToken.Add(i, "");
                }
                StringMarker.Marking(this);
            }
        }

        public Dictionary<int,string> MarkToken { get => markToken; set => markToken = value; }
        public SortedDictionary<double, ExpressionComponent> ComponentList { get => componentList; set => componentList = value; }

        public void AddComponent(int pos, ExpressionComponent component)
        {
            if (MarkToken[pos] != StringMarker.marker || component.ComponentType == ExpressionComponentType.String)
            {
                if (!ComponentList.ContainsKey(pos))
                    ComponentList[pos] = component;
            }
            
        }

       
        public void ToPostfix()
        {
            Stack<ExpressionComponent> stackOperator = new Stack<ExpressionComponent>();
            postfix = new List<ExpressionComponent>();
            foreach(ExpressionComponent component in componentList.Values)
            {
                switch (component.ComponentType)
                {
                    case ExpressionComponentType.Number:
                    case ExpressionComponentType.String:
                    case ExpressionComponentType.Boolean:
                    case ExpressionComponentType.Null:
                        postfix.Add(component);
                        break;
                    case ExpressionComponentType.PatheL:
                        stackOperator.Push(component);
                        break;
                    case ExpressionComponentType.PatheR:

                        while (stackOperator.Count != 0 && stackOperator.Peek().ComponentType != ExpressionComponentType.PatheL)
                        {
                            postfix.Add(stackOperator.Pop());

                        }
                        
                        if (stackOperator.Count != 0)
                        {
                            stackOperator.Pop();
                        }
                        break;
                    case ExpressionComponentType.Operator:
                        if (stackOperator.Count!=0 && stackOperator.Peek().Priority >= component.Priority)
                        {
                            postfix.Add(stackOperator.Pop());
                        }
                        stackOperator.Push(component);
                        break;
                    
                }
            }
            while (stackOperator.Count != 0)
            {
                postfix.Add(stackOperator.Pop());
            }
        }
        public void Calculate()
        {

        }
    }
}
