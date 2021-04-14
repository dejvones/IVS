using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Math = MathLib.Math;

/// <summary>
/// Výběrová směrodatná odchylka, nad kterou byl proveden profiling
/// </summary>
namespace Profiling
{
    /// <summary>
    /// Implementace profilingu
    /// </summary>
    class Program
    {
        /// <summary>
        /// Hlavní funkce kódu
        /// </summary>
        /// <param name="args">Vstupní čísla pro výpočet výběrové směrodatné odchylky</param>
        static void Main(string[] args)
        {
            Math _math = new Math();
            var numbers = GetNums();
            double standartDeviation = GetDeviation(numbers, _math);
            Console.WriteLine(standartDeviation);
        }

        /// <summary>
        /// Získá čísla ze standartního vstupu a vloží je do seznamu
        /// </summary>
        /// <returns>Seznam čísel pro výpočet výběrové směrodatné odchylky</returns>
        public static List<string> GetNums()
        {

            var numbers = new List<string>();
            string line;
            while (true){
                line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }
                var num = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                numbers.AddRange(num);
            }
            return numbers;
        }

        /// <summary>
        /// Samotný výpočet výběrové směrodatné odchylky
        /// </summary>
        /// <param name="numbers">Seznam čísel, ze kterého se vypočítá výběrová směrodatná odchylka</param>
        /// <param name="_math">Instance matematické knihovny</param>
        /// <returns></returns>
        public static double GetDeviation(List<string> numbers, Math _math)
        {
            double sub;
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
                sub = _math.GetSub(x, m);
                m = _math.GetSum(m, _math.GetDiv(sub, i));
                s = _math.GetSum(s, _math.GetMul(_math.GetSub(x, m), _math.GetSub(x, oldM)));
                i++;
            }
            double variance = _math.GetDiv(s, _math.GetSub(i, 1));
            double deviation = _math.GetRoot(2, variance);
            return deviation;
        }
    }
}
