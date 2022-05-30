using NUnit.Framework;
using System.Collections.Generic;

namespace Sample_Project.NUnitTests
{
    public class Tests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestCaseSource(nameof(SourceProvider))]
        public void WhenDivideTwoNumbers_ThenReturnDivisionOfTwoNumbers(int a, int b, int expected)
        {

            var actual = _calculator.Divide(a, b);

            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<int[]> SourceProvider()
        {
            yield return new int[] { 300, 100, 3 };
        }
    }
}