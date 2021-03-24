using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MathLib
{
    /// <summary>
    /// Implementace jednotlivých operací v matematické knihovně
    /// </summary>
    public class Math : IMath
    {
        public double GetSum(double number1, double number2)
        {
            return number1 + number2;
        }
        public double GetSub(double number1, double number2)
        {
            return number1 - number2;
        }
        public double GetMul(double number1, double number2)
        {
            return number1 * number2;
        }
        public double GetDiv(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException();
            }
            return number1 / number2;
        }

        public ulong GetFactorial(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException();
            if (number == 0)
                return 1;
            var result = Convert.ToUInt64(number);
            for (var i = result - 1; i > 0; i--)
            {
                checked
                {
                    result *= i;
                }
            }
            return result;
        }

        public double GetPower(double basis, double exponent)
        {
            double result = System.Math.Pow(basis, exponent);

            if (double.IsInfinity(result) || double.IsNaN(result))
                throw new OverflowException();

            return result;
        }

        public double GetRoot(double degree, double basis)
        {
            bool minus = false;
            if (degree < 1)
                throw new ArgumentOutOfRangeException();
            if (basis < 0)
            {
                if (degree % 2 != 0)
                    minus = true;
                else
                    throw new ArgumentOutOfRangeException();
                basis = 0 - basis;
            }

            var result = System.Math.Pow(basis, 1.0 / degree);

            if (minus)
                return 0 - result;
            return result;
        }

        public double Log10(double arg)
        {
            if (arg <= 0)
                throw new ArgumentOutOfRangeException();
            return System.Math.Log10(arg);
        }

        public double LogE(double arg)
        {
            if (arg <= 0)
                throw new ArgumentOutOfRangeException();
            return System.Math.Log(arg);
        }
    }
}
