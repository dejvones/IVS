using System;
using System.Collections.Generic;
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
                throw new DivideByZeroException(); //TODO message
            }
            return number1 / number2;
        }

        public ulong GetFactorial(int number)
        {
            return 0;
        }

        public double GetPower(double basis, double exponent)
        {
            return 0;
        }

        public double GetRoot(double basis, double degree)
        {
            return 0;
        }

        public double Log10(double arg)
        {
            return 0;
        }

        public double LogE(double arg)
        {
            return 0;
        }
    }
}
