using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Vypočítá daný příklad pomocí knihovny
        /// </summary>
        private void GetResult()
        {
            //Nespravný počet operandů
            if (_operation != Operator.Fact && Input.Text == "")
            {
                MessageBox.Show("Operator vyzaduje 2 oprandy", "Chyba: Spatny zapis", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result = 0;
            int operand = 0;
            double secondOperand = 0;
            Output.Text += Input.Text + " = ";
            if (_operation != Operator.Fact)
                secondOperand = double.Parse(Input.Text, CultureInfo.InvariantCulture);
            //Podle operace provede
            switch (_operation)
            {
                case Operator.Add:
                    result = _math.GetSum(_operand, secondOperand);
                    break;
                case Operator.Sub:
                    result = _math.GetSub(_operand, secondOperand);
                    break;
                case Operator.Mul:
                    result = _math.GetMul(_operand, secondOperand);
                    break;
                case Operator.Div:
                    try
                    {
                        result = _math.GetDiv(_operand, secondOperand);
                    }
                    catch (DivideByZeroException)
                    {
                        ShowError("Nulou nelze dělit!");
                        result = 0;
                    }
                    break;
                case Operator.Fact:
                    try
                    {
                        operand = (int) _operand;
                        result = _math.GetFactorial(operand);
                    }
                    catch
                    {
                        ShowError("Faktoriál očekává celé nezáporné číslo.");
                        result = 0;
                    }
                    break;
                case Operator.Pow:
                    try
                    {
                        result = _math.GetPower(_operand, secondOperand);
                    }
                    catch (OverflowException)
                    {
                        ShowError("Výsledek není číslo.");
                        result = 0;
                    }
                    break;
                case Operator.Root:
                    try
                    {
                        result = _math.GetRoot(_operand, secondOperand);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ShowError("Nevhodný stupeň odmocniny. Stupeň odmocniny musí být větší než 0.");
                        result = 0;
                    }
                    break;
                case Operator.Log10:
                    try
                    {
                        result = _math.Log10(secondOperand);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ShowError("Operand logaritmu musí být větší než 1!");
                        result = 0;
                    }
                    break;
                case Operator.LogE:
                    try
                    {
                        result = _math.LogE(secondOperand);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ShowError("Operand logaritmu musí být větší než 1!");
                        result = 0;
                    }
                    break;
            }
            //Vypíše
            _operation = Operator.None;
            result = Math.Round(result, 12);
            Input.Text = Convert.ToString(result);
            _operand = result;
        }

        /// <summary>
        /// Zobrazí okno Erroru s daným textem
        /// </summary>
        /// <param name="text">Text Erroru</param>
        private void ShowError(string text)
        {
            HideAll.Visibility = Visibility.Visible;
            Error.Visibility = Visibility.Visible;
            ErrorText.Text = text;
        }

        /// <summary>
        /// Kliknutí na tlačítko Ok, při zobrazení Erroru a jeho ukončení
        /// </summary>
        /// <param name="sender">Tlačítko Ok v Erroru</param>
        /// <param name="e">Událost kliknutí</param>
        private void BtnErrorOk_OnClick(object sender, RoutedEventArgs e)
        {
            HideAll.Visibility = Visibility.Hidden;
            Error.Visibility = Visibility.Hidden;
        }
    }
}
