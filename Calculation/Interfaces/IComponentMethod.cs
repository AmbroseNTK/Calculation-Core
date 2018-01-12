using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    interface IComponentMethod
    {
        Dictionary<int, ExprComponent> Parse(Expression expression);
    }
}
