using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Binding_WPF.xaml
    /// </summary>
    public partial class Binding_WPF : Window, INotifyPropertyChanged
    {
        public Binding_WPF()
        {
            InitializeComponent();
            this.DataContext = this;
            BtnName = "Binding data";
        }

        private string btnName;
        public string BtnName
        {
            get { return btnName; }
            set
            {
                btnName = value;
                OnPropertyChanged("BtnName");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }
    }
}
