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
using Microsoft.EntityFrameworkCore;

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
            Load();
        }
        
        private void Load()
        {
            var de = PRN211_1Context.ins.Departments.Select(x => x.Name).ToList();
            cbxDepart.ItemsSource = de;
            var students = PRN211_1Context.ins.Students.Include(x => x.Depart).ToList();
            dgvStudents.ItemsSource = students;
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
                    ClearForm();
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
                ClearForm();
                Load();
            }
        }
    }
}
