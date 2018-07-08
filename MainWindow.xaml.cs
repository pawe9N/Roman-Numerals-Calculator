using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
