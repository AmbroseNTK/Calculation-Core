using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculation;
using Calculation.Operators;

namespace Calculation
{
    public class Expression
    {

        public Expression():this(""){}
        
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
        private ExpressionComponent result;
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
                StringMarker.Marking(this.RawExpression,this.MarkToken);
            }
        }

        public Dictionary<int,string> MarkToken { get => markToken; set => markToken = value; }
        public SortedDictionary<double, ExpressionComponent> ComponentList { get => componentList; set => componentList = value; }
        public ExpressionComponent Result { get => result;}

        public void AddComponent(int pos, ExpressionComponent component)
        {
            if (MarkToken[pos] != StringMarker.marker || component.ComponentType == ExpressionComponentType.String)
            {
                if (!ComponentList.ContainsKey(pos))
                {

                    if (component.ComponentType == ExpressionComponentType.Operator && MarkToken[pos] == "")
                    {
                        for (int i = pos; i < component.Identify.Length + pos; i++)
                        {
                            MarkToken[i] = component.Identify;
                        }
                        ComponentList[pos] = component;
                    }
                    if(component.ComponentType!=ExpressionComponentType.Operator)
                    {
                        ComponentList[pos] = component;
                    }
                }
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
                        if (stackOperator.Count != 0 
                            && stackOperator.Peek().Priority >= component.Priority 
                            && stackOperator.Peek().ComponentType == ExpressionComponentType.Operator)
                        {
                            postfix.Add(stackOperator.Pop());
                        }
                        stackOperator.Push(component);
                        break;
                    case ExpressionComponentType.Function:
                        stackOperator.Push(component);
                        postfix.Add(new Operators.OperatorWall());
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
            Stack<ExpressionComponent> stackResult = new Stack<ExpressionComponent>();

            foreach (ExpressionComponent component in postfix) {
                switch (component.ComponentType)
                {
                    case ExpressionComponentType.Number:
                    case ExpressionComponentType.String:
                    case ExpressionComponentType.Boolean:
                    case ExpressionComponentType.Null:
                    case ExpressionComponentType.WallO:
                        stackResult.Push(component);
                        break;
                    case ExpressionComponentType.Operator:
                        switch (component.TypeOfOperator)
                        {
                            case OperatorType.Unary:
                                if (stackResult.Count != 0)
                                {
                                    component.Args.Push(stackResult.Pop());
                                    
                                }
                                else
                                {
                                    //Error
                                }
                                break;
                            case OperatorType.Binary:
                                if (stackResult.Count > 1)
                                {
                                    component.Args.Push(stackResult.Pop());
                                    component.Args.Push(stackResult.Pop());
                                }
                                else
                                {
                                    //Error;
                                }
                                break;
                            
                        }
                        stackResult.Push(component.Process());
                        break;
                    case ExpressionComponentType.Function:
                        while(stackResult.Count!=0 && stackResult.Peek().ComponentType != ExpressionComponentType.WallO)
                        {
                            component.Args.Push(stackResult.Pop());
                        }
                        if (stackResult.Count != 0)
                        {
                            stackResult.Pop();
                        }
                        stackResult.Push(component.Process());
                        break;
                }
            }

            if (stackResult.Count != 0)
                result = stackResult.First();
            else
                result = new Operands.Null();
        
        }
    }
}
