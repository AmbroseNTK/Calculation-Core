using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Keywords
{
    class Function : CodeComponent
    {
        public Function()
        {
            Keyword = "fun";
        }

        public override void Parse(Compiler compiler)
        {
            ParseKeyword(compiler, new Function());
        }
    }
}
