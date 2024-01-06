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

namespace Exercise1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly string NO_DATA = "No Data";
        public MainWindow()
        {
            InitializeComponent();
            InitMajor();
        }


        private string GetHobbies()
        {
            string hobbies = string.Empty;
            if (cbMusic.IsChecked == true)
                hobbies += "Music, ";
            if (cbFootball.IsChecked == true)
                hobbies += "Football, ";
            if (cbCooking.IsChecked == true)
                hobbies += "Cooking, ";
            if (cbBook.IsChecked == true)
                hobbies += "Reading Book, ";
            return hobbies.Length > 2 ? hobbies.Substring(0, hobbies.Length - 2) : hobbies;
        }

        private void InitMajor()
        {
            List<string> list = new List<string>();
            list.Add("SE");
            list.Add("MC");
            list.Add("IB");
            list.Add("GD");
            list.Add("AI");
            list.Add("IA");
            list.Add("IS");
            major.ItemsSource = list;
        }

        private string GetGender()
        {
            if (Male.IsChecked == true) return "Male";
            else return "Female";
        }

        private string GetData()
        {
            string studentId = string.Empty;
            string studentName = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            string birthDateString = string.Empty;
            string gender = String.Empty;
            string majorString = String.Empty;
            string hobbies = String.Empty;

            string hobbiesString = GetHobbies();

            string genderString = GetGender();

            DateTime? selectedDate = birthDate.SelectedDate;
            string? majorSelected = (string?)major.SelectedItem;

            if (string.IsNullOrEmpty(tbStudentId.Text)) studentId = NO_DATA;
            else studentId = tbStudentId.Text;

            if (string.IsNullOrEmpty(tbStudentName.Text)) studentName = NO_DATA;
            else studentName = tbStudentName.Text;

            if (string.IsNullOrEmpty(tbEmail.Text)) email = NO_DATA;
            else email = tbEmail.Text;

            if (string.IsNullOrEmpty(pwPassword.Password)) password = NO_DATA;
            else password = pwPassword.Password;

            if (selectedDate.HasValue)
                birthDateString = selectedDate.Value.ToString("yyyy-MM-dd");
            else birthDateString = NO_DATA;

            if (string.IsNullOrEmpty(genderString)) gender = NO_DATA;
            else gender = genderString;

            if (string.IsNullOrEmpty(majorSelected)) majorString = NO_DATA;
            else majorString = majorSelected.ToString();

            if (string.IsNullOrEmpty(hobbiesString)) hobbies = NO_DATA;
            else hobbies = hobbiesString;

            string inf = $"StudentId: {studentId}; StudentName: {studentName}; Email: {email}; Password: {password}; BirthDate: {birthDateString};  Gender: {gender}; Major: {majorString}; Hobbies: {hobbies}";
            
            return inf;
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(GetData());
        }
    }
}
