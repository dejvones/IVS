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
            Assert.Equal(math.GetSum(42, 42), 84);
            Assert.Equal(math.GetSum(1, -1), 0);
            Assert.Equal(math.GetSum(-1, -1), -2);
            Assert.Equal(math.GetSum(0, 0), 0);
            Assert.Equal(math.GetSum(0, -1), -1);
            Assert.Equal(math.GetSum(-1, 0), -1);
            Assert.Equal(math.GetSum(0, 1), 1);
            Assert.Equal(math.GetSum(1, 0), 1);
            Assert.Equal(math.GetSum(1.23456789,1.23456789), 2.46913578);
            Assert.Equal(math.GetSum(1.23456789, -1.23456789),0);
        }

        [Fact]
        public void GetSubTest()
        {
            Assert.Equal(math.GetSub(42,42),0);
            Assert.Equal(math.GetSub(1, -1), 2);
            Assert.Equal(math.GetSub(-1, 1), -2);
            Assert.Equal(math.GetSub(-1, -1), 0);
            Assert.Equal(math.GetSub(0, 0), 0);
            Assert.Equal(math.GetSub(0,-1),1);
            Assert.Equal(math.GetSub(-1, 0), -1);
            Assert.Equal(math.GetSub(0, 1), -1);
            Assert.Equal(math.GetSub(1, 0), 1);
            Assert.Equal(math.GetSub(1.23456789, 1.23456789), 0);
            Assert.Equal(math.GetSub(1.23456789, -1.23456789), 2.46913578);
        }

        [Fact]
        public void GetMulTest()
        {
            Assert.Equal(math.GetMul(1,0), 0);
            Assert.Equal(math.GetMul(0, 1), 0);
            Assert.Equal(math.GetMul(1, 1), 1);
            Assert.Equal(math.GetMul(1, -1), -1);
            Assert.Equal(math.GetMul(-1, 1), -1);
            Assert.Equal(math.GetMul(-1, -1), 1);
            Assert.Equal(math.GetMul(0, 0), 0);
            Assert.Equal(math.GetMul(1.23456789, 1.23456789), 1.524157875019052);
            Assert.Equal(math.GetMul(1.23456789, -1.23456789), -1.524157875019052);
        }

        [Fact]
        public void GetDivTest()
        {
            Assert.Equal(math.GetDiv(42, 42), 1);
            Assert.Equal(math.GetDiv(1, -1), -1);
            Assert.Equal(math.GetDiv(-1, 1), -1);
            Assert.Equal(math.GetDiv(-1, -1), 1);
            Assert.Equal(math.GetMul(0, 42), 0);
            Assert.Equal(math.GetSub(1.23456789, 1.23456789), 1);
            Assert.Equal(math.GetSub(1.23456789, -1.23456789), -1);
            Assert.Throws<DivideByZeroException>(() => math.GetDiv(42,0));
            Assert.Throws<DivideByZeroException>(() => math.GetDiv(0, 0));

        }
    }
}
