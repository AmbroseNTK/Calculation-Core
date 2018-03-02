using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class Compiler
    {
        private string rawCode;
        private bool enableDebug;
        private string consoleOutput;
        private Dictionary<int, string> markToken;
        private SortedDictionary<int, CodeComponent> listCode;
        private List<CodeComponent> keywords;

        public string RawCode
        {
            get => rawCode;
            set
            {
                rawCode = value;
                markToken = new Dictionary<int, string>();
                for (int i = 0; i < rawCode.Length; i++)
                {
                    markToken.Add(i, "");
                }
                StringMarker.Marking(rawCode, MarkToken);
            }
        }
        public Compiler()
        {
            listCode = new SortedDictionary<int, CodeComponent>();
            InitSyntaxAnalyzer();
        }

        public virtual void InitSyntaxAnalyzer()
        {
            keywords = new List<CodeComponent>();

        }
        public string ConsoleOutput { get => consoleOutput; set => consoleOutput = value; }
        public Dictionary<int, string> MarkToken { get => markToken; }
        public SortedDictionary<int, CodeComponent> ListCode { get => listCode; }

        public void AnalyzeSyntax()
        {
           
        }

    }
}
