﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Operators
{
    class OperatorSubtract : ExpressionComponent
    {
        public OperatorSubtract()
        {
            ComponentType = ExpressionComponentType.Operator;
            Priority = 1;
            Identify = "\\-";
            TypeOfOperator = OperatorType.Binary;
        }

        public override void Parse(Expression expression)
        {
            ParseByLookingFor(expression, new OperatorSubtract());
        }

        public override ExpressionComponent Process(Stack<ExpressionComponent> args)
        {

            return new Operands.Null();
        }
    }
}
