using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Calculation;

namespace CalculatorDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();
            Expression expression = new Expression("fun(\"Main\"){ sum(1,2,3); call(\"Main\"); }");
            calculator.AddExpression(expression);
            calculator.Calculate();
        }
    }
}
