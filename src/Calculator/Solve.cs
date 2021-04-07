using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private void GetResult()
        {
            if (_operation != Operator.Fact && Input.Text == "")
            {
                MessageBox.Show("Operator vyzaduje 2 oprandy", "Chyba: Spatny zapis", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result = 0;
            int operand = 0;
            Output.Text += Input.Text + " = ";
            double secondOperand = Convert.ToDouble(Input.Text);
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
                        MessageBox.Show("Nulou nelze dělit", "Dělení nulou", MessageBoxButton.OK,
                            MessageBoxImage.Error);
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
                        MessageBox.Show("Očekává se celé nezáporné číslo", "Nevhodný operand", MessageBoxButton.OK,
                            MessageBoxImage.Error);
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
                        MessageBox.Show("Výsledek není číslo", "Nekonečno", MessageBoxButton.OK,
                            MessageBoxImage.Error);
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
                        MessageBox.Show("Nevhodný stupeň odmocniny. Stupeň odmocniny musí být větší než 0.", "Nevhodný stupeň", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
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
                        MessageBox.Show("Operand logaritmu musí být větší než 1.", "Nevhodný operand",
                            MessageBoxButton.OK, MessageBoxImage.Error);
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
                        MessageBox.Show("Operand logaritmu musí být větší než 1.", "Nevhodný operand",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        result = 0;
                    }
                    break;
            }
            _operation = Operator.None;
            Input.Text = Convert.ToString(result);
            _operand = result;
        }
    }
}
