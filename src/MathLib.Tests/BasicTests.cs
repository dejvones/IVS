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
            Assert.Equal(84,math.GetSum(42, 42));
            Assert.Equal(0,math.GetSum(1, -1));
            Assert.Equal(-2,math.GetSum(-1, -1));
            Assert.Equal(0,math.GetSum(0, 0));
            Assert.Equal(-1,math.GetSum(0, -1));
            Assert.Equal(-1,math.GetSum(-1, 0));
            Assert.Equal(1,math.GetSum(0, 1));
            Assert.Equal(1,math.GetSum(1, 0));
            Assert.Equal(2.46913578,math.GetSum(1.23456789,1.23456789));
            Assert.Equal(0,math.GetSum(1.23456789, -1.23456789));
        }

        [Fact]
        public void GetSubTest()
        {
            Assert.Equal(0,math.GetSub(42,42));
            Assert.Equal(2,math.GetSub(1, -1));
            Assert.Equal(-2,math.GetSub(-1, 1));
            Assert.Equal(0,math.GetSub(-1, -1));
            Assert.Equal(0,math.GetSub(0, 0));
            Assert.Equal(1,math.GetSub(0,-1));
            Assert.Equal(-1,math.GetSub(-1, 0));
            Assert.Equal(-1,math.GetSub(0, 1));
            Assert.Equal(1,math.GetSub(1, 0));
            Assert.Equal(0,math.GetSub(1.23456789, 1.23456789));
            Assert.Equal(2.46913578,math.GetSub(1.23456789, -1.23456789));
        }

        [Fact]
        public void GetMulTest()
        {
            Assert.Equal(0,math.GetMul(1,0));
            Assert.Equal(0,math.GetMul(0, 1));
            Assert.Equal(1,math.GetMul(1, 1));
            Assert.Equal(-1,math.GetMul(1, -1));
            Assert.Equal(-1,math.GetMul(-1, 1));
            Assert.Equal(1,math.GetMul(-1, -1));
            Assert.Equal(0,math.GetMul(0, 0));
            Assert.Equal(1.524157875019052,math.GetMul(1.23456789, 1.23456789));
            Assert.Equal(-1.524157875019052,math.GetMul(1.23456789, -1.23456789));
        }

        [Fact]
        public void GetDivTest()
        {
            Assert.Equal(1,math.GetDiv(42, 42));
            Assert.Equal(-1,math.GetDiv(1, -1));
            Assert.Equal(-1,math.GetDiv(-1, 1));
            Assert.Equal(1,math.GetDiv(-1, -1));
            Assert.Equal(0,math.GetMul(0, 42));
            Assert.Equal(1,math.GetSub(1.23456789, 1.23456789));
            Assert.Equal(-1,math.GetSub(1.23456789, -1.23456789));
            Assert.Throws<DivideByZeroException>(() => math.GetDiv(42,0));
            Assert.Throws<DivideByZeroException>(() => math.GetDiv(0, 0));

        }
    }
}
