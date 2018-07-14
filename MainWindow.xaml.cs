using RomanNumeralsCalculator.Classes;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            ExpressionBox.Focus();

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

            if (ExpressionBox.SelectedText.Length > 0)
            {
                ExpressionBox.SelectedText = content;

                Regex trimmer = new Regex(@"\s\s+");
                ExpressionBox.Text = trimmer.Replace(ExpressionBox.Text, " ");
                
                ExpressionBox.Select(0,0);
                int caretLength = ExpressionBox.Text.Length;
                ExpressionBox.CaretIndex = caretLength;
            }
            else
            {
                string[] operators = { "+", "-", "*", "/", "%", "^", "√" };
                if (operators.Contains(content))
                {
                    ExpressionBox.Text = ExpressionBox.Text.Insert(ExpressionBox.CaretIndex, $" {content} ");
                    int caretLength = ExpressionBox.Text.Length;
                    ExpressionBox.CaretIndex = caretLength + 3;
                }
                else
                {
                    ExpressionBox.Text = ExpressionBox.Text.Insert(ExpressionBox.CaretIndex, content);
                    int caretLength = ExpressionBox.Text.Length;
                    ExpressionBox.CaretIndex = caretLength + 1;
                }

                Regex trimmer = new Regex(@"\s\s+");
                ExpressionBox.Text = trimmer.Replace(ExpressionBox.Text, " ");
            }

            ExpressionBox.Focus();
        }

        private void CancelSymbol(object sender, RoutedEventArgs e)
        {
            if(ExpressionBox.SelectedText.Length > 0)
            {
                ExpressionBox.SelectedText = "";

                Regex trimmer = new Regex(@"\s\s+");
                ExpressionBox.Text = trimmer.Replace(ExpressionBox.Text, " ");

                int caretLength = ExpressionBox.Text.Length;
                ExpressionBox.CaretIndex = caretLength + 1;
            }
            else
            {
                string expression = ExpressionBox.Text.TrimEnd();

                if (expression.Length > 0)
                {
                    expression = expression.Substring(0, expression.Length - 1);

                    Regex trimmer = new Regex(@"\s\s+");
                    expression = trimmer.Replace(expression, " ");

                    int caretLength = expression.Length;

                    ExpressionBox.Text = expression;
                    ExpressionBox.CaretIndex = caretLength + 1;                
                }
            }        
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
                    ResultLabelText.FontSize = 70;
                    ResultLabelText.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#8873CB"));
                    ResultLabelText.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#250D71"));
                }
                catch (Exception ex)
                {
                    result.Append(expression + " : " + ex.Message);
                    ResultLabelText.FontSize = 16;
                    ResultLabelText.Background = new SolidColorBrush(Colors.Red);
                    ResultLabelText.Foreground = new SolidColorBrush(Colors.White);
                }

                ExpressionBox.Text = "";
                ResultLabelText.Text = result.ToString();
                LastExpressionText.Text = $"Last expression: {expression}";
                ExpressionBox.Focus();
            }
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SolveExpression(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                CancelSymbol(sender, e);
            }
        }


    }
}
