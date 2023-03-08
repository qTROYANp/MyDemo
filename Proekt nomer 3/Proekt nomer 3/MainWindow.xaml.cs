using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

namespace Proekt_nomer_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_click;
                }
            }
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
            {
                textLabel.Text = "";
            }
            else if (str == "=")
            {
                try
                {
                    string value = new DataTable().Compute(textLabel.Text, null).ToString();
                    if(value == "∞")
                    {
                        MessageBox.Show("НА НОЛЬ НЕ ДЕЛИМ!");
                        textLabel.Text = "";
                    }
                    else
                    {
                        textLabel.Text = value;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if ((str == "+") || (str == "/") || (str == "-") || (str == "*"))
            {
                if ((textLabel.Text == "") || (textLabel.Text.Contains("*")) || (textLabel.Text.Contains("+")) || (textLabel.Text.Contains("-")) || (textLabel.Text.Contains("/")))
                {
                 
                }
                else
                {
                    textLabel.Text += str;
                }
            }
            else
            {
                if (textLabel.Text.Length > 20)
                {
                    textLabel.Text += "";
                }
                else
                {
                    textLabel.Text += str;
                }
            }
        }
    }
}
