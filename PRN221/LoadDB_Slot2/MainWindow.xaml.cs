using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.EntityFrameworkCore;

namespace LoadDB_Slot2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class BooleanToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isMale)
            {
                return isMale ?"Male": "Female";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        
        private void Load()
        {
            var de = PRN211_1Context.ins.Departments.Select(x => x.Name).ToList();
            cbxDepart.ItemsSource = de;
            var students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
            dgvStudents.ItemsSource = students;
            cbxGender.ItemsSource = new List<string> { "Male", "Female", "All" };
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbId.Text) || String.IsNullOrEmpty(tbName.Text) || cbxDepart.SelectedItem == null || dob.SelectedDate == null || String.IsNullOrEmpty(tbGpa.Text))
            {
                MessageBox.Show("Data is not empty");
            }
            else
            {
                int.TryParse(tbId.Text, out int newId);
                var oldStudent = PRN211_1Context.ins.Students.Where(x => x.Id == newId).FirstOrDefault();
                if(oldStudent != null)
                {
                    MessageBox.Show("Id existed!");
                }
                else
                {
                    Student s = GetStudentForm();
                    PRN211_1Context.ins.Students.Add(s);
                    PRN211_1Context.ins.SaveChanges();
                    Load();
                }
            }
        }

        private void ClearForm()
        {
            tbName.Text = string.Empty;
            tbId.Text = string.Empty;
            tbGpa.Text = string.Empty;
            cbGender.IsChecked = false;
            cbxDepart.SelectedValue = null;
            dob.SelectedDate = null;
        }

        private Student GetStudentForm()
        {
            Student s = new Student();
            s.Id = int.Parse(tbId.Text);
            s.Name = tbName.Text;
            s.Gender = (bool)cbGender.IsChecked;
            s.DepartId = PRN211_1Context.ins.Departments.FirstOrDefault(x => x.Name.Equals((string)cbxDepart.SelectedValue)).Id;
            s.Dob = dob.SelectedDate;
            s.Gpa = double.Parse(tbGpa.Text);
            return s;
        }

        private void dgvStudents_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Student st = dgvStudents.SelectedItem as Student;
            tbId.Text = st.Id.ToString();
            tbName.Text = st.Name;
            cbGender.IsChecked = st.Gender;
            cbxDepart.SelectedValue = PRN211_1Context.ins.Departments.FirstOrDefault(x => x.Id.Equals(st.DepartId)).Name;
            dob.SelectedDate = st.Dob;
            tbGpa.Text = st.Gpa.ToString();
            
        }

        private void btnUpdates_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbId.Text, out int newId);
            var oldStudent = PRN211_1Context.ins.Students.Where(x => x.Id == newId).FirstOrDefault();
            if (oldStudent != null)
            {
                oldStudent.Name = tbName.Text;
                oldStudent.Gender = (bool)cbGender.IsChecked;
                oldStudent.DepartId = PRN211_1Context.ins.Departments.FirstOrDefault(x => x.Name.Equals((string)cbxDepart.SelectedValue)).Id;
                oldStudent.Dob = dob.SelectedDate;
                oldStudent.Gpa = double.Parse(tbGpa.Text);
                PRN211_1Context.ins.Students.Update(oldStudent);
                PRN211_1Context.ins.SaveChanges();
                Load();
            }
        }
        private void LoadWithSearch(List<Student> list)
        {
            if(list != null && list.Count > 0)
            {
                dgvStudents.ItemsSource = list;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(rbAll.IsChecked == true)
            {
                Load();
            }else if(rbMale.IsChecked == true)
            {
                var students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => x.Gender).ToList();
                LoadWithSearch(students);
            } else if(rbFemale.IsChecked == true)
            {
                var students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => !x.Gender).ToList();
                LoadWithSearch(students);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            rbAll.IsChecked = false;
            rbFemale.IsChecked = false;
            rbFemale.IsChecked = false;
            cbxGender.SelectedValue = null;
            cbMale.IsChecked =false;
            cbFemale.IsChecked =false;
        }

        private void cbxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxGender.SelectedValue != null)
            {
                if (cbxGender.SelectedValue.Equals("Male"))
                {
                    var students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => x.Gender).ToList();
                    LoadWithSearch(students);
                }
                else if (cbxGender.SelectedValue.Equals("Female"))
                {
                    var students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => !x.Gender).ToList();
                    LoadWithSearch(students);
                }
                else if (cbxGender.SelectedValue.Equals("All"))
                {
                    var students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
                    LoadWithSearch(students);
                }
            }
        }

        private void UpdateColumnVisibility(bool isGpaDisplayChecked)
        {
            idColumn.Visibility = isGpaDisplayChecked ? Visibility.Collapsed : Visibility.Visible;
            nameColumn.Visibility = isGpaDisplayChecked ? Visibility.Collapsed : Visibility.Visible;
            dobColumn.Visibility = isGpaDisplayChecked ? Visibility.Collapsed : Visibility.Visible;
            genderCheckboxColumn.Visibility = isGpaDisplayChecked ? Visibility.Collapsed : Visibility.Visible;
            genderTextColumn.Visibility = isGpaDisplayChecked ? Visibility.Collapsed : Visibility.Visible;
            majorColumn.Visibility = isGpaDisplayChecked ? Visibility.Collapsed : Visibility.Visible;
            gpaColumn.Visibility = isGpaDisplayChecked ? Visibility.Visible : Visibility.Collapsed;
        }


        private void HandleCheckBoxState(CheckBox checkBox, Visibility visibility)
        {

            dobColumn.Visibility = Visibility.Collapsed;
            genderCheckboxColumn.Visibility = Visibility.Collapsed;
            genderTextColumn.Visibility = Visibility.Collapsed;
            gpaColumn.Visibility = Visibility.Collapsed;
            idColumn.Visibility = Visibility.Collapsed;
            nameColumn.Visibility = Visibility.Collapsed;
            majorColumn.Visibility = Visibility.Collapsed;

            if (checkBox == cbGpaDisplay || cbGpaDisplay.IsChecked == true)
            {
                gpaColumn.Visibility = visibility;
            }
            
            if (checkBox == cbIdDisplay || cbIdDisplay.IsChecked == true)
            {
                idColumn.Visibility = visibility;
            }
            
            if (checkBox == cbNameDisplay || cbNameDisplay.IsChecked == true)
            {
                nameColumn.Visibility = visibility;
            }
            
            if (checkBox == cbMajorDisplay || cbMajorDisplay.IsChecked == true)
            {
                majorColumn.Visibility = visibility;
            }
            if(cbMajorDisplay.IsChecked == false && cbNameDisplay.IsChecked == false && cbIdDisplay.IsChecked == false && cbGpaDisplay.IsChecked == false)
            {
                dobColumn.Visibility = Visibility.Visible;
                genderCheckboxColumn.Visibility = Visibility.Visible;
                genderTextColumn.Visibility = Visibility.Visible;
                gpaColumn.Visibility = Visibility.Visible;
                idColumn.Visibility = Visibility.Visible;
                nameColumn.Visibility = Visibility.Visible;
                majorColumn.Visibility = Visibility.Visible;
            }
        }

        private void cbIdDisplay_Click(object sender, RoutedEventArgs e)
        {
            if (cbIdDisplay.IsChecked == true)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Visible);
            }
            else if (cbNameDisplay.IsChecked == false)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Collapsed);
            }
        }

        private void cbNameDisplay_Click(object sender, RoutedEventArgs e)
        {
            if (cbNameDisplay.IsChecked == true)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Visible);
            }
            else if (cbNameDisplay.IsChecked == false)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Collapsed);
            }
        }

        private void cbMajorDisplay_Click(object sender, RoutedEventArgs e)
        {
            if (cbMajorDisplay.IsChecked == true)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Visible);
            }
            else if (cbMajorDisplay.IsChecked == false)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Collapsed);
            }
        }

        private void cbGpaDisplay_Click(object sender, RoutedEventArgs e)
        {
            if (cbGpaDisplay.IsChecked == true)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Visible);
            }
            else if (cbGpaDisplay.IsChecked == false)
            {
                HandleCheckBoxState(sender as CheckBox, Visibility.Collapsed);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbId.Text) && dgvStudents.SelectedCells.Count > 0)
            {
                int.TryParse(tbId.Text, out int newId);
                var student = PRN211_1Context.ins.Students.Where(x => x.Id == newId).FirstOrDefault();
                if(student != null)
                {
                    PRN211_1Context.ins.Students.Remove(student);
                   
                }
                PRN211_1Context.ins.SaveChanges();
                Load();
            }
        }

        private void cbFemale_Checked(object sender, RoutedEventArgs e)
        {
            var students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => !x.Gender).ToList();

            if (cbMale.IsChecked == true)
            {
                students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
            }
            LoadWithSearch(students);
        }

        private void cbFemale_Unchecked(object sender, RoutedEventArgs e)
        {
            var students = new List<Student>();
            if (cbMale.IsChecked == true)
            {
                 students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => x.Gender).ToList();
            }
            else
            {
                 students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
            }
            LoadWithSearch(students);
        }

        private void cbMale_Checked(object sender, RoutedEventArgs e)
        {
            var students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => x.Gender).ToList();
            if (cbFemale.IsChecked == true)
            {
                students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
            }
            LoadWithSearch(students);
        }

        private void cbMale_Unchecked(object sender, RoutedEventArgs e)
        {
            var students = new List<Student>();
            if (cbFemale.IsChecked == true)
            {
                students = PRN211_1Context.ins.Students.Include(x => x.Depart).Where(x => !x.Gender).ToList();
            }
            else
            {
                students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
            }
            LoadWithSearch(students);
        }

        private void tbSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var students = new List<Student>();
            if (String.IsNullOrEmpty(tbSearchName.Text))
            {
                students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
            }
            else
            {
                students = PRN211_1Context.ins.Students.Where(x => x.Name.Contains(tbSearchName.Text)).ToList();
            }
            LoadWithSearch(students);
        }
    }
}
