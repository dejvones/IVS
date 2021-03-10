using System;
using Xunit;

namespace MathLib.Tests
{
    public class AdvancedTests
    {
        private readonly IMath math;

        /// <summary>
        /// Konstruktor pro pokročilé testy
        /// </summary>
        public AdvancedTests()
        {
            math = new Math();
        }

        [Fact]
        public void GetSumTest()
        {
            math.GetFactorial(1);
        }
    }
}
