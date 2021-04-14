using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MathLib;

/// <summary>
/// Implementace kalkulačky pomocí námi implementované knihovny Math.
/// </summary>
namespace Calculator
{
    /// <summary>
    /// Logika pro kalkulačku
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Výčet možný operátorů kalkulačky
        /// </summary>
        private enum Operator
        { 
            None, Add, Sub, Mul, Div, Fact, Pow, Root, Log10, LogE, AfterRemove
        }

        /// <summary>
        /// Aktuální operace
        /// </summary>
        private Operator _operation = Operator.None;

        /// <summary>
        /// Uložení 1. operandu
        /// </summary>
        private double _operand;

        /// <summary>
        /// Instance matematické knihovny
        /// </summary>
        private MathLib.Math _math;

        /// <summary>
        /// Konstruktor třídy, vytvoří novou instanci matematické knihovny
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _math = new MathLib.Math();
        }

        /// <summary>
        /// Při každém levém kliknutí myši, se nastaví focus na vstupní textbox
        /// </summary>
        /// <param name="sender">Objekt, na který bylo kliknuto</param>
        /// <param name="e">Událost kliknutí</param>
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) => 
            SetFocus();

        /// <summary>
        /// Nastaví focus na vstupní textbox
        /// </summary>
        private void SetFocus() => 
            Input.Focus();

        /// <summary>
        /// Při najetí na obrázek "i" se zobrazí text
        /// </summary>
        /// <param name="sender">Obrázek "i"</param>
        /// <param name="e">Událost najetí</param>
        private void Image_MouseEnter(object sender, MouseEventArgs e) => 
            InfoCard.Visibility = Visibility.Visible;

        /// <summary>
        /// Při sjetí z obrázku "i" zobrazený text zmizí
        /// </summary>
        /// <param name="sender">Obrázek "i"</param>
        /// <param name="e">Událost sjetí z prvku</param>
        private void Image_MouseLeave(object sender, MouseEventArgs e) => 
            InfoCard.Visibility = Visibility.Hidden;

        /// <summary>
        /// Rozhodnutí o tom, zda-li stisknutou klávesu zpracovat
        /// </summary>
        /// <param name="sender">Vstupní textbox</param>
        /// <param name="e">Událost textu, který se zobrazí</param>
        private void Input_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Pokud to je operátor
            switch (e.Text)
            {
                case "+":
                    Operator_Click(Add);
                    e.Handled = true;
                    return;
                case "-":
                    Operator_Click(Sub);
                    e.Handled = true;
                    return;
                case "*":
                    Operator_Click(Mul);
                    e.Handled = true;
                    return;
                case "/":
                    Operator_Click(Div);
                    e.Handled = true;
                    return;
                case "!":
                    Operator_Click(Fact);
                    e.Handled = true;
                    return;
                case "\r":
                    Enter_Click(Enter);
                    e.Handled = true;
                    return;
            }
            
            WriteNextExample();

            //Zkontroluje 
            if (Input.Text.Length > 20)
            {
                e.Handled = true;
                return;
            }
            //Zapíše zda-li je číslo
            e.Handled = !CheckNumber(Input.Text + e.Text);
        }
            
        /// <summary>
        /// Zkontroluje platnost výrazu podle regulárnýho výrazu, zda-li je číslo
        /// </summary>
        /// <param name="input">Testovaný výraz</param>
        /// <returns>Vrátí True pokud je výraz číslo, jinak False</returns>
        private bool CheckNumber(string input) =>
            new Regex("^[-]?[0-9]*$|^[-]?[0-9]+[.,][0-9]*$").IsMatch(input);

        /// <summary>
        /// Převede "," na "."
        /// </summary>
        /// <param name="sender">Vstupní textbox</param>
        /// <param name="e">Změněný text</param>
        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(',', '.');
            ((TextBox)sender).CaretIndex = ((TextBox)sender).Text.Length;
        }

        /// <summary>
        /// Při zobrazení výsledku a zápisu nového čísla, se vytvoří nový příklad
        /// </summary>
        private void WriteNextExample()
        {
            if (Input.Text == _operand.ToString())
            {
                Input.Text = "";
                Output.Text += _operand.ToString();
            }
        }

        /// <summary>
        /// Zápis čísel pomocí tlačítek
        /// </summary>
        /// <param name="sender">Tlačítka čísel</param>
        /// <param name="e">Událost kliknutí</param>
        private void BtnNum_OnClick(object sender, RoutedEventArgs e)
        {
            WriteNextExample();
            if (CheckNumber(Input.Text + ((Button)sender).Content))
                Input.Text += ((Button) sender).Content;
            SetFocus();
        }

        /// <summary>
        /// Negace čísla pomocí tlačítka
        /// </summary>
        /// <param name="sender">Tlačítko pro negaci</param>
        /// <param name="e">Událost kliknutí</param>
        private void Neg_Click(object sender, RoutedEventArgs e)
        {
            if (Input.Text.Contains('-'))
                Input.Text = Input.Text.Remove(0, 1);
            else
                Input.Text = "-" + Input.Text;
            SetFocus();
        }

        /// <summary>
        /// Mazání pomocí tlačítka
        /// </summary>
        /// <param name="sender">Tlačítko pro mazání</param>
        /// <param name="e">Událost kliknutí</param>
        private void Rb_Click(object sender, RoutedEventArgs e)
        {
            if (Input.Text.Length > 0)
                Input.Text = Input.Text.Remove(Input.Text.Length - 1);
            if (_operation != Operator.None)
            {
                if (Output.Text.Length > 0)
                {
                    _operation = Operator.AfterRemove;
                    Output.Text = Output.Text.Remove(Output.Text.Length - 1);
                    Output.Text = Output.Text.Remove(Output.Text.Length - 1);
                }
            }
            SetFocus();
        }

        /// <summary>
        /// Restart celé kalkulačky
        /// </summary>
        /// <param name="sender">Tlačítko pro smazání všech výstupů a vstupů</param>
        /// <param name="e">Událost kliknutí</param>
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            _operation = Operator.None;
            Output.Text = "";
            Input.Text = "";
            SetFocus();
        }

        /// <summary>
        /// Kliknutí na tlačítko operátora s operandem v levo
        /// </summary>
        /// <param name="sender">Tlačítko operatáru</param>
        /// <param name="e">Událost kliknutí</param>
        private void Operator_Click(object sender, RoutedEventArgs e = null)
        {
            //Zda-li něco již je na vstupu
            if (Input.Text == "")
            {
                SetFocus();
                return;
            }
            
            //Pokud je ukončený předešlý příklad
            if (_operation == Operator.None)
                SetOperator(sender);

            //Vyřeší předešlý neukončený příklad
            else
            {
                GetResult();
                Operator_Click(sender, e);
            }
            //Aktualizuje pohled
            ScrollOutput.ScrollToEnd();
            Input.Text = "";
            SetFocus();
        }

        /// <summary>
        /// Kliknutí na tlačítko operátora s operandem v pravo
        /// </summary>
        /// <param name="sender">Tlačítko operatáru</param>
        /// <param name="e">Událost kliknutí</param>
        private void OperatorLeft_Click(object sender, RoutedEventArgs e)
        {
            //Zda-li něco již je na vstupu
            if (Input.Text == "" && _operation != Operator.None)
            {
                SetFocus();
                return;
            }

            if (_operation == Operator.None)
                SetOperator(sender);
            //Vyřeší předešlý neukončený příklad
            else
            {
                GetResult();
                OperatorLeft_Click(sender, e);
            }
            //Aktualizuje pohled
            ScrollOutput.ScrollToEnd();
            Input.Text = "";
            SetFocus();
        }

        /// <summary>
        /// Získá operand a podle operátoru změní stav kalkulačky
        /// </summary>
        /// <param name="sender">Tlačítko operandu</param>
        private void SetOperator(object sender)
        {
            var operationName = ((Button)sender).Name;
            switch (operationName)
            {
                case "Mul":
                    _operand = double.Parse(Input.Text, CultureInfo.InvariantCulture);
                    Output.Text += "\n" + Input.Text + " * ";
                    _operation = Operator.Mul;
                    break;
                case "Root":
                    _operand = double.Parse(Input.Text, CultureInfo.InvariantCulture);
                    Output.Text += "\n" + Input.Text + "√";
                    _operation = Operator.Root;
                    break;
                case "Pow":
                    _operand = double.Parse(Input.Text, CultureInfo.InvariantCulture);
                    Output.Text += "\n" + Input.Text + "^";
                    _operation = Operator.Pow;
                    break;
                case "Log10":
                    Output.Text += "\n" + Input.Text + "log";
                    _operation = Operator.Log10;
                    break;
                case "LogE":
                    Output.Text += "\n" + Input.Text + "ln";
                    _operation = Operator.LogE;
                    break;
                case "Fact":
                    _operand = double.Parse(Input.Text, CultureInfo.InvariantCulture);
                    Output.Text += "\n" + Input.Text + "!";
                    _operation = Operator.Fact;
                    break;
                default:
                    _operand = double.Parse(Input.Text, CultureInfo.InvariantCulture);
                    Output.Text += "\n" + Input.Text + " " + ((Button) sender).Content + " ";
                    _operation = Enum.Parse<Operator>(operationName);
                    break;
            }
        }

        /// <summary>
        /// Kliknutí na tlačítko "="
        /// </summary>
        /// <param name="sender">Tlačítko "="</param>
        /// <param name="e">Událost kliknutí</param>
        private void Enter_Click(object sender, RoutedEventArgs e = null)
        {
            if (_operation == Operator.None) return;
            GetResult();
            ScrollOutput.ScrollToEnd();
            SetFocus();
        }
    }
}
