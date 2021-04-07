using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Výčet stavů pro nápovědu
        /// </summary>
        private enum HelpStatus
        {
            Start, Input, InputView, Operator, OperatorExtra, Output, LastInfo, End
        }

        private HelpStatus _status = HelpStatus.Start;


        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HelpCard.Visibility = Visibility.Visible;
            _status = HelpStatus.Start;
            Guide();
        }
        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            _status++;
            Guide();
        }
        private void BtnPrev_OnClick(object sender, RoutedEventArgs e)
        {
            _status--;
            Guide();
        }

        private void Guide()
        {
            switch (_status)
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
