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

        public void AddComponent(int pos, ExpressionComponent component)
        {
            if (MarkToken[pos] != StringMarker.marker || component.ComponentType == ExpressionComponentType.String)
            {
                if (!componentList.ContainsKey(pos))
                    componentList[pos] = component;
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
