using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
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
using System.Windows.Xps.Packaging;
using System.Xml;
using System.Xml.Linq;

namespace ConvertJsonToXML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        private string jsonContent;
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void btnLoad_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        //        openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

        //        if (openFileDialog.ShowDialog() == true)
        //        {
        //            string jsonContent = File.ReadAllText(openFileDialog.FileName);

        //            JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
        //            dataGrid.Columns.Clear();
        //            if (jsonDocument.RootElement.EnumerateArray().Any())
        //            {
        //                foreach (var property in jsonDocument.RootElement.EnumerateArray().First().EnumerateObject())
        //                {
        //                    DataGridTextColumn column = new DataGridTextColumn();
        //                    column.Header = property.Name;
        //                    column.Binding = new Binding($"[{property.Name}]");
        //                    dataGrid.Columns.Add(column);
        //                }
        //            }
        //            dataGrid.ItemsSource = jsonDocument.RootElement.EnumerateArray().ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading JSON file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    
                    jsonContent = File.ReadAllText(openFileDialog.FileName);
                    MessageBox.Show(jsonContent.ToString(), "Json Content", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonContent))
                {
                    MessageBox.Show("Please load a JSON file first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                ConvertAndSaveJsonToXml(jsonContent);
                MessageBox.Show("JSON data converted to XML and saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConvertAndSaveJsonToXml(string jsonContent)
        {
            XDocument xmlDocument = ConvertJsonToXml(jsonContent);
            SaveXmlToFile(xmlDocument, "output.xml");
        }

        private void SaveXmlToFile(XDocument xmlDocument, string filePath)
        {
            xmlDocument.Save(filePath);
        }

        private XDocument ConvertJsonToXml(string jsonContent)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
            XDocument xmlDocument = new XDocument();
            XElement rootElement = new XElement("Root");
            foreach (var jsonElement in jsonDocument.RootElement.EnumerateArray())
            {
                XElement jsonElementToXml = ConvertJsonElementToXml(jsonElement);
                rootElement.Add(jsonElementToXml);
            }
            xmlDocument.Add(rootElement);
            return xmlDocument;
        }

        private XElement ConvertJsonElementToXml(JsonElement jsonElement)
        {
            XElement xmlElement = new XElement(jsonElement.ValueKind.ToString());
            if (jsonElement.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in jsonElement.EnumerateObject())
                {
                    XElement propertyElement = new XElement(property.Name);
                    propertyElement.Add(ConvertJsonElementToXml(property.Value));
                    xmlElement.Add(propertyElement);
                }
            }
            else if (jsonElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var arrayElement in jsonElement.EnumerateArray())
                {
                    xmlElement.Add(ConvertJsonElementToXml(arrayElement));
                }
            }
            else
            {
                xmlElement.Value = jsonElement.ToString();
            }
            return xmlElement;
        }


    }
}
