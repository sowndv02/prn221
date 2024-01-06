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
using LoadDB_Slot2.Models;

namespace LoadDB_Slot2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var de = PRN211_1Context.ins.Departments.Select(x => x.Name).ToList();
            cbxDepart.ItemsSource = de;
            var students = PRN211_1Context.ins.Students.ToList();

            dgvStudents.ItemsSource = students;
        }
    }
}
