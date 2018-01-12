using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Exceptions
{
    class AddOperatorException : Exception
    {
        public AddOperatorException(int pos):base("Pos("+pos+"): Cannot + ")
        {
        }
    }
}
