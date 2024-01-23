using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for TreeView_WPF.xaml
    /// </summary>
    public partial class TreeView_WPF : Window
    {
        public TreeView_WPF()
        {
            InitializeComponent();

            // Display

            //MenuItem root = new MenuItem() { Title = "Menu" };
            //MenuItem childItem1 = new MenuItem() { Title = "Child item #1" };
            //childItem1.Items.Add(new MenuItem() { Title = "Child item #1.1" });
            //childItem1.Items.Add(new MenuItem() { Title = "Child item #1.2" });
            //root.Items.Add(childItem1);
            //root.Items.Add(new MenuItem() { Title = "Child item #2" });
            //trvMenu.Items.Add(root);


            // Binding
            //List<Family> families = new List<Family>();

            //Family family1 = new Family() { Name = "HowKteam.com" };
            //family1.Members.Add(new FamilyMember() { Name = "HowKteam", Age = 42 });
            //family1.Members.Add(new FamilyMember() { Name = "Kteam", Age = 39 });
            //family1.Members.Add(new FamilyMember() { Name = "Free Education", Age = 13 });
            //families.Add(family1);

            //Family family2 = new Family() { Name = "Kteam" };
            //family2.Members.Add(new FamilyMember() { Name = "K9", Age = 31 });
            //family2.Members.Add(new FamilyMember() { Name = "Mushi", Age = 28 });
            //families.Add(family2);

            //trvFamilies.ItemsSource = families;


            // Layzy Load
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo driveInfo in drives)
                trvStructure.Items.Add(CreateTreeItem(driveInfo));

        }

        public void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            if ((item.Items.Count == 1) && (item.Items[0] is string))
            {
                item.Items.Clear();

                DirectoryInfo expandedDir = null;
                if (item.Tag is DriveInfo)
                    expandedDir = (item.Tag as DriveInfo).RootDirectory;
                if (item.Tag is DirectoryInfo)
                    expandedDir = (item.Tag as DirectoryInfo);
                try
                {
                    foreach (DirectoryInfo subDir in expandedDir.GetDirectories())
                        item.Items.Add(CreateTreeItem(subDir));
                }
                catch { }
            }
        }

        private TreeViewItem CreateTreeItem(object o)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = o.ToString();
            item.Tag = o;
            item.Items.Add("Loading...");
            return item;
        }

    }


    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }

    public class Family
    {
        public Family()
        {
            this.Members = new ObservableCollection<FamilyMember>();
        }

        public string Name { get; set; }

        public ObservableCollection<FamilyMember> Members { get; set; }
    }

    public class FamilyMember
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
