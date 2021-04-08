using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MathLib;


namespace Profiling
{
    class Program
    {
        private readonly MathLib.Math _math;
        public Program() {
            _math = new MathLib.Math();
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Rozptyl();
        }

        private void Rozptyl() {

            var numbers = GetNums();
            double variance = GetVariance(numbers);
            double standartDeviation = _math.GetRoot(2, variance);
            Console.WriteLine(standartDeviation);
        }

        public static List<string> GetNums()
        {

            var numbers = new List<string>();
            string line;
            while (true){
                line = Console.ReadLine();
                if (line == null)  break;
                var num = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                numbers.AddRange(num);
            }
            return numbers;
        }

        public double GetVariance(List<string> numbers)
        {
            double m = 0.0;
            double s = 0.0;
            double oldM = 0.0;
            double x;
            double i = 1;

            foreach (var num in numbers)
            {
                if (!Double.TryParse(num, out x))
                {
                    Console.Error.WriteLine("Chybna hodnota na vstupu !");
                    System.Environment.Exit(1);
                }
                oldM = m;
                m = _math.GetSum(m, _math.GetDiv(_math.GetSub(x, m), i));
                s = _math.GetSum(s, _math.GetMul(_math.GetSub(x, m), _math.GetSub(x, oldM)));
                i++;
            }
            double variance = _math.GetDiv(s, _math.GetSub(i, 1));
            return variance;
        }
    }
}
