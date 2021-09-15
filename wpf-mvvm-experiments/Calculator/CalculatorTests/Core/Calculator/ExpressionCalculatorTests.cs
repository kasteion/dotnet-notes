using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Calculator.Tests
{
    [TestClass()]
    public class ExpressionCalculatorTests
    {
        [TestMethod()]
        public void ShouldCalculate()
        {
            var expression = "2+2";
            var calculator = new ExpressionCalculator();
            var value = calculator.Calculate(expression);
            Assert.AreEqual(4, value);
        }
    }
}