using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum HelpStatus
        {
            Start,
            Input,
            InputView,
            Operator,
            OperatorExtra,
            Output,
            LastInfo,
            End
        }

        enum Operator
        {
            None,
            Add,
            Sub,
            Mul,
            Div,
            Fact,
            Pow,
            Root,
            Log10,
            LogE,
        }

        private HelpStatus status = HelpStatus.Start;
        private Operator operation = Operator.None;
        private double operand;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) => 
            SetFocus();
        private void SetFocus() => 
            Input.Focus();
        private void Image_MouseEnter(object sender, MouseEventArgs e) => 
            InfoCard.Visibility = Visibility.Visible;
        private void Image_MouseLeave(object sender, MouseEventArgs e) => 
            InfoCard.Visibility = Visibility.Hidden;

        private void Input_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

                
            if (e.Text == "+")
            {
                Operator2Operands_Click(Add);
                e.Handled = true;
                return;
            }
            if (e.Text == "-")
            {
                Operator2Operands_Click(Sub);
                e.Handled = true;
                return;
            }
            if (e.Text == "*")
            {
                Operator2Operands_Click(Mul);
                e.Handled = true;
                return;
            }
            if (e.Text == "/")
            {
                Operator2Operands_Click(Div);
                e.Handled = true;
                return;
            }
            if (e.Text == "!")
            {
                Fact_Click(Fact);
                e.Handled = true;
                return;
            }

            if (e.Text == "\r")
            {
                Enter_Click(Enter);
                e.Handled = true;
                return;
            }

            if (Input.Text == operand.ToString())
            {
                Input.Text = "";
                Output.Text += operand.ToString();
            }

            e.Handled = !CheckNumber(Input.Text + e.Text);
        }
            

        private bool CheckNumber(string input) =>
            new Regex("^[-]?[0-9]*$|^[-]?[0-9]+[.,][0-9]*$").IsMatch(input);

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(',', '.');
            ((TextBox)sender).CaretIndex = ((TextBox)sender).Text.Length;
        }

        private void BtnNum_OnClick(object sender, RoutedEventArgs e)
        {
            if (Input.Text == operand.ToString())
            {
                Input.Text = "";
                Output.Text += operand.ToString();
            }
            if (CheckNumber(Input.Text + ((Button)sender).Content))
                Input.Text += ((Button) sender).Content;
            SetFocus();
        }

        private void Neg_Click(object sender, RoutedEventArgs e)
        {
            if (Input.Text.Contains('-'))
                Input.Text = Input.Text.Remove(0, 1);
            else
                Input.Text = "-" + Input.Text;
            SetFocus();
        }

        private void Rb_Click(object sender, RoutedEventArgs e)
        {
            if (Input.Text.Length > 0)
                Input.Text = Input.Text.Remove(Input.Text.Length - 1);
            SetFocus();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            operation = Operator.None;
            Output.Text = "";
            Input.Text = "";
            SetFocus();
        }

        private void Operator2Operands_Click(object sender, RoutedEventArgs e = null)
        {
            var operationName = ((Button) sender).Name;
            if (Input.Text == "") return;
            if (operation == Operator.None)
            {
                operand = Convert.ToDouble(Input.Text);
                if (operationName == "Mul")
                {
                    Output.Text += "\n" + Input.Text + " * ";
                    operation = Operator.Mul;
                }
                else if (operationName == "Root")
                {
                    Output.Text += "\n" + Input.Text + "√";
                    operation = Operator.Root;
                }
                else if (operationName == "Pow")
                {
                    Output.Text += "\n" + Input.Text + "^";
                    operation = Operator.Pow;
                }
                else
                {
                    Output.Text += "\n" + Input.Text + " " + ((Button)sender).Content + " ";
                    operation = Enum.Parse<Operator>(operationName);
                }

            }
            else
            {
                Solve();
                Operator2Operands_Click(sender, e);
            }
                

            ScrollOutput.ScrollToEnd();
            Input.Text = "";
            SetFocus();
        }

        private void OperatorLeft_Click(object sender, RoutedEventArgs e)
        {
            Output.Text += "\n" + Input.Text;
            Input.Text = "";
            var operationName = ((Button)sender).Name;
            if (operation == Operator.None)
            {
                if (operationName == "Log10")
                {
                    Output.Text += "\n" + Input.Text + "log";
                    operation = Operator.Log10;
                }
                else if (operationName == "LogE")
                {
                    Output.Text += "\n" + Input.Text + "ln";
                    operation = Operator.LogE;
                }
            }
            else
            {
                Solve();
                OperatorLeft_Click(sender, e);
            }
                

            ScrollOutput.ScrollToEnd();
            Input.Text = "";
            SetFocus();
        }

        private void Fact_Click(object sender, RoutedEventArgs e = null)
        {
            if (Input.Text == "") return;
            if (operation == Operator.None)
            {
                operand = Convert.ToDouble(Input.Text);
                Output.Text += "\n" + Input.Text + "!";
                operation = Operator.Fact;
            }
            else
            {
                Solve();
                Fact_Click(sender, e);
            }
                

            ScrollOutput.ScrollToEnd();
            Input.Text = "";
            SetFocus();
        }

        private void Enter_Click(object sender, RoutedEventArgs e = null)
        {
            if (operation == Operator.None) return;
            Solve();
            ScrollOutput.ScrollToEnd();
            SetFocus();
        }

        private void Solve()
        {
            if (Input.Text == "") return;
            double result = 0;
            Output.Text += Input.Text + " = ";
            switch (operation)
            {
                case Operator.Add:
                    result = Convert.ToDouble(Input.Text) + operand;
                    break;
            }
            operation = Operator.None;
            Input.Text = Convert.ToString(result);
            operand = result;
        }





        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HelpCard.Visibility = Visibility.Visible;
            status = HelpStatus.Start;
            Guide();
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            status++;
            Guide();
        }

        private void BtnPrev_OnClick(object sender, RoutedEventArgs e)
        {
            status--;
            Guide();
        }

        private void Guide()
        {
            switch (status)
            {
                case HelpStatus.Start:
                    HideAllHelpCanvas();
                    HideAll.Visibility = Visibility.Visible;
                    BtnPrev.Visibility = Visibility.Hidden;
                    TextHelp.Text = "Vítáme Tě v interaktivní nápovědě programu Kalkulačka ESD. Pro navigaci nápovědou použij horní tlačítko '>>' nebo '<<'.";
                    break;
                case HelpStatus.Input:
                    HideAllHelpCanvas();
                    HideForNumbersLeft.Visibility = Visibility.Visible;
                    HideForNumbersRight.Visibility = Visibility.Visible;
                    HideForNumbersTop.Visibility = Visibility.Visible;
                    BtnPrev.Visibility = Visibility.Visible;
                    TextHelp.Text = "Pro zápis operandu můžeš použít svou klávesnici nebo tlačítka ve zvýrazněné oblasti. " +
                                    "Při zápisu můžeš samozřejmě také mazat pomocí klávesnice, nebo za pomocíh speciálních tlačítek.";
                    break;
                case HelpStatus.InputView:
                    HideAllHelpCanvas();
                    HideTop.Visibility = Visibility.Visible;
                    HideBottom.Visibility = Visibility.Visible;
                    TextHelp.Text = "Hodnota tvého operandu se bude zobrazovat zde.";
                    break;
                case HelpStatus.Operator:
                    HideAllHelpCanvas();
                    HideNoButton.Visibility = Visibility.Visible;
                    HideForBasicOperator.Visibility = Visibility.Visible;
                    HideForBasicOperatorNumbers.Visibility = Visibility.Visible;
                    HideEnter.Visibility = Visibility.Visible;
                    TextHelp.Text = "Základní operátory '+ - * / !' můžeš zadat pomocí klávesnice nebo tlačítky ve zvýrazněné oblasti.";
                    break;
                case HelpStatus.OperatorExtra:
                    HideAllHelpCanvas();
                    HideNoButton.Visibility = Visibility.Visible;
                    HideForExtraOpRow.Visibility = Visibility.Visible;
                    HideForExtraOpNum.Visibility = Visibility.Visible;
                    TextHelp.Text = "Pro složitější operátory použij speciální tlačítka.";
                    break;
                case HelpStatus.Output:
                    HideAllHelpCanvas();
                    HideBottom.Visibility = Visibility.Visible;
                    HideTopFirst.Visibility = Visibility.Visible;
                    HideTopThird.Visibility = Visibility.Visible;
                    TextHelp.Text = "První operand, případně minulé výsledky uvidíš zde. Výsledek zobrazíš pomocí klávesy Enter nebo tlačítka.";
                    break;
                case HelpStatus.LastInfo:
                    HideAllHelpCanvas();
                    HideAll.Visibility = Visibility.Visible;
                    TextHelp.Text = "Nezapomeň, že některé operátory vyžadují 2 operandy '+ - * / mocnina a odmocnina' vkládají se tedy po zadání 1. operandu a následně se očekává operand další." +
                                    " Operátory 'log ln' vyžadují pouze 1 operand a to až po zadání operátoru. Operátor '!' vyžaduje operand ještě před zadáním operátoru.";
                    break;
                case HelpStatus.End:
                    HideAllHelpCanvas();
                    HelpCard.Visibility = Visibility.Hidden;
                    SetFocus();
                    break;
            }
        }

        private void HideAllHelpCanvas()
        {
            HideTop.Visibility = Visibility.Hidden;
            HideBottom.Visibility = Visibility.Hidden;
            HideAll.Visibility = Visibility.Hidden;
            HideForNumbersLeft.Visibility = Visibility.Hidden;
            HideForNumbersRight.Visibility = Visibility.Hidden;
            HideForNumbersTop.Visibility = Visibility.Hidden;
            HideNoButton.Visibility = Visibility.Hidden;
            HideForBasicOperator.Visibility = Visibility.Hidden;
            HideForBasicOperatorNumbers.Visibility = Visibility.Hidden;
            HideEnter.Visibility = Visibility.Hidden;
            HideForExtraOpRow.Visibility = Visibility.Hidden;
            HideForExtraOpNum.Visibility = Visibility.Hidden;
            HideTopFirst.Visibility = Visibility.Hidden;
            HideTopThird.Visibility = Visibility.Hidden;
        }
    }
}
