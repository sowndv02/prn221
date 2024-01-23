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
    /// Interaction logic for Command_WPF.xaml
    /// </summary>
    public partial class Command_WPF : Window
    {
        public Command_WPF()
        {
            InitializeComponent();
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #region 1
        //private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    MessageBox.Show("The New command was invoked");
        //}
        #endregion

        #region 2
        //private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = (txtEditor != null) && (txtEditor.SelectionLength > 0);
        //}

        //private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    txtEditor.Cut();
        //}

        //private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = Clipboard.ContainsText();
        //}

        //private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    txtEditor.Paste();
        //}
        #endregion

    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
                (
                        "Exit",
                        "Exit",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.A, ModifierKeys.Alt)
                                }
                );

    }
}
