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
            componentList = new SortedDictionary<int, ExpressionComponent>();
            parser = new List<ExpressionComponent>();
        }
        
        public Expression(string rawExpr)
        {
            RawExpression = rawExpr;
            componentList = new SortedDictionary<int, ExpressionComponent>();
            parser = new List<ExpressionComponent>();
        }

        private string rawExpression;
        private SortedDictionary<int, ExpressionComponent> componentList;
        private bool[] stringMarkArr;
        private List<ExpressionComponent> postfix;
        private Stack<ExpressionComponent> result;
        private List<ExpressionComponent> parser;
        public string RawExpression {
            get => rawExpression;
            set
            {
                rawExpression = value;
                stringMarkArr = new bool[rawExpression.Length];
                bool inStr = false;
                for(int i = 0; i < rawExpression.Length; i++)
                {
                    if (rawExpression[i] == '"')
                    {
                        
                        if (i > 0 && rawExpression[i - 1] == '\\')
                        {
                            StringMarkArr[i] = inStr;
                            continue;
                        }

                        inStr = !inStr;  
                    }
                    StringMarkArr[i] = inStr;
                }
               
            }
        }

        public bool[] StringMarkArr { get => stringMarkArr;}

        public void AddComponent(int pos, ExpressionComponent component)
        {
            if (!StringMarkArr[pos] || component.ComponentType == ExpressionComponentType.String)
            {
                componentList.Add(pos, component);
            }
        }

       
        public void ToPostfix()
        {

        }
        public void Calculate()
        {

        }
    }
}
