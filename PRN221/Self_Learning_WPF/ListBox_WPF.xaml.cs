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
    /// Interaction logic for ListBox_WPF.xaml
    /// </summary>
    public partial class ListBox_WPF : Window
    {
        List<string> ListData;
        public ListBox_WPF()
        {
            InitializeComponent();
            ListData = new List<string>();
            for(int i = 0; i < 10; i++)
            {
                ListData.Add(i.ToString());
            }
            cbCombo.ItemsSource = ListData;
            lsbList.ItemsSource = ListData; 
        }
    }
}
