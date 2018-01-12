using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    class DividedByZeroException : Exception
    {
        public DividedByZeroException() : base("Cannot divided by zero")
        {

        }
    }
}
