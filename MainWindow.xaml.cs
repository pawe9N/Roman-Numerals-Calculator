using RomanNumeralsCalculator.Classes;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RomanNumeralsCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CloseWindowWhileRunningTestsInDebugMode();
        }

        //Test is a custom solution configuration to running tests without showing MainWindow
        public void CloseWindowWhileRunningTestsInDebugMode()
        {
            #if TEST
                App.Current.MainWindow.Close();
            #endif
        }

        private void PutContent(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string content = btn.Content.ToString();

            string[] operators = { "+", "-", "*", "/", "%", "^", "√" };
            if (operators.Contains(content))
            {
                ExpressionBox.Text += $" {content} ";
            }
            else
            {
                ExpressionBox.Text += content;
            }
        }

        private void CancelSymbol(object sender, RoutedEventArgs e)
        {
            string expression = ExpressionBox.Text.TrimEnd();

            if(expression.Length > 0)
            {
                expression = expression.Substring(0, expression.Length - 1);
            }

            ExpressionBox.Text = expression;
        }

        private void SolveExpression(object sender, RoutedEventArgs e)
        {
            string expression = ExpressionBox.Text.TrimEnd();

            if(!string.IsNullOrEmpty(expression))
            {
                StringBuilder result = new StringBuilder();

                try
                {
                    result.Append(RomanExpressionSolver.Solve(expression));
                    ResultLabelText.FontSize = 100;
                }
                catch (ArgumentException ex)
                {
                    result.Append(expression + ": " + ex.Message);
                    ResultLabelText.FontSize = 16;
                }

                ExpressionBox.Text = "";
                ResultLabelText.Text = result.ToString();
                LastExpressionText.Text = expression;
            }
        }
    }
}
