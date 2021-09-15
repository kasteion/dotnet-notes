using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Calculator
{
    public class ExpressionCalculator : ICalculator
    {
        public double Calculate(string expression)
        {
            var datatable = new DataTable();
            var value = datatable.Compute(expression, "");
            return Convert.ToDouble(value);
        }
    }
}
