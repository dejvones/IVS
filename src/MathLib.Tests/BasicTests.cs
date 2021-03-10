using System;
using Xunit;

namespace MathLib.Tests
{
    public class BasicTests
    {
        private readonly IMath math;

        /// <summary>
        /// Konstruktor pro základní testy
        /// </summary>
        public BasicTests()
        {
            math = new Math();
        }

        [Fact]
        public void GetSumTest()
        {
            math.GetSum(1, 1);
        }
    }
}
