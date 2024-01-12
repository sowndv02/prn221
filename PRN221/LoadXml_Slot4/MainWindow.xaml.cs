using LoadXml_Slot4.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LoadXml_Slot4
{
    public partial class MainWindow : Window
    {
        List<Person> persons = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            SetDataComboxGender();
        }
        private void SetDataComboxGender()
        {
            List<string> genders = new List<string>() { "Male", "Female" };
            cbxGender.ItemsSource = genders;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var dialogBox = new OpenFileDialog() { Filter = "XML Files(*.xml)|*.xml|All Files(*.*)|*.*" };
            var result = dialogBox.ShowDialog();
            if (result == false) return;
            var serializer = new XmlSerializer(typeof(List<Person>));
            using Stream stream = File.OpenRead(dialogBox.FileName);
            persons = (List<Person>)serializer.Deserialize(stream);
            tbPath.Text = dialogBox.FileName.ToString();
            dgvDisplay.ItemsSource = persons;
            dgvDisplay.Items.Refresh();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var dialogBox = new SaveFileDialog() { Filter = "Xml Files(*.xml)|*.xml|All Files(*.*)|*.*" };
            var result = dialogBox.ShowDialog();
            if (result == false) return;
            var serializer = new XmlSerializer(typeof(List<Person>));
            using Stream stream = File.Create(dialogBox.FileName);
            serializer.Serialize(stream, persons);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tbId.Text);
            var x = persons.FirstOrDefault(x => x.Id == id);
            if (x != null) return;
            string name = tbName.Text;
            bool gender = ConvertGender(cbxGender.SelectedValue?.ToString());
            DateTime.TryParse(dob.SelectedDate?.ToString(), out DateTime dobs);
            decimal.TryParse(tbGpa.Text.ToString(), out decimal gpa);
            persons.Add(new Person { Id = id, Name = name, Gender = gender, Dob = dobs, Gpa = gpa });
            dgvDisplay.ItemsSource = persons;
            dgvDisplay.Items.Refresh();
        }
        private bool ConvertGender(string gender)
        {
            return !String.IsNullOrEmpty(gender) && gender.Equals("Male");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tbId.Text);
            var x = persons.FirstOrDefault(y => y.Id == id);
            if (x == null) return;
            x.Name = tbName.Text;
            x.Gender = ConvertGender(cbxGender.SelectedValue.ToString());
            DateTime.TryParse(dob.SelectedDate?.ToString(), out DateTime dobs);
            decimal.TryParse(tbGpa.Text.ToString(), out decimal gpa);
            x.Gpa = gpa;
            x.Dob = dobs;
            dgvDisplay.ItemsSource = persons;
            dgvDisplay.Items.Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tbId.Text);
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].Id == id)
                {
                    persons.RemoveAt(i);
                }
            }
            dgvDisplay.ItemsSource = persons;
            dgvDisplay.Items.Refresh();
        }

        private void dgvDisplay_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Person p = dgvDisplay.SelectedItem as Person;
            if (p != null)
            {
                tbId.Text = p.Id.ToString();
                tbName.Text = p.Name.ToString();
                cbxGender.SelectedValue = p.Gender ? "Male" : "Female";
                tbGpa.Text = p.Gpa.ToString();
                dob.SelectedDate = p.Dob;
            }
        }
    }


}
