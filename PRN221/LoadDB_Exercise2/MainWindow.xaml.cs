using DemoADOModel.DAL;
using DemoADOModel.Models;
using LoadDB_Exercise2.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LoadDB_Exercise2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class StringEqualityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (bool)value == ConvertGender(parameter?.ToString());

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        private bool ConvertGender(string gender)
        {
            return gender == "Male" ? true : false;
        }
    }

    public class BooleanToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isMale)
            {
                return isMale ? "Male" : "Female";
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
            var de = DepartmentDAO.GetAllDepartments().Select(x => x.Name).ToList();
            cbxDepart.ItemsSource = de;
            var students = StudentDAO.GetAllStudents();
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
                var oldStudent = StudentDAO.GetStudentById(newId);
                if (oldStudent != null)
                {
                    MessageBox.Show("Id existed!");
                }
                else
                {
                    Student s = GetStudentForm();
                    StudentDAO.AddStudent(s);
                    Load();
                }
            }
        }

        private void ClearForm()
        {
            tbName.Text = string.Empty;
            tbId.Text = string.Empty;
            tbGpa.Text = string.Empty;
            Male.IsChecked = false;
            Female.IsChecked = false;
            cbxDepart.SelectedValue = null;
            dob.SelectedDate = null;
            rbAll.IsChecked = false;
            rbMale.IsChecked = false;
            rbFemale.IsChecked = false;
            Load();
        }

        private Student GetStudentForm()
        {
            Student s = new Student();
            s.Id = int.Parse(tbId.Text);
            s.Name = tbName.Text;
            s.Gender = (bool)Male.IsChecked;
            s.DepartmentId = DepartmentDAO.GetDepartmentByName((string)cbxDepart.SelectedValue).Id;
            s.Dob = (DateTime)dob.SelectedDate;
            s.GPA = decimal.Parse(tbGpa.Text);
            return s;
        }

        private void dgvStudents_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Student st = dgvStudents.SelectedItem as Student;
            tbId.Text = st.Id.ToString();
            tbName.Text = st.Name;
            Male.IsChecked = st.Gender;
            cbxDepart.SelectedValue = DepartmentDAO.GetDepartmentById(st.DepartmentId).Name;
            dob.SelectedDate = st.Dob;
            tbGpa.Text = st.GPA.ToString();

        }

        private void btnUpdates_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbId.Text, out int newId);
            var oldStudent = StudentDAO.GetStudentById(newId);
            if (oldStudent != null)
            {
                oldStudent.Name = tbName.Text;
                oldStudent.Gender = (bool)Male.IsChecked;
                oldStudent.DepartmentId = DepartmentDAO.GetDepartmentByName((string)cbxDepart.SelectedValue.ToString()).Id;
                oldStudent.Dob = (DateTime)dob.SelectedDate;
                oldStudent.GPA = decimal.Parse(tbGpa.Text);
                StudentDAO.UpdateStudent(oldStudent);
                Load();
            }
        }
        private void LoadWithSearch(List<Student> list)
        {
            if (list != null && list.Count > 0)
            {
                dgvStudents.ItemsSource = list;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rbAll.IsChecked == true)
            {
                Load();
            }
            else if (rbMale.IsChecked == true)
            {
                var students = StudentDAO.SearchStudentByGender(true);
                LoadWithSearch(students);
            }
            else if (rbFemale.IsChecked == true)
            {
                var students = StudentDAO.SearchStudentByGender(false);
                LoadWithSearch(students);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            rbAll.IsChecked = false;
            rbFemale.IsChecked = false;
            rbFemale.IsChecked = false;
            cbxGender.SelectedValue = null;
            cbMale.IsChecked = false;
            cbFemale.IsChecked = false;
        }

        private void cbFemale_Checked(object sender, RoutedEventArgs e)
        {
            var students = StudentDAO.SearchStudentByGender(false);
            if (cbMale.IsChecked == true)
            {
                students = StudentDAO.GetAllStudents();
            }
            LoadWithSearch(students);

        }

        private void cbMale_Checked(object sender, RoutedEventArgs e)
        {
            var students = StudentDAO.SearchStudentByGender(true);
            if (cbFemale.IsChecked == true)
            {
                students = StudentDAO.GetAllStudents();
            }
            LoadWithSearch(students);
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
            if (cbMajorDisplay.IsChecked == false && cbNameDisplay.IsChecked == false && cbIdDisplay.IsChecked == false && cbGpaDisplay.IsChecked == false)
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
                var student = StudentDAO.GetStudentById(newId);
                if (student != null)
                {
                    StudentDAO.DeleteStudent(student.Id);

                }
                Load();
            }
        }

        private void tbSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var students = new List<Student>();
            if (String.IsNullOrEmpty(tbSearchName.Text))
            {
                students = StudentDAO.GetAllStudents().ToList();
            }
            else
            {
                students = StudentDAO.SearchStudentByName(tbSearchName.Text);
            }
            LoadWithSearch(students);
        }

        private void cbxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxGender.SelectedValue != null)
            {
                if (cbxGender.SelectedValue.Equals("Male"))
                {
                    var students = StudentDAO.SearchStudentByGender(true);
                    LoadWithSearch(students);
                }
                else if (cbxGender.SelectedValue.Equals("Female"))
                {
                    var students = StudentDAO.SearchStudentByGender(false);
                    LoadWithSearch(students);
                }
                else if (cbxGender.SelectedValue.Equals("All"))
                {
                    var students = StudentDAO.GetAllStudents();
                    LoadWithSearch(students);
                }
            }
        }
    }
}
