using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;
using System.Text;
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
    public partial class MainWindow : Window
    {
        private string _input = string.Empty;
        private string _operator;
        private double _firstNumber, _secondNumber;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            string buttonContent = button.Content.ToString();

            if (double.TryParse(buttonContent, out _))
            {
                _input += buttonContent;
                Display.Text = _input;
            }
            else if (buttonContent == "C")
            {
                _input = string.Empty;
                _operator = string.Empty;
                _firstNumber = _secondNumber = 0;
                Display.Text = string.Empty;
            }
            else if (buttonContent == "<-")
            {
               if (_input.Length > 0)
                {
                    _input = _input.Remove(_input.Length - 1);
                }
                Display.Text = _input;
            }
            else if (buttonContent == "=")
            {
                _secondNumber = double.Parse(_input);
                switch (_operator)
                {
                    case "+":
                        Display.Text = (_firstNumber + _secondNumber).ToString("F2");
                        break;
                    case "-":
                        Display.Text = (_firstNumber - _secondNumber).ToString("F2");
                        break;
                    case "*":
                        Display.Text = (_firstNumber * _secondNumber).ToString("F2");
                        break;
                    case "/":
                        Display.Text = (_firstNumber / _secondNumber).ToString("F2");
                        break;
                    case "%":
                        Display.Text = ((_firstNumber / _secondNumber) * 100).ToString("F2") + "%";
                        break;
                }
                _input = Display.Text;
            }
            else
            {
                _operator = buttonContent;
                _firstNumber = double.Parse(_input);
                _input = string.Empty;
            }
        }
    }
}