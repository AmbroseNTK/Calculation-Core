using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculation
{
    class Expression
    {
        private string text;
        private List<ExprComponent> exprComponent;
        private Stack<ExprComponent> resultStack;
        private Stack<ExprComponent> polishStack;
        public string Text {
            get => text;
            set
            {
                text = value;
                text = Regex.Replace(text, "([ ]{2,})", " ");
            }
        }

        public List<ExprComponent> ExprComponent { get => exprComponent; set => exprComponent = value; }
        public Stack<ExprComponent> ResultStack { get => resultStack; set => resultStack = value; }
        public Stack<ExprComponent> PolishStack { get => polishStack; set => polishStack = value; }
    }
}
