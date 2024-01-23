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
using System.Windows.Shapes;

namespace Self_Learning_WPF
{
    /// <summary>
    /// Interaction logic for DataTemplate_WPF.xaml
    /// </summary>
    public partial class DataTemplate_WPF : Window
    {
        public DataTemplate_WPF()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str1 = "sondv";
            string str2 = "he164023";
            btn1.DataContext = str1;
            btn2.DataContext = str2;
        }
    }
}
