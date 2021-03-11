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
        public void GetFactorialTest()
        {
            Assert.Equal(math.GetFactorial(5),Decimal.ToUInt64(120));
            Assert.Equal(math.GetFactorial(1), Decimal.ToUInt64(1));
            Assert.Equal(math.GetFactorial(0), Decimal.ToUInt64(1));
            Assert.Equal(math.GetFactorial(20), Decimal.ToUInt64(2432902008176640000));
            //TODO
            //Assert.Equal(math.GetFactorial(0.5), Decimal.ToUInt64(0.88622692545));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.GetFactorial(-1));
            Assert.Throws<OverflowException>(() => math.GetFactorial(50));
        }

        [Fact]
        public void GetPowerTest()
        {
            Assert.Equal(math.GetPower(42,0),1);
            Assert.Equal(math.GetPower(0, 0), 1);
            Assert.Equal(math.GetPower(0, 42), 0);
            Assert.Equal(math.GetPower(2, 2), 4);

            //Predpoklada se -(1)^0 == -1   (-1)^0 == 0 by bylo rozsireni
            Assert.Equal(math.GetPower(-1, 0), -1);
            Assert.Equal(math.GetPower(42, 1), 42);
            Assert.Equal(math.GetPower(2, -1), 0.5);
            Assert.Equal(math.GetPower(42, 0), 1);
            Assert.Equal(math.GetPower(-0.5, -1), -2);
            Assert.Throws<OverflowException>(() => math.GetPower(50,50));
            //inf
            Assert.Throws<OverflowException>(() => math.GetPower(0.0000005, -100)); 
        }

        [Fact]
        public void GetRootTest()
        {
            Assert.Equal(math.GetRoot(2,100),10);
            Assert.Equal(math.GetRoot(3, 8), 2);
            Assert.Equal(math.GetRoot(1, 8), 8);
            Assert.Equal(math.GetRoot(0, 8), 0);
            Assert.Equal(math.GetRoot(2, 0), 0);
            Assert.Equal(math.GetRoot(3, 1), 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => math.GetRoot(-1,42));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.GetRoot(2, -42));

        }

        [Fact]
        public void GetLog10Test()
        { 
            Assert.Equal(math.Log10(1),0);
            Assert.Equal(math.Log10(5), 0.698970004336);
            Assert.Equal(math.Log10(100), 2);
            Assert.Equal(math.Log10(0.0001), -4);
            Assert.Equal(math.Log10(2.5), 0.397940008672);
            Assert.Throws<ArgumentOutOfRangeException>(() => math.Log10(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.Log10(-1));
        }

        [Fact]
        public void GetLogETest()
        {
            Assert.Equal(math.LogE(1), 0);
            Assert.Equal(math.LogE(5), 0.698970004336);
            Assert.Equal(math.LogE(100), 4.6051701859881);
            Assert.Equal(math.LogE(0.0001), -9.2103403719762);
            Assert.Equal(math.LogE(2.5), 0.91629073187416);
            Assert.Throws<ArgumentOutOfRangeException>(() => math.LogE(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.LogE(-1));
        }
    }
}
