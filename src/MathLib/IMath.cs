using System;

namespace MathLib
{
    /// <summary>
    /// Rozhraní pro matematickou knihovnu
    /// </summary>
    public interface IMath
    {
        /// <summary>
        /// Funkce počítající součet 2 čísel
        /// </summary>
        /// <param name="number1">Sčítanec 1</param>
        /// <param name="number2">Sčítanec 2</param>
        /// <returns>Vrací součet</returns>
        double GetSum(double number1, double number2);

        /// <summary>
        /// Funkce počítající rozdíl 2 čísel
        /// </summary>
        /// <param name="number1">Menšenec</param>
        /// <param name="number2">Menšitel</param>
        /// <returns>Vrací rozdíl</returns>
        double GetSub(double number1, double number2);

        /// <summary>
        /// Funkce počítající součin 2 čísel
        /// </summary>
        /// <param name="number1">Činitel 1</param>
        /// <param name="number2">Činitel 2</param>
        /// <returns>Vrací součin</returns>
        double GetMul(double number1, double number2);

        /// <summary>
        /// Funkce počítající podíl 2 čísel
        /// </summary>
        /// <param name="number1">Dělenec</param>
        /// <param name="number2">Dělitel</param>
        /// <returns>Vrací podíl</returns>
        double GetDiv(double number1, double number2);

        /// <summary>
        /// Funkce počítající faktoriál čísla
        /// </summary>
        /// <param name="number">Číslo faktoriálu</param>
        /// <returns>Vrací výsledný faktoriál</returns>
        ulong GetFactorial(int number);

        /// <summary>
        /// Funkce počítající N mocninu čísla
        /// </summary>
        /// <param name="basis">Základ mocniny</param>
        /// <param name="exponent">Exponent</param>
        /// <returns>Vrací výslednou mocninu</returns>
        double GetPower(double basis, double exponent);

        /// <summary>
        /// Funkce počítající obecnou odmocninu
        /// </summary>
        /// <param name="degree">Stupeň odmocniny</param>
        /// <param name="basis">Základ odmocniny</param>
        /// <returns>Vrací výslednou odmocninu</returns>
        double GetRoot(double degree, double basis);

        /// <summary>
        /// Funkce počítající dekadický logaritmus
        /// </summary>
        /// <param name="arg">Argument logaritmu</param>
        /// <returns>Vrací výsledný logaritmus</returns>
        double Log10(double arg);

        /// <summary>
        /// Funkce počítající přirozený logartimus
        /// </summary>
        /// <param name="arg">Argument logaritmu</param>
        /// <returns>Vrací výsledný logaritmus</returns>
        double LogE(double arg);
    }
}
