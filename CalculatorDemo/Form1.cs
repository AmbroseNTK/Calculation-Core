﻿using System;
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
            calculator.AddExpression("abcd true true true 1.12+-3.14 \"Hi 1234.587\" ");
            calculator.Calculate();
        }
    }
}
