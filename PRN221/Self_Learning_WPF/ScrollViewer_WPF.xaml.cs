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
    /// Interaction logic for ScrollViewer_WPF.xaml
    /// </summary>
    public partial class ScrollViewer_WPF : Window
    {
        public ScrollViewer_WPF()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(scrviewer.VerticalOffset.ToString()); / Get scroll bar offset value
            //scrviewer.ScrollToEnd(); // Scroll to end
            // scrviewer.ScrollToHorizontalOffset();
            // scrviewer.ScrollableHeight.ToString(); // Maximum scroll offset
        }
    }
}
