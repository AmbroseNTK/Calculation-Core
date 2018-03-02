using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculation
{
    public class CodeComponent
    {
        private List<object> body;
        private string rawHead;
        private string rawBody;

        private string keyword;

        public CodeComponent() : this("", "") { }

        public CodeComponent(string rawHead, string rawBody)
        {
            this.body = new List<object>();
            this.rawHead = rawHead;
            this.rawBody = rawBody;
        }

        public string Keyword { get => keyword; set => keyword = value; }
        public string RawHead { get => rawHead; set => rawHead = value; }
        public string RawBody { get => rawBody; set => rawBody = value; }
        public List<object> Body { get => body; set => body = value; }

        public virtual void Parse(Compiler compiler){ }
    
        public void ParseKeyword(Compiler compiler, CodeComponent component)
        {
            MatchCollection matches = Regex.Matches(compiler.RawCode, 
                Keyword+ @"[\n\t ]*\((.*\n*\t*)\)[\n\t ]*\{[\n\t ]*((.*\n*\t*)*)[\n\t ]*\}");

            foreach(Match match in matches)
            {
                if (match.Groups.Count == 3)
                {
                    if (compiler.MarkToken[match.Index] != StringMarker.marker)
                    {
                        component.rawHead = match.Groups[1].Value;
                        component.rawBody = match.Groups[2].Value;
                        compiler.ListCode.Add(match.Index, component);
                       
                        for(int i = match.Index; i < match.Index + match.Length; i++)
                        {
                            compiler.MarkToken[i] = component.Keyword;
                           
                        }
                    }
                }
                else
                {
                    //Syntax error
                }
            }
        }

        public virtual void Process() { }
        public virtual void Analyze() { }

    }
}
