using System;
using Xunit;

/// <summary>
/// Testy pro matematickou knihovnu
/// </summary>
namespace MathLib.Tests
{
    /// <summary>
    /// Pokročilé testy pro matematickou knihovnu
    /// </summary>
    public class AdvancedTests
    {
        /// <summary>
        /// Instance matematické knihovny
        /// </summary>
        private readonly IMath math;

        /// <summary>
        /// Konstruktor pro pokročilé testy, který vytvoří novou instanci matematické knihovny
        /// </summary>
        public AdvancedTests()
        {
            math = new Math();
        }

        /// <summary>
        /// Test funkce pro vypocet faktorialu
        /// </summary>
        [Fact]
        public void GetFactorialTest()
        {
            Assert.Equal(math.GetFactorial(5),Decimal.ToUInt64(120));
            Assert.Equal(math.GetFactorial(1), Decimal.ToUInt64(1));
            Assert.Equal(math.GetFactorial(0), Decimal.ToUInt64(1));
            Assert.Equal(math.GetFactorial(20), Decimal.ToUInt64(2432902008176640000));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.GetFactorial(-1));
            Assert.Throws<OverflowException>(() => math.GetFactorial(50));
        }

        /// <summary>
        /// Test funkce pro vypocet mocniny o ruznem zakladu
        /// </summary>
        [Fact]
        public void GetPowerTest()
        {
            Assert.Equal(1,math.GetPower(42,0));
            Assert.Equal(1,math.GetPower(0, 0));
            Assert.Equal(0,math.GetPower(0, 42));
            Assert.Equal(4,math.GetPower(2, 2));

            //Predpoklada se (-1)^0 == 1 
            Assert.Equal(1,math.GetPower(-1, 0));
            Assert.Equal(42,math.GetPower(42, 1));
            Assert.Equal(0.5,math.GetPower(2, -1));
            Assert.Equal(1,math.GetPower(42, 0));
            Assert.Equal(-2,math.GetPower(-0.5, -1));
            Assert.Equal(8.8817841970012525E+84, math.GetPower(50,50));
            //inf
            Assert.Throws<OverflowException>(() => math.GetPower(0.0000005, -100)); 
        }

        /// <summary>
        /// Test funkce pro vypocet odmocniny o ruznem zakladu
        /// </summary>
        [Fact]
        public void GetRootTest()
        {
            Assert.Equal(10,math.GetRoot(2,100));
            Assert.Equal(2,math.GetRoot(3, 8));
            Assert.Equal(8,math.GetRoot(1, 8));
            Assert.Equal(0,math.GetRoot(2, 0));
            Assert.Equal(1,math.GetRoot(3, 1));
            Assert.Equal(-2,math.GetRoot(3,-8));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.GetRoot(0, 8));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.GetRoot(-1,42));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.GetRoot(2, -42));

        }

        /// <summary>
        /// Test funkce pro vypocet logaritmu o zakladu 10
        /// </summary>
        [Fact]
        public void GetLog10Test()
        { 
            Assert.Equal(0,math.Log10(1));
            Assert.Equal(0.6989700043360189, math.Log10(5));
            Assert.Equal(2,math.Log10(100));
            Assert.Equal(-4,math.Log10(0.0001));
            Assert.Equal(0.3979400086720376, math.Log10(2.5));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.Log10(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.Log10(-1));
        }

        /// <summary>
        /// Test funkce pro vypocet logaritmu o zakladu E
        /// </summary>
        [Fact]
        public void GetLogETest()
        {
            Assert.Equal(0,math.LogE(1));
            Assert.Equal(1.6094379124341003, math.LogE(5));
            Assert.Equal(4.605170185988092, math.LogE(100));
            Assert.Equal(-9.210340371976182, math.LogE(0.0001));
            Assert.Equal(0.9162907318741551, math.LogE(2.5));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.LogE(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => math.LogE(-1));
        }
    }
}
