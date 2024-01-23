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
    /// Interaction logic for ListView_WPF.xaml
    /// </summary>
    public partial class ListView_WPF : Window
    {
        List<string> list;
        public bool IsSort;

        public ListView_WPF()
        {

            InitializeComponent();
            //list = new List<string>() { "FPT", "HUST", "NEU"};
            //lsView.ItemsSource = list;


            // Display
            //List<User> items = new List<User>();
            //items.Add(new User() { Name = "HowKteam.com", Age = 42, Mail = "1@kteam.com" });
            //items.Add(new User() { Name = "Kteam", Age = 39, Mail = "2@kteam.com" });
            //items.Add(new User() { Name = "Free Education", Age = 7, Mail = "3@kteam.com" });
            //lvUsers.ItemsSource = items;


            // Grouping
            //List<User> items = new List<User>();
            //items.Add(new User() { Name = "HowKteam.com", Age = 42, Sex = SexType.Male });
            //items.Add(new User() { Name = "Kteam", Age = 39, Sex = SexType.Female });
            //items.Add(new User() { Name = "Free Education", Age = 13, Sex = SexType.Male });
            //lvUsers.ItemsSource = items;

            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            //view.GroupDescriptions.Add(groupDescription);

            //Sorting 
            //IsSort = false;
            //List<User> items = new List<User>();
            //items.Add(new User() { Name = "HowKteam.com", Age = 42 });
            //items.Add(new User() { Name = "Kteam", Age = 13 });
            //items.Add(new User() { Name = "Free Education", Age = 39 });
            //items.Add(new User() { Name = "Share to be better", Age = 13 });
            //lvUsers.ItemsSource = items;
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));

            // Multi Sorting
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            //view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

            // Fillter

            List<User> items = new List<User>();
            items.Add(new User() { Name = "HowKteam", Age = 42 });
            items.Add(new User() { Name = "Kteam", Age = 39 });
            items.Add(new User() { Name = "Free Education", Age = 13 });
            items.Add(new User() { Name = "Share to be better", Age = 13 });
            lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;



        }


        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as User).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }


        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            if (IsSort)
            {
                // Sort multiple
                //view.SortDescriptions.Remove(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
                
                // Sort single
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
            }
            else
            {
                //view.SortDescriptions.Remove(new SortDescription(header.Content.ToString(), ListSortDirection.Ascending));
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(header.Content.ToString(), ListSortDirection.Descending));
            }

            IsSort = !IsSort;
        }

        public enum SexType { Male, Female };
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
            public SexType Sex { get; set; }
        }
    }
}
